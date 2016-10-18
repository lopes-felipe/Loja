var modelo = {
    produtos: ko.observableArray([]),
    pedidos: ko.observableArray([]),
    erro: ko.observable(""),
    temErro: ko.observable(false),
    viewAtual: ko.observable("Produtos"),
    novoProduto: {
        Nome: "",
        Descricao: "",
        Preco: 0.0
    }
};

$(document).ready(function () {
    ko.applyBindings();
})