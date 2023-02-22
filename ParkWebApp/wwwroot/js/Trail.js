var dataTable;
$(document).ready(function () {
    loadDataTable();
})
function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "Trail/getAll",
            "type": "Get",
            "datatype":"json"
        },
        "columns": [
            { "data": "nationalPark.name", "width": "30%" },
            { "data": "name", "width": "20%" },
            { "data": "distance", "width": "10%" },
            { "data": "elevation", "width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                      <div class="text-center">
                       <a href="Trail/Upsert/${data}" class="btn btn-info"><i class="fas fa-edit"></i></a>
                        <a onclick=Delete("Trail/Delete/${data}") class="btn btn-danger"><i class="fas fa-trash-alt"></i></a>
                      </div>
                    `;
                }
            }
        ]
    })
};
function Delete (url){
    swal({
        title: "want to delete the trial for this national park",
        message: "delete the trial",
        buttons: true,
        icon: "warning",
        dangerModel: true
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