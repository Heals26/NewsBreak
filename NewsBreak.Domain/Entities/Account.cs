using NewsBreak.Persistence.Models;

namespace NewsBreak.Domain.Entities
{

    public class Account
    {

        public long AccountID { get; set; }
        public DateTime Created { get; set; }
        public string Email { get; set; }
        public long FirstName { get; set; }
        public long LastName { get; set; }
        public Password Password { get; set; }

    }

}
