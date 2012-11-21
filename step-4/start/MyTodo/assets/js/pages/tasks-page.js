(function($, ko) {

    function Task() {
        this.title = ko.ob("");
        this.description = ko.ob("");
        this.completed = ko.ob(false);
    }

    function TasksPageView() {
        this.selectedTask = new Task;
        this.createTask = function () {
            $.get("api/task/1", function () {
                alert("OK");
            });
            
            alert("Task title: " + this.selectedTask.title + ", description " + this.selectedTask.description);
        };
    }

    var pageView = new TasksPageView;
    ko.applyBindings(pageView);
}(window.jQuery, window.ko));   