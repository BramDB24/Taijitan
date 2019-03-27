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
        var index = afwezigeLeden.indexOf(id);
        if (index !== -1) afwezigeLeden.splice(index, 1);
        document.getElementById(id).style.backgroundColor = "#4F9960"; // backcolor

    }
    return false;
}


function aanwezighedenRegistreren() {
    document.getElementById("aanwezig").value = aanwezigeLeden.reduce((a, b) => a + "," + b);
    document.getElementById("afwezig").value = afwezigeLeden.reduce((a, b) => a + "," + b);
}