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
    self.playlistList = ko.observableArray();
    self.selectedPlaylist = ko.observable("");

    self.init = function (data) {


        $.ajax({
            url: "/playlist/GetAll",
            type: "GET",
            dataType: "json",
            beforeSend: function (xhr) { xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('token')); },
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                for (var i = 0; i < data.count; i++) {
                    console.log(data.playlists[i])
                    self.playlistList.push({
                        playlistId: data.playlists[i].id,
                        playlistName: data.playlists[i].name,
                    });
                }
            }

        });

        var currentMovie = new CurrentMovieViewModel();
        if (data[0].description == null) {
            data[0].description = 'No description';
        }
        currentMovie.init(data[0].id, data[0].title, data[0].pictureUrl, data[0].rating, data[0].tags, data[0].actors, data[0].categoryName, data[0].description)
        self.FetchedMovie(currentMovie);
    }

}

