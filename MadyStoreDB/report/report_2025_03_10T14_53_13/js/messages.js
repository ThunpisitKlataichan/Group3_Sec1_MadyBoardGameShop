var currentlySelectedTab = null; // Points to currently selected tab DOM object
var sortDesc = true; // True if panel should be sorted in descending order from most time to least

var collapseHeight = 10;
var collapseSize = "*," + collapseHeight;
var collapseImage = "img/expander_arrow_down.gif";
var expandImage = "img/expander_arrow_up.gif";

var messageIdsForCurrentNode = [];
var viewingAllMessages = true;

/**
 * Gets messages frame expanded state.
 * @returns True if messages frame is expanded, false otherwise.
 */
function isExpanded() {
    return (this.innerHeight > collapseHeight);
}

/**
 * Deteremines whether or not frame is expanded or collapsed, then updates frame contents and toggle button to reflect this.
 * This function should be called whenever the frame resizes.
 */
function buttonStatusReset() {
    var expander = document.getElementById("expander_td");
    if (isExpanded()) {
        expander.classList.remove("close");
        expander.setAttribute("aria-label", "Messages section expanded, press Enter to collapse");
    } else {
        expander.classList.add("close");
        expander.setAttribute("aria-label", "Messages section collapsed, press Enter to expand");
    }
}

/**
 * Toggles tree node collapsed/expanded state.
 * @param {object} element Collapsed/expanded button DOM element.
 */
function toggle(element) {
    if (element.children[0].classList.contains("messageMinimized")) {
        element.children[0].classList.remove("messageMinimized");
        element.children[0].src = "img/nolines_minus.gif";
        element.parentElement.getElementsByTagName("table")[0].classList.remove("hidden-element");
    } else {
        element.children[0].classList.add("messageMinimized");
        element.children[0].src = "img/nolines_plus.gif";
        element.parentElement.getElementsByTagName("table")[0].classList.add("hidden-element");
    }
}

/**
 * Called when a messages filter drop-down changes.
 * 
 * @param {object} e Tree node DOM element
 */
function nodeSelectChanged(e) {
    viewingAllMessages = e.selectedIndex === 0;

    if (viewingAllMessages) {
        filterMessagesNodes();
    } else {
        filterMessagesNodes(messageIdsForCurrentNode);
    }
}

/**
 * Gets a strongly-typed value of the data field of an element using provided accessor and caches it
 * to accelerate retrieval the next time.
 * 
 * @param {any} element Element to get the value for.
 * @param {string} dataName Name of the data field.
 * @param {any} converter A function that converts string data value to a desired type.
 */
function getDataValue(element, dataName, converter) {
    if (element.datasetCache === undefined) {
        element.datasetCache = {};
    }

    if (element.datasetCache[dataName] === undefined) {
        element.datasetCache[dataName] = converter(element.dataset[dataName]);
    }

    return element.datasetCache[dataName];
}

/**
 * Sets a strongly-typed value in the data field cache of an element.
 * 
 * @param {any} element Element to set the value for.
 * @param {string} dataName Name of the data field to set.
 * @param {any} value Data value.
 */
function setDataValue(element, dataName, value) {
    if (element.datasetCache === undefined) {
        element.datasetCache = {};
    }

    element.datasetCache[dataName] = value;
}

/**
 * Sorts provided conversion message DOM elements according to the current `sortDesc` value.
 * 
 * @param {any} messageElements Conversion message DOM elements.
 */
function sortConversionMessages(messageElements) {
    if (!messageElements || messageElements.length === 0) {
        return;
    }

    messageElements.sort(function (a, b) {
        var estimateA = getDataValue(a, "estimate", parseFloat);
        var estimateB = getDataValue(b, "estimate", parseFloat);
        return estimateA === estimateB ? 0 : ((estimateA > estimateB) === sortDesc ? -1 : 1);
    });

    // Re-append all elements to their respective parents in the new order
    for (var elementIndex = 0; elementIndex < messageElements.length; ++elementIndex) {
        var messageElement = messageElements[elementIndex];
        messageElement.parentElement.appendChild(messageElement);
    }
}

/**
 * Filters messages to show only messages attached to provided nodes.
 * If no nodes are specified, then all messages will be displayed.
 * 
 * @param {object} nodeIds Identifiers of the object nodes to display messages for.
 */
