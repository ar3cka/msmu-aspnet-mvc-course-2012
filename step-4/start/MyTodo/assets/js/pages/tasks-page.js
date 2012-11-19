(function($, ko) {

    function TasksPageView() {

        var $createTaskWindow = $("#createTaskWindow");

        $(".modal-form").on("submit", function() {
        });

        this.createTask = function() {
            alert("Create Task action.");
            $createTaskWindow.modal("hide");
        };
    }

    var pageView = new TasksPageView;
    ko.applyBindings(pageView);
}(window.jQuery, window.ko));   