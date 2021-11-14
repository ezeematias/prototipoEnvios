$("#btnCreateProducto").on("click", function () {

    $.ajax(
        {
            type: 'GET',
            url: '/Productos/CreateProducto',
            contentType: 'application/json; charset=utf=8',
            success: function (result) {
                $('#modal-add-content').html(result);
                $('#modal-add').modal('show');
            },
            error: function (er) {
                alert(er);
            }
        });
});

$("#btnDeleteProducto").on("click", function () {
    var data = $("#Producto").val()
    if (confirm('¿DESEA ELIMINAR ESTE PRODUCTO?') == true) {
        $.ajax(
            {
                type: 'GET',
                url: '/Productos/DeleteProducto?id=' + data,
                contentType: 'application/json; charset=utf=8',
                success: function (response) {
                    if (response.result == "SUCCESS") {
                        alert("REGISTRO BORRADO");
                        location.reload();
                    }
                },
                error: function (er) {
                    alert("ERROR AL QUERER BORRAR EL REGISTRO");
                }
            });
    }
});

$("#btnEditProducto").on("click", function () {
    $.ajax(
        {
            type: 'GET',
            url: '/Productos/EditProducto?id=' + data,
            contentType: 'application/json; charset=utf=8',
            success: function (result) {
                $('#modal-edit-content').html(result);
                $('#modal-edit').modal('show');
            },
            error: function (er) {
                alert(er);
            }
        });
});
