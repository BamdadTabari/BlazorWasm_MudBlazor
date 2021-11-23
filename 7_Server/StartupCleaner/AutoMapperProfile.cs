using AutoMapper;
using illegible.Entity.BlogEntity.Post;
using illegible.Shared.SharedDto.BlogPost;

namespace illegible.Server.StartupCleaner
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BlogPost,BlogPostDto>().ReverseMap();
        }
    }
}
