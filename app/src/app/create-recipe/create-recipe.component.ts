import { Component } from '@angular/core';
import { Ingredient, Recipe } from '../DTO/recipe';
import { RecipeService } from '../Services/recipe.service';

@Component({
	selector: 'app-create-recipe',
	templateUrl: './create-recipe.component.html',
	styleUrls: ['./create-recipe.component.css']
})
export class CreateRecipeComponent {

	constructor(private recipeService : RecipeService) { }

	recipe: Recipe =
		{
			name: '',
			author: '',
			ingredients: [],
			steps: []
		}

	sendRecipe(): void {
		if (this.recipe.ingredients.length < 1)
			return;

		if (this.recipe.steps.length < 1)
			return;


		console.log(this.recipe)

		this.recipeService.add(this.recipe)
			.subscribe(res => {
				console.log(res);
			})
	}
}
