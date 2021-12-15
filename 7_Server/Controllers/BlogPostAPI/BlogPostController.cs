using System.Collections.Generic;
using illegible.Repository.IRepository.BlogPostTablesIRepository;
using illegible.Shared.SharedDto.BlogPost;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;

namespace illegible.Server.Controllers.BlogPostAPI
{
    [Route("BlogPost")]
    [ApiController]
    public class BlogPost : ControllerBase
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public BlogPost(IBlogPostRepository blogPostRepository, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _blogPostRepository = blogPostRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost("AddBlogPost"),AutoValidateAntiforgeryToken]
        public async Task AddBlogPost([FromBody] BlogPostDto blogPostDto)
        {
            blogPostDto.Author = _userManager.GetUserName(User);
            var blogPost = _mapper.Map<Entity.BlogEntity.Post.BlogPost>(blogPostDto);
            await _blogPostRepository.AddBlogPostAsync(blogPost);
        }

        [HttpGet("GetAllBlogPost")]
        public async Task<IEnumerable<BlogPostDto>> GetAllBlogPost()
        {
            var blogPostList = await _blogPostRepository.GetAllBlogPostAsync();
            var blogPostDtoList = _mapper.Map<IEnumerable<BlogPostDto>>(blogPostList);
            return blogPostDtoList;
        }

        [HttpGet("GetBlogPost/{postId}")]
        public async Task<BlogPostDto> GetBlogPost([FromRoute]long postId)
        {
            var blogPost = await _blogPostRepository.GetBlogPostByIdAsync(postId);
            var blogPostDto = _mapper.Map<BlogPostDto>(blogPost);
            return blogPostDto;
        }
    }
}
