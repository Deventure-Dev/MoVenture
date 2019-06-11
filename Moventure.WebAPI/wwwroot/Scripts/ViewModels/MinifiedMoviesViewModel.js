var MinifiedMovieViewModel = function () {
   var self = this;
    self.Id = ko.observable();
    self.Title = ko.observable();
    self.PictureUrl = ko.observable();
    self.Rating = ko.observable();
    self.Tags = ko.observableArray();
    self.MainCategory = ko.observable();

    self.init = function (id, title, pictureUrl, rating, tags, mainCategory) {
        self.Id(id);
        self.Title(title);
        self.PictureUrl(pictureUrl);
        self.Rating(rating);
        self.Tags(tags);
        self.MainCategory(mainCategory);
    }
}


var MinifiedMoviesListViewModel = function () {
    debugger
    var self = this;
    self.MinifiedMovies = ko.observableArray();
    self.init = function (minifiedMovies) {
        var minifiedMovieList = [];
        console.log(minifiedMovies);
        for (var i = 0; i < minifiedMovies.length; i++)
        {
            var minifiedVm = new MinifiedMovieViewModel();
            var currentMinifiedMovie = minifiedMovies[i];
            minifiedVm.init(currentMinifiedMovie.id, currentMinifiedMovie.title, currentMinifiedMovie.pictureUrl, currentMinifiedMovie.rating, currentMinifiedMovie.mainCategory);
            minifiedMovieList.push(minifiedVm);
        }
        self.MinifiedMovies(minifiedMovieList);
    }
}

