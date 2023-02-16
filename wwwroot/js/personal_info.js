var birthDate;
var birthDateN;
var placeHolder;
var age;
var height;
var weight;

  //Date of Birth
$("#cm").click(function() {
    $("#heightInput").attr("placeholder", "___cm");


});
$("#ft_in").click(function() {
    $("#heightInput").attr("placeholder", "__ftin");
});
$("#lb").click(function() {
    $("#weightInput").attr("placeholder", "__lb");
});
$("#kg").click(function() {
    $("#weightInput").attr("placeholder", "__kg");
});

$(document).ready(function(){
    $("#submit").click(function () {
        birthDate = $("#birthday").val();
        birthDateN = parseInt(birthDate.slice(-4));
        age = 2022 - birthDateN;
        if (age < 13 || age > 70 || birthDate.length==0) {
            $("#birthday").css("border", "1px solid #C54545");
            $("#warning-icon-birthday").show();
            $("#warning-birthday").show();
        }
        else {
            $("#warning-icon-birthday").hide();
            $("#birthday").css("border", "1px solid #504D4D");
            $("#warning-birthday").hide();
        }



        height = $("#heightInput").val();
        weight = $("#weightInput").val();
        if (height >= 140 && height <= 200) {
            $("#warning-icon-height").hide();
            $("#heightInput").css("border", "1px solid #504D4D");
            $("#warning-height").hide();
        }
        else if (height < 140 || height > 200) {
            $("#heightInput").css("border", "1px solid #C54545");
            $("#warning-icon-height").show();
            $("#warning-height").show();
        }
        if (weight > 40) {
            $("#weightInput").css("border", "1px solid #504D4D");
            $("#warning-icon-weight").hide();
            $("#warning-weight").hide();
        }
        else if (weight < 40) {
            $("#weightInput").css("border", "1px solid #C54545");
            $("#warning-icon-weight").show();
            $("#warning-weight").show();
        }
      

    });


});


