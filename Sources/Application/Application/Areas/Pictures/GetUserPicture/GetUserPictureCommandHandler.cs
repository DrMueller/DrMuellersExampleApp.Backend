using MediatR;

namespace Mmu.DrMuellersExampleApp.Application.Areas.Pictures.GetUserPicture
{
    public class GetUserPictureCommanHandler : IRequestHandler<GetUserPictureCommand, UserPictureResultDto>
    {
        public Task<UserPictureResultDto> Handle(GetUserPictureCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(
                new UserPictureResultDto
                {
                    Url = "https://www.fribourgregion.ch/wp-content/uploads/2022/03/Geraldine-c-4.jpg"
                });
        }
    }
}