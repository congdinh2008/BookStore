$.noConflict();
(function ($) {
    $(function () {
        $(".UpdateLink").click(function () {
            var recordToUpdate = $(this).attr("data-id");

            if (recordToUpdate != '') {
                $.post("/ShoppingCart/UpdateQuantity", { "id": recordToUpdate },
                    function (data) {
                        if (data.ItemCount == 0) {
                            $('#row-' + data.UpdateId).fadeOut('slow');
                        } else {
                            $('#item-count-' + data.UpdateId).text(data.ItemCount);
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
        $('#row-' + data.UpdateId).fadeOut('slow');
    } else {
        $('#item-count-' + data.UpdateId).text(data.ItemCount);
    }

    $('#cart-total').text(data.CartTotal);
    $('#update-message').text(data.Message);
    $('#cart-status').text('Cart (' + data.CartCount + ')');
}