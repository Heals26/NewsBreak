using NewsBreak.Persistence.Models;

namespace NewsBreak.Domain.Entities
{

    public class Account
    {


        #region Constructors

        public Account()
        {
            this.Claims = new HashSet<ClientClaim>();
        }

        #endregion Constructors

        #region Properties

        public long AccountID { get; set; }
        public DateTime Created { get; set; }
        public string Email { get; set; }
        public long FirstName { get; set; }
        public long LastName { get; set; }
        public Password Password { get; set; }

        public ICollection<ClientClaim> Claims { get; set; }

        #endregion Properties

    }

}
