import { Component } from "@angular/core";

interface IGame {
    title: string,
    price?: number,
    image: string
}

@Component({
    selector: 'softuni-game',
    templateUrl: './game.component.html',
    styleUrls: ['./game.component.css']
})

export class Gamecomponent {
    games: IGame[] = [
        { title: 'Crusader Kings 3', price: 49.99, image: 'https://i.ytimg.com/vi/rfdmC3r7aLo/maxresdefault.jpg' },
        { title: 'Rome II: Total War', price: 29.99, image: '' },
        { title: 'Fifa 21', image: '' },
        { title: 'Europa Universalis IV', price: 19.99, image: 'https://cdn1.epicgames.com/salesEvent/salesEvent/EGS_EuropaUniversalisIV_ParadoxDevelopmentStudioParadoxTinto_S3_2560x1440-aa3002ec221d43dcd7e49f5458e74766' }
    ]
}