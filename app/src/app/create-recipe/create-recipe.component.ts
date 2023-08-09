import { Ingredient, Recipe } from '../DTO/recipe';
import { RecipeService } from '../Services/recipe.service';
import { Component, EventEmitter, OnInit, Output, Input } from '@angular/core';


@Component({
	selector: 'app-create-recipe',
	templateUrl: './create-recipe.component.html',
	styleUrls: ['./create-recipe.component.css']
})
export class CreateRecipeComponent {

	@Output() public onUploadFinished = new EventEmitter<any>();

    @Input() public value: FormData | undefined = new FormData();
    @Input() public title: string = '';
    @Input() public imgUrl: string = '';

    ngOnInit(): void {}

    uploadFile = (files: any) => {
        if (files.length == 0) {
            return;
        }

        let fileToUpload = <File>files[0];

        this.value = new FormData();
        this.value.append('file', fileToUpload, fileToUpload.name);
        this.imgUrl = URL.createObjectURL(fileToUpload);

        this.onUploadFinished.emit(this.value);
    };

    getImgSrc() {
        if (this.imgUrl !== '') return this.imgUrl;

        return '../assets/comida.jpg';
    }

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
