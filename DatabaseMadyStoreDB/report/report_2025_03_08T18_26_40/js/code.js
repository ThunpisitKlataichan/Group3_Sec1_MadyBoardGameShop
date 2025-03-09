const resizeBar = document.getElementById('resize-bar');
const leftSide = document.getElementById('left-side');
const rightSide = document.getElementById('right-side');
const dividerWidth = 8;

const sqlDiv = document.getElementById('scrollable-body');

const decorationTypes = Object.freeze({
    highlight: 0,
    bookmark: 1
});

resizeBar.addEventListener('mousedown', function (e) {
    sqlDiv.addEventListener('mousemove', handleMouseMove);
});

document.addEventListener('mouseup', function (e) {
    sqlDiv.removeEventListener('mousemove', handleMouseMove, false);
});

/**
 * Handles mouse move event, used for drag to resize source/target editors.
 * @param {Object} e Event.
 */
function handleMouseMove(e) {
    var leftSideWidth = (e.x - (dividerWidth / 2));
    leftSide.style.width = leftSideWidth;
    rightSide.style.width = sqlDiv.clientWidth - leftSideWidth - dividerWidth - 1;
}

/**
 * Updates width of left and right side code views.
 */
function updateLeftRightSide() {
    var halfWidth = sqlDiv.clientWidth / 2;
    leftSide.style.width = halfWidth;
    rightSide.style.width = halfWidth - dividerWidth - 1;
}

window.addEventListener('resize', updateLeftRightSide);

window.addEventListener('load', updateLeftRightSide);

monaco.editor.onDidCreateEditor(function (e) {
    document.getElementById('monaco-left-side-sql').style.display = 'none';
    document.getElementById('monaco-right-side-sql').style.display = 'none';
});

function initEditor (editorElementId, sqlElementId, language) {
    const editorSql = prepareSqlText(document.getElementById(sqlElementId).innerText);
    const editor = monaco.editor.create(document.getElementById(editorElementId), {
        value: editorSql,
        language: language,
        automaticLayout: true,
        readOnly: true,
        contextmenu: false,
        folding: false,
        glyphMargin: true,
        minimap: {
            enabled: false
        }
    });

    // Normalize all line breaks to just \n, as this is how we count absolute character positions
    editor.getModel().setEOL(monaco.editor.EndOfLineSequence.LF);

    /**
     * Note about editor.decorationsData:
     * DecorationsData was set up because editorDecorations returned by editor.deltaDecorations doesn't contain all the information we need.
     * DecorationsData is a key value pair. Key is the line number that a decoration is on, value is its corresponding data.
     *
     * Having a key value pair is very helpful for decorations like bookmarks, where we need to quickly determine if a bookmark is on a given line.
     * On the other hand, for some decorations (highlighting), we don't need to store the line they are on.
     * This is because after we tell Monaco to render a highlight decoration, we don't perform any further logic requiring line numbers.
     *
     * Even though we don't need to store line number for highlighting, we still need an object in decorationsData containing decoration_id.
     * This is because we will need decoration_id in the event we want to remove this decoration.
     *
     * Data for problem margins is not stored in decorationsData since we never need to modify it.
     *
     * Keys greater than 0 will denote a bookmark placed on corresponding line, whereas anything less than or equal to 0 will denote a highlight decoration.
     * This means we don't have to filter through potentially hundreds of bookmarks to find one highlight object.
     * We can simply start searching for our highlight object at key 0 and proceed downwards until we find it.
     */
    editor.decorationsData = [];
    editor.numberOfBookmarks = 0;
    return editor;
}

const sourceEditor = initEditor('monaco-left-side', 'monaco-left-side-sql', sourceLanguage);
const targetEditor = initEditor('monaco-right-side', 'monaco-right-side-sql', targetLanguage);

/**
 * Prepares SQL text to be displayed in Monaco Editor.
 * This includes replacing escaped HTML characters with original values.
 * @param {String} sqlText SQL text to prepare.
 * @returns {String} Prepared SQL text, ready to be displayed in Monaco.
 */
function prepareSqlText (sqlText) {
    sqlText = sqlText.replace(/&lt;|&amp;/g, function (text) {
        if (text === '&lt;') {
            return '<';
        }
        return '&';
    });
    return sqlText;
}

