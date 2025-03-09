var selectedTab = 'stat-buttons-tab-0';
var barCharts = [];

// These variable names need to match the 'chartName' of the pie charts
var pieConversion;
var pieEffort;

/**
 * Initializes a pie chart within the given layout element.
 * 
 * @param {any} data Series of values to render in the chart.
 * @param {any} dataPointName Labels for the data elements.
 * @param {string} title Chart title
 * @param {string} subtitle Chart subtitle.
 * @param {string} chartName Identifier of the HTML element to use a chart container.
 */
function initPieChart(data, dataPointName, title, subtitle, chartName) {
    this[chartName] = Highcharts.chart(chartName, {
        "chart": {
            "type": 'pie'
        },
        "title": { "text": title },
        "subtitle": { "text": subtitle },
        "credits": { "enabled": false },
        "exporting": { "enabled": false },
        "tooltip": { "enabled": false },
        "accessibility": { "point": { "valueSuffix": '%' } },
        "plotOptions": {
            "pie": {
                "cursor": 'pointer',
                "allowPointSelect": false,
                "dataLabels": {
                    "enabled": true,
                    "formatter": function () {
                        if (this.point.y > 0) {
                            return this.point.name + '<br>' + this.point.y + ' ' + dataPointName + '(s) (' + this.point.percentage.toFixed(1) + '%)';
                        }

                        return null;
                    }
                },
                "borderWidth": 0
            },
            "series": {
                "animation": false
            }
        },
        "series": [{
            "name": 'Conversion',
            "colorByPoint": true,
            "point": {
                "events": {
                    "click": function (event) {
                        if (event.point.color === 'crimson' || event.point.color === 'navy') {
                            filterMessagesSeverity('error');
                        } else if (event.point.color === 'gold' || event.point.color === 'steelblue') {
                            filterMessagesSeverity('warning');
                        } else if (event.point.color === 'forestgreen') {
                            filterMessagesSeverity('info');
                        }
                    }
                }
            },
            "data": data
        }],
    });
}

/**
 * Initializes a bar chart within the given layout element.
 * 
 * @param {any} data Series of values to render in the chart.
 * @param {any} chartName Identifier of the HTML element to use a chart container.
 */
function initBarChart(data, chartName) {
    Highcharts.chart(chartName, {
        "chart": {
            "type": 'bar',
            "height": 60,
            "margin": 0
        },
        "title": {
            "text": ''
        },
        "xAxis": {
            "visible": false
        },
        "yAxis": {
            "visible": false
        },
        "legend": {
            "enabled": false,
            "reversed": false
        },
        "tooltip": {
            "enabled": true,
            "animation": false,
            "hideDelay": 0,
            "formatter": function () {
                var dataPointName =
                    this.point.color === "steelblue" || this.point.color === "navy" ? "Hour" : "Object";
                return this.y + ' ' + dataPointName + '(s)<br>(' + this.percentage.toPrecision(3) + '%)';
            }
        },
        "accessibility": {
            "announceNewData": {
                "enabled": true
            },
            "point": {
                "valueSuffix": '%'
            }
        },
        "credits": {
            "enabled": false
        },
        "exporting": {
            "enabled": false
        },
        "plotOptions": {
            "series": {
                "stacking": 'percent',
                "animation": false
            },
            "bar": {
                "borderWidth": 0,
                "groupPadding": 0,
                "pointPadding": 0,
                "dataLabels": {
                    "enabled": true,
                    "formatter": function () {
                        if (this.y === 0) {
                            return '';
                        }
                        return this.percentage.toFixed(1) + '%';
                    }
                }
            }
        },
        "series": [{
            "name": 'Error Object', data: [data.errorElements],
            "dataLabels":
                [{
                    "enabled": true,
                    "inside": true,
                    "style": { "fontSize": '0.85em' }
                }],
            "color": 'crimson',
            "stack": 'object',
            "pointWidth": 40,
            "states": { "inactive": { "opacity": 1 } }
        },
        {
            "name": 'Warning Object',
            "data": [data.warningElements],
            "dataLabels":
                [{
                    "enabled": true,
                    "inside": true,
                    "style": { "fontSize": '0.85em' }
                }],
            "color": 'gold',
            "stack": 'object',
            "pointWidth": 40,
            "states": { "inactive": { "opacity": 1 } }
        },
        {
            "name": 'Automatic Object',
            "data": [data.automaticElements],
            "dataLabels":
                [{
                    "enabled": true,
                    "inside": true,
                    "style": { "fontSize": '0.85em' }
                }],
            "color": 'forestgreen',
            "stack": 'object',
            "pointWidth": 40,
            "states": { "inactive": { "opacity": 1 } }
        },
        {
            "name": 'Error Hours', data: [data.errorHours],
            "dataLabels":
                [{
                    "enabled": false
                }],
            "color": 'navy',
            "stack": 'effort',
            "pointWidth": 20,
            "states": { "inactive": { "opacity": 1 } }
        },
        {
            "name": 'Warning Hours',
            "data": [data.warningHours],
            "dataLabels":
                [{
                    "enabled": false
                }],
            "color": 'steelblue',
            "stack": 'effort',
            "pointWidth": 20,
            "states": { "inactive": { "opacity": 1 } }
        },
        ]
    });
}

