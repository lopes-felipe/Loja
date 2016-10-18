var enviaRequisicao = function (url, verbo, dados, callbackSucesso, callbackErro, opcoes) {

    var opcoesRequest = opcoes || {};
    opcoesRequest.type = verbo;
    opcoesRequest.success = callbackSucesso;
    opcoesRequest.error = callbackErro;

    if (!url || !verbo) {
        errorCallback(401, "URL e verbo HTTP obrigatórios");
    }

    if (dados) {
        opcoesRequest.data = JSON.stringify(dados);
        opcoesRequest.contentType = "application/json; charset=utf-8";
        opcoesRequest.dataType = "json";
    }

    $.ajax(url, opcoesRequest);
}