/**
 * Finds the code fragment that contains character at the given offset.
 * @param {any} editor Editor to search.
 * @param {any} offset Character offset in the editor.
 * @param {any} columnInText True if column is within text, meaning user clicked on text, false otherwise.
 */
function findSelectionAtOffset(editor, offset, columnInText) {
    var selection;
    var cursorPosition = editor.getModel().getPositionAt(offset);

    for (var editorSelectionIndex in editor.selections) {
        var editorSelection = editor.selections[editorSelectionIndex];

        var selectionStartPosition = editor.getModel().getPositionAt(editorSelection.start);
        var selectionEndPosition = editor.getModel().getPositionAt(editorSelection.end);

        var columnWithinRange = !(columnInText &&
            ((cursorPosition.lineNumber === selectionStartPosition.lineNumber && cursorPosition.column < selectionStartPosition.column) ||
                (cursorPosition.lineNumber === selectionEndPosition.lineNumber && cursorPosition.column > selectionEndPosition.column)));

        if (selectionStartPosition.lineNumber <= cursorPosition.lineNumber && selectionEndPosition.lineNumber >= cursorPosition.lineNumber && columnWithinRange) {
            selection = editorSelection;
            break;
        }
    }

    return selection;
}

/**
 * Highlights code associated with the given selection on both (source and target) editors.
 * @param {Object} editor Editor to highlight the code in.
 * @param {Object} selection Code selection to highlight.
 * @param {Object} reflectedEditor Reflected editor to highlight corresponding selection.
 * @param {Boolean} setPosition True if editor position should be set to end of highlighted selection of code.
 */
function highlightCodeOnBothEditors(editor, selection, reflectedEditor, setPosition) {
    if (selection === undefined) {
        // In the case when there are no valid selections, remove decorations
        clearHighlightCodeOnOneEditor(editor);
        clearHighlightCodeOnOneEditor(reflectedEditor);
        return;
    }

    // Highlight this object's code
    highlightCodeOnOneEditor(editor, selection.start, selection.end, setPosition);

    // Highlight reflected object's code
    var allUndefined = true;
    selection.reflection.forEach(function (id) {
        var reflectedSelection;
        for (var reflectedEditorSelectionIndex in reflectedEditor.selections) {
            var reflectedEditorSelection = reflectedEditor.selections[reflectedEditorSelectionIndex];
            if (reflectedEditorSelection.guid === id) {
                reflectedSelection = reflectedEditorSelection;
                break;
            }
        }

        if (reflectedSelection !== undefined) {
            highlightCodeOnOneEditor(reflectedEditor, reflectedSelection.start, reflectedSelection.end, true);
            allUndefined = false;
        }
    });

    // If all reflections are undefined, clear reflected side decorations
    if (allUndefined) {
        clearHighlightCodeOnOneEditor(reflectedEditor);
    }
}

/**
 * Highlights code on one editor.
 * @param {Object} editor Editor to highlight code for.
 * @param {Number} start Offset to begin highlight.
 * @param {Number} end Offset to end highlight.
 * @param {Boolean} setPosition True if editor position should be set to end of highlighted selection of code.
 */
function highlightCodeOnOneEditor (editor, start, end, setPosition) {
    clearHighlightCodeOnOneEditor(editor);

    const startPosition = editor.getModel().getPositionAt(start);
    const endPosition = editor.getModel().getPositionAt(end);
    const range = new monaco.Range(startPosition.lineNumber, startPosition.column - 1, endPosition.lineNumber, endPosition.column - 1);

    // Add decoration to selected lines
    const addedDecorations = editor.deltaDecorations([], [{
        range: range,
        options: {
            isWholeLine: false,
            className: 'code-highlight'
        }
    }]);

    var decorationIndex = 0;
    while (editor.decorationsData[decorationIndex] !== undefined) {
        decorationIndex--;
    }

    editor.decorationsData[decorationIndex] = {
        decoration_id: addedDecorations[0],
        line_number: startPosition.lineNumber,
        type: decorationTypes.highlight
    };

    editor.revealRange(range, monaco.editor.ScrollType.Smooth);

    if (setPosition) {
        editor.setPosition(startPosition);
    }
}

/**
 * Clears highlighted code on one editor.
 * @param {Object} editor Editor to clear highlight for.
 */
