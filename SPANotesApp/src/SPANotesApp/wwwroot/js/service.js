function getExpTimeTypesServ() {
    return $.Deferred(function () {
        var self = this;
        $.get("/api/exptimetypes", function (data) {
            self.resolve(data);
        })
    });
}

function getAllItemsServ() {
    return $.Deferred(function () {
        var self = this;
        sendAjaxRequest("GET", function (data) {
            self.resolve(data);
        })
    });
}

function openItemServ(id) {
    return $.Deferred(function () {
        var self = this;
        sendAjaxRequest("GET", function (data) {
            self.resolve(data);
        }, id)
    });
}

function addItemServ(item) {
    return $.Deferred(function () {
        var self = this;
        sendAjaxRequest("POST", function (data) {
            self.resolve(data);
        }, null, item)
    });
}

function sendAjaxRequest(httpMethod, callback, url, data) {
    $.ajax("/api/notes" + (url !== undefined && url !== null ? "/" + url : ""), {
        type: httpMethod,
        success: callback,
        data: data,
        contentType: "application/json",
        dataType: "json"
    });
}