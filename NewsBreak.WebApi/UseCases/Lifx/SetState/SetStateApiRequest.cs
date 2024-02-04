namespace NewsBreak.WebApi.UseCases.Lifx.SetState
{

    public class SetStateApiRequest
    {

        #region Properties

        public string Brightness { get; set; }
        public string Color { get; set; }
        public decimal Duration { get; set; }
        public string Power { get; set; }

        #endregion Properties

    }

}
