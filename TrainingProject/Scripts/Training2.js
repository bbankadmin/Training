
function coinChanged() {
    var selectedOption = $('input[name=radCoin]:checked', '#myForm').val();

    $.ajax({
        url: '/Training/GetCoin?coinID=' + selectedOption,
        error: function () {
        },
        success: function (data) {
            var res = $.parseJSON(data);
            $('#coinName').html("");
            for (var i = 0; i < res.length; i++) {
                $('#coinName').append(res[i].SpecialCoin.Type);
            }
        },
        type: 'POST'
    });

    $.ajax({
        url: '/Training/GetCoinsPerson?CoinID=' + selectedOption,
        error: function () {
        },
        success: function (data) {
            var res = $.parseJSON(data);
            $('#selectedCoin').html("");
            for (var i = 0; i < res.length; i++) {
                $('#selectedCoin').append(res[i].Person.FirstName);
                $('#selectedCoin').append("<br/>");
            }
        },
        type: 'POST'
    });
}
