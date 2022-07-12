namespace Victory.Services.API.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class FoodsController : ControllerBase
{
    private readonly IFoodRepositoryService _repository;

    public FoodsController(IFoodRepositoryService repository) => _repository = repository;

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
    /// <response code="404">If the foods was not found.</response>
    [AllowAnonymous]
    [Tags(tags: "Foods")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FoodEntity>>> GetList() =>
        await _repository.GetFoodListAsync() is IEnumerable<FoodEntity> foods
        ? Ok(value: foods)
        : NotFound();

    /// <summary>
    /// Get all foods by Type.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Foods/Type=Breakfast
    ///
    /// </remarks>
    /// <returns>Foods list.</returns>
    /// <response code="200">Foods list.</response>
    /// <response code="404">If the foods was not found.</response>
    [AllowAnonymous]
    [Tags(tags: "Foods")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet("Type={type}")]
    public async Task<ActionResult<IEnumerable<FoodEntity>>> GetList(string type) =>
        await _repository.GetFoodListByTypeAsync(type) is IEnumerable<FoodEntity> foods
        ? Ok(value: foods)
        : NotFound();

    /// <summary>
    /// Get food by Id.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Foods/Id=1
    ///
    /// </remarks>
    /// <param name="id">Id.</param>
    /// <returns>Food.</returns>
    /// <response code="200">Food.</response>
    /// <response code="404">If the food was not found.</response>
    [Authorize]
    [Tags(tags: "Foods")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "Id={id}")]
    public async Task<ActionResult<FoodEntity>> Get(int id) =>
        await _repository.GetFoodAsync(id) is FoodEntity food
        ? Ok(value: food)
        : NotFound();

    /// <summary>
    /// Create food.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     POST /Foods
    ///     {
    ///         "id": 0, (auto)
    ///         "createdDate": "2022-06-06T09:17:12.672Z",
    ///         "name": "Pelmeny",
    ///         "description": "Delicious dumplings",
    ///         "costInUSD": 10.99,
    ///         "imagePath": "path",
    ///         "foodTypeId": 1
    ///     }
    ///
    /// </remarks>
    /// <returns>Food.</returns>
    /// <response code="201">Food.</response>
    /// <response code="400">If an error has occurred.</response>
    [Authorize]
    [Tags(tags: "Foods")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<FoodEntity>> Create([FromBody] FoodEntity food)
    {
        if (food is not null) await _repository.CreateAsync(entity: food);

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
    ///         "createdDate": "2022-06-06T09:17:12.672Z",
    ///         "name": "Pelmeny",
    ///         "description": "Delicious dumplings",
    ///         "costInUSD": 10.99,
    ///         "imagePath": "path",
    ///         "foodTypeId": 1
    ///     }
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully modified.</response>
    /// <response code="400">If an error has occurred.</response>
    [Authorize]
    [Tags(tags: "Foods")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] FoodEntity food)
    {
        if (food is not null) await _repository.UpdateAsync(entity: food);

        return NoContent();
    }

    /// <summary>
    /// Delete food.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     DELETE /Foods/Id=1
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully deleted.</response>
    /// <response code="400">If an error has occurred.</response>
    [Authorize]
    [Tags(tags: "Foods")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpDelete(template: "Id={id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);

        return NoContent();
    }
}