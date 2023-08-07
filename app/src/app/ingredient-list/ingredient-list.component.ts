import { Component } from '@angular/core';

@Component({
	selector: 'app-ingredient-list',
	templateUrl: './ingredient-list.component.html',
	styleUrls: ['./ingredient-list.component.css']
})
class IngredientListComponent {

	ingredients: Ingredient[] = []

	inputBind : string = ""

	addIngredient(): void {
		if(this.inputBind.length < 3) return
		
		this.ingredients.push(
			{
				id: this.ingredients.length,
				description: this.inputBind
			})



		this.inputBind = ""
		console.log(this.ingredients)
	}


	removeIngredient(index : number)
	{
		this.ingredients = this.ingredients.filter(i => i.id != index)
	}
}

interface Ingredient
{
	id : number;
	description: string;
}


export { IngredientListComponent, Ingredient }