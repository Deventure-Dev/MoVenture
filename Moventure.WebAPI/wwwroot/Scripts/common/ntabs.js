if (NTabs !== undefined) {
    throw "Use only one version of NTabs";
}
var NTabs = undefined;

function GetActiveNTabByIndex(index) {
    return $($("#n-tabs-" + index).children().first(".n-tabs-header")).children(".n-tab.n-tab-active")[0];
}

$(document).ready(function () {
    NTabs = "v1.1";

    var _ntabsPool = 0;
    var allTabs = $(".n-tabs");

    for (var i = 0; i < allTabs.length; i++) {
        allTabs[i].id = "n-tabs-" + (_ntabsPool++);

        var header = $(allTabs[i]).children().first(".n-tabs-header");
        $(header).attr("data-ntab-header", allTabs[i].id);

        var tabs = $(header).children(".n-tab");

        for (var j = 0; j < tabs.length; j++) {
            $(tabs[j]).click(nTabsShowTab.bind(tabs[j], tabs));
            $($("#" + $(tabs[j]).attr("data-target"))).attr("data-ntab-body", allTabs[i].id);
        }
    }
});

function InitNtabs() {
    NTabs = "v1.1";

    var _ntabsPool = 0;
    var allTabs = $(".n-tabs");

    for (var i = 0; i < allTabs.length; i++) {
        allTabs[i].id = "n-tabs-" + (_ntabsPool++);

        var header = $(allTabs[i]).children().first(".n-tabs-header");
        $(header).attr("data-ntab-header", allTabs[i].id);

        var tabs = $(header).children(".n-tab");

        for (var j = 0; j < tabs.length; j++) {
            $(tabs[j]).click(nTabsShowTab.bind(tabs[j], tabs));
            $($("#" + $(tabs[j]).attr("data-target"))).attr("data-ntab-body", allTabs[i].id);
        }
    }
}

function nTabsShowTab(otherTabs) {
    var target = this;
    var $target = $(this);

    if (target === undefined || target === null) {
        return
    }

    //var isActiveTab = hasClass(target, "n-tab-active");
    //if (isActiveTab === true) {
    //    return;
    //}

    var allTabs = otherTabs;
    var allTabBodies = [];
    for (var i = 0; i < allTabs.length; i++) {
        allTabBodies.push($("#" + $(allTabs[i]).attr("data-target")));
    }

    for (var i = 0; i < allTabs.length; i++) {
        $(allTabs[i]).removeClass("n-tab-active");
    }
    $target.addClass("n-tab-active");

    for (var i = 0; i < allTabBodies.length; i++) {
        if (!$(allTabBodies[i]).hasClass("hidden-n-tab")) {
            $(allTabBodies[i]).addClass("hidden-n-tab");
        }
    }

    var targetTabBody = $target.attr("data-target");
    $("#" + targetTabBody).removeClass("hidden-n-tab");
};

function getActiveNTabValueByContainer(tabContainer) {
    var container;
    //if tabContainer is ID gets value else value is null and takes by class 
    if (tabContainer !== undefined) {
        container = document.getElementById(tabContainer);
        if (container == null) {
            container = document.getElementsByClassName(tabContainer);
        }
    }

    if (container == null) {
        container = document.getElementsByClassName("n-tabs");
    }

    var tabs = container[0].getElementsByClassName("n-tab");
    var activeTab;
    for (var i = 0; i < tabs.length; i++) {
        var tabClass = $(tabs[i]).attr("class");
        try {
            if (tabClass.includes("n-tab-active")) {
                activeTab = i;
            }

        } catch (e) {
            //this is for IE
            if (tabClass.indexOf("n-tab-active") == -1) {
                activeTab = i;
            }
        }
    }
    return activeTab;
}

function switchNTabs(tabId) {
    var tabParent;
    if (tabId === undefined) {
        console.log("invalid tabid");
    }

    tabParent = $("#" + tabId).parent();

    //list of tabs
    var tabs = tabParent.children();
    //list of containers
    var tabContainersParent = tabParent.parent().children()[1];
    var tabsContainers = $(tabContainersParent).children();
    //sets all tabs unactive and hides all containers in the given context
    for (var i = 0; i < tabs.length; i++) {
        $(tabs[i]).removeClass("n-tab-active");
        $(tabsContainers[i]).addClass("hidden-n-tab");
    }

    //sets the selected tab active and shows the container in the given context
    $("#" + tabId).addClass("n-tab-active");
    $("#" + tabId + "-tab").removeClass("hidden-n-tab");
}