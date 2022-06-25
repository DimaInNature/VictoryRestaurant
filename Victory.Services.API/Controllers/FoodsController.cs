namespace Victory.Services.API.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class FoodsController : ControllerBase
{
    private readonly IFoodFacadeService _repository;

    public FoodsController(IFoodFacadeService repository) => _repository = repository;

    /// <summary>
    /// Получение списка всех блюд.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET /Foods
    ///
    /// </remarks>
    /// <returns>Возвращает список всех блюд.</returns>
    /// <response code="200">Возвращает список блюд.</response>
    /// <response code="404">Если ничего не было найдено.</response>
    [Tags(tags: "Foods")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Food>>> GetList() =>
        await _repository.GetFoodListAsync() is IEnumerable<Food> foods
        ? Ok(value: foods)
        : NotFound();

    /// <summary>
    /// Получение списка всех блюд определённого типа.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET /Foods/Type=Завтрак
    ///
    /// </remarks>
    /// <returns>Возвращает список всех блюд.</returns>
    /// <response code="200">Возвращает список блюд.</response>
    /// <response code="404">Если ничего не было найдено.</response>
    [Tags(tags: "Foods")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet("Type={type}")]
    public async Task<ActionResult<IEnumerable<Food>>> GetList(string type) =>
        await _repository.GetFoodListByTypeAsync(type) is IEnumerable<Food> foods
        ? Ok(value: foods)
        : NotFound();

    /// <summary>
    /// Получение блюда по его идентификатору.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET /Foods/1
    ///
    /// </remarks>
    /// <param name="id">Идентификатор блюда.</param>
    /// <returns>Возвращает блюдо.</returns>
    /// <response code="200">Возвращает найденное блюдо.</response>
    /// <response code="404">Если ничего не было найдено.</response>
    [Tags(tags: "Foods")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "Id")]
    public async Task<ActionResult<Food>> Get(int id) =>
        await _repository.GetFoodAsync(id) is Food food
        ? Ok(value: food)
        : NotFound();

    /// <summary>
    /// Создание блюда.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST /Foods
    ///     {
    ///         "id": 0, (Автоинкремент)
    ///         "createdDate": "2022-06-06T09:17:12.672Z",
    ///         "name": "Pelmeny",
    ///         "description": "Delicious dumplings",
    ///         "costInUSD": 10.99,
    ///         "imagePath": "path",
    ///         "type": 0
    ///     }
    ///
    /// </remarks>
    /// <returns>Возвращает созданное блюдо.</returns>
    /// <response code="200">Если объект был создан.</response>
    /// <response code="400">Если произошла ошибка.</response>
    [Tags(tags: "Foods")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<Food>> Create([FromBody] Food food)
    {
        if (food is not null) await _repository.CreateAsync(entity: food);

        return Ok();
    }

    /// <summary>
    /// Изменение блюда.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     PUT /Foods
    ///     {
    ///         "id": 1, (Id изменяемого объекта)
    ///         "createdDate": "2022-06-06T09:17:12.672Z",
    ///         "name": "Pelmeny",
    ///         "description": "Delicious dumplings",
    ///         "costInUSD": 10.99,
    ///         "imagePath": "path",
    ///         "type": 0
    ///     }
    ///
    /// </remarks>
    /// <response code="204">Объект успешно изменён.</response>
    /// <response code="400">Если произошла ошибка.</response>
    [Tags(tags: "Foods")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] Food food)
    {
        if (food is not null) await _repository.UpdateAsync(entity: food);

        return NoContent();
    }

    /// <summary>
    /// Удаление блюда.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     DELETE /Foods/1
    ///
    /// </remarks>
    /// <response code="204">Объект успешно удалён.</response>
    /// <response code="400">Если произошла ошибка.</response>
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