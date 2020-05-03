function getPasswordHash(passWordElement,nonceElement,hashElement) {

    var password = $('#', passWordElement).attr('value');
    var nonce = $('#', nonceElement).attr('value')

    $('#',+ hashElement).attr('value', $.sha256(password + nonce));
    $('#',+ passWordElement).attr('value', '');
}