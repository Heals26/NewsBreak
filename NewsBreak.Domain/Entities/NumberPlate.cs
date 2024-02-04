namespace NewsBreak.Domain.Entities
{

    public class NumberPlate
    {

        #region Properties

        public long NumberPlateID { get; set; }

        public string CarType { get; set; }
        public DateTime DateCreatedUtc { get; set; }
        public string MapFriendlyAddress { get; set; }
        public string Registration { get; set; }

        #endregion Properties

    }

}
