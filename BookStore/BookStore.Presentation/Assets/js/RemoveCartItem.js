$.noConflict();
(function ($) {
    $(function () {
        $(".RemoveLink").click(function () {
            var recordToDelete = $(this).attr("data-id");

            if (recordToDelete != '') {
                $.post("/ShoppingCart/RemoveFromCart", { "id": recordToDelete },
                    function (data) {
                        if (data.ItemCount == 0) {
                            $('#row-' + data.DeleteId).fadeOut('slow');
                        } else {
                            $('#item-count-' + data.DeleteId).text(data.ItemCount);
                        }
                        $('#cart-total').text(data.CartTotal);
                        $('#update-message').text(data.Message);
                        $('#cart-status').text('Cart (' + data.CartCount + ')');
                    });
            }
        });

    });
})(jQuery)

function handleUpdate() {
    var json = context.get_data();
    var data = Sys.Serialization.JavaScriptSerializer.deserialize(json);

    if (data.ItemCount == 0) {
        $('#row-' + data.DeleteId).fadeOut('slow');
    } else {
        $('#item-count-' + data.DeleteId).text(data.ItemCount);
    }

    $('#cart-total').text(data.CartTotal);
    $('#update-message').text(data.Message);
    $('#cart-status').text('Cart (' + data.CartCount + ')');
}