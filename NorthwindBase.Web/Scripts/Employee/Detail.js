var validator;
$(function () {
    var datePickerConfig = {
        changeMonth: true,
        changeYear: true,
        showOn: 'both',
        buttonImage: '//jqueryui.com/resources/demos/datepicker/images/calendar.gif',
        buttonImageOnly: true,
        buttonText: 'Select date',
        dateFormat: 'yy/mm/dd',
        yearRange: '1900:' + (new Date).getFullYear()
    };

    $('#BirthDate').datepicker(datePickerConfig);
    $('#HireDate').datepicker(datePickerConfig);

    $.validator.setDefaults({
        highlight: function (element) {
            $(element).closest('.form-group').addClass('has-error');
        },
        unhighlight: function (element) {
            $(element).closest('.form-group').removeClass('has-error');
        },
        errorElement: 'span',
        errorClass: 'error-message',
        errorPlacement: function (error, element) {
            if (element.parent('.input-group').length) {
                error.insertAfter(element.parent());
            } else {
                error.insertAfter(element);
            }
        }
    });

    validator = $('#form-Detail').validate({
        onfocusout: false,
        rules: {
            LastName: 'required',
            FirstName: 'required'
        },
        messages: {
            LastName: 'Last Name is required',
            FirstName: 'First Name is required'
        }
    });
});

$('#BackBtn').click(function () {
    location.href = '/Employee/Information';
});

$('#SaveBtn').click(function () {
    if (!$('#form-Detail').valid()) {
        validator.focusInvalid();
        return false;
    }

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