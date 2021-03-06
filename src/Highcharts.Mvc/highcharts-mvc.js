﻿var hCharts = [];

function setIntervalAndExecute(func, time) {
    func();
    return (setInterval(func, time));
}

Highcharts.Chart.prototype.clearSeries = function () {
    while (this.series.length > 0)
        this.series[0].remove(true);
};

function loadChartAjax(options) {
    var chart = hCharts[options.chartId];
    var url = options.url;
    var animation = options.animation;
    var interval = options.interval;

    var fn = function () {
        if ("GET" === options.method) {
            $.getJSON(url, function (data) {
                parseAjaxResult(chart, data, animation)
            });
        } else {
            $.post(url, null, function (data) {
                parseAjaxResult(chart, data, animation)
            }, "json");
        }
    }

    if (typeof (interval) != 'undefined')
        setIntervalAndExecute(fn, interval);
    else
        fn();
}

function parseAjaxResult(chart, data, animation) {
    $.each(data, function (key, value) {
        if (chart.series.length > key) {
            var serie = chart.series[key];
            for (var i = 0; i < serie.data.length; i++) {
                serie.data[i].update(value.Values[i], false, false);
            }
        }
        else {
            chart.addSeries({
                name: value.Name,
                data: value.Values
            }, false, false);
        }
    });
    chart.redraw(animation);
}