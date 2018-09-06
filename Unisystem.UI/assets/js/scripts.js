$("#phone").mask("(99) 99999-9999");

$('table').DataTable(
    {
        "language": {
            "sProcessing": "A processar...",
            "sLengthMenu": "Mostrar _MENU_ registos",
            "sZeroRecords": "Não foram encontrados resultados",
            "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registos",
            "sInfoEmpty": "Mostrando de 0 até 0 de 0 registos",
            "sInfoFiltered": "(filtrado de _MAX_ registos no total)",
            "sInfoPostFix": "",
            "sSearch": "Procurar:",
            "sUrl": "",
            "oPaginate": {
                "sFirst": "Primeiro",
                "sPrevious": "Anterior",
                "sNext": "Seguinte",
                "sLast": "Último"
            }
        }
    }
);

$('form').submit(function (e) {
    $('.error-message').html("")

    e.preventDefault();

    if ($('#id').val() === "") {
        InsertUser();
    }
    else {
        UpdateUser();
    }
})

function ShowModal() {
    ClearModal();

    $("#userModal").modal();
}

function ClearModal() {
    $('#id').val("")
    $('#name').val("")
    $('#email').val("")
    $('#phone').val("")
}

function InsertUser() {
    var user = {
        "Name": $('#name').val(),
        "Email": $('#email').val(),
        "Phone": $('#phone').val(),
    }

    $.ajax({
        url: '/home/post',
        type: 'POST',
        data: user
    }).done(function (response) {
        $('.error-message').html("")

        if (response.Status === true) {
            window.location.reload();
        }
        else {
            $('.error-message').html(response.Message)
        }
    })
}

function EditUser(id) {
    $.ajax({
        url: '/home/edit/' + id,
        type: 'GET'
    }).done(function (response) {
        ShowModal();
        $('#id').val(response.Id)
        $('#name').val(response.Name)
        $('#email').val(response.Email)
        $('#phone').val(response.Phone)
    })
}

function UpdateUser() {
    var user = {
        "Id": $('#id').val(),
        "Name": $('#name').val(),
        "Email": $('#email').val(),
        "Phone": $('#phone').val(),
    }

    $.ajax({
        url: '/home/edit',
        type: 'POST',
        data: user
    }).done(function (response) {
        if (response.Status === true) {
            window.location.reload();
        }
        else {
            $('.error-message').html(response.Message)
        }
    })
}

function DeleteUser(id) {
    $.confirm({
        title: 'Atenção',
        titleIcon: 'glyphicon glyphicon-exclamation-sign',
        template: 'danger',
        message: 'Deseja realmente remover esse usuário?',
        templateOk: 'danger',
        labelOk: 'Remover',
        labelCancel: 'Cancelar',
        onOk: function () {
            $.ajax({
                url: '/home/Delete/' + id,
                type: 'post'
            }).done(function (response) {
                if (response.Status === true) {
                    window.location.reload()
                }
            })
        }
    });
}

