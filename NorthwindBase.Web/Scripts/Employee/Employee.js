function Delete(id) {
    if (confirm('Delete Employee ID ' + id + ' data, Are you sure?')) {
        location.href = '/Employee/Delete/' + id;
    }
}

$('#BackBtn').click(function () {
    location.href = '/Employee/Information';
});

$('#SaveBtn').click(function () {
    var formData = new FormData($('#form-Detail')[0]);
    $.blockUI({ message: 'Process...' });
    $.ajax({
        url: '/Employee/SaveDetail',
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
});