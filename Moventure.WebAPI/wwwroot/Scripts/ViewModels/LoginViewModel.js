var CurrentLoginViewModel = function () {
    var self = this;
    self.loginUsername = ko.observable();
    self.loginPassword = ko.observable();

    self.init = function (username, password) {
        self.loginUsername(username);
        self.loginPassword(password);
    }
}


var LoginViewModel = function () {
    var self = this;
    self.LoginUser = ko.observable();
    self.loginPassword = ko.observable("");
    self.loginUsername = ko.observable("");

    self.init = function () {
        var currentUser = new CurrentLoginViewModel();
        currentUser.init(self.loginUsername(), self.loginPassword());
        self.LoginUser(currentUser);
        ko.applyBindings(self.LoginUser);
    }

    self.loginUserFunction = function () {
        var userData = {
            Username: self.LoginUser().loginUsername(),
            Password: self.LoginUser().loginPassword()
        }

        $.ajax ({
            url: "/auth/login",
            type: "POST",
            data: JSON.stringify(userData),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (returnedData) {
                console.log(returnedData)
                localStorage.setItem("token", returnedData.token);
                //location.href = "/#"
            },
            error: function (err) {
                alert("Failed to asdasdasd");
            }
        });
    } 
}

