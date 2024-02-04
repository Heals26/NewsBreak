namespace NewsBreak.WebApi.UseCases.Users.CreateUser
{

    public class CreateUserApiRequest
    {

        #region Properties

        /// <summary>
        /// Date of creation
        /// </summary>
        public DateTime CreatedOnUTC { get; set; }

        /// <summary>
        /// The users email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The users first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The users last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The users password
        /// </summary>
        public string Password { get; set; }

        #endregion Properties

    }

}
