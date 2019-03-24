// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code. 
var aanwezigeLeden = new Array();
var afwezigeLeden = new Array();
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
function determineMaterial(id, materialType) {
    $.ajax({
        type: "get",
        url: `/graad/ongetmateriaal?oefeningid=${id}`,
        success: function (result) {
            doWork(result, materialType)
        },
        failure: function x(response) {
            alert(respone);
        }
    });
}

function doWork(expectedMaterial, materialType) {
    switch (materialType) {
        case "video":
            createVideoHtml(expectedMaterial);
            break;
        case "afbeelding":
            createAfbeeldingHtml(expectedMaterial);
            break;
        case "tekst":
            createTekstHtml(expectedMaterial);
            break;
    }
}

function createVideoHtml(material) {
    const mydiv = document.createElement('div');
    mydiv.setAttribute('class', 'col-md-12 resp-container');

    var myIframe = document.createElement('iframe');
    myIframe.setAttribute('class', 'resp-iframe');
    myIframe.src = material[0].url;
    myIframe.frameBorder = 0;
    myIframe.allowFullscreen;
    mydiv.appendChild(myIframe);

    document.getElementById('Material').appendChild(mydiv);
}

function createAfbeeldingHtml(material) {
    document.getElementById('Material').innerHTML = '';
}