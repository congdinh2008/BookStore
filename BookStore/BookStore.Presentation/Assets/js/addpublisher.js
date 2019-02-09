function addPublisher() {
    var result = validatePublisher();
    if (result == false) {
        return false;
    } else {
        var publisherObj = {
            Name: $('#PublisherName').val(),
            Description: $('#PublisherDescription').val()

        };
        $.ajax({
            url: "/Admin/BookManagement/AddPublisher",
            data: JSON.stringify(publisherObj),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                $('#PubList').append(new Option(publisherObj.Name, result.PublisherId, true, true));
                $('#ModalAddPublisher').modal('hide');
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
};
function validatePublisher() {
    var isValid = true;
    if ($('#PublisherName').val().trim() == "") {
        $('#PublisherName').css('border-color', 'Red');
        isValid = false;
    } else {
        $('#PublisherName').css('border-color', 'lightgrey');
        isValid = true;
    }
    if ($('#PublisherDescription').val().trim() == "") {
        $('#PublisherDescription').css('border-color', 'Red');
        isValid = false;
    } else {
        $('#PublisherDescription').css('border-color', 'lightgrey');
        isValid = true;
    }
    return isValid;
}
function resetModalPub() {
    $('#PublisherName').val("");
    $('#PublisherDescription').val("");
}
