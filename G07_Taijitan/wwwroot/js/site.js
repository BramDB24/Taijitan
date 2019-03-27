// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code. 
var aanwezigeLeden = new Array();
var afwezigeLeden = new Array();
var lesmateriaal = new Array();
var oefeningId;

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
        document.getElementById(id).style.backgroundColor = "#4F9960"; // backcolor

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
            oefeningId = id;
            checkType(lesmateriaal, materialType);
        },
        failure: function x(response) {
            alert(response);
        }
    });
}

function postComment() {
    var data = $("#commentsection").val();
    $("input[type=text]").val("");
    $("textarea").val("");
    console.log(data);
    $.ajax({
        type: "post",
        url: `/graad/getcommentaar`,
        data: {
            comment: data, oefeningId: oefeningId
        },
        succes: function (result) {
            console.log('succes');
        },
        error: function (result) {
            console.log('failed');
        }
    })
}

function checkOnEmptyTextArea() {
    if ($("#commentsection").val().trim().length < 1) {
        $("#submitbutton").prop("disabled", true);
    } else {
        $("#submitbutton").prop("disabled", false);
    }
}



function checkType(result, materialType) {
    clearContentOfScreen();

    var check = true;
    if (checkLeeg(result, materialType)) {
        Array.from(result).forEach(function (element) {
            if (element.hasOwnProperty(materialType)) {
                switch (materialType) {
                    case 'url': createVideoHtml(element); break;
                    case 'image': createAfbeeldingHtml(element, check); check = false; break;
                    case 'file': createTekstHtml(element); break;
                }
            }
        })
    } else {
        const mydiv = document.createElement('div');
        const divtextnode = document.createTextNode('Er is geen beschikbaar lesmateriaal voor dit bepaald onderdeel');
        mydiv.appendChild(divtextnode);
        document.getElementById('Material').appendChild(mydiv);

    }

}
function checkLeeg(result, materialType) {
    var temp = false;
    Array.from(result).forEach(function (element) {
        if (element.hasOwnProperty(materialType)) {
            temp = true;
        }
    })
    return temp;
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

function createAfbeeldingHtml(material, check) {


    if (check) {
        const myDivItem = document.createElement('div');
        myDivItem.setAttribute('class', 'slideshow-container');
        document.getElementById('Material').appendChild(myDivItem);
        const myDivItem1 = document.createElement('div');
        myDivItem1.setAttribute('class', 'text-center');
        myDivItem1.setAttribute('id', 'div1');
        document.getElementById('Material').appendChild(myDivItem1);
        const myATag = document.createElement('a');
        myATag.setAttribute('class', 'prev');
        myATag.setAttribute('onclick', 'plusSlides(-1)');
        myATag.appendChild(document.createTextNode('\u276E'));
        document.getElementById('Material').appendChild(myATag);
        const myATag1 = document.createElement('a');
        myATag1.setAttribute('class', 'next');
        myATag1.setAttribute('onclick', 'plusSlides(1)');
        myATag1.appendChild(document.createTextNode('\u276F'));
        document.getElementById('Material').appendChild(myATag1);
    }

    var image = new Image();
    image.src = `data:image/gif;base64,${material.image}`

    const myDiv = document.createElement('div');
    myDiv.setAttribute('class', 'mySlides');
    const myh3 = document.createElement('h3');
    myh3.setAttribute('class', 'text-center');
    image.setAttribute('class', 'displayed');
    const myh3TextNode = document.createTextNode(material.naam);
    myh3.appendChild(myh3TextNode);
    myDiv.appendChild(myh3);
    myDiv.appendChild(image);
    const myDivItem = document.getElementsByClassName('slideshow-container');
    myDivItem[0].appendChild(myDiv);
    const myDiv2 = document.createElement('span');
    const teller = document.getElementsByClassName('dot').length + 1;
    myDiv2.setAttribute('class', 'dot');
    myDiv2.setAttribute('onclick', `currentSlide(${teller})`);
    document.getElementById('div1').appendChild(myDiv2);
    if (teller == 1) {
        myDiv2.click();
    }


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