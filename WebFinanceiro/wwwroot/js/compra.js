window.addEventListener('load', function () {
    $('#Dashboard').removeClass('active');
    $('#Categorias').removeClass('active');
    $('#Despesas').removeClass('active');
    $('#SistemasFinanceiro').removeClass('active');
    $('#Sugestao').removeClass('active');
    $('#Contato').removeClass('active');
    $('#Compras').addClass('active');
});


var ObjetoCompras = new Object();

ObjetoCompras.JsonLanguage = {
    "sEmptyTable": "Nenhum registro encontrado",
    "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
    "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
    "sInfoFiltered": "(Filtrados de _MAX_ registros)",
    "sInfoThousands": ".",
    "sLengthMenu": "_MENU_ Resultados por página",
    "sLoadingRecords": "Carregando...",
    "sProcessing": "Processando...",
    "sZeroRecords": "Nenhum registro encontrado",
    "sSearch": "Buscar",
    "oPaginate": {
        "sNext": "Próximo",
        "sPrevious": "Anterior",
        "sFirst": "Primeiro",
        "sLast": "Último"
    }
};

ObjetoCompras.columns = [

    {
        "data": "comprado",
        "render": function (data, type, row, meta) {
            if (type === 'display') {

                var idCampo = "input_" + row.id;

                var onchange = "ObjetoCompras.Atualizar(" + row.id + "," + idCampo + " ,this);";

                // return '<input type="checkbox" class="editor-active" onchange="' + onchange + '" >';
                //return "<label class='switch'>  <input id='" + idCampo + "' type='checkbox' class='editor-active' onchange='" + onchange + "' />  <span class='slider round'></span>  </label>";
                //style = 'width: 61px; height: 34px;'

                if (row.comprado) {
                    return '<label class="form-check-label"><input class="form-check-input" type="checkbox" value="" onchange=' + onchange + ' checked><span class="form-check-sign"><span class="check"></span></span></label>';
                }
                else {
                    return '<label class="form-check-label"><input class="form-check-input" type="checkbox" value="" onchange=' + onchange + '><span class="form-check-sign"><span class="check"></span></span></label>';
                }

                //<div class="form-check"><label class="form-check-label"><input class="form-check-input" type="checkbox" value="" checked><span class="form-check-sign"><span class="check"></span></span></label></div>


            }

            //  style = "width: 61px;height: 34px; top: 41px;left: 6px;"

            return data;

        }

    },

    {
        "data": "nome"
    }]

ObjetoCompras.Atualizar = function (id, idcampo, objeto) {

    if (objeto.checked) {
        // objeto.checked = false;
        //  ObjetoCompras.confirmacao(this, "Confirma?", "Sim", "Não", id, objeto, 1, true);

        ObjetoCompras.AtualizaItem(id, true);
    }
    else {
        //  objeto.checked = true;
        // ObjetoCompras.confirmacao(this, "Confirma?", "Sim", "Não", id, objeto, 1, false);
        ObjetoCompras.AtualizaItem(id, false);
    }
}

ObjetoCompras.confirmacao = function (objeto, titulo, textoBotaoOk, textoBotaoCancela, id, objCustomizado, tipo, alteraStatusCheckBox) {


    // tipo 1 == Organização
    // tipo 2 == Assinatura

    swal({
        title: titulo,
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: textoBotaoOk,
        cancelButtonText: textoBotaoCancela,
        closeOnConfirm: true,
        closeOnCancel: true,
        allowEscapeKey: true
    },
        function (isConfirm) {
            if (isConfirm) {

                if (tipo == 1) {
                    ObjetoCompras.AtualizaOrganizacao(id);
                }
                else {
                    ObjetoCompras.AtualizaAssinatura(id);
                }

                objCustomizado.checked = alteraStatusCheckBox;
            }
            return isConfirm;
        });
}

