using NewsBreak.Persistence.Models;

namespace NewsBreak.Domain.Entities
{

    public class User
    {


        #region Constructors

        public User()
        {
            this.Claims = new HashSet<ClientClaim>();
        }

        #endregion Constructors

        #region Properties

        public long UserID { get; set; }
        public DateTime Created { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Password Password { get; set; }

        public ICollection<ClientClaim> Claims { get; set; }

        #endregion Properties

    }

}
