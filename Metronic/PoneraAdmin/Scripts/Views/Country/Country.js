window.Ponera.Role = (function (crudHelper) {
    $(document).ready(function () {

        crudHelper.setOptions({
            getUrl: "GetById",
            deleteUrl: "Delete",
            postUrl: "save",
            beforeGet: function () {

            }
        });
    });
}(Ponera.CrudHelper))