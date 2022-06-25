namespace Victory.Services.API.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class FoodTypesController : ControllerBase
{
    private readonly IFoodTypeFacadeService _repository;

    public FoodTypesController(IFoodTypeFacadeService repository) => _repository = repository;

    /// <summary>
    /// Получение списка всех разновидностей блюд.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET /FoodTypes
    ///
    /// </remarks>
    /// <returns>Возвращает список всех разновидностей блюд.</returns>
    /// <response code="200">Возвращает список разновидностей блюд.</response>
    /// <response code="404">Если ничего не было найдено.</response>
    [Tags(tags: "FoodTypes")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FoodType>>> GetList() =>
        await _repository.GetFoodTypeListAsync() is IEnumerable<FoodType> foodTypes
        ? Ok(value: foodTypes)
        : NotFound();

    /// <summary>
    /// Получение списка всех разновидностей блюд по их наименованию.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET /FoodTypes/Name=Полдник
    ///
    /// </remarks>
    /// <returns>Возвращает список разновидностей блюд.</returns>
    /// <response code="200">Возвращает список разновидностей блюд.</response>
    /// <response code="404">Если ничего не было найдено.</response>
    [Tags(tags: "FoodTypes")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet("Name={name}")]
    public async Task<ActionResult<IEnumerable<FoodType>>> GetList(string name) =>
        await _repository.GetFoodTypeListAsync(name) is IEnumerable<FoodType> foodTypes
        ? Ok(value: foodTypes)
        : NotFound();

    /// <summary>
    /// Получение разновидности блюд по её идентификатору.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET /FoodTypes/1
    ///
    /// </remarks>
    /// <param name="id">Идентификатор разновидности блюд.</param>
    /// <returns>Возвращает разновидность блюд.</returns>
    /// <response code="200">Возвращает найденную разновидность блюд.</response>
    /// <response code="404">Если ничего не было найдено.</response>
    [Tags(tags: "FoodTypes")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "Id")]
    public async Task<ActionResult<FoodType>> Get(int id) =>
        await _repository.GetFoodTypeAsync(id) is FoodType foodType
        ? Ok(value: foodType)
        : NotFound();

    /// <summary>
    /// Создание разновидности блюд.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST /FoodTypes
    ///     {
    ///         "id": 0, (Автоинкремент)
    ///         "name": "Полдник"
    ///     }
    ///
    /// </remarks>
    /// <returns>Возвращает созданную разновидность блюд.</returns>
    /// <response code="201">Возвращает созданную разновидность блюд.</response>
    /// <response code="400">Если произошла ошибка.</response>
    [Tags(tags: "FoodTypes")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<FoodType>> Create([FromBody] FoodType foodType)
    {
        if (foodType is not null) await _repository.CreateAsync(entity: foodType);

        return Ok();
    }

    /// <summary>
    /// Изменение разновидности блюд.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     PUT /FoodTypes
    ///     {
    ///         "id": 1, (Id изменяемого объекта)
    ///         "name": "Полдник"
    ///     }
    ///
    /// </remarks>
    /// <response code="204">Объект успешно изменён.</response>
    /// <response code="400">Если произошла ошибка.</response>
    [Tags(tags: "FoodTypes")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] FoodType foodType)
    {
        if (foodType is not null) await _repository.UpdateAsync(entity: foodType);

        return NoContent();
    }

    /// <summary>
    /// Удаление разновидности блюд.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     DELETE /FoodTypes/1
    ///
    /// </remarks>
    /// <response code="204">Объект успешно удалён.</response>
    /// <response code="400">Если произошла ошибка.</response>
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