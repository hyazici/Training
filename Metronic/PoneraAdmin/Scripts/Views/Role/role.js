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

//window.Ponera.Role = (function (window, $) {
//    "use strict";

//    var curretRoleModel = { Id : 0, RoleName : '' };

//    var setValues = function(id, roleText) {
//        $('#RoleName').val(roleText);
//        $('#hiddenId').val(id);

//        curretRoleModel.RoleName = roleText;
//        curretRoleModel.Id = id === '' ? 0 : parseInt(id);
//    }

//    $(document).ready(function () {
//        $('#resetButton').click(function () {
//            setValues(0, '');
//        });

//        $('#dataTable').on("click", ".editButton", function () {
//            var editButton = $(this);
//            var id = editButton.data('id');
//            $.ajax({
//                type: "POST",
//                url: "GetById/" + id,
//                success: function (data, status, jqXHR) {
//                    setValues(data.Id, data.RoleName);

//                    $('label[data-id=' + id + ']').text(data.RoleName);
//                },
//                error: function (jqXHR, status, errorThrown) {
//                    alert("Bir hata oluştu");
//                }
//            });
//        });

//        $('#submitButton').click(function () {
//            var valid = $('form').valid();
//            var roleName = $('#RoleName').val();
//            var id = $('#hiddenId').val();

//            setValues(id, roleName);

//            if (valid) {
//                $.ajax({
//                    type: "POST",
//                    url: "save",
//                    data:  JSON.stringify(curretRoleModel),
//                    success: function (data, status, jqXHR) {
//                        if (curretRoleModel.Id === 0) {
//                            alert("Başarıyla eklendi");
//                            var template = $('#newItemTemplate').html();

//                            curretRoleModel.Id = data.Id;

//                            var rendered = Mustache.render(template, curretRoleModel);

//                            $('#dataTable > tbody').append(rendered);
//                        } else {
//                            alert("Başarıyla güncellendi");

//                            $('label[data-id=' + curretRoleModel.Id + ']').text(curretRoleModel.RoleName);
//                        }

//                    },
//                    error : function(jqXHR, status, errorThrown) {
//                        alert("Bir hata oluştu");
//                    },
//                    datatype: "json",
//                    contentType: "application/json; charset=utf-8"
//                });
//            }
//        });

//        $('#deleteButton').click(function() {
//            if (curretRoleModel.Id === 0) {
//                alert('Lütfen bir role seçiniz');
//                return;
//            }
//            var confirmed = confirm("Silmek istediğinize emin misiniz?");

//            if (!confirmed) {
//                return;
//            }

//            $.ajax(
//                {
//                    type: "GET",
//                    url: "Delete/" + curretRoleModel.Id,
//                    success: function (data, status, jqXHR) {
//                        $('tr[data-id=' + curretRoleModel.Id + ']').remove();

//                        setValues(0, '');
//                    },
//                    error : function(jqXHR, status, errorThrown) {
//                        alert("Bir hata oluştu");
//                    }
//                }
//            );
//        });
//    });

//    return {

//    };
//}(window, $));