function filterMessagesNodes(nodeIds) {
    var conversionMessages = document.getElementsByClassName("conversion-message");
    var visibleConversionMessages = [];
    var messageCountBySeverity = { "info": 0, "warning": 0, "error": 0 };

    for (var conversionMessageIndex = 0; conversionMessageIndex < conversionMessages.length; ++conversionMessageIndex) {
        var conversionMessage = conversionMessages[conversionMessageIndex];
        var messageNodes = conversionMessage.getElementsByClassName("node-message");

        var visibleMessageNodes = 0;
        var messageEstimate = 0;

        // Go over all message nodes and compute number of visible ones and their time estimate
        for (var messageNodeIndex = 0; messageNodeIndex < messageNodes.length; ++messageNodeIndex) {
            var messageNode = messageNodes[messageNodeIndex];

            if (nodeIds === undefined || nodeIds[messageNode.dataset.nodeId] !== undefined) {
                // Show the message if node ids are not provided (showing all)
                // or message is for the node included in the list.
                visibleMessageNodes += 1;
                messageEstimate += getDataValue(messageNode, "estimate", parseFloat);
                messageNode.style.display = "block";
            } else {
                // Hide the node
                messageNode.style.display = "none";
            }
        }

        if (visibleMessageNodes > 0) {
            // If there are visible nodes under conversion message
            visibleConversionMessages.push(conversionMessage);

            // Increment number of total messages for given severity
            messageCountBySeverity[conversionMessage.dataset.severity] += 1;

            // Update the conversion message row with new estimate and show it
            var conversionMessageDescription = conversionMessage.children[2];

            // Set time estimate of visible nodes
            conversionMessageDescription.children[1].innerText =
                messageEstimate === 0 ? "" : "(" + messageEstimate.toFixed(1) + "h)";

            // Set number of visible nodes
            conversionMessageDescription.children[3].innerText =
                "(" + visibleMessageNodes + ")";

            // Update message estimate to make sure sorting works as expected
            setDataValue(conversionMessage, "estimate", messageEstimate);

            conversionMessage.style.display = "block";
        } else {
            // If there are no visible nodes - just hide the conversion message altogether
            conversionMessage.style.display = "none";
        }
    }

    // Sort conversion messages based on their time estimate
    sortConversionMessages(visibleConversionMessages);

    // Update number of messages of each severity
    document.getElementById("espan").innerText = "Error (" + messageCountBySeverity["error"] + ")";
    document.getElementById("wspan").innerText = "Warning (" + messageCountBySeverity["warning"] + ")";
    document.getElementById("ispan").innerText = "Info (" + messageCountBySeverity["info"] + ")";
}

/**
 * Filter message to show only messages of a given severity.
 * @param {string} severity Severity of messages to filter.
 */
function filterMessageSeverity(severity) {
    top.postMessage({ "command": messageConstants.command.setMessagesSeverity, "section": messageConstants.section.messages, "severity": severity }, "*");
    var messageGroup = document.getElementsByClassName('all');

    for (var groupIndex = 0; groupIndex < messageGroup.length; groupIndex++) {
        if (messageGroup[groupIndex].id === severity + '-messages') {
            messageGroup[groupIndex].classList.remove("hidden-element");
        } else {
            messageGroup[groupIndex].classList.add("hidden-element");
        }
    }
}

/**
 * Called when a severity tab has been selected.
 * Highlights appropriate tab and toggles sorting direction if currently selected tab is clicked.
 * @param {object} tab Tab user wishes to filter.
 * @param {boolean} toggleSort True if sort mode (ascending/descending) should be toggled, false otherwise.
 */
function severityTabSelected(tab, toggleSort) {
    // If user clicks tab that is already selected, change sorting mode
    if (currentlySelectedTab === tab) {
        if (toggleSort) {
            sortDesc = !sortDesc;
        }

        // Apply new sort direction to all visible conversion message elements
        var conversionMessageElements = document.getElementsByClassName('conversion-message');
        var visibleConversionMessageElements = []
        for (var elementIndex = 0; elementIndex < conversionMessageElements.length; ++elementIndex) {
            var conversionMessageElement = conversionMessageElements[elementIndex];
            if (conversionMessageElement.style.display !== "none") {
                visibleConversionMessageElements.push(conversionMessageElement);
            }
        }

        sortConversionMessages(visibleConversionMessageElements);

        var sortDescendingArrows = tab.parentElement.getElementsByClassName('sort-descending');
        var sortAscendingArrows = tab.parentElement.getElementsByClassName('sort-ascending');

        var showElements = sortDesc ? sortDescendingArrows : sortAscendingArrows;
        var hideElements = sortDesc ? sortAscendingArrows : sortDescendingArrows;

        for (var elementIndex = 0; elementIndex < showElements.length; elementIndex++) {
            showElements[elementIndex].classList.remove('hidden-element');
            hideElements[elementIndex].classList.add('hidden-element');
        }
    }

    currentlySelectedTab.classList.remove("tab-selected");
    currentlySelectedTab = document.getElementById(tab.id);
    currentlySelectedTab.classList.add("tab-selected");
    filterMessageSeverity(tab.id);
}

window.addEventListener("DOMContentLoaded",
    function () {
        var severity = getUrlParameterValue(document.location.search, 'severity')
        if (severity === null) {
            severity = 'error';
        }

        currentlySelectedTab = document.getElementById(severity);

        if (currentlySelectedTab !== null) {
            currentlySelectedTab.classList.add("tab-selected");
        }

        filterMessageSeverity(severity);
    });

window.addEventListener('message',
    function (e) {
        var message = e.data;
        if (message.command === messageConstants.command.updateMessagesFrame) {
            // Select-variable will always update when a new node is navigated to.  
            document.getElementById('node-select').options['select-variable'].value = message.node;
            messageIdsForCurrentNode = message.descendantNodes;

            if (!viewingAllMessages) {
                document.getElementById('node-select').selectedIndex = 1;
                filterMessagesNodes(message.descendantNodes);
            }
        } else if (message.command === messageConstants.command.setMessagesSeverity) {
            severityTabSelected(document.getElementById(message.severity), false);
        }
    });
