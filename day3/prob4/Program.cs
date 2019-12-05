namespace LinqAndLamdaExpressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    internal class Program
    {
        private static void Main(string[] args)
        {
            List<User> allUsers = ReadUsers("users.json");
            List<Post> allPosts = ReadPosts("posts.json");

            #region Demo

            // 1 - find all users having email ending with ".net".
            var users1 = from user in allUsers
                         where user.Email.EndsWith(".net")
                         select user;

            var users11 = allUsers.Where(user => user.Email.EndsWith(".net"));

            IEnumerable<string> userNames = from user in allUsers
                                            select user.Name;

            var userNames2 = allUsers.Select(user => user.Name);

            foreach (var value in userNames2)
            {
                Console.WriteLine(value);
            }

            IEnumerable<Company> allCompanies = from user in allUsers
                                                select user.Company;

            var users2 = from user in allUsers
                         orderby user.Email
                         select user;

            var netUser = allUsers.First(user => user.Email.Contains(".net"));
            Console.WriteLine(netUser.Username);

            #endregion

            // 2 - find all posts for users having email ending with ".net".
            IEnumerable<int> usersIdsWithDotNetMails = from user in allUsers
                                                       where user.Email.EndsWith(".net")
                                                       select user.Id;

            IEnumerable<Post> posts = from post in allPosts
                                      where usersIdsWithDotNetMails.Contains(post.UserId)
                                      select post;

            foreach (var post in posts)
            {
                Console.WriteLine(post.Id + " " + "user: " + post.UserId);
            }

            // 3 - print number of posts for each user.
            Console.WriteLine("\n3 - print number of posts for each user.\n");

            var postsByUser = allPosts
                .GroupBy(post => post.UserId)
                .Select(group => new { UserId = group.Key, Posts = group.Count() })
                .OrderBy(post => post.Posts);

            foreach (var item in postsByUser)
            {
                Console.WriteLine("User {0} has {1} posts.", item.UserId, item.Posts);
            }

            Console.WriteLine("\n3 - print number of posts for each user V2.\n");

            var postsByUser2 = from p in allPosts
                               group p by p.UserId into g
                               select new { uid = g.Key, count = g.Count() };

            foreach (var item in postsByUser2)
            {
                Console.WriteLine("User {0} has {1} posts.", item.uid, item.count);
            }

            // 4 - find all users that have lat and long negative.
            Console.WriteLine("\n4 - find all users that have lat and long negative.\n");

            IEnumerable<User> users = allUsers
                .Where(user => user.Address.Geo != null)
                .Where(user => user.Address.Geo.Lat < 0 && user.Address.Geo.Lng < 0)
                .Select(user => user);

            foreach (var user in users)
            {
                Console.WriteLine($"User {user.Name} has negative geo coordinate: {user.Address.Geo.Lat} - {user.Address.Geo.Lng}");
            }

            // 5 - find the post with longest body.
            Console.WriteLine("\n5 - find the post with longest body.\n");

            var longestPost = allPosts.OrderByDescending(post => post.Body.Length)
                .First();

            Console.WriteLine("The longest post is: {0}", longestPost.Body);

            // 6 - print the name of the employee that have post with longest body.
            Console.WriteLine("\n6 - print the name of the employee that have post with longest body.\n");
            User u = allUsers.Where(user => user.Id == longestPost.UserId).First();

            Console.WriteLine("The user with longest post is: {0}", u.Name);

            // 7 - select all addresses in a new List<Address>. print the list.
            Console.WriteLine("\n7 - select all addresses in a new List<Address>. print the list.\n");
            List<Address> addresses = allUsers.Select(user => user.Address).ToList();

            foreach (var addr in addresses)
            {
                Console.WriteLine($"{addr.Geo.Lat} - {addr.Geo.Lng}");
            }

            // 8 - print the user with min lat
            Console.WriteLine("\n8 - print the user with min lat\n");
            User userMinLat = allUsers.Where(user => user.Address.Geo != null)
                .OrderBy(user => user.Address.Geo.Lat)
                .First();

            Console.WriteLine("The user with min lat is: {0}", userMinLat.Name);

            // 9 - print the user with max long
            Console.WriteLine("\n9 - print the user with max long\n");
            User userMaxLng = allUsers.Where(user => user.Address.Geo != null)
                .OrderByDescending(user => user.Address.Geo.Lng)
                .First();

            Console.WriteLine("The user with max lng is: {0}", userMaxLng.Name);

            // 10 - create a new class: public class UserPosts { public User User {get; set}; public List<Post> Posts {get; set} }
            //    - create a new list: List<UserPosts>
            //    - insert in this list each user with his posts only
            Console.WriteLine("\n10 - insert in this list each user with his posts only.\n");
            List<UserPosts> up = new List<UserPosts>();

            foreach (User userrr in allUsers)
            {
                UserPosts p = new UserPosts()
                {
                    User = userrr,
                    Posts = allPosts.Where(post => post.UserId == userrr.Id).ToList()
                };

                up.Add(p);
            }

            foreach (UserPosts pp in up)
            {
                Console.WriteLine(pp.User.Name);
                foreach (Post ppp in pp.Posts)
                {
                    Console.WriteLine(ppp.Body);
                }
            }

            // 11 - order users by zip code
            Console.WriteLine("\n11 - order users by zip code.\n");

            var usersByZipCode = allUsers
                .Where(user => user.Address.Zipcode != null)
                .OrderBy(user => user.Address.Zipcode);

            foreach (var usr in usersByZipCode)
            {
                Console.WriteLine($"{usr.Id} - {usr.Name} - {usr.Address.Zipcode}");
            }

            // 12 - order users by number of posts
            Console.WriteLine("\n12 - order users by number of posts\n");

            foreach (var item in postsByUser)
            {
                Console.WriteLine("User {0} has {1} posts.", item.UserId, item.Posts);
            }

            Console.ReadKey();
        }

        private static List<Post> ReadPosts(string file)
        {
            return ReadData.ReadFrom<Post>(file);
        }

        private static List<User> ReadUsers(string file)
        {
            return ReadData.ReadFrom<User>(file);
        }
    }
}
