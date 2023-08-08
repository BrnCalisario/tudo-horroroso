import { Component, Input, Output } from '@angular/core';
import { Ingredient } from '../DTO/recipe';

@Component({
	selector: 'app-ingredient-list',
	templateUrl: './ingredient-list.component.html',
	styleUrls: ['./ingredient-list.component.css']
})
class IngredientListComponent {


	@Input() public ingredients: Ingredient[] = []

	inputBind : string = ""

	addIngredient(): void {
		if(this.inputBind.length < 3) return
		
		this.ingredients.push(
			{
				id: this.ingredients.length,
				name: this.inputBind
			})

		this.inputBind = ""		
	}


	removeIngredient(index : number)
	{
		this.ingredients = this.ingredients.filter(i => i.id != index)
	}
}




export { IngredientListComponent }