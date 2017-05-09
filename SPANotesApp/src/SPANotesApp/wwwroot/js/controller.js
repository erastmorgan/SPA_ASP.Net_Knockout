var koModel = model;

function changeSectionsVisibility(sourceVal) {
    if (sourceVal === "List") {
        koModel.showItemsList(true)
        koModel.showAddNew(false);
        koModel.showSelectedItem(false);
    } else if (sourceVal === "New") {
        koModel.newItem.name("");
        koModel.newItem.description("");
        koModel.newItem.expTimeType.key(koModel.expTimeTypes()[0].key);
        koModel.newItem.expTimeType.value(koModel.expTimeTypes()[0].value + '&nbsp;<span class="caret"></span>');
        koModel.showItemsList(false)
        koModel.showAddNew(true);
        koModel.showSelectedItem(false);
    } else if (sourceVal === "Selected") {
        koModel.showItemsList(false)
        koModel.showAddNew(false);
        koModel.showSelectedItem(true);
    }

    koModel.errorMessage("");
}

function addItem(item) {
    if (item.newItem.name() == "" || item.newItem.name() === undefined || item.newItem.description() == "" || item.newItem.description() === undefined) {
        alert("Note name and description fields are required.")
        return;
    }

    $.when(addItemServ(JSON.stringify({
        name: item.newItem.name(),
        description: item.newItem.description(),
        expTimeType: item.newItem.expTimeType.key()
    }))).then(function ()
    {
        $.when(getAllItemsServ()).then(function (data) {
            getAllItems(data);
        });
    });
}

function openItem(item) {
    $.when(openItemServ(item.noteId)).then(function (data) {
        if (data === undefined || data === null) {
            koModel.errorMessage("The data is not available or has expiration date/time.");
            return;
        }

        koModel.selectedItem.name("Subject: " + data.name);
        koModel.selectedItem.description(data.description);
        koModel.selectedItem.createdDateTime(formatDate(new Date(data.createdDateTime)));
        var date = formatDate(new Date(data.expirationDateTime));
        var expDateTime = "12/31/9999 11:59 pm" === date ? "Never" : date;
        koModel.selectedItem.expirationDateTime(expDateTime);

        changeSectionsVisibility("Selected");
    });
}

function getAllItems(data) {
    koModel.notes.removeAll();
    for (var i = 0; i < data.length; i++) {
        koModel.notes.push(data[i]);
    }

    changeSectionsVisibility("List");
}

function getExpTimeTypes() {
    $.get("/api/exptimetypes", function (data) {
        koModel.expTimeTypes.removeAll();
        for (var i = 0; i < data.length; i++) {
            koModel.expTimeTypes.push(data[i]);
        }

        koModel.newItem.expTimeType.key(data[0].key);
        koModel.newItem.expTimeType.value(data[0].value + '&nbsp;<span class="caret"></span>');
    });
}

function selectExpTime(item) {
    koModel.newItem.expTimeType.key(item.key);
    koModel.newItem.expTimeType.value(item.value + '&nbsp;<span class="caret"></span>');
}

$(document).ready(function () {
    $.when(getAllItemsServ()).then(getAllItems);
    $.when(getExpTimeTypesServ()).then(getExpTimeTypes);
    ko.applyBindings(koModel);
});

function formatDate(date) {
    var hours = date.getHours();
    var minutes = date.getMinutes();
    var ampm = hours >= 12 ? 'pm' : 'am';
    hours = hours % 12;
    hours = hours ? hours : 12;
    minutes = minutes < 10 ? '0' + minutes : minutes;
    var strTime = hours + ':' + minutes + ' ' + ampm;
    return date.getMonth() + 1 + "/" + date.getDate() + "/" + date.getFullYear() + " " + strTime;
}