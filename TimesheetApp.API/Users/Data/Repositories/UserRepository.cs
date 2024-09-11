using TimesheetApp.API.Users.Data.Entities;

namespace TimesheetApp.API.Users.Data.Repositories;

public class UserRepository : IUserRepository
{
    public async Task<UserEntity> GetById(int id)
    {
        return new UserEntity
        {
            Id = id,
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@gmail.com",
            Birthdate =  DateTime.Now.AddYears(-21),
        };
    }
}