var CategoryViewModel = function () {
    var self = this;
    self.Id = ko.observable();
    self.Name = ko.observable();
    self.SavedAt = ko.observable();
    self.SavedBy = ko.observable();

    self.init = function (id, name, savedAt, savedBy) {
        self.Id(id);
        self.Id(name);
        self.Id(savedAt);
        self.Id(savedBy);
    }
}

//var CategoriesViewModel // cum facem? Categoria nu are o lista de movie.
//deci facem lista de movie in continuare