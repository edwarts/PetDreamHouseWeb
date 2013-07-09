
function ChangeProductImage(toImage, ImgID) {
    var i = document.getElementById(ImgID);
    i.setAttribute("src", toImage);
}

function LimitText(tb, max, div) {
    var ev = event;
    var len = tb.textContent.length;
    document.getElementById(div).innerHTML = (max - len) + ' Characters Remaining';
    if (len < max) {
        return true;
    } else {
        if (ev.keyCode == 46 || ev.keyCode == 8) { return true; }
        return false;
    }
}