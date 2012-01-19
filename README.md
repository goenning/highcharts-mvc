# ASP.NET MVC Helpers for [Highcharts](http://www.highcharts.com/)

This is a open-source Highcharts wrapper for ASP.NET MVC which aims to provide a better, easier and cleaner API.

![Highcharts](https://github.com/oenning/highcharts-mvc/raw/master/highcharts.png)

> Highcharts is a charting library written in pure JavaScript, offering intuitive, interactive charts to your web site or web application. 
> Highcharts currently supports line, spline, area, areaspline, column, bar, pie and scatter chart types.
> **Source:** [Highcharts](http://www.highcharts.com/)

**NOTE:** This project is still a draft, it's only about `40%` of the whole Highcharts API.


## Usage

### 1. Installation

Install it with NuGet (yes, it's prerelease).

`PM> Install-Package Highcharts.Mvc -Pre`

Go to [highcharts official website](http://www.highcharts.com/), download it and add it to your project. (I will soon include it in the NuGet package).


### 2. Configuration

In your `_Layout.cshtml` (AKA: MasterPage) add a reference to these files:

```
<script src="@Url.Content("~/Scripts/jquery-1.5.1.min.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/Highcharts/highcharts.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/highcharts-mvc.js")" type="text/javascript"></script>
```

The next step is not really necessary, but it is recommended in order to keep your views cleaner.
In the `web.config` inside the Views folder add this to the namespaces:

```
<add namespace="Highcharts.Mvc"/>
```

You will end up with something like this:

```
<system.web.webPages.razor>
<host factoryType="System.Web.Mvc.MvcWebRazorHostFactory, System.Web.Mvc, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
<pages pageBaseType="System.Web.Mvc.WebViewPage">
    <namespaces>
    <add namespace="Highcharts.Mvc"/>
    <add namespace="System.Web.Mvc" />
    <add namespace="System.Web.Mvc.Ajax" />
    <add namespace="System.Web.Mvc.Html" />
    <add namespace="System.Web.Routing" />
    </namespaces>
</pages>
</system.web.webPages.razor>
```

### 3. How to use

Now you are ready to start building your charts.
With Highcharts MVC you write:

```
@(
    Html.Highchart("myChart")
        .Title("Tickets per month")
		.WithSerieType(ChartSerieType.Line)
        .AxisX("Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec")
        .AxisY("Quantity")
        .Series(
            new Serie("iPad", new int[] { 0, 0, 0, 0, 0, 0, 16, 20, 40, 61, 100, 800 }),
            new Serie("MacBook", new int[] { 616, 713, 641, 543, 145, 641, 134, 673, 467, 859, 456, 120 }),
            new Serie("iPhone", new int[] { 10, 45, 75, 100, 421, 546, 753, 785, 967, 135, 765, 245 })
        )
        .ToHtmlString()
)
```

Instead of:

```
<div id="myChart"></div>
<script type="text/javascript">
    var myChart;
    $(document).ready(function () {
        myChart = new Highcharts.Chart({
				chart: {
					renderTo: 'myChart',
					type: 'line'
				}, title: {
					text: 'Tickets per month'
				}, xAxis: {
					categories: ['Jan','Feb','Mar','Apr','May','Jun','Jul','Aug','Sep','Oct','Nov','Dec']
				}, yAxis: {
					title: { 
						text: 'Products'
					}
				}, series: [
					{ name:'iPad', data: [0,0,0,0,0,0,16,20,40,61,100,120] },
					{ name:'MacBook', data: [616,713,641,543,145,641,134,673,467,859,456,120] },
					{ name:'iPhone', data: [10,45,75,100,null,546,753,785,967,135,765,245] }
				]
        });
    });
</script>
```

Do you want to power-up your charts with ajax-enabled highcharts? That's easy buddy, check this out:

```
@(
    Html.Highchart("myAjaxChart")
        .Title("Tickets per month")
        .WithSerieType(ChartSerieType.Column)
        .AxisX("Jan", "Feb", "Mar")
        .AxisY("Quantity")
        .Series(
            AjaxConfig.LoadFrom(Url.Action("LoadData", "Ajax")).Reload(5000)
        )
        .ToHtmlString()
)
```

## FAQ

### 1. Does it work with ASP.NET WebForms?

Even though the name of this project is **Highcharts MVC**, it does work with ASP.NET WebForms. It is not a WebControl (which is preferred), but you
can you use like this:

```
<#=
    new HighchartChart("myChart")
        .Title("Tickets per month")
		.WithSerieType(ChartSerieType.Line)
        .AxisX("Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec")
        .AxisY("Quantity")
        .Series(
            new Serie("iPad", new int[] { 0, 0, 0, 0, 0, 0, 16, 20, 40, 61, 100, 800 }),
            new Serie("MacBook", new int[] { 616, 713, 641, 543, 145, 641, 134, 673, 467, 859, 456, 120 }),
            new Serie("iPhone", new int[] { 10, 45, 75, 100, 421, 546, 753, 785, 967, 135, 765, 245 })
        )
        .ToHtmlString()
#>
```