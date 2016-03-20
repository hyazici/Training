/// <reference path="../../jquery-2.1.4.js" />
/// <reference path="../namespace.js" />
/// <reference path="../toastr.js" />

window.Ponera.Utils.MessageHelper = (function () {

    var toastrDefaultOptions = {
        "closeButton": true,
        "debug": false,
        "positionClass": "toast-top-right",
        "onclick": null,
        "showDuration": "1000",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };

    var showToastrNotification = function(title, message, messageType, option) {
        toastr.options = option ? option : toastrDefaultOptions;

        toastr[messageType](message, title);
    }

    return {
        showMessage: function (title, message) {
            alert(message);
        },
        showDialog: function (title, message) {
            var confirmed = confirm(message);
            return confirmed;
        },
        showNotificationSuccess: function (title, message, option) {
            showToastrNotification(title, message, 'success', option);
        },
        showNotificationWarning: function (title, message, option) {
            showToastrNotification(title, message, 'warning', option);
        },
        showNotificationError: function (title, message, option) {
            showToastrNotification(title, message, 'error', option);
        }
    }
}());