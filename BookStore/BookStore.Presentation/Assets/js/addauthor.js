function addAuthor() {
    var result = validateAuthor();
    if (result == false) {
        return false;
    }
    else {
        var authorObj = {
            Name: $('#AuthorName').val(),
            Description: $('#AuthorDescription').val()

        };
        $.ajax({
            url: "/Admin/BookManagement/AddAuthor",
            data: JSON.stringify(authorObj),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                $('#AutList').append(new Option(authorObj.Name, result.AuthorId, true, true));
                $('#ModalAddAuthor').modal('hide');
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
};
function validateAuthor() {
    var isValid = true;
    if ($('#AuthorName').val().trim() == "") {
        $('#AuthorName').css('border-color', 'Red');
        isValid = false;
    } else {
        $('#AuthorName').css('border-color', 'lightgrey');
        isValid = true;
    }
    if ($('#AuthorDescription').val().trim() == "") {
        $('#AuthorDescription').css('border-color', 'Red');
        isValid = false;
    } else {
        $('#AuthorDescription').css('border-color', 'lightgrey');
        isValid = true;
    }
    return isValid;
}
function resetModalAut() {
    $('#AuthorName').val("");
    $('#AuthorDescription').val("");
}
