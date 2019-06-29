var CurrentPlaylistViewModel = function () {
    var self = this;
    self.playlistName = ko.observable();

    self.init = function (name) {
        self.playlistName(name);
    }
    
}


var AddPlaylistViewModel = function () {
    var self = this;
    self.PlaylistToAdd = ko.observable();
    self.playlistName = ko.observable("Nume");

    self.init = function () {
        
        var currentPlaylistToAdd = new CurrentPlaylistViewModel();
        currentPlaylistToAdd.init(self.playlistName());
        self.PlaylistToAdd(currentPlaylistToAdd);
    }

    self.addPlaylistFunction = function () {

        var decodedToken = parseJwt(localStorage.getItem('token'));
        var playlistData = {
            name: self.playlistName(),
            UserId: decodedToken.nameid
        }

        $.ajax({
            url: "/playlist/Create",
            type: "POST",
            data: JSON.stringify(playlistData),
            dataType: "json",
            beforeSend: function (xhr) { xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('token')); },
            contentType: "application/json; charset=utf-8",
            success: function (returnedData) {
                console.log(returnedData)
                alert("Successfully added!!");
            },
            error: function () {
                alert("Failed to add");
            }
        });
    }
    

    self.parseJwt = function (token) {
        var base64Url = token.split('.')[1];
        var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
        var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
            return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
        }).join(''));

        return JSON.parse(jsonPayload);
    };
}

