function Delete(id) {
    if (confirm('Delete Employee ID ' + id + ' data, Are you sure?')) {
        location.href = '/Employee/Delete/' + id;
    }
}

$('#BackBtn').click(function () {
    location.href = '/Employee/Information';
});