function searching() {
    $.ajax({
        url: "Gif/Search",
        type: "Get",
        data: {
            search: (document.getElementById('textInsert').nodeValue)
        },
        success: function (data) {
            data.data.forEach(function (item) {
                {
                    $('#foo').append(`img src = "${item}"`);

                }
            }
      });
 
}