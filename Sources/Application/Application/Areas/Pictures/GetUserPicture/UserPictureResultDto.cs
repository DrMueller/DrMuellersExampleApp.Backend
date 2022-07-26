using JetBrains.Annotations;

namespace Mmu.DrMuellersExampleApp.Application.Areas.Pictures.GetUserPicture
{
    [PublicAPI]
    public class UserPictureResultDto
    {
        public string Url { get; set; } = null!;
    }
}