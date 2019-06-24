var HomeViewModel = function () {
    var self = this;


    self.Categories = ko.observableArray();

    self.init = function (categories) {
        var categoriesList = [];
        for (var i = 0; i < categories.data.length; i++)
        {
            console.log(categories.data[0])
            var categoryVM = new CategoryViewModel();
            var currentCategory = categories[i];
            categoryVM.init(currentCategory.Id, currentCategory.Name,
                            currentCategory.SavedAt, currentCategory.SavedBy);
            categoriesList.push(categoryVM);
        }
        self.Categories(categoriesList);
    }
}

ko.applyBindings(HomeViewModel, document.getElementById("minified-table"))