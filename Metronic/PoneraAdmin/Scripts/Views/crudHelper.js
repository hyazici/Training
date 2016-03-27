/// <reference path="../../jquery-2.1.4.js" />
/// <reference path="../namespace.js" />
/// <reference path="~/Scripts/mustache.js" />
/// <reference path="ajaxHelper.js" />
/// <reference path="~/Scripts/Views/namespace.js" />
/// <reference path="~/Scripts/Views/messageHelper.js" />
/// <reference path="~/Scripts/Views/responsiveTable.js" />
/// <reference path="~/Content/datatables/datatables.js" />
window.Ponera.CrudHelper = (function(windows, $, ajaxHelper, messageHelper) {
    var _options = {};
    var _pageModel = {};
    var _dataTable;
    var _selectedRow;

    var setDeleteButtonState = function (state) {
        $('#deleteButton').prop("disabled", state);

        if (state && state === true) {
            $('#deleteButton').removeAttr("data-toggle");
        } else {
            $('#deleteButton').attr('data-toggle', 'confirmation');
        }
    }

    var setUpDataTable = function () {
        var table = $('#dataTable');

        _dataTable = table.DataTable({
            // Internationalisation. For more info refer to http://datatables.net/manual/i18n
            "language": {
                "aria": {
                    "sortAscending": ": activate to sort column ascending",
                    "sortDescending": ": activate to sort column descending"
                },
                "emptyTable": "No data available in table",
                "info": "Showing _START_ to _END_ of _TOTAL_ entries",
                "infoEmpty": "No entries found",
                "infoFiltered": "(filtered1 from _MAX_ total entries)",
                "lengthMenu": "_MENU_ entries",
                "search": "Search:",
                "zeroRecords": "No matching records found"
            },

            // Or you can use remote translation file
            //"language": {
            //   url: '//cdn.datatables.net/plug-ins/3cfcc339e89/i18n/Portuguese.json'
            //},

            // setup buttons extentension: http://datatables.net/extensions/buttons/
            buttons: [
                { extend: 'print', className: 'btn default' },
                { extend: 'pdf', className: 'btn default' },
                { extend: 'csv', className: 'btn default' }
            ],

            // setup responsive extension: http://datatables.net/extensions/responsive/
            responsive: {
                details: {

                }
            },

            "order": [
                [0, 'asc']
            ],

            "lengthMenu": [
                [5, 10, 15, 20, -1],
                [5, 10, 15, 20, "All"] // change per page values here
            ],
            // set the initial value
            "pageLength": 10,

            "dom": "<'row' <'col-md-12'B>><'row'<'col-md-6 col-sm-12'l><'col-md-6 col-sm-12'f>r><'table-scrollable't><'row'<'col-md-5 col-sm-12'i><'col-md-7 col-sm-12'p>>", // horizobtal scrollable datatable

            // Uncomment below line("dom" parameter) to fix the dropdown overflow issue in the datatable cells. The default datatable layout
            // setup uses scrollable div(table-scrollable) with overflow:auto to enable vertical scroll(see: assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.js). 
            // So when dropdowns used the scrollable div should be removed. 
            //"dom": "<'row' <'col-md-12'T>><'row'<'col-md-6 col-sm-12'l><'col-md-6 col-sm-12'f>r>t<'row'<'col-md-5 col-sm-12'i><'col-md-7 col-sm-12'p>>",
        });
    }

    var resetForm = function () {
        _pageModel.Id = 0;
        _selectedRow = null;
        setDeleteButtonState(true);

        $('.ponera-form-control').each(function () {
            var name = $(this).attr('name');
            $(this).val('');

            _pageModel[name] = '';
        });

        $('tr.selected').removeClass('selected');
    }

    $(document).ready(function () {
        resetForm();
        setUpDataTable();

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
            _selectedRow = $(this);
            var id = _selectedRow.data('id');
            
            _dataTable.$('tr.selected').removeClass('selected');
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
                        if (_pageModel.Id === 0 || _pageModel.Id === '') {
                            _pageModel.Id = data.Id;

                            var arr = [];

                            for (var x in _pageModel) {
                                if (_pageModel.hasOwnProperty(x) && x !== "Id") {
                                    var label = "<label data-colunmname=" + x + ">" + _pageModel[x] + "</label>";
                                    arr.push(label);
                                }
                            }

                            var addedRow = _dataTable.row.add(arr);
                            $(addedRow.node()).attr('data-id', data.Id);
                            addedRow.draw(false);

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
                    // $('tr[data-id=' + _pageModel.Id + ']').remove();

                    var row = _dataTable.row(_selectedRow);
                    row.remove().draw(false);

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
}(window, $, Ponera.Utils.AjaxHelper, Ponera.Utils.MessageHelper));