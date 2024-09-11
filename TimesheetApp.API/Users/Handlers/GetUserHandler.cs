using MediatR;
using TimesheetApp.API.Users.Data.Repositories;
using TimesheetApp.API.Users.Mappers;
using TimesheetApp.API.Users.Models;
using TimesheetApp.API.Users.Queries;

namespace TimesheetApp.API.Users.Handlers;

public sealed class GetUserHandler : IRequestHandler<GetUser, UserModel>
{
    private readonly IUserRepository _userRepository;

    public GetUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<UserModel> Handle(GetUser request, CancellationToken cancellationToken)
    {
        var userEntity = await _userRepository.GetById(request.UserId);
        return userEntity.ToModel();
    }
}
