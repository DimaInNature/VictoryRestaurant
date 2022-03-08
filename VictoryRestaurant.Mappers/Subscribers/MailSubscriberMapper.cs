namespace VictoryRestaurant.Mappers.Subscribers;

public static class MailSubscriberMapper
{
    public static MailSubscriberEntity ToEntity(this MailSubscriber mailSubscriberItem) =>
       mailSubscriberItem is not null ? new()
       {
           Id = mailSubscriberItem.Id,
           Mail = mailSubscriberItem.Mail
       }
       : throw new ArgumentNullException($"{nameof(MailSubscriberMapper)},{nameof(mailSubscriberItem)}");

    public static MailSubscriber ToDomain(this MailSubscriberEntity mailSubscriberModel) =>
       mailSubscriberModel is not null ? new()
       {
           Id = mailSubscriberModel.Id,
           Mail = mailSubscriberModel.Mail
       }
       : throw new ArgumentNullException($"{nameof(MailSubscriberMapper)},{nameof(mailSubscriberModel)}");

    public static async Task<MailSubscriber> ToDomain(this Task<MailSubscriberEntity> mailSubscriberModel) =>
        await mailSubscriberModel is not null ? new()
        {
            Id = mailSubscriberModel.Result.Id,
            Mail = mailSubscriberModel.Result.Mail
        }
      : throw new ArgumentNullException($"{nameof(MailSubscriberMapper)},{nameof(mailSubscriberModel)}");
}
