/// <reference path="../../jquery-2.1.4.js" />
/// <reference path="../namespace.js" />

// TODO : @deniz The jqXHR.success(), jqXHR.error(), and jqXHR.complete() callbacks are deprecated, use jqXHR.done(), jqXHR.fail(), and jqXHR.always()
window.Ponera.Utils.AjaxHelper = (function ($) {
    return {
        post: function (url, jsonData, onSuccess, onError, onComplete) {
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
                complete: function(jqXHR, status) {
                    if (onComplete) {
                        onComplete(jqXHR, status);
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