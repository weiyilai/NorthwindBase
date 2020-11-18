function Delete(id) {
    if (confirm('Delete Employee ID ' + id + ' data, Are you sure?')) {
        location.href = '/Employee/Delete/' + id;
    }
}

$('#AddBtn').click(function () {
    location.href = '/Employee/Add';
});