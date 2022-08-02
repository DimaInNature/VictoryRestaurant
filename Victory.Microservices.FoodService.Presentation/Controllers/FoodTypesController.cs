namespace Victory.Microservices.FoodService.Presentation.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class FoodTypesController : ControllerBase
{
    private readonly IFoodTypeAppService _foodTypeService;

    public FoodTypesController(IFoodTypeAppService foodTypeService) =>
        _foodTypeService = foodTypeService;

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
    /// <response code="200">Food types list.</response>
    [Tags(tags: "FoodType")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FoodTypeEntity>>> GetList()
    {
        var result = await _foodTypeService.GetAllAsync();

        return result.Any() is false ? NotFound() : Ok(value: result);
    }

    /// <summary>
    /// Get food type by Id.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /FoodTypes/1
    ///
    /// </remarks>
    /// <param name="id">Id.</param>
    /// <returns>Food type.</returns>
    /// <response code="200">Food type.</response>
    /// <response code="404">If the food type was not found.</response>
    [Tags(tags: "FoodType")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "{id}")]
    public async Task<ActionResult<FoodTypeEntity>> Get(int id)
    {
        var result = await _foodTypeService.GetAsync(id);

        return result is not null ? Ok(value: result) : NotFound();
    }

    /// <summary>
    /// Create food type.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     POST /FoodTypes
    ///     {
    ///         "id": 0,
    ///         "name": "Dinner"
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Created.</response>
    [Tags(tags: "FoodType")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<FoodTypeEntity>> Create(
        [FromBody] FoodTypeEntity foodType)
    {
        if (foodType is not null)
            await _foodTypeService.CreateAsync(entity: foodType);

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
    ///         "name": "Dinner"
    ///     }
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully modified.</response>
    [Tags(tags: "FoodType")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult> Update(
        [FromBody] FoodTypeEntity foodType)
    {
        if (foodType is not null)
            await _foodTypeService.UpdateAsync(entity: foodType);

        return NoContent();
    }

    /// <summary>
    /// Delete food types.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     DELETE /FoodTypes/1
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully deleted.</response>
    [Tags(tags: "FoodType")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpDelete(template: "{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _foodTypeService.DeleteAsync(id);

        return NoContent();
    }
}