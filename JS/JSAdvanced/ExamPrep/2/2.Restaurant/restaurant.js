class Restaurant {
    constructor(budget) {
        this.budgetMoney = Number(budget);
        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }

    loadProducts(products) {
        products.forEach(el => {
            let [productName, productQuantity, price] = el.split(' ');

            productQuantity = Number(productQuantity);
            price = Number(price);

            if (price <= this.budgetMoney) {

                if (!this.stockProducts[productName]) {
                    this.stockProducts[productName] = productQuantity;
                } else {
                    this.stockProducts[productName] += productQuantity;
                }
                
                this.budgetMoney -= price;
                this.history.push(`Successfully loaded ${productQuantity} ${productName}`);
            } else {
                this.history.push(`There was not enough money to load ${productQuantity} ${productName}`);
            }
        });

        return this.history.join('\n');
    };

    addToMenu(meal, neededProducts, price) {

        if (this.menu[meal]) {
            return `The ${meal} is already in the our menu, try something different.`;
        } else {
            this.menu[meal] = {
                products: [],
                price: price
            };

            this.menu[meal].products.forEach(el => {
                let [productName, productQuantity] = neededProducts.split(' ');
                productQuantity = Number(productQuantity);

                this.menu[meal].products[productName] = productQuantity;
            });

            let numberOfMeals = Number(Object.keys(this.menu).length);
            if (numberOfMeals == 1) {
                return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`;
            }

            return `Great idea! Now with the ${meal} we have ${numberOfMeals} meals in the menu, other ideas?`;
        } 
    };

    showTheMenu() {
        let mealsInMenu = Object.keys(this.menu);

        if (mealsInMenu.length == 0) {
            return "Our menu is not ready yet, please come later...";
        }

        let result = [];

        for (const meal of mealsInMenu) {
            const currentMealPrice = this.menu[meal].price;
            result.push(`${meal} - $ ${currentMealPrice}`);
        }

        return result.join('\n');
    };

    makeTheOrder(meal) {

        if (!this.menu[meal]) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        }

        const neededProducts = {};

        for (const product in this.menu[meal].products) {
            if (!this.stockProducts[product] || this.stockProducts[product] < this.menu[meal].products[product]) {
                return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
            }

            neededProducts[product] = this.menu[meal].products[product];
        }

        for (const neededProduct in neededProducts) {
            this.stockProducts[neededProducts] -= neededProducts[neededProduct];
        }
        
        const mealPrice = this.menu[meal].price;
        this.budgetMoney += mealPrice;

        return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${mealPrice}.`;
    };
}

let kitchen = new Restaurant(1000);
console.log(kitchen.loadProducts(['Banana 10 5', 'Banana 20 10', 'Strawberries 50 30', 'Yogurt 10 10', 'Yogurt 500 1500', 'Honey 5 50']));

/*
Output 1 should be like:
Successfully loaded 10 Banana
Successfully loaded 20 Banana
Successfully loaded 50 Strawberries
Successfully loaded 10 Yogurt
There was not enough money to load 500 Yogurt
Successfully loaded 5 Honey
*/

console.log(kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99));
console.log(kitchen.addToMenu('Pizza', ['Flour 0.5', 'Oil 0.2', 'Yeast 0.5', 'Salt 0.1', 'Sugar 0.1', 'Tomato sauce 0.5', 'Pepperoni 1', 'Cheese 1.5'], 15.55));

/*
Output 2 should be like: 
Great idea! Now with the frozenYogurt we have 1 meal in the menu, other ideas?
Great idea! Now with the Pizza we have 2 meals in the menu, other ideas?
*/

console.log(kitchen.showTheMenu());

/*
Output 3 should be like: 
frozenYogurt - $ 9.99
Pizza - $ 15.55
*/

kitchen.loadProducts(['Yogurt 30 3', 'Honey 50 4', 'Strawberries 20 10', 'Banana 5 1']);
kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99);
console.log(kitchen.makeTheOrder('frozenYogurt'));

/*
Output 4 should be like: 
Your order (frozenYogurt) will be completed in the next 30 minutes and will cost you 9.99.
*/