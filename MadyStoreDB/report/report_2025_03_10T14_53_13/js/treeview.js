/**
 * Width of tree when collapsed, used to determine whether or not tree is expanded.
 */
var collapseWidth = 10;

/**
 * Tree node element that is currently selected.
 */
var currentlySelectedTreeNodeElement = null;

/**
 * Gets tree expanded state.
 * @returns True if tree is expanded, false otherwise.
 */
function isExpanded() {
    return (this.innerWidth > collapseWidth);
}

/**
 * Toggles tree node expand/collapse.
 * Used when user clicks +/- button next to tree node name.
 * @param {object} element 
 */
function toggleOpenCloseNode(element) {
    if (element.parentElement.parentElement.classList.contains("collapsed")) {
        element.parentElement.parentElement.classList.remove("collapsed");
    } else {
        element.parentElement.parentElement.classList.add("collapsed");
    }
}

/**
 * Deteremines whether or not frame is expanded or collapsed, then updates frame contents and toggle button to reflect this.
 * This function should be called whenever the frame resizes.
 */
function resetButtonStatus() {
    var expander = document.getElementById("expander-left");
    var tree = document.getElementById("tree");
    var treeBody = document.getElementById("tree-body");
    if (isExpanded()) {
        treeBody.classList.remove('overflow-hidden');
        tree.classList.remove("hidden");
        expander.classList.remove("close");
        expander.setAttribute("aria-label", "Objects tree section expanded, press Enter to collapse")
    } else {
        treeBody.classList.add('overflow-hidden');
        tree.classList.add("hidden");
        expander.classList.add("close");
        expander.setAttribute("aria-label", "Objects tree section collapsed, press Enter to expand")
    }

    tree.focus();
}

/**
 * Selects a node in the tree, determines ids of all descending nodes, updates scenario.
 * This function should be called whenever a tree node is clicked or user wishes to navigate to a different node.
 * @param {object} treeNodeElement Tree node element to select, if known.
 * @param {string} nodeId Identifier of the node to select.
 * @param {string} conversionMessageId Identifier of the conversion message to navigate to when node is selected.
 * @returns Newly selected tree node or `undefined`, if selection didn't change.
 */
function pathTo(treeNodeElement, nodeId, conversionMessageId) {
    // If a user clicks on a tree node, then all ancestor nodes have already been expanded.
    // In the case that a user clicks on a message, ancestor nodes may not be expanded.
    if (treeNodeElement === null) {
        treeNodeElement = document.getElementById(nodeId);
        // Expand all ancestor nodes if not already expanded.
        // Start cursor at third ancestor level to avoid expanding current tree node.
        var cursor = treeNodeElement.parentElement.parentElement.parentElement;
        while (cursor != null) {
            if (cursor.classList.contains("collapsed")) {
                cursor.classList.remove("collapsed");
            }

            cursor = cursor.parentElement;
        }
    }

    if (currentlySelectedTreeNodeElement !== null) {
        currentlySelectedTreeNodeElement.classList.remove("nodeSel");
    }

    treeNodeElement.classList.add("nodeSel");

    // We must supply updateScenario function with a list of all descending nodes.
    // This will be used to filter which messages to show in message box.
    var nodes = treeNodeElement.parentElement.parentElement.getElementsByClassName("node")
    var descendantNodes = [];
    for (var childNodeIndex = 0; childNodeIndex < nodes.length; childNodeIndex++) {
        descendantNodes[nodes[childNodeIndex].id] = true;
    }

    var newlySelectedNode;
    if (treeNodeElement != currentlySelectedTreeNodeElement) {
        newlySelectedNode = treeNodeElement;
    }

    currentlySelectedTreeNodeElement = treeNodeElement;
    updateScenario(nodeId, descendantNodes, conversionMessageId);

    return newlySelectedNode;
}

window.addEventListener('message', function (e) {
    var message = e.data;
    if (message.command === messageConstants.command.treeNavigateClick && message.path !== undefined) {
        // User has clicked on a message, simulate a tree node click
        var selectedTreeNode = pathTo(null, message.path, message.conversionMessageId);

        // Ensure tree node is visible.
        // When navigating to a conversion message, target tree node may not be visible.
        // We wan't to make sure user sees that we selected a different tree node, thus
        // we scroll the tree view to reveal the selected tree node.
        if (selectedTreeNode) {
            selectedTreeNode.scrollIntoView();
        }
    }
});
