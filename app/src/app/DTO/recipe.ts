interface Ingredient {
    id: number;
    name: string;
}

interface Step {
    id: number;
    description: string
}

interface Recipe {
    name: string;
    author: string;
    ingredients: Ingredient[];
    steps: Step[];
}

export { Ingredient, Step, Recipe}