ObjetoCompras.CarregaTabelaItensOld = function () {
    //var table = $('#tabelaItens').DataTable();

    var dataTable = $('#tabelaItens').dataTable();
    $('#barraDePesquisa').keyup(function () {
        dataTable.fnFilter(this.value);
    });

    if ($.fn.dataTable.isDataTable('#tabelaItens')) {
        var table = $('#tabelaItens').DataTable();
        table.destroy();
    }

    $.ajax({
        type: 'GET',
        timeout: 5000, //Parametrizar com obj
        url: '/ItemCompra/CarregaItensCompra',
        async: false,

        success: function (jsonRetornado) {

            var colunas = ObjetoCompras.columns;

            if (jsonRetornado.sucesso) {

                var table = $('#tabelaItens').DataTable({
                    data: jsonRetornado.dados,
                    columns: colunas,
                    "paging": true,
                    "ordering": true,
                    "info": false,
                    "searching": true,
                    "language": ObjetoCompras.JsonLanguage,
                    //"language": {
                    //    "search": "Pesquisa:"
                    //},

                    //"scrollX": true,
                    //"lengthChange": false,
                    //"autoWidth": true,
                    //"iDisplayLength": 2,

                    //columnDefs: [{
                    //    "width": "20%",
                    //    //"className": "dt-center",
                    //    //"targets": "_all",
                    //    // render: $.fn.dataTable.render.ellipsis(100),
                    //}],
                    //fixedColumns: true,

                    //Quantidade Itens Pagina
                    "lengthMenu": [[10, 25, 50, 100, 1000], [10, 25, 50, 100, 1000]],

                    rowCallback: function (row, data) {
                        // Set the checked state of the checkbox in the table
                        //$('input.editor-active', row).prop('checked', data.comprado);

                    }
                });

                table.columns.adjust().draw();


            }
            else {
                var table2 = $('#tabelaItens').DataTable({

                    columns: colunas,
                    "paging": true,
                    //"ordering": true,
                    "info": false,
                    //"searching": true,
                    "language": ObjetoCompras.JsonLanguage,
                    // "scrollX": true,
                    "lengthChange": false,
                    // "autoWidth": true,

                    //columnDefs: [{
                    //    "width": "20%",
                    //    "className": "dt-center",
                    //    "targets": "_all",
                    //    render: $.fn.dataTable.render.ellipsis(100),
                    //}],

                    //Quantidade Itens Pagina
                    //"lengthMenu": [[10, 25, 50, 100, 1000], [10, 25, 50, 100, 1000]],

                    //rowCallback: function (row, data) {
                    //    // Set the checked state of the checkbox in the table
                    //    $('input.editor-active', row).prop('checked', data.statusOrganizacao == 1);
                    //    $('input.editor-active-assinatura', row).prop('checked', data.statusassinatura == 1);
                    //}
                });

                // table.columns.adjust().draw();
            }



        }
    });


    //var table = $('#tabelaItens').DataTable();
}

ObjetoCompras.CarregaTabelaItens = function () {

    if ($.fn.dataTable.isDataTable('#tabelaItens')) {
        var table = $('#tabelaItens').DataTable();
        table.destroy();
    }

    $("#dadosTabelaItem").html("");

    var idCompra = $("#Id").val();

    $.ajax({
        type: 'GET',
        timeout: 5000, //Parametrizar com obj
        url: '/ItemCompra/CarregaItensCompra',
        async: true,
        data: {
            idCompra: idCompra
        },
        success: function (jsonRetornado) {


            if (jsonRetornado.sucesso) {

                jsonRetornado.dados.forEach(function (item) {

                    var input = "";

                    var tr = $("<tr>");
                    var td = $("<td>");

                    var div = $("<div>", { class: "form-check" });
                    var label = $("<label>", { class: "form-check-label" });


                    var onchange = "ObjetoCompras.Atualizar(" + item.id + "," + idCampo + " ,this);";
                    var idCampo = "input_" + item.id;
                    if (item.comprado) {
                        input = $("<input>", {
                            class: "orm-check-input", type: "checkbox", checked: "checked", onchange: onchange,
                        });
                    }
                    else {
                        input = $("<input>", {
                            class: "orm-check-input", type: "checkbox", onchange: onchange,
                        });
                    }


                    // return '<input type="checkbox" class="editor-active" onchange="' + onchange + '" >';
                    //return "<label class='switch'>  <input id='" + idCampo + "' type='checkbox' class='editor-active' onchange='" + onchange + "' />  <span class='slider round'></span>  </label>";

                    //var idCampo = "input_" + item.id;

                    //var onchange = "ObjetoCompras.Atualizar(" + item.id + "," + idCampo + " ,this);";
                    //if (item.comprado) {
                    //    td.append("<label class='switch'>  <input id='" + idCampo + "' type='checkbox' class='editor-active' onchange='" + onchange + "' />  <span  class=''></span>  </label>");
                    //}
                    //else {
                    //    td.append('<input type="checkbox" class="editor-active" onchange="' + onchange + '" >');
                    //}


                    var span = $("<span>", { class: "form-check-sign" });
                    var span2 = $("<span>", { class: "check" });

                    var input2 = $("<input>", {
                        class: "orm-check-input", type: "checkbox", checked: "checked"
                    });





                    span2.append(input2);
                    span.append(span2);
                    input.append(span);

                    label.append(input);
                    div.append(label);
                    td.append(div);
                    tr.append(td);

                    var td2 = $("<td>");
                    td2.text(item.nome);
                    tr.append(td2);


                    tr.append('<td class="td-actions text-right"><button type="button"  onclick="ObjetoCompras.RemoverItemDaCompra(' + "'" + item.id + "'" + "," + "'" + item.nome + "'" + ')"  rel="tooltip" title="Remover" class="btn btn-danger btn-link btn-sm"><i class="material-icons">close</i></button>');


                    $("#dadosTabelaItem").append(tr);
                });

                ObjetoCompras.ConfiguraTabela();
            }
        }
    });


}

