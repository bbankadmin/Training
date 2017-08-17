
function personChanged() {
    var selectedOption = $('input[name=radPerson]:checked', '#myForm').val();

    $.ajax({
        url: '/Training/GetPerson?personID=' + selectedOption,
        error: function () {
        },
        success: function (data) {
            var res = $.parseJSON(data);
            $('#personName').html("");
            for (var i = 0; i < res.length; i++) {
                $('#personName').append(res[i].Person.FirstName);
            }
        },
        type: 'POST'
    });

    $.ajax({
        url: '/Training/GetPersonCoins?personID=' + selectedOption,
        error: function () {
        },
        success: function (data) {
            var res = $.parseJSON(data);
            $('#selectedPerson').html("");
            for (var i = 0; i < res.length; i++) {
                $('#selectedPerson').append(res[i].Coin.Type);
                $('#selectedPerson').append("<br/>");
            }
        },
        type: 'POST'
    });
}
