export abstract class Employee {
    salary: number = 0;
    tasks: string[] = [];
    private currentTaskIndex: number = 0;

    constructor(public name: string, public age: number) {

    }

    work(): void {
        console.log(this.tasks[this.currentTaskIndex]);
        this.currentTaskIndex = (this.currentTaskIndex + 1) % this.tasks.length;
    }

    collectSalary(): void {
        console.log(`${this.name} recieved ${this.getSalary()} this month.`);
    }

    protected getSalary(): number {
        return this.salary;
    }
}

export class Junior extends Employee {
    tasks: string[] = [`${this.name} is working on a simple task.`]
}

export class Senior extends Employee {
    tasks: string[] = [
        `${this.name} is working on a complicated task.`,
        `${this.name} is taking time off work.`,
        `${this.name} is supervising junior workers.`
    ];
    
}

export class Manager extends Employee {
    tasks: string[] = [
        `${this.name} scheduled a meeting.`,
        `${this.name} is preparing quarterly report.`
    ];
    dividend: number = 0;

    protected getSalary(): number {
        return this.salary + this.dividend;
    }
}