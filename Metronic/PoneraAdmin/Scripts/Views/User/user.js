window.Ponera.User = (function (crudHelper) {
    var setUpDataTable = function () {
        var table = $('#dataTable');

        var dataTable = table.DataTable({
            "language": {
                "url": "/Scripts/Views/dataTableTurkish.json"
            },

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

        crudHelper.setOptions({
            getUrl: "GetById",
            deleteUrl: "Delete",
            postUrl: "save"
        });
    });
}(Ponera.CrudHelper))