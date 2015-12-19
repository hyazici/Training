window.Ponera = {};

window.Ponera.Customer = (function() {
    "use strict";

    var number = 0;
    console.log(number);

    return {
        benBirPublicMethodum: function() {
            console.log("Wuhuuuu");
        },
        getNumber : function() {
            return number;
        },
        setNumber : function(input) {
            number = input;
        }
    };
}());