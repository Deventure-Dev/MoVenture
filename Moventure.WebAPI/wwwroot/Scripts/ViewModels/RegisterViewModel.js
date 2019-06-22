var CurrentRegisterViewModel = function () {
    var self = this;
    self.registerEmail = ko.observable();
    self.registerPassword = ko.observable();

    self.init = function (email, password) {
        self.registerEmail(email);
        self.registerPassword(password);
    }
}


var RegisterViewModel = function () {
    var self = this;
    self.RegisteredUser = ko.observable();
    self.registerPassword = ko.observable("");
    self.registerEmail = ko.observable("");

    self.init = function () {
        var currentUser = new CurrentRegisterViewModel();
        currentUser.init(self.registerEmail(), self.registerPassword());
        self.RegisteredUser(currentUser);
        ko.applyBindings(self.RegisteredUser);
    }

    self.registerUserFunction = function () {
        var userData = {
            Email: self.RegisteredUser().registerEmail(),
            Password: self.RegisteredUser().registerPassword()
        }

        $.ajax ({
            url: "/auth/register",
            type: "POST",
            data: JSON.stringify(userData),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (returnedData) {
                alert("Successfully registered!!");
            }
        });
    } 
}

