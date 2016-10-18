var produtosUrl = lojaServicosUrl + "/produtos/";

var buscarProdutos = function () {
    enviaRequisicao(produtosUrl, "GET", null, function (dados) {
        modelo.produtos.removeAll();
        modelo.produtos.push.apply(modelo.produtos, dados);
        tratarSucesso();
    }, tratarErro);
};

var cadastrarProduto = function (produto, callbackSucesso) {
    enviaRequisicao(produtosUrl, "POST", produto, function () {
        buscarProdutos();
        tratarSucesso();

        if (callbackSucesso)
            callbackSucesso();

    }, tratarErro);
};

var excluirProduto = function (produto) {
    enviaRequisicao(produtosUrl + produto.ID, "DELETE", null,
        function () {
            modelo.produtos.remove(function (item) {
                return item.ID == produto.ID;
            });

            tratarSucesso();
        }, tratarErro);
};

var tratarErro = function (erro) {
    modelo.erro('(' + erro.status + ') ' + erro.statusText);
    modelo.temErro(true);
};

var tratarSucesso = function () {
    modelo.temErro(false);
    modelo.erro('');
};