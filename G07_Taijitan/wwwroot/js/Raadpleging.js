function makeAjaxPostCall(oefening) {
    $.ajax({
        type: "post",
        url: "/graad/getConsult",
        data: {
            oefeningid: oefening
        },
        success: function () {
            
        }
    });


}
