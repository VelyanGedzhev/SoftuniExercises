import { Junior, Manager, Senior } from "./employee";

const junior = new Junior('John', 20);
junior.work(); //simple task
junior.work(); //simple task
junior.collectSalary(); //received 0 this month

junior.salary = 1200;
junior.collectSalary(); //received 1200 this month

const senior = new Senior('Owen', 24);
senior.work(); // complicated task
senior.work(); // time off
senior.work(); // supervising
senior.collectSalary(); //received 0 this month

senior.salary = 2400;
senior.collectSalary(); //received 2400 this month

const manager = new Manager("Glenn", 34);
manager.work(); // schedule a meeting
manager.work(); // preparing a report
manager.work(); // schedule a meeting
manager.collectSalary(); //received 0 this month

manager.dividend = 300;
manager.collectSalary(); //received 300 this month

manager.salary = 3000;
manager.collectSalary(); //received 3300 this month