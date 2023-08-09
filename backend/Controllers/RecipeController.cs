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
        [FromServices] IRepository<Recipe> recipeRepo,
        [FromServices] IImageService imageService
    )
    {

        var files = Request.Form.Files;
        var img = await imageService.GetImageBytes(files[0]);

        Recipe recipe = new()
        {
            Name = recipeDTO.Name,
            Author = recipeDTO.Author,
            Ingredients = recipeDTO.Ingredients,
            Steps = recipeDTO.Steps,
            Photo = img
        };

        await recipeRepo.Add(recipe);
        return Ok();
    }

    [HttpGet("getAll")]
    public async Task<ActionResult> GetAll(
        [FromServices] RecipeService recipeService)
    {
        var query = await recipeService.GetAll();
        return Ok(query);
    }

    [HttpDelete("delete")]
    public async Task<ActionResult> Delete(
        [FromBody] RecipeDTO recipeDTO,
        [FromServices] IRepository<Recipe> recipeRepo)
    {
        Recipe recipe = new Recipe();

        recipe.Name = recipeDTO.Name;
        recipe.Author = recipeDTO.Author;
        //recipe.Ingredients = recipeDTO.Ingredients;
        //recipe.Steps = recipeDTO.Steps;

        await recipeRepo.Delete(recipe);
        return Ok();
    }

    [HttpPost("update")]
    public async Task<ActionResult> Update(
        [FromBody] RecipeDTO recipeDTO,
        [FromServices] IRepository<Recipe> recipeRepo)
    {
        Recipe recipe = new Recipe();

        recipe.Name = recipeDTO.Name;
        recipe.Author = recipeDTO.Author;
        //recipe.Ingredients = recipeDTO.Ingredients;
        //recipe.Steps = recipeDTO.Steps;

        await recipeRepo.Update(recipe);
        return Ok();
    }

}