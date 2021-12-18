//using illegible.Server.Controllers.BlogPostAPI;
//using illegible.Test.Fixture;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace illegible.Test
//{
//    //todo: it's not complete
//    public class BlogPostControllerTest : IClassFixture<ControllerFixture>
//    {
//        BlogPost blogController;

//        /**
//         * xUnit constructor runs before each test. 
//         */
//        public BlogPostControllerTest(ControllerFixture fixture)
//        {
//            blogController = fixture.blogPostController;
//        }

//        [Fact]
//        public void Get_WithoutParam_Ok_Test()
//        {
//            var result = blogController.GetAllBlogPost();

//            Assert.Equal(200,new OkObjectResult(result).StatusCode);
//        }
//    }
//}
