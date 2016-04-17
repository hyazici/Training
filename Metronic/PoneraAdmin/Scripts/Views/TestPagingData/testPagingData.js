window.Ponera.TestPagingData = (function () {
    var setUpDataTable = function () {
        var table = $('#dataTable');

        var dataTable = table.DataTable({
            "language": {
                "url": "/Scripts/Views/dataTableTurkish.json"
            },
            "processing": true,
            "serverSide": true,
            "ajax": "/TestPagingData/GetAjaxData",
            "searchDelay": 800,
            // "pagingType": "full_numbers",
            "columns": [
                { "data": "SiraNo", "orderable": true },
                { "data": "Kota", "orderable": true },
                { "data": "Ilce", "orderable": true },
                { "data": "Mahalle", "orderable": true },
                { "data": "CepTel", "orderable": true },
                { "data": "Adi", "orderable": true },
                { "data": "Soyadi", "orderable": true }
            ],
            buttons: [
                { extend: 'print', className: 'btn default' },
                { extend: 'pdf', className: 'btn default' },
                { extend: 'csv', className: 'btn default' }
            ],
        });
    }

    $(document).ready(function () {
        setUpDataTable();
    });
}())