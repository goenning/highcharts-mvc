function setIntervalAndExecute(func, time) {
    func();
    return (setInterval(func, time));
}

Highcharts.Chart.prototype.clearSeries = function () {
    while (this.series.length > 0)
        this.series[0].remove(true);
};

function postChartAjax(chart, url, interval) {
    return loadAjax(chart, url, 'POST', interval);
}

function getChartAjax(chart, url, interval) {
    return loadAjax(chart, url, 'GET', interval);
}

function loadAjax(chart, url, method, interval) {
    var fn = function () {
        if (method == "GET") {
            $.getJSON(url, function (data) {
                parseAjaxResult(chart, data)
            });
        } else {
            $.post(url, null, function (data) {
                parseAjaxResult(chart, data)
            }, "json");
        }
    }

    if (interval != undefined)
        setIntervalAndExecute(fn, interval);
    else
        fn();
}

function parseAjaxResult(chart, data) {
    $.each(data, function (key, value) {
        if (chart.series.length > key) {
            var series = chart.series[key];
            series.setData(value.Values, false);
        }
        else {
            chart.addSeries({
                name: value.Name,
                data: value.Values
            });
        }
        chart.redraw()
    });
}