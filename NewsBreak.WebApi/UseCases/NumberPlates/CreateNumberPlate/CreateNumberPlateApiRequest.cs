namespace NewsBreak.WebApi.UseCases.NumberPlates.CreateNumberPlate
{

    public class CreateNumberPlateApiRequest
    {

        #region Properties

        /// <summary>
        /// The type of car
        /// </summary>
        public string CarType { get; set; }

        /// <summary>
        /// When you saw the vehicle, defaults to current time if left null
        /// </summary>
        public DateTime? DateCreatedUtc { get; set; }

        /// <summary>
        /// The latitude and longitude of where you saw the vehicle. For example '-33.6294450344, 150.783468902'
        /// </summary>
        public string MapFriendlyAddress { get; set; }

        /// <summary>
        /// The registration plate of the vehicle. For example ARY-38S
        /// </summary>
        public string Registration { get; set; }

        #endregion Properties

    }

}
