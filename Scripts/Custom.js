
$(document).ready(function () {


    //Add the loading loader to the page
    $body = $("body");

    $(document).on({
        ajaxStart: function () { $body.addClass("loading"); },
        ajaxStop: function () { $body.removeClass("loading"); }
    });

    $("#search").click(function () {

        var keywords = $("#keywords").val();

        GetAllTweets(keywords);

        

    })


})


function GetAllTweets(keywords) {
    jQuery.support.cors = true;
    $.ajax({
        url: 'http://localhost:42401/api/tweets/'+ keywords,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            
            //Add Top Retweeted First
            var topRetweeted = $("#toptweeted");
            addElement(topRetweeted, data.TopRetweeted);

            //Add top Followed 
            var topFollowed = $("#topfollowed");
            addElement(topFollowed, data.TopFollowed);

            //add Top Mentioned
            var topMentioned = $("#topmentioned");
            addElement(topMentioned, data.TopMentioned);


            var alldata = $("#alldata");

            alldata.html(data);
            
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

function addElement(element,data)
{
    var template = $.templates("#twitterTemplate");

    element.html(template.render(data));
}