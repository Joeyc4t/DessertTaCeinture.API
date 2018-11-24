namespace DessertTaCeinture.API.Models
{
    public class RateModel
    {
        #region Fields
        private int _Id;
        private int _RateOnFive;
        #endregion

        #region Properties
        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }

        public int RateOnFive
        {
            get
            {
                return _RateOnFive;
            }
            set
            {
                _RateOnFive = value;
            }
        }
        #endregion
    }
}