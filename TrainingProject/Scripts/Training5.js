function reverseString() {
    var getText = document.getElementById("inputString").value;
    var reversedText = getText.split('').reverse().join('');
    $('#reversed').html("");
    $('#reversed').append(reversedText);

}

function checkEnter(e) {
    console.log('checkEnter');
    console.log(e.keyCode);
    if (e.keyCode == 13) {
        reverseString()
    } else { }
}