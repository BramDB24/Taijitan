// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code. 
var aanwezigeLeden = new Array();
var afwezigeLeden = new Array();
    Array.from(document.getElementsByClassName("leden")).forEach(function (element) {
    afwezigeLeden.push(element.id);
});


    function registreerAanwezigheid(id)
    {
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

