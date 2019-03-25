// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code. 
var aanwezigeLeden = new Array();
var afwezigeLeden = new Array();
var lesmateriaal = new Array();

Array.from(document.getElementsByClassName("leden")).forEach(function (element) {
    afwezigeLeden.push(element.id);
});



function registreerAanwezigheid(id) {
    if (aanwezigeLeden.includes(id)) {
        afwezigeLeden.push(id);
        var index = aanwezigeLeden.indexOf(id);
        if (index !== -1) aanwezigeLeden.splice(index, 1);
        document.getElementById(id).style.backgroundColor = "#FFFFFF"; // backcolor

    } else {
        aanwezigeLeden.push(id);
        if (index !== -1) afwezigeLeden.splice(index, 1);
        document.getElementById(id).style.backgroundColor = "#7FFF00"; // backcolor

    }
    return false;
}


function aanwezighedenRegistreren() {
    document.getElementById("aanwezig").value = aanwezigeLeden.reduce((a, b) => a + "," + b);
    document.getElementById("afwezig").value = afwezigeLeden.reduce((a, b) => a + "," + b);
}


function determineMaterial(id, materialType) {
    $.ajax({
        type: "get",
        url: `/graad/ongetmateriaal?oefeningid=${id}`,
        success: function (result) {
            lesmateriaal = result;
            checkType(lesmateriaal, materialType);
        },
        failure: function x(response) {
            alert(respone);
        }
    });
}

function checkType(result, materialType) {
    clearContentOfScreen();
    Array.from(result).forEach(function (element) {    
        if (element.hasOwnProperty(materialType)) {          
            switch (materialType) {
                case 'url': createVideoHtml(element); break;
                case 'image': createAfbeeldingHtml(element); break;
                case 'file': createTekstHtml(element); break;
            }
        }                 
    })
}

function createVideoHtml(material) {
    const mydiv = document.createElement('div');
    mydiv.setAttribute('class', 'col-md-12 resp-container');

    var myIframe = document.createElement('iframe');
    myIframe.setAttribute('class', 'resp-iframe');
    myIframe.src = material.url;
    myIframe.frameBorder = 0;
    myIframe.allowFullscreen;
    mydiv.appendChild(myIframe);

    document.getElementById('Material').appendChild(mydiv);
}

function createAfbeeldingHtml(material) {

    const myContainer = document.createElement('div');
    myContainer.setAttribute('class', 'container');

    var image = new Image();
    image.src = `data:image/gif;base64,${material.image}`

    const myDiv = document.createElement('div');
    myDiv.setAttribute('class', 'col-md-12');

    const myh3 = document.createElement('h3');
    myh3.setAttribute('class', 'text-center');
    const myh3TextNode = document.createTextNode(material.naam);
    myh3.appendChild(myh3TextNode);
    myDiv.appendChild(myh3);
    myDiv.appendChild(image);

    myContainer.appendChild(myDiv);
    document.getElementById('Material').appendChild(myDiv);

}

function createTekstHtml(material) {

    const myContainer = document.createElement('div');
    myContainer.setAttribute('class', 'container');

    var myembed = document.createElement('embed');
    myembed.src = `data:application/pdf;base64,${material.file}`;
    myembed.type = 'application/pdf'
    myembed.setAttribute('class', 'tekstpdf');

    const myDiv = document.createElement('div');
    myDiv.setAttribute('class', 'col-sm-12 col-md-12 text-center');

    const myh3 = document.createElement('h3');
    myh3.setAttribute('class', 'text-center');
    const myh3TextNode = document.createTextNode(material.naam);
    myh3.appendChild(myh3TextNode);
    myDiv.appendChild(myh3);
    myDiv.appendChild(myembed);

    myContainer.appendChild(myDiv);
    document.getElementById('Material').appendChild(myDiv);

}

function clearContentOfScreen() {
    var node = document.getElementById('Material');
    var cnode = node.cloneNode(false);
    node.parentNode.replaceChild(cnode, node);
}