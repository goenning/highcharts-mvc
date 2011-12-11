function setIntervalAndExecute(func, time) {
    func();
    return (setInterval(func, time));
}

Highcharts.Chart.prototype.clearSeries = function () {
    while (this.series.length > 0)
        this.series[0].remove(true);
};