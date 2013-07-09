
var SliderIndex = 0;
var SliderPause = false;
function InitSlider(prntCtrl) {

}


function SliderChange(btn,NewLink,Target, OffButton, OnButton) {
    for (n = 0; n < 20; n++) {
        try {
            document.getElementById("SliderBtn_" + n).setAttribute("src", OffButton);
        } catch (e) { }
    }

    btn.setAttribute("src", OnButton);
    SliderIndex = btn.getAttribute("Index");
    var nid = "SliderImg_" + btn.getAttribute("Index");

    var img = document.createElement("img");
    img.setAttribute("id", nid);
    img.src = btn.getAttribute("RelatedImage");
    img.style.opacity = 0;
    img.style.position = 'absolute';
    img.style.top = '0px';
    img.style.left = '0px';
    img.setAttribute("alt", "Pet Dream House");
    var ifo = document.getElementById("SliderImgs");

    ifo.appendChild(img);

    FadeIn(nid, 0);

    var lnk = ifo.parentNode;
    lnk.setAttribute("href", NewLink);
    lnk.setAttribute("target", Target);
}


function FadeIn(ImgIn,pos){
    if (pos < 1.01) {
        var ii = document.getElementById(ImgIn);
        ii.style.opacity = pos;
        pos += .01;
        setTimeout("FadeIn('" + ImgIn + "'," + pos + ");", 8);
    } else {
        var ifo = document.getElementById("SliderImgs");
        var ilen = ifo.getElementsByTagName("img");
        for (n = 0; n < ilen.length - 1; n++) { ifo.removeChild(ilen[n]); }
    }
}

function AutoSlide() {
    if(SliderPause==true){
        for (n = 0; n < 20; n++) {
            try {
                document.getElementById("SliderBtn_" + n).setAttribute("src", OffButton);
            } catch (e) { }
        }

        try {
            SliderIndex = parseFloat(SliderIndex) + 1;
            var i = document.getElementById("SliderBtn_" + SliderIndex);
            if (i) {
                i.click();
            } else {
                i = document.getElementById("SliderBtn_0");
                SliderIndex = 0
                i.click();
            }
        } catch (e) {}
    }
    setTimeout("AutoSlide();", 5000);
}

function SetSlider(b) {
    SliderPause = b;
}

AutoSlide();