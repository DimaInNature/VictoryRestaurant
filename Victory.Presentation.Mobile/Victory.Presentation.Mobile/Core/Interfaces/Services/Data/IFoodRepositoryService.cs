namespace Victory.Presentation.Mobile.Core.Interfaces.Services.Data;

public interface IFoodRepositoryService
{
    public Task<List<Food>> GetFoodListAsync();
}