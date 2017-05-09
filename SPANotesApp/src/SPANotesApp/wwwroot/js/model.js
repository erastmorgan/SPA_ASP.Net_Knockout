var model = {
    notes: ko.observableArray(),
    expTimeTypes: ko.observableArray(),
    newItem: {
        name: ko.observable(),
        description: ko.observable(),
        expTimeType: {
            key: ko.observable(),
            value: ko.observable()
        }
    },
    selectedItem: {
        name: ko.observable(),
        description: ko.observable(),
        createdDateTime: ko.observable(),
        expirationDateTime: ko.observable()
    },
    showItemsList: ko.observable(true),
    showSelectedItem: ko.observable(false),
    showAddNew: ko.observable(false),
    errorMessage: ko.observable("")
};