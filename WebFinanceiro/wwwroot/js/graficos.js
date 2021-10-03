var ObjetoGrafico = new Object();

function formatMoney(n, c, d, t) {
    c = isNaN(c = Math.abs(c)) ? 2 : c, d = d == undefined ? "," : d, t = t == undefined ? "." : t, s = n < 0 ? "-" : "", i = parseInt(n = Math.abs(+n || 0).toFixed(c)) + "", j = (j = i.length) > 3 ? j % 3 : 0;
    return s + (j ? i.substr(0, j) + t : "") + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + t) + (c ? d + Math.abs(n - i).toFixed(c).slice(2) : "");
}

ObjetoGrafico.CarregaGrafico = function () {

    $("#Despesa_Paga").text("0,00");
    $("#Despesa_Pendente").text("0,00");
    $("#Investimento").text("0,00");


    $.ajax({
        type: 'GET',
        timeout: 50000, //Parametrizar com objs
        url: '/Despesas/CarregaGraficos',
        async: true,
        //data: {
        //    "idSistema": idSistema, 'emailUsuario': emailUsuario
        //},
        success: function (jsonRetornado) {

            if (jsonRetornado.sucesso == "OK") {
                $("#Despesa_Paga").text(formatMoney(jsonRetornado.despesas_pagas));
                $("#Despesa_Pendente").text(formatMoney(jsonRetornado.despesas_pendentes));
                $("#Investimento").text(formatMoney(jsonRetornado.investimentos));
                $("#Despesa_atrasadas").text(formatMoney(jsonRetornado.despesas_naoPagasMesesAnteriores));
            }
            else {
                $("#Despesa_Paga").text("0,00");
                $("#Despesa_Pendente").text("0,00");
                $("#Investimento").text("0,00");
                $("#Despesa_atrasadas").text("0,00");
                
            }


        }
    });



}



$(function () {
    ObjetoGrafico.CarregaGrafico();
});