/**
 * Switches from one tab to another.
 * @param {Object} nextTab Tab user wishes to navigate to.
 */
function tabClicked(nextTab) {
    // Hide previous content and deselect tab
    const previousContent = document.getElementById('content-' + selectedTab);
    previousContent.classList.add('tab-content-hidden');
    const previousTab = document.getElementById(selectedTab);
    previousTab.classList.remove('tab-selected');

    // Show next content and select tab
    selectedTab = nextTab.id;
    const nextContent = document.getElementById('content-' + selectedTab);
    nextContent.classList.remove('tab-content-hidden');
    nextTab.classList.add('tab-selected');
}

/**
 * Programmatically selects points of pie charts based on severity provided.
 * @param {string} severity Severity of chart point, either "error", "warning" or "info".
 */
function selectPieChartPoint(severity) {

    if (pieConversion === undefined) {
        return;
    }

    if (severity === 'error' || severity === 'warning') {
        pieConversion.series[0].points.find(function (point) { return point.name.toLowerCase() === severity }).select(true);

        if (pieEffort !== undefined) {
            pieEffort.series[0].points.find(function (point) { return point.name.toLowerCase() === severity }).select(true);
        }
    } else if (severity === 'info') {
        pieConversion.series[0].points.find(function (point) { return point.name === 'Automatic' }).select(true);

        if (pieEffort !== undefined) {
            var selectedEffortPoint = pieEffort.series[0].points.find(function (point) { return point.selected });
            if (selectedEffortPoint) {
                selectedEffortPoint.select(false);
            }
        }
    }
}

function filterMessagesSeverity(severity) {
    selectPieChartPoint(severity);
    top.postMessage({ "command": messageConstants.command.setMessagesSeverity, "section": messageConstants.section.scenario, "severity": severity }, "*");
}

window.addEventListener('DOMContentLoaded',
    function () {
        var sqlPath = './sql.html?conversionMessageId=' + getUrlParameterValue(document.location.search, 'conversionMessageId');
        var codeFrame = document.getElementById('code-iframe');

        if (codeFrame) {
            codeFrame.src = sqlPath;
        }

        top.postMessage({ "command": messageConstants.command.getMessagesSeverity, "section": messageConstants.section.scenario }, "*");
    });

// Initialize bar charts once page has finished loading and all styles are applied
window.addEventListener("load", function () {
    barCharts.forEach(function (barChart) {
        // Lazily initialize the charts to allow initial page loading
        setTimeout(function () { initBarChart(barChart, barChart.barChartName); }, 100);
    })
});

window.addEventListener('message', function (e) {
    var message = e.data;
    if (message.command === messageConstants.command.setMessagesSeverity) {
        selectPieChartPoint(message.severity);
    }
});
