function Delete(id) {
    if (confirm('Delete Employee ID ' + id + ' data, Are you sure?')) {
        location.href = '/Employee/Delete/' + id;
    }
}

$('#AddBtn').click(function () {
    location.href = '/Employee/Add';
});

$('#BackBtn').click(function () {
    location.href = '/Employee/Information';
});

$('#SaveBtn').click(function () {
    var actionUri = '';
    switch ($('#ActionMode').val()) {
        case '0':
            actionUri = '/Employee/AddDetail';
            break;
        case '1':
            actionUri = '/Employee/SaveDetail';
            break;
    }

    if (actionUri != '') {
        var formData = new FormData($('#form-Detail')[0]);
        $.blockUI({ message: 'Process...' });
        $.ajax({
            url: actionUri,
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            success: function (response, textStatus, jqXHR) {
                $.unblockUI();
                console.log(response);
                if (response.Result) {
                    if (confirm('Save success, Do you redirect to the information page?')) {
                        location.href = '/Employee/Information';
                    }
                    else {
                        location.href = '/Employee/Detail/' + $('#EmployeeID').val();
                    }
                }
            },
            error: function (xhr, textStatus, errorThrown) {
                $.unblockUI();
                console.log('Ajax request error');
            }
        });
    }
});