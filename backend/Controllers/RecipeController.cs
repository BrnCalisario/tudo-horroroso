using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TudoHorroroso.DTO;
using TudoHorroroso.Model;
using TudoHorroroso.Repositories;
using TudoHorroroso.Services;

namespace TudoHorroroso.Controllers;


[ApiController]
[EnableCors("MainPolicy")]
[Route("recipe")]
public class RecipeController : ControllerBase
{
    [HttpPost("create")]
    public async Task<ActionResult> Create(
        [FromBody] RecipeDTO recipeDTO,
        [FromServices] RecipeRepository recipeRepo,
        [FromServices] RecipeService recipeService)
    {
        Recipe recipe = new Recipe();

        recipe.Id = recipeService.GenerateHexId();
        recipe.Name = recipeDTO.Name;
        recipe.Author = recipeDTO.Author;
        recipe.Ingredients = recipeDTO.Ingredients;
        recipe.Steps = recipeDTO.Steps;

        await recipeRepo.Add(recipe);
        return Ok();
    }

    [HttpDelete("delete")]
    public async Task<ActionResult> Delete(
        [FromBody] RecipeDTO recipeDTO,
        [FromServices] RecipeRepository recipeRepo)
    {
        Recipe recipe = new Recipe();

        recipe.Name = recipeDTO.Name;
        recipe.Author = recipeDTO.Author;
        recipe.Ingredients = recipeDTO.Ingredients;
        recipe.Steps = recipeDTO.Steps;

        await recipeRepo.Delete(recipe);
        return Ok();
    }

    [HttpPost("update")]
    public async Task<ActionResult> Update(
        [FromBody] RecipeDTO recipeDTO,
        [FromServices] RecipeRepository recipeRepo)
    {
        Recipe recipe = new Recipe();

        recipe.Name = recipeDTO.Name;
        recipe.Author = recipeDTO.Author;
        recipe.Ingredients = recipeDTO.Ingredients;
        recipe.Steps = recipeDTO.Steps;

        await recipeRepo.Update(recipe);
        return Ok();
    }

}