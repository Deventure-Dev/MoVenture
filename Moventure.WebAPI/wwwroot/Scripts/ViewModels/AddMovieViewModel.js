var CurrentMovieViewModel = function () {
    var self = this;
    self.movieTitle = ko.observable();
    self.selectedCategory = ko.observable();
    self.moviePictureUrl = ko.observable();
    self.movieTrailerUrl = ko.observable();
    self.movieDescription = ko.observable();
    self.movieRating = ko.observable();
    self.categories = ko.observableArray();

    self.init = function (title, pictureUrl, trailerUrl, description, rating, category, categoriesRecieved) {
        self.movieTitle(title);
        self.selectedCategory(category);
        self.moviePictureUrl(pictureUrl);
        self.movieTrailerUrl(trailerUrl);
        self.movieDescription(description);
        self.movieRating(rating);
        self.categories(categoriesRecieved);
    }
}


var AddMovieViewModel = function () {
    var self = this;
    self.MovieToAdd = ko.observable();
    self.movieTitle = ko.observable("");
    self.selectedCategory = ko.observable("");
    self.moviePictureUrl = ko.observable("");
    self.movieTrailerUrl = ko.observable("");
    self.movieDescription = ko.observable("");
    self.movieRating = ko.observable("");
    self.categories = ko.observableArray(["Please select category"]);
   
    self.addMovieFunction = function () {
        var movieData = {
            Title: self.MovieToAdd().movieTitle(),
            PictureUrl: self.MovieToAdd().moviePictureUrl(),
            TrailerUrl: self.MovieToAdd().movieTrailerUrl(),
            Description: self.MovieToAdd().movieDescription(),
            Rating: self.MovieToAdd().movieRating(),
            CategoryName: self.MovieToAdd().selectedCategory(),
        }

        $.ajax({
            url: "/movie/Create",
            type: "POST",
            data: JSON.stringify(movieData),
            dataType: "json",
            beforeSend: function (xhr) { xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('token')); },
            contentType: "application/json; charset=utf-8",
            success: function (returnedData) {
                alert("Successfully added!!");
            },
            error: function () {
                alert("Failed to add");
            }
        });
    }

    self.init = function () {

    $.ajax({
        url: "/category/GetAll",
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            for (var i = 0; i < data.count; i++) {
                self.categories.push(data.categories[i].name);
            }
        }

    });

        var currentMovie = new CurrentMovieViewModel();
        currentMovie.init(self.movieTitle(), self.moviePictureUrl(), self.movieTrailerUrl(), self.movieDescription(), self.movieRating(), self.selectedCategory(), self.categories());
        self.MovieToAdd(currentMovie);
        ko.applyBindings(self.MovieToAdd);
    }
}

