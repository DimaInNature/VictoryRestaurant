namespace VictoryRestaurant.Web.Entities.Abstract;

public abstract class BaseEntity : IBaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
}