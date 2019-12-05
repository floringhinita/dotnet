namespace LinqAndLamdaExpressions.Models
{
    using System.Collections.Generic;

    public class UserPosts
    {
        public User User { get; set; }

        public List<Post> Posts { get; set; }
    }
}
