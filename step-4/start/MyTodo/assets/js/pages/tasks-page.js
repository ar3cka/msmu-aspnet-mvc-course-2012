/// <reference path="../libs/knockout-2.2.0.js" />
/// <reference path="../libs/jquery-1.8.2.intellisense.js" />

(function ($, ko) {

    function Task() {
        var self = this;
        self.id = ko.observable(null);
        self.title = ko.observable("");
        self.description = ko.observable("");
        self.completed = ko.observable(false);

        self.create = function () {
            var data = {
                Title: self.title(),
                Description: self.description()
            };
            $.post("api/task", data, function (result) {
                self.id(result);
            });
        };
        
        self.update = function () {
        };
        
        self.delete = function () {
        };

        Task.loadAll = function (taskLoadedCallback) {
            $.getJSON("api/task", function (data) {
                var tasks = [];
                $.each(data, function (index, item) {
                    var task = new Task;
                    task.id(item.TaskId);
                    task.title(item.Title);
                    task.description(item.Description);
                    tasks.push(task);
                });
                taskLoadedCallback(tasks);
            });
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
            Task.loadAll(function (tasks) {
                self.tasks(tasks);
            });
        };
    }

    var tasksPage = new TasksPage;
    ko.applyBindings(tasksPage);

    $(function () {
        tasksPage.refreshTaskList();
    });
    
}(window.jQuery, window.ko));