function clearHighlightCodeOnOneEditor (editor) {
    const previousDecorations = [];
    var decorationIndex = 0;
    while (editor.decorationsData[decorationIndex] !== undefined) {
        previousDecorations.push(editor.decorationsData[decorationIndex].decoration_id);
        delete editor.decorationsData[decorationIndex];
        decorationIndex--;
    }

    editor.deltaDecorations(previousDecorations, []);
}

/**
 * Adds/removes a bookmark on a given line.
 * @param {Object} editor Editor to toggle bookmark.
 * @param {Number} lineNumber Line number to toggle bookmark.
 * @param {Boolean} isSource True if editor is source (left side), false otherwise.
 */
function toggleBookmark (editor, lineNumber, isSource) {
    if (editor.decorationsData[lineNumber] === undefined) {
        // Bookmark does not already exists on this line, add decoration
        const decorations = editor.deltaDecorations([], [{
            range: new monaco.Range(lineNumber, 1, lineNumber, 1),
            options: {
                glyphMarginClassName: 'line-bookmarked'
            }
        }]);

        editor.decorationsData[lineNumber] = {
            decoration_id: decorations[0],
            line_number: lineNumber,
            type: decorationTypes.bookmark
        };
        editor.numberOfBookmarks++;
    } else {
        // Bookmark already exists, we must remove it
        const removedDecorations = [];
        removedDecorations.push(editor.decorationsData[lineNumber].decoration_id);
        delete editor.decorationsData[lineNumber];
        editor.deltaDecorations(removedDecorations, []);
        editor.numberOfBookmarks--;
    }

    updateBookmarkButtons(editor, isSource);
}

/**
 * Adds mouse down handler on an editor.
 * @param {Object} editor Editor to add mouse down handler.
 * @param {Object} reflectedEditor Reflected editor.
 * @param {Boolean} isSource True if editor is source (left side), false otherwise.
 */
function addMouseDownHandler (editor, reflectedEditor, isSource) {
    editor.onMouseDown(function (e) {
        // Check if user clicked on glyph margin or scroll bar
        if (e.target.type === monaco.editor.MouseTargetType.CONTENT_TEXT ||
            e.target.type === monaco.editor.MouseTargetType.CONTENT_EMPTY) {
            // If user clicks on space after lines, we should clear highlighting, set line number to -1
            if (e.target.detail !== null && e.target.detail.isAfterLines) {
                clearHighlightCodeOnOneEditor(editor);
                clearHighlightCodeOnOneEditor(reflectedEditor);
                return;
            }

            highlightCodeOnBothEditors(
                editor,
                findSelectionAtOffset(
                    editor,
                    editor.getModel().getOffsetAt(e.target.position),
                    e.target.type === monaco.editor.MouseTargetType.CONTENT_TEXT),
                reflectedEditor,
                false);
        } else if (e.target.type === monaco.editor.MouseTargetType.GUTTER_GLYPH_MARGIN ||
            e.target.type === monaco.editor.MouseTargetType.GUTTER_LINE_NUMBERS ||
            e.target.type === monaco.editor.MouseTargetType.GUTTER_LINE_DECORATIONS) {
            toggleBookmark(editor, e.target.position.lineNumber, isSource);
        }
    });
}

/**
 * Handles problem button click.
 * @param {Number} action -1 to navigate to previous problem, 1 to navigate to next problem.
 * @param {Boolean} isSource True if editor is source (left side), false otherwise.
 */
function handleProblemButtonClick (action, isSource) {
    const editor = isSource ? sourceEditor : targetEditor;
    const reflectedEditor = isSource ? targetEditor : sourceEditor;

    if (editor.problems.length === 0) {
        return;
    }

    // We have an ordered array of editorProblems, determine previousProblem and nextProblem relative to editor position
    var offset = editor.getModel().getOffsetAt(editor.getPosition());

    var previousProblem = editor.problems.length - 1;
    var nextProblem = 0;

    for (var problemIndex in editor.problems) {
        var problem = editor.problems[problemIndex];

        if (offset > problem.end) {
            previousProblem = problemIndex;
        } else if (offset < problem.start) {
            nextProblem = problemIndex;
            break;
        }
    }

    var selection = editor.problems[action < 0 ? previousProblem : nextProblem];
    highlightCodeOnBothEditors(editor, selection, reflectedEditor, true);
}

