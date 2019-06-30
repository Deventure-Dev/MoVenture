var PlaylistMovieViewModel = function () {
    var self = this;
    self.Id = ko.observable();
    self.Name = ko.observable();
    self.MinifiedMoviesListViewModel = ko.observableArray();

    self.init = function (id, name, minifiedMovies) {
        self.Id(id);
        self.Name(name);

        var minifiedMovieList = [];
        for (var i = 0; i < minifiedMovies.length; i++) {
            var minifiedVm = new MinifiedMovieViewModel();
            var currentMinifiedMovie = minifiedMovies[i];
            minifiedVm.init(currentMinifiedMovie.id, currentMinifiedMovie.title, currentMinifiedMovie.pictureUrl, currentMinifiedMovie.rating, currentMinifiedMovie.mainCategory);
            minifiedMovieList.push(minifiedVm);
        }

        self.MinifiedMoviesListViewModel(minifiedMovieList);

    }

    self.deletePlaylist = function () {
        var deleteConfirmation = confirm("Are you sure?");
        if (deleteConfirmation == true) {
            $.ajax({
                url: "/playlist/DeletePlaylist?id=" + self.Id(),
                type: "POST",
                dataType: "json",
                beforeSend: function (xhr) { xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('token')); },
                contentType: "application/json; charset=utf-8",
                success: function (returnedData) {
                    location.href = "/playlist"
                },
                error: function () {
                    alert("Failed to delete");
                }
            });
        }
    }

}

