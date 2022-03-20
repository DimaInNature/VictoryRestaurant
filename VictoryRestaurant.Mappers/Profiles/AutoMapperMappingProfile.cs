namespace VictoryRestaurant.Mappers.Profiles;

public class AutoMapperMappingProfile : Profile
{
    public AutoMapperMappingProfile()
    {
        CreateMap<Food, FoodEntity>();
        CreateMap<FoodEntity, Food>();

        CreateMap<ContactMessage, ContactMessageEntity>();
        CreateMap<ContactMessageEntity, ContactMessage>();

        CreateMap<User, UserEntity>();
        CreateMap<UserEntity, User>();

        CreateMap<MailSubscriber, MailSubscriberEntity>();
        CreateMap<MailSubscriberEntity, MailSubscriber>();

        CreateMap<Booking, BookingEntity>();
        CreateMap<BookingEntity, Booking>();
    }
}