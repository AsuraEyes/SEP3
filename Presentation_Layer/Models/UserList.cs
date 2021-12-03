namespace Presentation_Layer.Models
{
    public class UserList
    {
        public int Count { get; set; }
        public User[] userList { get; set; }

        public UserList()
        {
            userList = new User[] { };
        }
    }
}