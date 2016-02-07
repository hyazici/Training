/// <reference path="../../jquery-2.1.4.js" />
/// <reference path="../namespace.js" />
/// <reference path="../../mustache.js" />


window.Ponera.Role = (function(crudHelper) {
    $(document).ready(function() {

        crudHelper.setOptions({
            getUrl: "GetById",
            deleteUrl: "Delete",
            postUrl: "save",
            beforeGet : function() {

            }
        });
    });
}(Ponera.CrudHelper))