ObjetoCompras.RemoverItemDaCompra = function (id, Nome) {

    var resultado = ObjetoCompras.ConfirmacaoTela("Deletar Item?", "Sim", "Não", id, Nome);


}

ObjetoCompras.ConfirmacaoTela = function (titulo, textoBotaoOk, textoBotaoCancela, id, Nome) {

    Swal.fire({
        title: titulo,
        text: "Deseja deletar o item: " + Nome,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: textoBotaoOk,
        cancelButtonText: textoBotaoCancela
    }).then((result) => {
        if (result.value) {
            ObjetoCompras.DeletaItem(id);
            Swal.fire(
                'Deletado!',
                'Item deletado com Sucesso!',
                'success'
            )
        }
    })

}

ObjetoCompras.DeletaItem = function (id) {

    $.ajax({
        type: 'POST',
        timeout: 5000, //Parametrizar com obj
        url: '/ItemCompra/RemoveItem',
        async: true,
        data: {
            id: id
        },
        success: function (jsonRetornado) {



            ObjetoCompras.CarregaTabelaItens();
        }
    });
}

ObjetoCompras.AtualizaItem = function (id, comprado) {

    $.ajax({
        type: 'POST',
        timeout: 5000, //Parametrizar com obj
        url: '/ItemCompra/AtualizaItem',
        async: true,
        data: {
            id: id, comprado: comprado
        },
        success: function (jsonRetornado) {

        }
    });
}

ObjetoCompras.AdicionaClickBotao = function () {

    //$("#btnIncluirItem").click(
    //    function () {
    //        ObjetoCompras.LiberarInclusaoItem();
    //    }
    //);

    $("#btnAtualizar").click(
        function () {
            ObjetoCompras.CarregaTabelaItens();
        }
    );


    $("#btnSalvar").click(
        function () {
            ObjetoCompras.SalvarItem();
        }
    );

    $("#btnCancelar").click(
        function () {
            ObjetoCompras.Cancelar();
        }
    );

}

ObjetoCompras.SalvarItem = function () {

    var id = $("#Id").val();
    var descricao = $("#Descricao").val();
    $("#mensagemerro").text("");

    if (descricao !== null && descricao !== "" && descricao !== "") {
        $.ajax({
            type: 'POST',
            timeout: 50000, //Parametrizar com objs
            url: '/ItemCompra/AdicionarItem',
            async: true,
            data: {
                "id": id, 'descricao': descricao
            },
            success: function (jsonRetornado) {

                if (jsonRetornado.sucesso == "OK") {
                    ObjetoCompras.CarregaTabelaItens();

                    $("#Descricao").val("");
                }
                else {
                    $("#mensagemerro").text("Não foi possivél cadastrar o item");
                }


            }
        });
    }
    else {
        $("#mensagemerro").text("Campo Obrigatório.");
    }

}

ObjetoCompras.Cancelar = function () {

    $("#Descricao").val("");

}

ObjetoCompras.LiberarInclusaoItem = function () {
    $("#IncluirItem").show();
    $("#Descricao").val("");
}

ObjetoCompras.ConfiguraTabela = function () {

    var table = $('#tabelaItens').DataTable({
        //dom: 'Bfrtip',
        //buttons: [
        //    'copyHtml5',
        //    'excelHtml5',
        //    'csvHtml5',
        //    'pdfHtml5'
        //],
        //buttons: [
        //    {
        //        extend: 'excel',
        //        text: 'Save current page',
        //        exportOptions: {
        //            modifier: {
        //                page: 'current'
        //            }
        //        }
        //    }
        //],
        //"paging": true,
        "ordering": true,
        //"info": true,
        //"searching": false,
        "language": ObjetoCompras.JsonLanguage,
        //"scrollX": true,
        //"recordsFiltered": 100,
        //"recordsTotal": 30000,
        "lengthMenu": [[50, 100, -1], [50, 100, "All"]]
    });

    //table.buttons().container()
    //    .appendTo('#example_wrapper .col-sm-6:eq(0)');

}

$(function () {

    ObjetoCompras.CarregaTabelaItens();
    ObjetoCompras.AdicionaClickBotao();

    //  setInterval(ObjetoCompras.CarregaTabelaItens, 60000);
});







