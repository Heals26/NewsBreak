using NewsBreak.Application.Dtos.Users;

namespace NewsBreak.Application.UseCases.Users.GetUsers
{

    public interface IGetUsersOutputPort
    {

        Task PresentUsersAsync(IQueryable<UserDto> users, CancellationToken cancellationToken);

    }

}
