using System;

namespace Domain
{
    [Serializable]
    public class ApiUser
    {
        public string NickName { get; set; }

        public DateTime BirthDay { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}
