/// <reference path="../typings/jquery/jquery.d.ts" />
var AssignLocationModel = /** @class */ (function () {
    function AssignLocationModel() {
    }
    return AssignLocationModel;
}());
function initAssetAssignment() {
    $("#AssignAssetButton").click(function () {
        //alert("Toimii!");
        var locationCode = $("#Tarkennus").val();
        var assetCode = $("#Merkki").val();
        //var nimiHenkilo = $("#Nimi").val(); 
        alert("L: " + locationCode + ", A:" + assetCode/*+ "H: " + nimiHenkilo*/);
        //määritetään muuttuja:
        var data = new AssignLocationModel();
        data.Tarkennus = locationCode;
        data.Merkki = assetCode;
        //data.Nimi = nimiHenkilo;
        //lähetetään JSON-muotoista dataa palvelimelle
        $.ajax({
            type: "POST",
            url: "/Logi/LogiTallennus",
            data: JSON.stringify(data),
            contentType: "application/json",
            success: function (data) {
                if (data.success === true) {
                    alert("Asset successfully assigned.");
                }
                else {
                    alert("There was an error: " + data.error);
                }
            },
            dataType: "json"
        });
    });
}