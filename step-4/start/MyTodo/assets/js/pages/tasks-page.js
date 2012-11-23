/// <reference path="../libs/knockout-2.2.0.js" />

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
            var t1 = new Task;
            t1.title("1");
            t1.description("1");
            
            var t2 = new Task;
            t2.title("2");
            t2.description("2");

            return [t1, t2];
        };
    }

    function TasksPage() {
        var self = this;
        self.selectedTask = ko.observable(new Task);
        self.tasks = ko.observableArray([]);

        self.createTask = function () {
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