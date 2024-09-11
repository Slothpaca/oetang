using TimesheetApp.API.Users.Data.Entities;
using TimesheetApp.API.Users.Models;

namespace TimesheetApp.API.Users.Mappers;

public static class UserMapperExtensions
{
    public static UserModel ToModel(this UserEntity user)
    {
        return new UserModel
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
        };
    }
}