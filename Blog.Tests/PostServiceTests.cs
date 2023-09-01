using Blog.Application;
using NSubstitute;

namespace Blog.UnitTests
{
    public class PostServiceTests
    {
        [Fact]
        public void TitleAndContentIsvalid_ReturnTrue_WithDefaultObject()
        {
            //Arrange
            string title = "Testes unitarios com NSubstitute";
            string content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit";

            var post = new Post(content, title);
            var postRepository = Substitute.For<IPostRepository>();

            var notificationService = Substitute.For<INotificationService>();

            var postService = new PostService(notificationService, postRepository);

            //Act

            var result = postService.Create(post);

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Data);
            Assert.True(result.Success);
            Assert.Empty(result.Message);

            postRepository.Received(1).Add(Arg.Any<Post>());
            notificationService.Received(1).Notify(title);
        }

        [Fact]
        public void TitleIsInvalid_ReturnFalse_WithDefaultObject()
        {
            //Arrange
            string title = "Test";
            string content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit";

            var post = new Post(content, title);
            var postRepository = Substitute.For<IPostRepository>();

            var notificationService = Substitute.For<INotificationService>();

            var postService = new PostService(notificationService, postRepository);

            //Act

            var result = postService.Create(post);

            //Assert
            Assert.NotNull(result);
            Assert.Null(result.Data);
            Assert.False(result.Success);
            Assert.NotEmpty(result.Message);
            Assert.Equal("Content should have min 5 characteres", result.Message);

            postRepository.DidNotReceive().Add(Arg.Any<Post>());
            notificationService.DidNotReceive().Notify(title);

        }
    }
}