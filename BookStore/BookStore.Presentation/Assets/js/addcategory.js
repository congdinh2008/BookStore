function addCategory() {
    var result = validateCategory();
    if (result == false) {
        return false;
    }
    else {
        var categoryObj = {
            Name: $('#CategoryName').val(),
            Description: $('#CategoryDescription').val()

        };
        $.ajax({
            url: "/Admin/BookManagement/AddCategory",
            data: JSON.stringify(categoryObj),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                $('#CateList').append(new Option(categoryObj.Name, result.CategoryId, true, true));
                $('#ModalAddCategory').modal('hide');
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
};
function validateCategory() {
    var isValid = true;
    if ($('#CategoryName').val().trim() == "") {
        $('#CategoryName').css('border-color', 'Red');
        isValid = false;
    } else {
        $('#CategoryName').css('border-color', 'lightgrey');
        isValid = true;
    }
    if ($('#CategoryDescription').val().trim() == "") {
        $('#CategoryDescription').css('border-color', 'Red');
        isValid = false;
    } else {
        $('#CategoryDescription').css('border-color', 'lightgrey');
        isValid = true;
    }
    return isValid;
}
function resetModalCat() {
    $('#CategoryName').val("");
    $('#CategoryDescription').val("");
}
