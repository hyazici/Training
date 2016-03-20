/// <reference path="../../jquery-2.1.4.js" />
/// <reference path="../namespace.js" />
/// <reference path="../../mustache.js" />
/// <reference path="~/Scripts/jquery.validate-vsdoc.js" />
/// <reference path="~/Scripts/Views/crudHelper.js" />

window.Ponera.Role = (function(crudHelper) {
    $(document).ready(function() {
        var validator = $(".ponera-form").validate({
            errorClass: 'help-block help-block-error',
            messages: {
                RoleName: {
                    required: 'Rol adı girmeniz gerekmektedir'
                }
            },
            rules: {
                RoleName: {
                    required: true
                }
            },
            highlight: function (element) {
                $(element).closest('.form-group').addClass('has-error');
            },
            unhighlight: function(element) {
                $(element).closest('.form-group').removeClass('has-error');
            }
        });

        crudHelper.setOptions({
            getUrl: "GetById",
            deleteUrl: "Delete",
            postUrl: "save",
            afterGet : function() {
                validator.resetForm();
            },
            onReset : function() {
                validator.resetForm();
            }
        });
    });
}(Ponera.CrudHelper))