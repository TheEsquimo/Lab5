namespace Lab5
{
    class User
    {
        private string name;
        private string email;

        public User(string theName, string theEmail)
        {
            name = theName;
            email = theEmail;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}