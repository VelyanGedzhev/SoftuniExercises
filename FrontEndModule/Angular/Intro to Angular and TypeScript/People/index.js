"use strict";
exports.__esModule = true;
var employee_1 = require("./employee");
var junior = new employee_1.Junior('John', 20);
junior.work(); //simple task
junior.work(); //simple task
junior.collectSalary(); //received 0 this month
junior.salary = 1200;
junior.collectSalary(); //received 1200 this month
var senior = new employee_1.Senior('Owen', 24);
senior.work(); // complicated task
senior.work(); // time off
senior.work(); // supervising
senior.collectSalary(); //received 0 this month
senior.salary = 2400;
senior.collectSalary(); //received 2400 this month
var manager = new employee_1.Manager("Glenn", 34);
manager.work(); // schedule a meeting
manager.work(); // preparing a report
manager.work(); // schedule a meeting
manager.collectSalary(); //received 0 this month
manager.dividend = 300;
manager.collectSalary(); //received 300 this month
manager.salary = 3000;
manager.collectSalary(); //received 3300 this month
