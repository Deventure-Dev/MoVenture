var CategoriesViewModel = function () {
    debugger
    var self = this;
    self.CategoriesListViewModel = ko.observableArray();

    self.init = function (categories) {
        var categoriesList = [];
        debugger
        console.log(categories);
        for (var i = 0; i < categories.data.length; i++) {
            var curentCategory = new CategoryViewModel();
            curentCategory.init(categories.data[i].id, categories.data[i].title, categories.data[i].movieList);
            categoriesList.push(curentCategory);
        }

        self.CategoriesListViewModel(categoriesList);
    }
}
