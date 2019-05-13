var HomeViewModel = function () {
    var self = this;


    self.Categories = ko.observableArray();

    self.init = function (categories) {
        var categoriesList = [];
        for (var i = 0; i < categories.length; i++)
        {
            var categoryVM = new CategoryViewModel();
            var currentCategory = categories[i];
            categoryVM.init(currentCategory.Id, currentCategory.Name,
                            currentCategory.SavedAt, currentCategory.SavedBy);
            categoriesList.push(categoryVM);
        }
        self.Categories(categoriesList);
    }
}