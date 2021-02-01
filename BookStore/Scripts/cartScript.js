function addToCart() {    
    var bookId = $(event.target).attr('id');
    var address = `/Cart/AddToCart?id=${Number.parseInt(bookId)}`;

    var response = $.getJSON(address, function (json) {
        return json
    }).done(function () {
        alert(response.responseJSON.result);
    })
}