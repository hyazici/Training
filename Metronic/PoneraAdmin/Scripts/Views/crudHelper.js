/// <reference path="../../jquery-2.1.4.js" />
/// <reference path="../namespace.js" />
/// <reference path="~/Scripts/mustache.js" />

window.Ponera.Utils.AjaxHelper = (function ($) {
    return {
        post: function (url, jsonData, onSuccess, onError) {
            $.ajax({
                type: "POST",
                url: url,
                data: JSON.stringify(jsonData),
                success: function (data, status, jqXHR) {
                    if (onSuccess) {
                        onSuccess(data, status, jqXHR);
                    }
                },
                error: function (jqXHR, status, errorThrown) {
                    if (onError) {
                        onError(jqXHR, status, errorThrown);
                    }
                },
                datatype: "json",
                contentType: "application/json; charset=utf-8"
            });
        },
        getById: function (url, id, onSuccess, onError) {
            $.ajax({
                type: "GET",
                url: url + "/" + id,
                success: function (data, status, jqXHR) {
                    if (onSuccess) {
                        onSuccess(data, status, jqXHR);
                    }
                },
                error: function (jqXHR, status, errorThrown) {
                    if (onError) {
                        onError(jqXHR, status, errorThrown);
                    }
                }
            });
        }
    }
}($));

window.Ponera.Utils.MessageHelper = (function () {

    return {
        showMessage: function (title, message) {
            alert(message);
        },
        showDialog: function (title, message) {
            var confirmed = confirm(message);
            return confirmed;
        }
    }

}());

window.Ponera.CrudHelper = (function(windows, $, ajaxHelper, messageHelper) {
    var _options = {};
    var _pageModel = {};

    var resetForm = function () {
        _pageModel.Id = 0;

        $('.ponera-form-control').each(function () {
            var name = $(this).attr('name');
            $(this).val('');

            _pageModel[name] = '';
        });
    }

    $(document).ready(function () {
        _pageModel.Id = 0;

        $('#resetButton').click(function() {
            resetForm();
        });

        $('#dataTable').on("click", ".editButton", function() {
            var editButton = $(this);
            var id = editButton.data('id');
            
            if (_options.beforeGet) {
                _options.beforeGet();
            }

            ajaxHelper.getById(_options.getUrl, id, function(data, status, jqXHR) {
                _pageModel = data;

                for (var key in _pageModel) {
                    $('.ponera-form-control[name=' + key + ']').val(_pageModel[key]);
                    $('#dataTable tr[data-id=' + id + '] label[data-colunmName=' + key + ']').text(_pageModel[key]);
                }
            }, function(jqXHR, status, errorThrown) {
                messageHelper.showMessage("Title", "Bir hata oluştu");
            });
        });

        $('#submitButton').click(function() {
            var valid = $('form').valid();

            $('.ponera-form-control').each(function () {
                var name = $(this).attr('name');
                var value = $(this).val();

                _pageModel[name] = value;
            });

            if (valid) {
                ajaxHelper.post(_options.postUrl, _pageModel,
                    function (data, status, jqXHR) {
                        if (_pageModel.Id === 0 || _pageModel.Id === '') {
                            var template = $('#newItemTemplate').html();
                            _pageModel.Id = data.Id;
                            var rendered = Mustache.render(template, _pageModel);
                            $('#dataTable tbody').append(rendered);

                            messageHelper.showMessage("Title", "Başarıyla eklendi");
                        } else {
                            messageHelper.showMessage("Title", "Başarıyla güncellendi");

                            for (var key in _pageModel) {
                                $('#dataTable tr[data-id=' + _pageModel.Id + '] label[data-colunmName=' + key + ']').text(_pageModel[key]);
                            }
                        }

                        resetForm();
                    },
                    function() {
                        messageHelper.showMessage("Title", "Bir hata oluştu");
                    });
            }
        });

        $('#deleteButton').click(function() {
            if (_pageModel.Id === 0) {
                messageHelper.showMessage("Title", "Bir seçim yapınız");
                return;
            }
            var confirmed = messageHelper.showDialog("Title", "Silmek istediğinize emin misiniz?");

            if (!confirmed) {
                return;
            }

            ajaxHelper.getById(_options.deleteUrl, _pageModel.Id,
                function() {
                    $('tr[data-id=' + _pageModel.Id + ']').remove();

                    resetForm();
                },
                function() {
                    messageHelper.showMessage("Title", "Bir hata oluştu");
                });
        });
    });

    return {
        // _options.getUrl
        // _options.deleteUrl
        // _options.postUrl
        // _options.beforeGet
        // _options.afterGet
        // _options.beforeSave
        // _options.afterSave
        // _options.beforeDelete
        // _options.afterDelete     
        setOptions: function(options) {
            _options = options;
        },
        getPageModel :function() {
            return _pageModel;
        }
    }
}(window, $, Ponera.Utils.AjaxHelper, window.Ponera.Utils.MessageHelper));