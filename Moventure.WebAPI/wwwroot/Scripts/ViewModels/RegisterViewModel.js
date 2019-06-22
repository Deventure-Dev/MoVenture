var CurrentRegisterViewModel = function () {
    var self = this;
    self.Email = ko.observable();

    self.init = function (email) {
        self.Email(email)
    }
}


var RegisterViewModel = function () {
    var self = this;
    self.RegisteredUser = ko.observable();

    self.init = function (data) {
        var currentUser = new CurrentRegisterViewModel();
    }
}

