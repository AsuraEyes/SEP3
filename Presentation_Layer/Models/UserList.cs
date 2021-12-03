namespace Presentation_Layer.Models
{
    public class UserList
    {
        public int Count { get; set; }
        public User[] UserList { get; set; }

        public UserList()
        {
            UserList = new User[] { };
        }
    }
}