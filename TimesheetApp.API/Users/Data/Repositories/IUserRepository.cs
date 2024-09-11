using TimesheetApp.API.Users.Data.Entities;

namespace TimesheetApp.API.Users.Data.Repositories;

public interface IUserRepository
{
    Task<UserEntity> GetById(int id);
}