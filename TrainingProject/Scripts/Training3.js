
function friendChanged(type) {
    var selectedOption = "";


    if (type == "dropdown") {
        selectedOption = $('#selFriend').val();
    } else if (type == "radio") {
        selectedOption = $('input[name=radFriend]:checked', '#myForm').val();
    }

    $.ajax({
        url: '/Training/GetFriend?FriendID=' + selectedOption,
        error: function () {
        },
        success: function (data) {
            var res = $.parseJSON(data);
            $('#userName').html("");
            for (var i = 0; i < res.length; i++) {
                $('#userName').append(res[i].Friend.UserName);
            }
        },
        type: 'POST'
    });

    $.ajax({
        url: '/Training/GetFriendGames?FriendID=' + selectedOption,
        error: function () {
        },
        success: function (data) {
            var res = $.parseJSON(data);
            $('#selectedFriend').html("");

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


            $('#selectedFriend').append(table);
        },
        type: 'POST'
    });
}
