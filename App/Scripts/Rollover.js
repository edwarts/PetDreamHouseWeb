

function SetImages() {
    var imgs = document.getElementsByTagName("img");

    for (n = 0; n < imgs.length - 1; n++) {
        var on = imgs[n].getAttribute("on");
        if (on == null) { continue; }
        var a = imgs[n].parentNode;

        var src = imgs[n].getAttribute("src");
        var pth = src.substr(0, src.lastIndexOf("/")+1);
        var off = src.substr( src.lastIndexOf("/") + 1,1000);

//            if (location.href.toString().toLowerCase().startsWith(a.href.toLowerCase())) {
//                imgs[n].setAttribute("src", pth + on);
//            } else {
//                imgs[n].setAttribute("off", off);
//                imgs[n].setAttribute("onmouseover", "this.src='" + pth + on + "';");
//                imgs[n].setAttribute("onmouseout", "this.src='" + pth + off + "';");
//            }
        }
}

function SetActiveLink() {
    var loc = location.pathname;

}

String.prototype.startsWith = function (str)
{ return (this.match("^" + str) == str) }

window.onload = function () { SetImages(); SetActiveLink(); }