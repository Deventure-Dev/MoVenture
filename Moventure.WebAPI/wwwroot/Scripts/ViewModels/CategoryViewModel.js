var CategoryViewModel = function () {
    var self = this;
    self.Id = ko.observable();
    self.Name = ko.observable();
    self.MinifiedMoviesListViewModel = ko.observableArray();

    self.init = function (id, name, minifiedMovies) {
        self.Id(id);
        self.Name(name);

        var minifiedMovieList = []; 
        for (var i = 0; i < minifiedMovies.length; i++)
        {
            var minifiedVm = new MinifiedMovieViewModel();
            var currentMinifiedMovie = minifiedMovies[i];
            minifiedVm.init(currentMinifiedMovie.id, currentMinifiedMovie.title, currentMinifiedMovie.pictureUrl, currentMinifiedMovie.rating, currentMinifiedMovie.mainCategory);
            minifiedMovieList.push(minifiedVm);
        }

        self.MinifiedMoviesListViewModel(minifiedMovieList);
    }


}

