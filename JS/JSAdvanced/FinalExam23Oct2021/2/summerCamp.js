class SummerCamp {
    constructor(organizer, location) {
        this.organizer = organizer;
        this.location = location;
        this.priceForTheCamp = { 'child': 150, 'student': 300, 'collegian': 500 };
        this.listOfParticipants = [];
    };

    registerParticipant(name, condition, money) {
        if (!this.priceForTheCamp[condition]) {
            throw new Error('Unsuccessful registration at the camp.');
        }

        if (this.listOfParticipants.find(p => p.name == name) != undefined) {
            return `The ${name} is already registered at the camp.`;
        }

        const priceOfConditionType = Number(this.priceForTheCamp[condition]);
        if (priceOfConditionType > money) {
            return 'The money is not enough to pay the stay at the camp.';
        }

        const participantToAdd = {
            name,
            condition,
            power: 100,
            wins: 0
        };

        this.listOfParticipants.push(participantToAdd);
        return `The ${name} was successfully registered.`;
    };

    unregisterParticipant(name) {
        if (this.listOfParticipants.find(p => p.name == name) == undefined) {
            throw new Error(`The ${name} is not registered in the camp.`);
        }

        console.log(this.listOfParticipants);
        this.listOfParticipants = this.listOfParticipants.filter(p => p.name != name);
        console.log(this.listOfParticipants);
        return `The ${name} removed successfully.`;
    };

    timeToPlay(typeOfGame, participant1, participant2) {
        if (typeOfGame == 'WaterBalloonFights') {

            const player1 = this.listOfParticipants.find(p => p.name == participant1);
            const player2 = this.listOfParticipants.find(p => p.name == participant2);

            if (player1 == undefined ||
                player2 == undefined) {
                throw new Error(`Invalid entered name/s.`);
            }

            if (player1.condition != player2.condition) {
                throw new Error(`Choose players with equal condition.`);
            }

            let name = '';

            if (player1.power == player2.power) {
                return `There is no winner.`;
            } else if (player1.power < player2.power) {
                name = player2.name;
                player2.wins += 1;
            } else {
                name = player1.name;
                player1.wins += 1;
            }

            return `The ${name} is winner in the game ${typeOfGame}.`

        } else if (typeOfGame == 'Battleship') {
            if (!this.listOfParticipants.find(p => p.name == participant1)) {
                throw new Error(`Invalid entered name/s.`);
            }

            const player1 = this.listOfParticipants.find(p => p.name == participant1);
            player1.power += 20;
            
            return `The ${player1.name} successfully completed the game ${typeOfGame}.`
        }
    };

    toString() {
        const numberOfParticipants = this.listOfParticipants.length;

        let result = [];
        result.push(`${this.organizer} will take ${numberOfParticipants} participants on camping to ${this.location}`);

        this.listOfParticipants
            .sort((a, b) => b.wins - a.wins)
            .forEach(player => result.push(`${player.name} - ${player.condition} - ${player.power} - ${player.wins}`));
        
        

        // for (const player of this.listOfParticipants) {
        //     result.push(`${player.name} - ${player.condition} - ${player.power} - ${player.wins}`);
        // }

        return result.join('\n');
    };
}

const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
console.log(summerCamp.timeToPlay("Battleship", "Petar Petarson"));
console.log(summerCamp.registerParticipant("Sara Dickinson", "child", 200));
//console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Sara Dickinson"));
console.log(summerCamp.registerParticipant("Dimitur Kostov", "student", 300));
console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Dimitur Kostov"));

console.log(summerCamp.toString());


