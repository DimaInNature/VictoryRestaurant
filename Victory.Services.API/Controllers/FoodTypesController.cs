namespace Victory.Services.API.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class FoodTypesController : ControllerBase
{
    private readonly IFoodTypeFacadeService _repository;

    public FoodTypesController(IFoodTypeFacadeService repository) => _repository = repository;

    /// <summary>
    /// Get all food types.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /FoodTypes
    ///
    /// </remarks>
    /// <returns>Return all food types.</returns>
    /// <response code="200">Food type list.</response>
    /// <response code="404">If the food types was not found.</response>
    [Tags(tags: "FoodTypes")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FoodTypeEntity>>> GetList() =>
        await _repository.GetFoodTypeListAsync() is IEnumerable<FoodTypeEntity> foodTypes
        ? Ok(value: foodTypes)
        : NotFound();

    /// <summary>
    /// Get food type by Name.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /FoodTypes/Name=Breakfast
    ///
    /// </remarks>
    /// <returns>Food type.</returns>
    /// <response code="200">Food type</response>
    /// <response code="404">If the food type was not found.</response>
    [Tags(tags: "FoodTypes")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet("Name={name}")]
    public async Task<ActionResult<IEnumerable<FoodTypeEntity>>> GetList(string name) =>
        await _repository.GetFoodTypeListAsync(name) is IEnumerable<FoodTypeEntity> foodTypes
        ? Ok(value: foodTypes)
        : NotFound();

    /// <summary>
    /// Get food type by Id.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /FoodTypes/Id=1
    ///
    /// </remarks>
    /// <param name="id">Id.</param>
    /// <returns>Food type.</returns>
    /// <response code="200">Food type.</response>
    /// <response code="404">If the food type was not found.</response>
    [Tags(tags: "FoodTypes")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "Id={Id}")]
    public async Task<ActionResult<FoodTypeEntity>> Get(int id) =>
        await _repository.GetFoodTypeAsync(id) is FoodTypeEntity foodType
        ? Ok(value: foodType)
        : NotFound();

    /// <summary>
    /// Create food type.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     POST /FoodTypes
    ///     {
    ///         "id": 0, (auto)
    ///         "name": "Breakfast"
    ///     }
    ///
    /// </remarks>
    /// <returns>Food type.</returns>
    /// <response code="201">Food type.</response>
    /// <response code="400">If an error has occurred.</response>
    [Tags(tags: "FoodTypes")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<FoodTypeEntity>> Create([FromBody] FoodTypeEntity foodType)
    {
        if (foodType is not null) await _repository.CreateAsync(entity: foodType);

        return Ok();
    }

    /// <summary>
    /// Update food type.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     PUT /FoodTypes
    ///     {
    ///         "id": 1,
    ///         "name": "Breakfast"
    ///     }
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully modified.</response>
    /// <response code="400">If an error has occurred.</response>
    [Tags(tags: "FoodTypes")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] FoodTypeEntity foodType)
    {
        if (foodType is not null) await _repository.UpdateAsync(entity: foodType);

        return NoContent();
    }

    /// <summary>
    /// Delete food type.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     DELETE /FoodTypes/Id=1
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully deleted.</response>
    /// <response code="400">If an error has occurred.</response>
    [Tags(tags: "FoodTypes")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpDelete(template: "Id={id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);

        return NoContent();
    }
}