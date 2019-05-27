var CategoryViewModel = function () {
    var self = this;
    self.Id = ko.observable();
    self.Name = ko.observable();
    self.MinifiedMovies = ko.observableArray();

    self.init = function (id, name, minifiedMovies) {
        self.Id(id);
        self.Name(name);

        var minifiedMovieList = []; 
        for (var i = 0; i < minifiedMovies.length; i++)
        {
            var minifiedVm = new MinifiedMovieViewModel();
            var currentMinifiedMovie = minifiedMovies[i];
            minifiedVm.init(currentMinifiedMovie.Id, currentMinifiedMovie.Title, currentMinifiedMovie.PictureUrl, currentMinifiedMovie.Rating, currentMinifiedMovie.MainCategory);
            minifiedMovieList.push(minifiedVm);
        }

        self.MinifiedMovies(minifiedMovieList);
    }


}

