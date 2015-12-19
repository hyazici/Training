window.Ponera = {};

window.Ponera.Customer = (function(window, $) {
    "use strict";

    $(document).ready(function() {
        $('.btn').click(function() {
            var valid = $('form').valid();

            if (valid) {
                $('form').submit();
            }
        });
    });

    return {

    };
}(window, $));