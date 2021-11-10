$("#Pais").change(function () {
    var PaisID = $(this).val();
    $.getJSON("/Envios/LoadProvincias/", { PaisID },
        function (classesData) {
            var select = $("#Provincia");
            select.empty();
            select.append($('<option/>', {
                value: 0,
                text: "ELIJA UNA PROVINCIA"
            }));
            $.each(classesData, function (index, itemData) {
                select.append($('<option/>', {
                    value: itemData.Value,
                    text: itemData.Text
                }));
            });
        });
});

$("#Provincia").change(function () {
    var ProvinciaID = $(this).val();
    $.getJSON("/Envios/LoadLocalidades/", { ProvinciaID },
        function (classesData) {
            var select = $("#Localidad");
            select.empty();
            select.append($('<option/>', {
                value: 0,
                text: "ELIJA UNA LOCALIDAD"
            }));
            $.each(classesData, function (index, itemData) {
                select.append($('<option/>', {
                    value: itemData.Value,
                    text: itemData.Text
                }));
            });
        });
});

$('#submitbtn').click(function (e) {
    e.preventDefault();
    if ($("#Pais").val() != "" && $("#Provincia").val() != "" && $("#Localidad").val() != "" && $("#CalleName").val() != "") {

        var selectedValue = "PAIS: " + $("#Pais option:selected").text() + '\r\n' +
            "PROVINCIA: " + $("#Provincia option:selected").text() + '\r\n' +
            "LOCALIDAD: " + $("#Localidad option:selected").text() + '\r\n' +
            "CALLE: " + $("#CalleName").val();
        $('#txtInfo').val(selectedValue);
    }
    else {
        alert("FALTAN COMPLETAR DATOS")
    }
});

$("#btnCreatePais").on("click", function () {

    $.ajax(
        {
            type: 'GET',
            url: '/Envios/CreatePais',
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

$("#btnCreateProvincia").on("click", function () {

    $.ajax(
        {
            type: 'GET',
            url: '/Envios/CreateProvincia',
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

$("#btnCreateLocalidad").on("click", function () {

    $.ajax(
        {
            type: 'GET',
            url: '/Envios/CreateLocalidad',
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

$("#btnDeletePais").on("click", function () {
    var data = $("#Pais").val()
    if (data == 0) {
        alert("SELECCIONE UN PAIS A ELIMINAR");
    }
    else {
        if (confirm('¿DESEA ELIMINAR ESTE PAIS?') == true) {
            $.ajax(
                {
                    type: 'GET',
                    url: '/Envios/DeletePais?id=' + data,
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
    }
});

$("#btnDeleteProvincia").on("click", function () {
    var data = $("#Provincia").val()
    if (data == 0) {
        alert("SELECCIONE UNA PROVINCIA A ELIMINAR");
    }
    else {
        if (confirm('¿DESEA ELIMINAR ESTA PROVINCIA?') == true) {
            $.ajax(
                {
                    type: 'GET',
                    url: '/Envios/DeleteProvincia?id=' + data,
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
    }
});

$("#btnDeleteLocalidad").on("click", function () {
    var data = $("#Localidad").val()
    if (data == 0) {
        alert("SELECCIONE UNA LOCALIDAD A ELIMINAR");
    }
    else {
        if (confirm('¿DESEA ELIMINAR ESTA LOCALIDAD?') == true) {
            $.ajax(
                {
                    type: 'GET',
                    url: '/Envios/DeleteLocalidad?id=' + data,
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
    }
});

$("#btnEditPais").on("click", function () {
    var data = $("#Pais").val();
    if (data == 0) {
        alert("SELECCIONE UN PAIS A MODIFICAR");
    }
    else {
        $.ajax(
            {
                type: 'GET',
                url: '/Envios/EditPais?id=' + data,
                contentType: 'application/json; charset=utf=8',
                success: function (result) {
                    $('#modal-edit-content').html(result);
                    $('#modal-edit').modal('show');
                },
                error: function (er) {
                    alert(er);
                }
            });
    }
});

$("#btnEditProvincia").on("click", function () {
    var data = $("#Provincia").val();
    if (data == 0) {
        alert("SELECCIONE UNA PROVINCIA A MODIFICAR");
    }
    else {
        $.ajax(
            {
                type: 'GET',
                url: '/Envios/EditProvincia?id=' + data,
                contentType: 'application/json; charset=utf=8',
                success: function (result) {
                    $('#modal-edit-content').html(result);
                    $('#modal-edit').modal('show');
                },
                error: function (er) {
                    alert(er);
                }
            });

    }
});

$("#btnEditLocalidad").on("click", function () {
    var data = $("#Localidad").val();
    if (data == 0) {
        alert("SELECCIONE UNA LOCALIDAD A MODIFICAR");
    }
    else {
        $.ajax(
            {
                type: 'GET',
                url: '/Envios/EditLocalidad?id=' + data,
                contentType: 'application/json; charset=utf=8',
                success: function (result) {
                    $('#modal-edit-content').html(result);
                    $('#modal-edit').modal('show');
                },
                error: function (er) {
                    alert(er);
                }
            });
    }
});