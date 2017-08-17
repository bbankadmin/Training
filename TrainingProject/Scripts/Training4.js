function gameInputed() {


    $.ajax({
        url: '/Training/GetGames',
        error: function () {
        },
        success: function (data) {
            var res = $.parseJSON(data);
            $('#gameName').html("");

            var table = "";
            table += "<table border=\"1\" class=\"tblGame\">";
            table += "<tr>"
            table += "<th>";
            table += "Game";
            table += "</th>";
            table += "<th>";
            table += "Price";
            table += "</th>";
            table += "</tr>";
            for (var i = 0; i < res.length; i++) {
                table += "<tr>";
                table += "<td>";
                table += res[i].Game.GameName;
                table += "</td>";
                table += "<td>";
                table += res[i].Game.GamePrice;
                table += "</td>";
                table += "</tr>";
            }
            table += "</table>";


            $('#games').append(table);
        },
        type: 'POST'
    });

}
