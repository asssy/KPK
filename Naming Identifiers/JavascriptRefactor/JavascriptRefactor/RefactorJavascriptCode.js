function onClickButton(event, arguments) {
    var myWindow = window;
    var browserName = myWindow.navigator.appCodeName;
    var firefoxMozilla = (browserName == "Mozilla");

    if (firefoxMozilla) {
        alert("Yes");
    }
    else {
        alert("No");
    }
}
