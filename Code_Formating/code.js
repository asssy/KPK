browserName = navigator.appName

addScroll = false;

if ((navigator.userAgent.indexOf('MSIE 5') > 0) || (navigator.userAgent.indexOf('MSIE 6')) > 0) {
    addScroll = true;
}

var off = 0;
var text = "";
var pointX = 0;
var pointY = 0;

document.onMouseMove = mouseMove;
if (browserName == "Netscape") {
    document.captureEvents(Event.mouseMove)
}; 

function mouseMove(evn) {
    if (browserName == "Netscape") {
        pointX = evn.pageX - 5;
        pointY = evn.pageY;
    }
    else {
        pointX = event.x - 5; 
        pointY = event.y;
    }

    if (browserName == "Netscape") {
        if (document.layers['ToolTip'].visibility == 'show') {
            PopTip();
        }
    }
    else {
        if (document.all['ToolTip'].style.visibility == 'visible') {
            PopTip();
        }
    }
}

function PopTip() {
    if (browserName == "Netscape") {
        theLayer = eval('document.layers[\'ToolTip\']');
        if ((pointX + 120) > window.innerWidth) {
            pointX = window.innerWidth - 150;
        }

        theLayer.left = pointX + 10;
        theLayer.top = pointY + 15;
        theLayer.visibility = 'show';
    }
    else {
        theLayer = eval('document.all[\'ToolTip\']');
        if (theLayer) {
            pointX = event.x - 5;
            pointY = event.y;
            if (addScroll) {
                pointX = pointX + document.body.scrollLeft;
                pointY = pointY + document.body.scrollTop;
            }

            if ((pointX + 120) > document.body.clientWidth) {
                pointX = pointX - 150;
            }

            theLayer.style.pixelLeft = pointX + 10;
            theLayer.style.pixelTop = pointY + 15;
            theLayer.style.visibility = 'visible';
        }
    }
}

function HideTip() {
    args = HideTip.arguments;
    if (browserName == "Netscape") {
        document.layers['ToolTip'].visibility = 'hide';
    }
    else {
        document.all['ToolTip'].style.visibility = 'hidden';
    }
}

function HideMenu1() {
    if (browserName == "Netscape") {
        document.layers['menu1'].visibility = 'hide';
    }
    else {
        document.all['menu1'].style.visibility = 'hidden';
    }
}

function ShowMenu1() {
    if (browserName == "Netscape") {
        theLayer = eval('document.layers[\'menu1\']');
        theLayer.visibility = 'show';
    }
    else {
        theLayer = eval('document.all[\'menu1\']');
        theLayer.style.visibility = 'visible';
    }
}

function HideMenu2() {
    if (browserName == "Netscape") {
        document.layers['menu2'].visibility = 'hide';
    }
    else {
        document.all['menu2'].style.visibility = 'hidden';
    }
}

function ShowMenu2() {
    if (browserName == "Netscape") {
        theLayer = eval('document.layers[\'menu2\']');
        theLayer.visibility = 'show';
    }
    else {
        theLayer = eval('document.all[\'menu2\']');
        theLayer.style.visibility = 'visible';
    }
}