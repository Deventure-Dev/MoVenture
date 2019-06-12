// app.js
(function ($) {
    var app = Sammy("body");
    app.use(Sammy.Template, "html");

    $(document).ready(function () {
        app.run("#/");
    });
})(jQuery);

// controller.home
(function () {
    var app = Sammy.apps.body;
   
    app.get("#/", homeController);
    app.get("#/home", homeController);

    function homeController(context) {
        context.render($("#home_html"), {}, homeView);
    };

    function homeView(view) {
        $("#view").html(view);
      
    };
})();


// controller.home
(function () {
    var app = Sammy.apps.body;
    app.get("#/details/", homeController);

    function homeController(context) {
        context.render($("#details"), {}, homeView);
    };

    function homeView(view) {
        $("#details").html(view);
      
    };
})();



(function () {
})(window);
