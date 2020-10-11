// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {

    $.get("api/passages", function (data) {

        //We will a typed class generated in real application. data will be of type passage

        jQuery('<div/>', {
            id: 'passage-passage',
            "class": 'flex-child',
        }).appendTo('#passage-main');

        jQuery('<div/>', {
            id: 'passage-questions',
            "class": 'flex-child',            
        }).appendTo('#passage-main');

        //template for passage panel
        $('#passage-passage').html("<div class='flex-container'><div class='flex-child'><div id='pass-title' class='title'></div><div id='pass-desc'></div></div><div class='flex-child' id='pass-img'></div></div>");
        //Set values retrieved from the server
        $('#pass-title').html(data["title"]);
        $('#pass-desc').html(data["description"]);
        $('#pass-img').html('<img src="' + data["imageURL"] + '">');

        //template for question panel
        $('#passage-questions').html("<div><div id='q-message'/><div class='title' id='q-query'/><div id='q-section'/><div id='q-btns'/>")
        //Set values for questions retrieved from server
        $('#q-query').html("Query: " + data["query"]);

        var questions = data["questions"];
        //question 1
        $('#q-section').append("<div class='q-container' id='qid-" + questions[0]["questionId"] + "'>" + questions[0]["questionName"] + "</div>");
        questions[0]["options"].forEach(item => $('#qid-1').append('<div class="a-container"><input type="radio" name="qid-1" value="' + item["value"] + '"/><span>' + item["name"] + '</span></div>'));

        //question 2
        $('#q-section').append("<div style='display:none' class='q-container' id='qid-" + questions[1]["questionId"] + "'>" + questions[1]["questionName"] + "</div>");
        questions[1]["options"].forEach(item => $('#qid-2').append('<div class="a-container"><input type="checkbox" name="qid-2" value="' + item["value"] + '"><span>' + item["name"] + '</span></div>'));


        $('input[name="qid-1"]:radio').bind("change", onAnswerSelected);

        //Create buttons
        $('#q-btns').html("<button id='btn-submit'>Submit</button><button id='btn-skip'>Skip</button><div id='q-server'/>")
        $('#btn-submit').bind("click", onSubmitClicked);
        $('#btn-skip').bind("click", onSkipClicked);

        //global variables to store answer
        window.q1_value = 0;
        window.q2_value = 0;
        window.sum = 0;

    });
});

function onAnswerSelected(event) {
    $("#q-server").html("");
    if (this.value === "100") {
        $('#qid-2').show();
    }
    else {
        $('#qid-2').hide();
    }
}

function onSubmitClicked(event) {
    var answer1 = parseInt($('input[name="qid-1"]:checked').val());
    if (isNaN(answer1)) {
        $("#q-message").html("Please select an answer for question 1");
        return;
    }
    var answer2 = 0;
    var total = 0;
    if (answer1 === 100) {
        $('input[name="qid-2"]:checked').each(function () {
            answer2 += parseInt(this.value);
        });

        if (answer2 == 0) {
            $("#q-message").html("Please select an answer for question 2");
            return;
        }
    }



    //storing globally
    window.q1_value = answer1;
    window.q2_value = answer2;
    window.sum = q1_value + q2_value;

    $("#q-message").html("");
    sendToServer(answer1 + answer2);   
}

function onSkipClicked() {
    location.reload(true);
}

function sendToServer(sum) {

    $("#q-server").html("Answers score: " + sum + " , Calling server...");
    console.log("Sending data to server through questions api");
}



