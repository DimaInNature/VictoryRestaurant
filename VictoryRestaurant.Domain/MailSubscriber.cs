using VictoryRestaurant.Domain.Abstract;

namespace VictoryRestaurant.Domain;

public class MailSubscriber : IDomainModel
{
    public int Id { get; set; }
    public string Mail { get; set; }
}