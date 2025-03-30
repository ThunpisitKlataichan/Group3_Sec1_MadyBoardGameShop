//////////////////////////////
// Constants
//////////////////////////////

const messageConstants = Object.freeze({
    "command": {
        "toggleView": "toggle-view",
        "scenario": "scenario",
        "treeNavigate": "tree-navigate",
        "treeNavigateClick": "tree-navigate-click",
        "updateMessagesFrame": "update-messages-frame",
        "setMessagesSeverity": "set-messages-severity",
        "getMessagesSeverity": "get-messages-severity"
    },
    "section": {
        "messages": "messages",
        "tree": "tree",
        "reportHeader": "reportHeader",
        "scenario": "scenario",
        "all": "all",
    }
});

//////////////////////////////

/**
 * Takes a URL parameter string and a desired parameter name and returns parameter value if present.
 * @param {any} parameterString String in the form of "?parameter1=a&parameter2=b"
 * @param {any} parameterName Name of query string parameter
 */
function getUrlParameterValue(parameterString, parameterName) {
    var tokens = parameterString.split(/[?|&]/);
    for (var i in tokens) {
        var token = tokens[i];
        if (token.length === 0) {
            continue;
        }

        var equalsIndex = token.indexOf("=");
        var key = token.substring(0, equalsIndex);
        if (key !== parameterName) {
            continue;
        }

        return token.substring(equalsIndex + 1);
    }

    return null;
};

//////////////////////////////
// Cross-frame communication functions
//////////////////////////////

/**
 * Shows/hides report header.
 * @param {any} isReportHeaderExpanded true to show, false to hide
 */
function showReportHeader(isReportHeaderExpanded) {
    window.parent.postMessage({ "command": messageConstants.command.toggleView, "section": messageConstants.section.reportHeader, "state": isReportHeaderExpanded }, "*");
}

/**
 * Shows/hides tree view.
 * @param {any} isTreeExpanded true to show, false to hide
 */
function showTree(isTreeExpanded) {
    window.parent.postMessage({ "command": messageConstants.command.toggleView, "section": messageConstants.section.tree, "state": isTreeExpanded }, "*");
}

/**
 * Shows/hides messages view.
 * @param {any} isMessagesExpanded true to show, false to hide
 */
function showMessages(isMessagesExpanded) {
    window.parent.postMessage({ "command": messageConstants.command.toggleView, "section": messageConstants.section.messages, "state": isMessagesExpanded }, "*");
}

/**
 * Toggles the show/hide state of header, treeview and messages frame.
 */
function toggleAll() {
    window.parent.postMessage({ "command": messageConstants.command.toggleView, "section": messageConstants.section.all, "state": true }, "*");
}

/**
 * Updates center content and top navigation frames.
 * @param {string} node Node id of scenario to update to.
 * @param {string[]} descendantNodes Array of all descendant node ids.
 * @param {string} conversionMessageId Id of converison message if available.
 * @param {string} nodeName Name of node.
 */
function updateScenario(node, descendantNodes, conversionMessageId) {
    window.parent.postMessage({ "command": messageConstants.command.scenario, "node": node, "conversionMessageId": conversionMessageId, "descendantNodes": descendantNodes }, "*");
}

/**
 * This function gets called when a message has been clicked, now we must navigate to the object through the tree.
 * @param {any} path Id of object to navigate to in the tree
 * @param {any} conversionMessageId Id of conversion message if present.
 */
function treeNav(path, conversionMessageId) {
    window.parent.postMessage({ "command": messageConstants.command.treeNavigate, "path": path, "conversionMessageId": conversionMessageId }, "*");
}

/**
 * Triggers .click() on appropriate item in tree, which will result in navigating to desired scenario.
 * @param {any} data Json data from event in the form of {"path": path, "conversionMessageId": conversionMessageId}}.
 */
function treeNavClick(data) {
    var frame = treeframe.contentWindow !== undefined ? treeframe.contentWindow : treeframe;
    frame.postMessage({ "command": messageConstants.command.treeNavigateClick, "path": data.path, "conversionMessageId": data.conversionMessageId }, "*");
}

//////////////////////////////
