var CategoriesViewModel = function () {
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

var CategoriesListViewModel = function () {
    var self = this;
    self.CategoriesViewModel = ko.observableArray();

    self.init = function (categories) {
        var categoriesList = [];
        console.log(categories);
        for (var i = 0; i < minifiedMovies.data.length; i++) {
            var minifiedVm = new MinifiedMovieViewModel();
            var currentMinifiedMovie = minifiedMovies.data[i];
            minifiedVm.init(currentMinifiedMovie.id, currentMinifiedMovie.movieList[0].title, currentMinifiedMovie.movieList[0].pictureUrl, currentMinifiedMovie.movieList[0].rating, currentMinifiedMovie.movieList[0].mainCategory);
            minifiedMovieList.push(minifiedVm);
        }
        self.MinifiedMovies(minifiedMovieList);
    }
}

