namespace Blog.Application
{
    public class PostService
    {
        public INotificationService _notificationService { get; set; }
        public IPostRepository _postRepository { get; set; }

        public PostService(INotificationService notificationService, IPostRepository postRepository)
        {
            _notificationService = notificationService;
            _postRepository = postRepository;
        }

        public RequestResult<Post> Create(Post post)
        {
            var (validation, message) = post.ValidateTitleLenght();

            if (!validation)
                return new RequestResult<Post>(message, validation);

            (validation, message) = post.ValidateContentLenght();

            if (!validation)
                return new RequestResult<Post>(message, validation);

            _postRepository.Add(post);

            _notificationService.Notify(post.Title);

            return new RequestResult<Post>(string.Empty, validation, post);
        }
    }
}
