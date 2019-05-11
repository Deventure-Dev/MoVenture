var MinifiedMovieViewModel = function () {
    var self = this;
    self.Id = ko.observable();
    self.Title = ko.observable();
    self.PictureUrl = ko.observable();
    self.Rating = ko.observable();
    self.Length = ko.observable();
    self.CreatedBy = ko.observable();
    self.Tags = ko.observableArray();
    self.MainCategory = ko.observable();

    self.init = function (id, title, pictureUrl, rating, length, createdBy, tags, MainCategory) {
        self.Id(id);
        self.Title(title);
        self.PictureUrl(pictureUrl);
        self.Rating(rating);
        self.Length(length);
        self.CreatedBy(createdBy);
        self.Tags(tags);
        self.MainCategory(MainCategory);
    }
}

var MinifiedMoviesListViewModel = function () {
    var self = this;
    self.MinifiedMovies = ko.observableArray();

    self.init = function (minifiedMovies) {
        var minifiedMovieList = [];
        for (var i = 0; i < minifiedMovies.length; i++)
        {
            var minifiedVm = new MinifiedMovieViewModel();
            var currentMinifiedMovie = minifiedMoviesp[i];
            minifiedVm.init(currentMinifiedMovie.Id, currentMinifiedMovie.Title, currentMinifiedMovie.PictureUrl, currentMinifiedMovie.Rating, currentMinifiedMovie.Length, currentMinifiedMovie.CreatedBy, currentMinifiedMovie.MainCategory);
            minifiedMovieList.push(minifiedVm);
        }
        self.MinifiedMovies(minifiedMovieList);
    }
}