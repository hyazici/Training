/// <reference path="../../jquery-2.1.4.js" />
/// <reference path="../namespace.js" />
/// <reference path="~/Scripts/mustache.js" />
/// <reference path="ajaxHelper.js" />
/// <reference path="~/Scripts/Views/namespace.js" />
/// <reference path="~/Scripts/Views/messageHelper.js" />
/// <reference path="~/Scripts/Views/responsiveTable.js" />
window.Ponera.CrudHelper = (function(windows, $, ajaxHelper, messageHelper, responsiveTable) {
    var _options = {};
    var _pageModel = {};

    var setDeleteButtonState = function (state) {
        $('#deleteButton').prop("disabled", state);

        if (state && state === true) {
            $('#deleteButton').removeAttr("data-toggle");
        } else {
            $('#deleteButton').attr('data-toggle', 'confirmation');
        }
    }

    var resetForm = function () {
        _pageModel.Id = 0;
        setDeleteButtonState(true);

        $('.ponera-form-control').each(function () {
            var name = $(this).attr('name');
            $(this).val('');

            _pageModel[name] = '';
        });
    }

    $(document).ready(function () {
        resetForm();

        $('#resetButton').click(function() {
            resetForm();

            if (_options.onReset) {
                _options.onReset();
            }
        });

        //$('#example tbody').on('click', 'tr', function () {
        //    console.log(table.row(this).data());
        //});

        $('#dataTable tbody').on("click", "tr", function () {
            var table = $('#dataTable').DataTable();
            //var rowData = table.row(this).data();

            var tr = $(this);
            var id = tr.data('id');
            
            table.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');

            if (_options.beforeGet) {
                _options.beforeGet();
            }

            ajaxHelper.getById(_options.getUrl, id, function(data, status, jqXHR) {
                _pageModel = data;

                for (var key in _pageModel) {
                    $('.ponera-form-control[name=' + key + ']').val(_pageModel[key]);
                    $('#dataTable tr[data-id=' + id + '] label[data-colunmName=' + key + ']').text(_pageModel[key]);
                }
                setDeleteButtonState(false);

                if (_options.afterGet) {
                    _options.afterGet(status);
                }
            }, function(jqXHR, status, errorThrown) {
                messageHelper.showNotificationError("Hata!", "Bir hata oluştu. Düzelmezse sistem yöneticisine başvurun");

                if (_options.afterGet) {
                    _options.afterGet(status);
                }
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
                $('div.page-content-wrapper').block({
                    message: 'Lütfen Bekleyiniz...',
                    animate: true
                });
                ajaxHelper.post(_options.postUrl, _pageModel,
                    function (data, status, jqXHR) {
                        var dataTable = $('#dataTable').DataTable();
                        if (_pageModel.Id === 0 || _pageModel.Id === '') {
                            _pageModel.Id = data.Id;

                            var arr = [];

                            for (var x in _pageModel) {
                                if (_pageModel.hasOwnProperty(x) && x !== "Id") {
                                    arr.push(_pageModel[x]);
                                }
                            }
                            arr.push("Seç");
                            dataTable.row.add(arr).draw(false);
                            messageHelper.showNotificationSuccess("", "Başarıyla eklendi");
                        } else {
                            messageHelper.showNotificationSuccess("", "Başarıyla güncellendi");

                            for (var key in _pageModel) {
                                if (_pageModel.hasOwnProperty(key)) {
                                    $('#dataTable tr[data-id=' + _pageModel.Id + '] label[data-colunmName=' + key + ']').text(_pageModel[key]);
                                }
                            }
                        }
                        resetForm();
                    }, function() {
                        messageHelper.showNotificationError("Hata!", "Bir hata oluştu. Düzelmezse sistem yöneticisine başvurun");
                    }, function() {
                        $('div.page-content-wrapper').unblock();
                    });
            }
        });

        $('#deleteButton').on('confirmed.bs.confirmation', function () {
            if (_pageModel.Id === 0) {
                messageHelper.showNotificationWarning("Uyarı!", "Silmek istediğiniz satırı seçin");
                return;
            }

            ajaxHelper.getById(_options.deleteUrl, _pageModel.Id,
                function() {
                    $('tr[data-id=' + _pageModel.Id + ']').remove();

                    resetForm();
                },
                function() {
                    messageHelper.showNotificationError("Hata!", "Bir hata oluştu. Düzelmezse sistem yöneticisine başvurun");
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
        // _options.onReset
        setOptions: function(options) {
            _options = options;
        },
        getPageModel :function() {
            return _pageModel;
        }
    }
}(window, $, Ponera.Utils.AjaxHelper, Ponera.Utils.MessageHelper, Ponera.Utils.ResponsiveTable));