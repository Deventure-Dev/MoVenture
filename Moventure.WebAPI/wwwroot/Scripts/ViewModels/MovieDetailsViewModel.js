var CurrentMovieViewModel = function () {
    var self = this;
    self.Id = ko.observable();
    self.Title = ko.observable();
    self.MainCategory = ko.observable();
    self.PictureUrl = ko.observable();
    self.Rating = ko.observable();
    self.Tags = ko.observableArray();
    self.Description = ko.observable();
    self.Actors = ko.observableArray();
    self.selectedPlaylist = ko.observable();
    self.playlistList = ko.observableArray();

    
    self.init = function (id, title, pictureUrl, rating, tags, actors, categoryName, description, selected, list) {
        self.Id(id);
        self.Title(title);
        self.PictureUrl(pictureUrl);
        self.Rating(rating);
        self.MainCategory(categoryName);
        self.Tags(tags);
        self.Actors(actors);
        self.Description(description);
        self.selectedPlaylist(selected);
        self.playlistList(list);
    }
}


var MovieDetailsViewModel = function () {
    var self = this;
    self.FetchedMovie = ko.observable();
    self.playlistList = ko.observableArray(["Select playlist"]);
    self.selectedPlaylist = ko.observable("");

    addToPlaylistFunction = function () {
        var destinationPlaylist = self.FetchedMovie().selectedPlaylist();

        $.ajax({
            url: "/playlist/GetByName?playlistName=" + destinationPlaylist,
            type: "GET",
            dataType: "json",
            beforeSend: function (xhr) { xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('token')); },
            contentType: "application/json; charset=utf-8",
            success: function (playlistByName) {
                $.ajax({
                    url: "/playlist/AddMovieToPlaylist?movieId=" + self.FetchedMovie().Id() + "&playlistId=" + playlistByName[0].id,
                    type: "POST",
                    dataType: "json",
                    beforeSend: function (xhr) { xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('token')); },
                    contentType: "application/json; charset=utf-8",
                    success: function (posted) {
                        alert("Movie added successfully to " + destinationPlaylist)
                    },
                    error: function (err) {
                        console.log("ERR", err)
                    }

                });
            },
            error: function (err) {
                console.log("ERR", err)
            }

        });
    }

    self.init = function (recievedData) {

        var decodedToken = self.parseJwt(localStorage.getItem('token'));

        $.ajax({
            url: "/playlist/GetByUserId?userId=" + decodedToken.nameid,
            type: "GET",
            dataType: "json",
            beforeSend: function (xhr) { xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('token')); },
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                for (var i = 0; i < data.playlists.length; i++) {
                    self.playlistList.push(
                        data.playlists[i].name,
                    );
                }

                var currentMovie = new CurrentMovieViewModel();
                if (recievedData[0].description == null) {
                    recievedData[0].description = 'No description';
                }

                currentMovie.init(recievedData[0].id, recievedData[0].title, recievedData[0].pictureUrl, recievedData[0].rating, recievedData[0].tags, recievedData[0].actors, recievedData[0].categoryName, recievedData[0].description, self.selectedPlaylist(), self.playlistList())
                self.FetchedMovie(currentMovie);
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