/**
 * Handles bookmark button click
 * @param {Number} action -1 to navigate to previous bookmark, 0 to clear all bookmarks, 1 to navigate to next bookmark.
 * @param {Boolean} isSource True if editor is source (left side), false otherwise.
 */
function handleBookmarkButtonClick (action, isSource) {
    const editor = isSource ? sourceEditor : targetEditor;

    // We will navigate previous/next bookmark based on cursor's position in editor
    const startLineNumber = editor.getPosition().lineNumber;
    var lineToScrollTo = 0;
    if (action === 0) {
        const bookmarksToRemove = [];
        editor.decorationsData = editor.decorationsData.filter(function (d) { if (d.type === decorationTypes.bookmark) { bookmarksToRemove.push(d.decoration_id); return false; } return true; });
        editor.deltaDecorations(bookmarksToRemove, []);
        editor.numberOfBookmarks = 0;
        updateBookmarkButtons(editor, isSource);
    } else if (action === -1) {
        lineToScrollTo = startLineNumber - 1;
        const cycleSegments = [1, startLineNumber];
        for (var cycleSegmentIndex = 0; cycleSegmentIndex < cycleSegments.length; cycleSegmentIndex++) {
            while (lineToScrollTo >= cycleSegments[cycleSegmentIndex]) {
                if (editor.decorationsData[lineToScrollTo] !== undefined) {
                    editor.revealLineInCenter(lineToScrollTo, monaco.editor.ScrollType.Smooth);
                    editor.setPosition(new monaco.Position(lineToScrollTo, 0));
                    return;
                }

                lineToScrollTo--;
            }

            lineToScrollTo = editor.decorationsData.length - 1;
        }
    } else if (action === 1) {
        lineToScrollTo = startLineNumber + 1;
        const cycleSegments = [editor.decorationsData.length - 1, startLineNumber];
        for (var cycleSegmentIndex = 0; cycleSegmentIndex < cycleSegments.length; cycleSegmentIndex++) {
            while (lineToScrollTo <= cycleSegments[cycleSegmentIndex]) {
                if (editor.decorationsData[lineToScrollTo] !== undefined) {
                    editor.revealLineInCenter(lineToScrollTo, monaco.editor.ScrollType.Smooth);
                    editor.setPosition(new monaco.Position(lineToScrollTo, 0));
                    return;
                }

                lineToScrollTo++;
            }

            lineToScrollTo = 1;
        }
    }
}

/**
 * Called initially to enable problem buttons if any problems are present.
 * @param {Object} sourceEditor Source editor to enable problem buttons for.
 * @param {Object} targetEditor Target editor to enable problem buttons for.
 */
function initProblemButtons (sourceEditor, targetEditor) {
    if (sourceEditor.problems.length > 0) {
        document.getElementById('source_previous_problem').classList.remove('nav-button-disabled');
        document.getElementById('source_next_problem').classList.remove('nav-button-disabled');
    }

    if (targetEditor.problems.length > 0) {
        document.getElementById('target_previous_problem').classList.remove('nav-button-disabled');
        document.getElementById('target_next_problem').classList.remove('nav-button-disabled');
    }
}

/**
 * Enables/disables bookmark buttons depending on if any bookmarks exist.
 * @param {Object} editor Editor to update bookmark buttons for.
 * @param {Boolean} isSource True if editor is source (left side), false otherwise.
 */
function updateBookmarkButtons (editor, isSource) {
    const side = isSource ? 'source' : 'target';
    if (editor.numberOfBookmarks > 0) {
        document.getElementById(side + '_previous_bookmark').classList.remove('nav-button-disabled');
        document.getElementById(side + '_next_bookmark').classList.remove('nav-button-disabled');
        document.getElementById(side + '_clear_bookmarks').classList.remove('nav-button-disabled');
    } else {
        document.getElementById(side + '_previous_bookmark').classList.add('nav-button-disabled');
        document.getElementById(side + '_next_bookmark').classList.add('nav-button-disabled');
        document.getElementById(side + '_clear_bookmarks').classList.add('nav-button-disabled');
    }
}

/**
 * Navigates to first occurrence of a provided conversion message.
 * @param {Object} editor
 * @param {String} conversionMessageId
 * @param {Object} reflectedEditor
 */
