/// <reference path="../../jquery-2.1.4.js" />
/// <reference path="../namespace.js" />
/// <reference path="../../mustache.js" />
/// <reference path="~/Scripts/jquery.validate-vsdoc.js" />
/// <reference path="~/Scripts/Views/crudHelper.js" />

window.Ponera.Role = (function (crudHelper) {
    var setUpDataTable = function () {
        var table = $('#dataTable');

        var dataTable = table.DataTable({
            // Internationalisation. For more info refer to http://datatables.net/manual/i18n
            //"language": {
            //    "aria": {
            //        "sortAscending": ": activate to sort column ascending",
            //        "sortDescending": ": activate to sort column descending"
            //    },
            //    "emptyTable": "Herangi bir kayıt yok",
            //    "info": "Toplam _TOTAL_ kayıttan _START_ ve _END_ arasındakiler gösteriliyor",
            //    "infoEmpty": "Kayıt bulunamadı",
            //    "infoFiltered": "(filtered1'den toplam _MAX_ kayıt)",
            //    "lengthMenu": "_MENU_ kayıt göster",
            //    "search": "Ara:",
            //    "zeroRecords": "Eşleştirilen kayıt bulunamadı"
            //},

            "language": {
                "url": "/Scripts/Views/dataTableTurkish.json"
            },

            // Or you can use remote translation file
            //"language": {
            //   url: '//cdn.datatables.net/plug-ins/3cfcc339e89/i18n/Portuguese.json'
            //},

            // setup buttons extentension: http://datatables.net/extensions/buttons/
            buttons: [
                //{ extend: 'print', className: 'btn default' },
                //{ extend: 'pdf', className: 'btn default' },
                //{ extend: 'csv', className: 'btn default' }
            ],

            // setup responsive extension: http://datatables.net/extensions/responsive/
            responsive: {
                details: {

                }
            },

            "order": [
                //[0, 'asc']
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

    $(document).ready(function () {
        setUpDataTable();

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