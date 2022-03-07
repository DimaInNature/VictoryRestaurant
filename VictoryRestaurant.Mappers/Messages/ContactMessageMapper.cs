namespace VictoryRestaurant.Mappers.Messages;

public static class ContactMessageMapper
{
    public static ContactMessageEntity ToEntity(this ContactMessage contactMessageItem) =>
        contactMessageItem is not null ? new()
        {
            Id = contactMessageItem.Id,
            Name = contactMessageItem.Name,
            Mail = contactMessageItem.Mail,
            Message = contactMessageItem.Message,
            Phone = contactMessageItem.Phone
        }
        : throw new ArgumentNullException($"{nameof(ContactMessageMapper)},{nameof(contactMessageItem)}");

    public static ContactMessage ToDomain(this ContactMessageEntity contactMessageModel) =>
       contactMessageModel is not null ? new()
       {
           Id = contactMessageModel.Id,
           Name = contactMessageModel.Name,
           Mail = contactMessageModel.Mail,
           Message = contactMessageModel.Message,
           Phone = contactMessageModel.Phone
       }
       : throw new ArgumentNullException($"{nameof(ContactMessageMapper)},{nameof(contactMessageModel)}");

    public static async Task<ContactMessage> ToDomain(this Task<ContactMessageEntity> contactMessageModel) => await
      contactMessageModel is not null ? new ContactMessage()
      {
          Id = contactMessageModel.Result.Id,
          Name = contactMessageModel.Result.Name,
          Mail = contactMessageModel.Result.Mail,
          Message = contactMessageModel.Result.Message,
          Phone = contactMessageModel.Result.Phone
      }
      : throw new ArgumentNullException($"{nameof(ContactMessageMapper)},{nameof(contactMessageModel)}");
}
