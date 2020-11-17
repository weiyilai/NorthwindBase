function Delete(id) {
    if (confirm('Are you sure?')) {
        location.href = '/Employee/Delete/' + id;
    }
}