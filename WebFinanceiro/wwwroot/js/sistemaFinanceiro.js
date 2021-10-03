window.addEventListener('load', function () {
    $('#Dashboard').removeClass('active');
    $('#Categorias').removeClass('active');
    $('#Despesas').removeClass('active');
    $('#SistemasFinanceiro').addClass('active');
    $('#Sugestao').removeClass('active');
    $('#Contato').removeClass('active');
    $('#Compras').removeClass('active');
});



var ObjetoSistema = new Object();

ObjetoSistema.IncluirNovousuario = function () {


    var html = '<tr><td><div class="form-group"><label class="bmd-label-floating">Digite o E-mail</label><input id="EmailUsuario" class="form-control" /><span id="mensagemerro" class="text-danger"></span></br><input type="button" value="Save" class="btn btn-primary" onclick="ObjetoSistema.SalvarUsuario()" />   <input type="button" value="Cancelar" class="btn btn-primary" onclick="ObjetoSistema.ListarUsuarios()" /></div></td></tr> ';

    $("#tabelaUsuario").html(html);

}

ObjetoSistema.ListarUsuarios = function () {
    var idSistema = $("#Id").val();

    var html = '<tr><td><div class="form-group"><input type="button" value="Incluir Novo Usuário" class="btn btn-primary" onclick="ObjetoSistema.IncluirNovousuario()" /></br><span id="mensagemerro" class="text-danger"></span></div></td></tr>';

    $("#tabelaUsuario").html('');

    $.ajax({
        type: 'GET',
        timeout: 50000, //Parametrizar com objs
        url: '/UsuarioSistemaFinanceiro/ListaUsuariosSistema',
        data: { "idSistema": idSistema },
        async: false,
        success: function (jsonRetornado) {

            jsonRetornado.usuarios.forEach(function (item) {



                html += '<tr><td class="td-actions text-right"><button type="button"  onclick="ObjetoSistema.RemoverUsuario(' + "'" + item + "'" + ')"  rel="tooltip" title="Remover" class="btn btn-danger btn-link btn-sm"><i class="material-icons">close</i></button></td>';
                html += '<td style="position:relative;right: 30px;">' + item + '</td></tr>';
            });

        }
    });


    $("#tabelaUsuario").html(html);
}


ObjetoSistema.SalvarUsuario = function () {

    var idSistema = $("#Id").val();
    var emailUsuario = $("#EmailUsuario").val();


    $.ajax({
        type: 'POST',
        timeout: 50000, //Parametrizar com objs
        url: '/UsuarioSistemaFinanceiro/AdicionarUsuaio',
        async: true,
        data: {
            "idSistema": idSistema, 'emailUsuario': emailUsuario
        },
        success: function (jsonRetornado) {

            if (jsonRetornado.sucesso == "OK") {
                ObjetoSistema.ListarUsuarios();
            }
            else {
                $("#mensagemerro").text(jsonRetornado.sucesso);
            }


        }
    });


}

ObjetoSistema.RemoverUsuario = function (emailUsuario) {

    var idSistema = $("#Id").val();

    $.ajax({
        type: 'POST',
        timeout: 50000, //Parametrizar com objs
        url: '/UsuarioSistemaFinanceiro/RemoverUsuario',
        async: false,
        data: {
            "idSistema": idSistema, 'emailUsuario': emailUsuario
        },
        success: function (jsonRetornado) {

            if (jsonRetornado.sucesso == "OK") {
                ObjetoSistema.ListarUsuarios();
            }
            else {
                $("#mensagemerro").text(jsonRetornado.sucesso);
            }


        }
    });
}


$(function () {
    ObjetoSistema.ListarUsuarios();
});