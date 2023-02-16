
var age, highet, weight, activity, gender, bmr, amr;

$("#submit-form").click(function () {
    age = $("#age").val();
    highet = $("#Higeht").val();
    weight = $("#Weight").val();

    //activity=$("#activiy").find(":selected").text();
    if ($("#activiy").val() == 1) {
        activity = 1.2;
        $("#war4").hide();
    }
    else if ($("#activiy").val() == 2) {
        activity = 1.375;
        $("#war4").hide();

    }
    else if ($("#activiy").val() == 3) {
        activity = 1.55;
        $("#war4").hide();

    }
    else if ($("#activiy").val() == 4) {
        activity = 1.725;
        $("#war4").hide();

    }
    else if ($("#activiy").val() == 5) {
        activity = 1.9;
        $("#war4").hide();

    }

    else {
        activity = 0;
        bmr = 0;
        $("#war4").show();

    };
    if ($("#formSec input[type='radio']:checked").val() == 1) {
        gender = 66.47;
        bmr = gender + (13.75 * weight) + (5.003 * highet) - (6.755 * age);
        $("#war5").hide();

    }
    else if ($("#formSec input[type='radio']:checked").val() == 2) {
        gender = 655.1;
        bmr = gender + (9.563 * weight) + (1.850 * highet) - (4.676 * age);
        $("#war5").hide();
    }
    else {
        bmr = 0;
        $("#war5").show();
    };
    amr = bmr * activity;
    if ($("#age").val().length === 0 || $("#Higeht").val() === 0 || $("#Weight").val() === 0) {
        bmr = 0;
    };
    if (!(amr == 0 || bmr == 0)) {
        $("#result-text").text(amr.toFixed(0));
        $("#result-text").show();
        $("#calorie-text").show();
    };

    if ($("#age").val().length === 0) {
        $("#warning-text").show();

        $("#war1").show();
    }
    else if (!($("#age").val().length === 0)) {
        $("#war1").hide();
    };

    if ($("#Higeht").val().length === 0) {
        $("#warning-text").show();

        $("#war2").show();
    }
    else if (!($("#Higeht").val().length === 0)) {
        $("#war2").hide();
    };

    if ($("#Weight").val().length === 0) {
        $("#warning-text").show();

        $("#war3").show();
    }
    else if (!($("#Weight").val().length === 0)) {
        $("#war3").hide();
    };
});
$("#rest-form").click(function () {
    $("#result-text").hide();
    $("#calorie-text").hide();
    $("#warning-text").hide();

});