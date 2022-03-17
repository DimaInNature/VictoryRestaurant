namespace VictoryRestaurant.Mappers.Users;

public static class UserMapper
{
    public static UserEntity ToEntity(this User userItem) =>
      userItem is not null ? new()
      {
          Id = userItem.Id,
          Login = userItem.Login,
          Password = userItem.Password,
          Role = userItem.Role
      }
      : throw new ArgumentNullException($"{nameof(UserMapper)},{nameof(userItem)}");

    public static User ToDomain(this UserEntity userModel) =>
       userModel is not null ? new()
       {
           Id = userModel.Id,
           Login = userModel.Login,
           Password = userModel.Password,
           Role = userModel.Role
       }
       : throw new ArgumentNullException($"{nameof(UserMapper)},{nameof(userModel)}");

    public static async Task<User> ToDomain(this Task<UserEntity> userModel) =>
        await userModel is not null ? new()
        {
            Id = userModel.Result.Id,
            Login = userModel.Result.Login,
            Password = userModel.Result.Password,
            Role = userModel.Result.Role
        }
      : throw new ArgumentNullException($"{nameof(UserMapper)},{nameof(userModel)}");
}