using illegible.Entity.BlogEntity.Post;
using illegible.Repository.IRepository.BlogPostTablesIRepository;
using illegible.Shared.SharedDto.BlogPost;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace illegible.Server.Controllers.BlogPostAPI
{
    [Route("[controller]")]
    [ApiController]
    public class BlogPost: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public BlogPost(IMapper mapper, IBlogPostRepository blogPostRepository, UserManager<IdentityUser> userManager)
        {
            _mapper = mapper;
            _blogPostRepository = blogPostRepository;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("AddBlogPost")]
        public async Task AddBlogPost([FromBody] BlogPostDto blogPostDto)
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            blogPostDto.Author = currentUser.Identity.Name;

            var blogPost = _mapper.From(blogPostDto).AdaptToType<Entity.BlogEntity.Post.BlogPost>();
            await _blogPostRepository.AddBlogPostAsync(blogPost);
        }

        [HttpGet]
        [Route("GetAllBlogPost")]
        public async Task<IActionResult> GetAllBlogPost()
        {
            var blogPostList = await _blogPostRepository.GetAllBlogPostAsync();
            var blogPostDtoList = _mapper.From(blogPostList).AdaptToType<List<BlogPostDto>>();
            return Ok(blogPostDtoList);
        }
    }
}
