namespace Dashboard
{
    public class User
    {
        public int UserID { get; private set; }
        private string Password { get; set; }

        public User(int userid, string password)
        {
            UserID = userid;
            Password = password;
        }

        public string GetPassword()
        {
            return Password;
        }
    }
}
