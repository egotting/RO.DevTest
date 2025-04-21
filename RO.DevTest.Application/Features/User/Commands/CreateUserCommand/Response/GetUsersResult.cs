namespace RO.DevTest.Application.Features.User.Commands.CreateUserCommand.Response;

public class GetUsersResult
{
    public GetUsersResult()
    {
    }

    public GetUsersResult(Domain.Entities.User user)
    {
        UserName = user.UserName!;
        Email = user.Email!;
        Name = user.Name;
    }


    public string UserName { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
}