var dataTable;
$(document).ready(function () {
    loadDataTable();
})
function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "NationalPark/getAll",
            "type": "Get",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "40%" },
            { "data": "state", "width": "40%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                       <div class="text-center">
                       <a href="NationalPark/Upsert/${data}" class="btn btn-info"><i class="fas fa-edit"></i></a>
                        <a onclick=Delete("NationalPark/Delete/${data}") class="btn btn-danger"><i class="fas fa-trash-alt"></i></a>
                      </div>
                     `;
                }
            }
        ]
    })
};
function Delete (url){
    swal({
        title: "want to delete the national park",
        message: "delete the national park",
        buttons: true,
        icon: "warning",
        dangerModel:true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                url: url,
                method: "delete",
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}