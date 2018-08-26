namespace Dashboard
{
    public unsafe class User
    {
        public int UserID { get; private set; }
        private unsafe char* Password { get; set; }

        public unsafe User(int userid, string password)
        {
            UserID = userid;
            Password = ConvertToPointer(password.ToCharArray());
            password = null;
        }

        public unsafe string GetPassword()
        {
            return new string(Password);
        }

        private unsafe char* ConvertToPointer(char[] s)
        {
            fixed (char* p = s) //Convert to Char*
                return p;
        }

        public unsafe void ClearPassword()
        {
            for (int i = 0; Password[i] != '\0'; ++i)
            {
                Password[i] = '\0'; //Overwrite location in memory with \0 which is an explicit NUL terminator
            }
        }

        unsafe ~User() //Called when garbage collected
        {
        }
    }
}
