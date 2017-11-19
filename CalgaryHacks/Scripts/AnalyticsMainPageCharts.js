    
var CommunityBelonging = document.getElementById("communityBelonging").getContext("2d");
var MeSeData = {
    labels: [
        "2017",
        "2016"
    ],
    datasets: [
        {
            label: "Community Belonging",
            data: [68, 67],
            backgroundColor: ["#66A2EB", "#66A2EB" ],
            hoverBackgroundColor: ["#FCCE56", "#FCCE56"]
        }]
};

var MeSeChart = new Chart(CommunityBelonging, {
    type: 'horizontalBar',
    data: MeSeData,
    options: {
        scales: {
            xAxes: [{
                ticks: {
                    min: 60 // Edit the value according to what you need
                }
            }],
            yAxes: [{
                stacked: true
            }]
        }, title: {
            display: true,
            text: 'Community Belonging (%)'
        },
        legend: {
            display: false,
        }

    }
});

//Graph for the Daily Needs And Services 
var DailyNeedsAndServices = document.getElementById("dailyNeedsBarChart").getContext("2d");
var MeSeData = {
    labels: [
        "2017",
        "2016"
    ],
    datasets: [
        {
            //label: "Daily Needs And Services",
            data: [22, 19],
            backgroundColor: ["#00FF00", "#00FF00" ],
            hoverBackgroundColor: ["#FCCE56", "#FCCE56"]
        }]
};

var MeSeChart = new Chart(DailyNeedsAndServices, {
    type: 'horizontalBar',
    data: MeSeData,
    options: {
        scales: {
            xAxes: [{
                ticks: {
                    min: 0 // Edit the value according to what you need
                }
            }],
            yAxes: [{
                stacked: true
            }]
        },
        title: {
            display: true,
            text: 'Daily Needs (%)'
        },
        legend: {
            display: false,
        }
    }
});


//Percentage of Active Adults
var activeAdults = document.getElementById("activeAdults").getContext("2d");
var MeSeData = {
    labels: [
        "2017",
        "2015"
    ],
    datasets: [
        {
            //label: "Active Adults",
            data: [57, 63],
            backgroundColor: ["#FF0000", "#FF0000"],
            hoverBackgroundColor: ["#FCCE56", "#FCCE56"]
        }]
};


var activeAdultsChart = new Chart(activeAdults, {
    type: 'horizontalBar',
    data: MeSeData,
    options: {
        scales: {
            xAxes: [{
                ticks: {
                    min: 0 // Edit the value according to what you need
                }
            }],
            yAxes: [{
                stacked: true
            }]
        },
        title: {
            display: true,
            text: 'Active Adults (%)'
        },
        legend: {
            display: false,
        }
    }
});


//Percentage of Accessibility Transit
var accessibilityTransit = document.getElementById("accessibilityTransit").getContext("2d");
var MeSeData = {
    labels: [
        "2016",
        "2015"
    ],
    datasets: [
        {
            label: "Accessibility To Transit",
            data: [14.5, 14.7],
            backgroundColor: ["#778899", "#778899"],
            hoverBackgroundColor: ["#FCCE56", "#FCCE56"]
        }]
};


var activeAdultsChart = new Chart(accessibilityTransit, {
    type: 'horizontalBar',
    data: MeSeData,
    options: {
        scales: {
            xAxes: [{
                ticks: {
                    min: 0 // Edit the value according to what you need
                }
            }],
            yAxes: [{
                stacked: true
            }]
        }, title: {
            display: true,
            text: 'Accessibility To Transit (%)'
        }, legend: {
            display: false,
        }


    }
});