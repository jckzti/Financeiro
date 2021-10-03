window.addEventListener('load', function () {
    $('#Dashboard').removeClass('active');
    $('#Categorias').removeClass('active');
    $('#Despesas').removeClass('active');
    $('#SistemasFinanceiro').removeClass('active');
    $('#Sugestao').removeClass('active');
    $('#Contato').removeClass('active');
    $('#Compras').addClass('active');


});



var objetoItemCompra = new Object();

objetoItemCompra.AlteraCompra = function (id) {

    var nomeCampo = "comprado_" + id;
    var chk = document.getElementById(nomeCampo);
    var comprado = false;

    if (chk.checked) {
        comprado = true;
    } else {
        comprado = false;
    }

    $.ajax({
        type: 'POST',
        timeout: 50000, //Parametrizar com objs
        url: '/ItemCompra/AlteraCompra',
        async: true,
        data: {
            "id": id, 'comprado': comprado
        },
        success: function (jsonRetornado) {

            if (jsonRetornado.sucesso == "OK") {
                //   jsonRetornado.comprado
                var nomeCampoConfirmacao = "#confirmacao_" + id;
                $(nomeCampoConfirmacao).addClass("confirmaSalvou");

            }

        }
    });


}