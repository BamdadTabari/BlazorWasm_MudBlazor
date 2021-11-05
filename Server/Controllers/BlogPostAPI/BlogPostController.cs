using illegible.Entity.BlogEntity.Post;
using illegible.Repository.IRepository.BlogPostTablesIRepository;
using illegible.Shared.SharedDTO.BlogPost;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace illegible.Server.Controllers.BlogPostAPI
{
    [Route("[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBlogPostRepository _blogPostRepository;
        public BlogPostController(IMapper mapper,
            IBlogPostRepository blogPostRepository)
        {
            _mapper = mapper;
            _blogPostRepository = blogPostRepository;
        }
        
        [HttpPost]
        [Route("AddBlogPost")]
        public async Task AddBlogPost([FromBody] BlogPostDTO blogPostDTO)
        {
            
            var blogPost = _mapper.From(blogPostDTO).AdaptToType<BlogPost>();
            await _blogPostRepository.AddBlogPostAsync(blogPost);
        }

        [HttpGet]
        [Route("GetAllBlogPost")]
        public async Task<IActionResult> GetAllBlogPost()
        {
            var blogPostList = await _blogPostRepository.GetAllBlogPostAsync();
            var blogPostDTOList = _mapper.From(blogPostList).AdaptToType<List<BlogPostDTO>>();
            return Ok(blogPostDTOList);
        }
    }
}
