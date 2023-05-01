var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            url: "/course/getall"
        },
        "columns": [
            { "data": "courseName", "width": "15%" },
            
            {
                data: "courseNum",
                "render": function (data) {
                    return `
                          <div class="w-75 btn-group" role="group">
                            <a href="/course/upsert?courseNum=${data}"
                            class="btn btn-primary mx-2">ערוך <i class="bi bi-pencil-square"></i></a>
                            <a onClick=Delete('/course/delete?courseNum=${data}') class="btn btn-danger mx-2">מחק <i class="bi bi-trash-fill"></i> </a>

                    </div>`

                },
                "width": "15%"
            }
        ]

    });
}

function Delete(url) {
    Swal.fire({
        title: 'האם אתה בטוח?',
        text: "קורס זה יימחק לצמיתות ואיתו כל המידע",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'כן',
        cancelButtonText: 'לא'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                },
                error: function (xhr, status, error) {
                    toastr.error(error);
                }
            });
        }
    });
}
