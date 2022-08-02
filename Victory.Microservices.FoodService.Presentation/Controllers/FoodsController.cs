namespace Victory.Microservices.FoodService.Presentation.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class FoodsController : ControllerBase
{
    private readonly IFoodAppService _foodService;

    public FoodsController(IFoodAppService foodService) =>
        _foodService = foodService;

    /// <summary>
    /// Get all foods.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Foods
    ///
    /// </remarks>
    /// <returns>Return all foods.</returns>
    /// <response code="200">Foods list.</response>
    [Tags(tags: "Food")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FoodEntity>>> GetList()
    {
        var result = await _foodService.GetAllAsync();

        return result.Any() is false ? NotFound() : Ok(value: result);
    }

    /// <summary>
    /// Get all foods by food type.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Foods/Type=Breakfast
    ///
    /// </remarks>
    /// <returns>Return all foods.</returns>
    /// <response code="200">Foods list.</response>
    [Tags(tags: "Food")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet("Type={type}")]
    public async Task<ActionResult<IEnumerable<FoodEntity>>> GetList(string type)
    {
        if(string.IsNullOrWhiteSpace(type)) return new List<FoodEntity>();

        var result = await _foodService.GetAllAsync(entity => entity.FoodType?.Name == type);

        return result.Any() is false ? NotFound() : Ok(value: result);
    }

    /// <summary>
    /// Get food by Id.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Foods/1
    ///
    /// </remarks>
    /// <param name="id">Id.</param>
    /// <returns>Food.</returns>
    /// <response code="200">Food.</response>
    /// <response code="404">If the food was not found.</response>
    [Tags(tags: "Food")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "{id}")]
    public async Task<ActionResult<FoodEntity>> Get(int id)
    {
        var result = await _foodService.GetAsync(id);

        return result is not null ? Ok(value: result) : NotFound();
    }

    /// <summary>
    /// Create food.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     POST /Foods
    ///     {
    ///         "id": 0,
    ///         "createdDate": Date,
    ///         "name": "FoodName",
    ///         "description": "FoodDescription",
    ///         "costInUSD": 125.5,
    ///         "imagePath": Local Path | Url,
    ///         "foodTypeId: 1
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Created.</response>
    [Tags(tags: "Food")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<FoodEntity>> Create(
        [FromBody] FoodEntity food)
    {
        if (food is not null)
            await _foodService.CreateAsync(entity: food);

        return Ok();
    }

    /// <summary>
    /// Update food.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     PUT /Foods
    ///     {
    ///         "id": 1,
    ///         "createdDate": Date,
    ///         "name": "FoodName",
    ///         "description": "FoodDescription",
    ///         "costInUSD": 125.5,
    ///         "imagePath": Local Path | Url,
    ///         "foodTypeId: 1
    ///     }
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully modified.</response>
    [Tags(tags: "Food")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult> Update(
        [FromBody] FoodEntity food)
    {
        if (food is not null)
            await _foodService.UpdateAsync(entity: food);

        return NoContent();
    }

    /// <summary>
    /// Delete food.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     DELETE /Foods/1
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully deleted.</response>
    [Tags(tags: "Food")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpDelete(template: "{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _foodService.DeleteAsync(id);

        return NoContent();
    }
}