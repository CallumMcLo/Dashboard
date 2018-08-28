using System.Security;

namespace Dashboard
{
    public class User
    {
        public int UserID { get; private set; }
        private SecureString Password { get; set; }
        public User(int userid, SecureString password)
        {
            UserID = userid;
            Password = password;
        }

        public SecureString GetPassword()
        {
            return Password;
        }

        public int GetUsername()
        {
            return UserID;
        }
    }
}
