var CurrentMovieViewModel = function () {
    var self = this;
    self.Id = ko.observable();
    self.Title = ko.observable();
    self.PictureUrl = ko.observable();
    self.Rating = ko.observable();
    self.Tags = ko.observableArray();
    //self.MainCategory = ko.observable();

    self.init = function (id, title, pictureUrl, rating, tags) {
        self.Id(id);
        self.Title(title);
        self.PictureUrl(pictureUrl);
        self.Rating(rating);
        self.Tags(tags);
    }
}

var MovieDetailsViewModel = function () {
    var self = this;
    self.FetchedMovie = ko.observableArray();
    self.init = function (data) {
        var currentMovie = new CurrentMovieViewModel();
        currentMovie.init(data[0].id, data[0].title, data[0].pictureUrl, data[0].rating, data[0].tags)
        self.FetchedMovie(currentMovie);
    }
}

