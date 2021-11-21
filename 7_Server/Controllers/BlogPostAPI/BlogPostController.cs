using System;
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
    public class BlogPost : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBlogPostRepository _blogPostRepository;

        public BlogPost(IMapper mapper, IBlogPostRepository blogPostRepository)
        {
            _mapper = mapper;
            _blogPostRepository = blogPostRepository;
        }

        [HttpPost]
        [Route("AddBlogPost")]
        public async Task AddBlogPost([FromBody] BlogPostDto blogPostDto)
        {
            //System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            //blogPostDto.Author = currentUser.Identity.Name;
            var blogPost = new Entity.BlogEntity.Post.BlogPost()
            {
                Summary = blogPostDto.Summary,
                PostAttachedLinkUrlSubject = blogPostDto.PostAttachedLinkUrlSubject,
                PostContext = blogPostDto.PostContext,
                AttachedLinkTypeEnum = blogPostDto.AttachedLinkTypeEnum,
                Author = "illegible",
                PostAttachedLinkUrl = blogPostDto.PostAttachedLinkUrl,
                PostImageUrl = blogPostDto.PostImageUrl,
                PostVideoUrl = blogPostDto.PostVideoUrl,
                Title = blogPostDto.Title,
                WriteTime = DateTime.Now
            };
            //var blogPost = _mapper.From(blogPostDto).AdaptToType<Entity.BlogEntity.Post.BlogPost>();
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
