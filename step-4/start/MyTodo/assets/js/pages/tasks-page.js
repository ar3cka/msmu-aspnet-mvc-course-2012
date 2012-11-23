/// <reference path="../libs/knockout-2.2.0.js" />
/// <reference path="../libs/jquery-1.8.2.intellisense.js" />

(function ($, ko) {

    function Task() {
        var self = this;
        self.title = ko.observable("");
        self.description = ko.observable("");
        self.completed = ko.observable(false);

        self.create = function () {
        };
        
        self.update = function () {
        };
        
        self.delete = function () {
        };

        Task.loadAll = function () {
            var tasks = [];
            $.getJSON("api/task", function (data) {
                $.each(data, function (index, item) {
                    var task = new Task;
                    task.title(item.title);
                    task.description(item.description);
                    tasks.push(task);
                });
            });

            return tasks;
        };
    }

    function TasksPage() {
        var self = this;
        self.selectedTask = ko.observable(new Task);
        self.tasks = ko.observableArray([]);

        self.createTask = function (data, event) {
            var task = ko.utils.unwrapObservable(self.selectedTask());
            task.create();
            self.tasks.push(task);
            self.selectedTask(new Task);
        };

        self.refreshTaskList = function () {
            self.tasks(Task.loadAll());
        };
    }

    var tasksPage = new TasksPage;
    ko.applyBindings(tasksPage);

    $(function () {
        tasksPage.refreshTaskList();
    });
    
}(window.jQuery, window.ko));