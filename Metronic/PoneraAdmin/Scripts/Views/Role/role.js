/// <reference path="../../jquery-2.1.4.js" />
/// <reference path="../namespace.js" />
/// <reference path="../../mustache.js" />


window.Ponera.Role = (function (window, $) {
    "use strict";

    var curretRoleModel = { Id : 0, RoleName : '' };

    var setValues = function(id, roleText) {
        $('#RoleName').val(roleText);
        $('#hiddenId').val(id);

        curretRoleModel.RoleName = roleText;
        curretRoleModel.Id = id;
    }

    $(document).ready(function () {
        $('#createNewButton').click(function() {
            $('#RoleName').val = '';
            $('#hiddenId').val = '';

            curretRoleModel.Id = 0;
            curretRoleModel.RoleName = '';
        });

        $('#editButton').click(function() {
            var editButton = $(this);
            var id = editButton.data('id');
            var roleText = $('label[data-id=' + id + ']').text();

            setValues(id, roleText);
        });

        $('#submitButton').click(function () {
            var valid = $('form').valid();
            var roleName = $('#RoleName').val();
            var id = $('#hiddenId').val();

            setValues(id, roleName);

            if (valid) {
                $.ajax({
                    type: "POST",
                    url: "save",
                    data:  JSON.stringify(curretRoleModel),
                    success: function(data, status, jqXHR) {
                        alert("Başarıyla eklendi");
                        var template = $('#newRoleTemplate').html();

                        curretRoleModel.Id = data.Id;

                        var rendered = Mustache.render(template, curretRoleModel);

                        $('#rolesTable').append(rendered);
                    },
                    error : function(jqXHR, status, errorThrown) {
                        alert("Bir hata oluştu");
                    },
                    datatype: "json",
                    contentType: "application/json; charset=utf-8"
                });
            }
        });

        $('#deleteButton').click(function() {
            if (curretRoleModel.Id === 0) {
                alert('Lütfen bir role seçiniz');
                return;
            }
            var confirm = confirm("Silmek istediğinize emin misiniz?");

            if (!confirm) {
                return;
            }


        });
    });

    return {

    };
}(window, $));