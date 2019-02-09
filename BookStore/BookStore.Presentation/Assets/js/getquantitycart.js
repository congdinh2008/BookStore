$(document).ready(function () {
    $('#addCart').click(function () {
        var quantityCart = parseInt($('#QuantityCart').val());
        var url = "/ShoppingCart/AddToCart?bookId=@Model.Book.Id" + "&quantity=" + quantityCart;
        $('#addCart').attr("href", url);
    });
});