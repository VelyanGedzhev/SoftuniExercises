"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
exports.__esModule = true;
exports.Manager = exports.Senior = exports.Junior = exports.Employee = void 0;
var Employee = /** @class */ (function () {
    function Employee(name, age) {
        this.name = name;
        this.age = age;
        this.salary = 0;
        this.tasks = [];
        this.currentTaskIndex = 0;
    }
    Employee.prototype.work = function () {
        console.log(this.tasks[this.currentTaskIndex]);
        this.currentTaskIndex = (this.currentTaskIndex + 1) % this.tasks.length;
    };
    Employee.prototype.collectSalary = function () {
        console.log("".concat(this.name, " recieved ").concat(this.getSalary(), " this month."));
    };
    Employee.prototype.getSalary = function () {
        return this.salary;
    };
    return Employee;
}());
exports.Employee = Employee;
var Junior = /** @class */ (function (_super) {
    __extends(Junior, _super);
    function Junior() {
        var _this = _super !== null && _super.apply(this, arguments) || this;
        _this.tasks = ["".concat(_this.name, " is working on a simple task.")];
        return _this;
    }
    return Junior;
}(Employee));
exports.Junior = Junior;
var Senior = /** @class */ (function (_super) {
    __extends(Senior, _super);
    function Senior() {
        var _this = _super !== null && _super.apply(this, arguments) || this;
        _this.tasks = [
            "".concat(_this.name, " is working on a complicated task."),
            "".concat(_this.name, " is taking time off work."),
            "".concat(_this.name, " is supervising junior workers.")
        ];
        return _this;
    }
    return Senior;
}(Employee));
exports.Senior = Senior;
var Manager = /** @class */ (function (_super) {
    __extends(Manager, _super);
    function Manager() {
        var _this = _super !== null && _super.apply(this, arguments) || this;
        _this.tasks = [
            "".concat(_this.name, " scheduled a meeting."),
            "".concat(_this.name, " is preparing quarterly report.")
        ];
        _this.dividend = 0;
        return _this;
    }
    Manager.prototype.getSalary = function () {
        return this.salary + this.dividend;
    };
    return Manager;
}(Employee));
exports.Manager = Manager;
