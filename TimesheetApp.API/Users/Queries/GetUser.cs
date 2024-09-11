using MediatR;
using TimesheetApp.API.Users.Models;

namespace TimesheetApp.API.Users.Queries;

public sealed record GetUser(int UserId) : IRequest<UserModel>;