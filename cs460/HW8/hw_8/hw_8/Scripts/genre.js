function displayGenre(data) {
    console.log("Ajax working");
    console.log(data);
    $("#genreList").empty();

    $.each(data, function (i, obj) {
        $("#genreList").append("<li>" + obj["Title"] + " "+ "by" + " " + obj["ArtistName"] + "</li>");
    });
    $("#ShowList").css("display", "block");
}



$(".genreButton").click(function () {
    var genre = $(this).val();
    var source = "/Home/GetGenre/" + genre;
    console.log(source);
    $.ajax({
        type: "GET",
        datatype: "json",
        data:{genre},
        url: source,
        success: function (data){
            displayGenre(data);
        }
    });
});