function navigateToConversionMessage (editor, conversionMessageId, reflectedEditor) {
    if (conversionMessageId === undefined ||
        conversionMessageId === null ||
        conversionMessageId === 'null') {
        return;
    }

    for (var problemIndex in editor.problems) {
        var s = editor.problems[problemIndex];
        if (s.convmessErrorIds.indexOf(conversionMessageId) >= 0 ||
            s.convmessWarningIds.indexOf(conversionMessageId) >= 0 ||
            s.convmessInfoIds.indexOf(conversionMessageId) >= 0) {
            highlightCodeOnBothEditors(editor, s, reflectedEditor, true);
            return;
        }
    }
}

/**
 * Gets error type from a provided selection.
 * @param {Object} s Selection to get error type.
 * @returns {String|undefined} Error type ('error'|'warning'|'info') or undefined.
 */
function getSelectionErrorType (s) {
    if (s === undefined) {
        return undefined;
    }

    if (s.convmessErrorIds.length > 0) {
        return 'error';
    } else if (s.convmessWarningIds.length > 0) {
        return 'warning';
    } else if (s.convmessInfoIds.length > 0) {
        return 'info';
    }
    return undefined;
}

/**
 * Adds decoration to editor's margin to denote a problem.
 * @param {Object} editor Editor to apply decoration to.
 * @param {Number} start Start line of problem.
 * @param {Number} end End line of problem.
 * @param {String} level Level of problem ('error'|'warning'|'info')
 */
function addProblemMarginDecoration (editor, start, end, level) {
    editor.deltaDecorations([], [{
        range: new monaco.Range(start, 1, end, 1),
        options: {
            isWholeLine: true,
            // Monaco orders decorations based on the class name, not based on the order
            // in which decorations are actually added.
            // To trick it to place margins for nested problems over the outer ones -
            // we append non-existing class name with the starting line number.
            // Per standard, class names cannot start with digit, so we prepend 'L' (for line).
            marginClassName: 'L' + ('00000000' + start).substr(-8) + ' ' + level + '-margin'
        }
    }]);
}

/**
 * Collect all problems, attach to their respective editor and add problem margin.
 * @param {any} sourceEditor Source editor to collect problems and apply problem margin to.
 * @param {any} targetEditor Target editor to collect problems and apply problem margin to.
 */
function collectProblems (sourceEditor, targetEditor) {
    // Collect list of selections with problems on reflected side
    targetEditor.problems = targetEditor.selections.filter(function (s) { return getSelectionErrorType(s) })

    var editorSelectionsToSearchFor = [];
    for (var targetEditorProblemIndex in targetEditor.problems) {
        var selection = targetEditor.problems[targetEditorProblemIndex];
        var type = getSelectionErrorType(selection);
        if (selection.reflection.length > 0) {
            // Since a reflection exists, this problem may also be on source side, add to map
            editorSelectionsToSearchFor[selection.reflection] = type;
        }

        addProblemMarginDecoration(
            targetEditor,
            targetEditor.getModel().getPositionAt(selection.start).lineNumber,
            targetEditor.getModel().getPositionAt(selection.end).lineNumber,
            type);
    }

    sourceEditor.problems = [];
    for (var sourceEditorSelectionIndex in sourceEditor.selections) {
        var selection = sourceEditor.selections[sourceEditorSelectionIndex];
        if (editorSelectionsToSearchFor[selection.guid]) {
            sourceEditor.problems.push(selection);
            addProblemMarginDecoration(
                sourceEditor,
                sourceEditor.getModel().getPositionAt(selection.start).lineNumber,
                sourceEditor.getModel().getPositionAt(selection.end).lineNumber,
                editorSelectionsToSearchFor[selection.guid]);
        }
    }
}

sourceEditor.selections = sourceEditorSelections;
targetEditor.selections = targetEditorSelections;

addMouseDownHandler(sourceEditor, targetEditor, true);
addMouseDownHandler(targetEditor, sourceEditor, false);

// Since problems are only attached to target editor, we only need to call collectProblems and initProblemButtons once.
collectProblems(sourceEditor, targetEditor);
initProblemButtons(sourceEditor, targetEditor);

const conversionMessageId = getUrlParameterValue(document.location.search, 'conversionMessageId');
navigateToConversionMessage(sourceEditor, conversionMessageId, targetEditor);
navigateToConversionMessage(targetEditor, conversionMessageId, sourceEditor);
