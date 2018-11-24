namespace DessertTaCeinture.API.Models
{
    public class OriginModel
    {
        #region Fields
        private int _Id;
        private string _Country;
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

        public string Country
        {
            get
            {
                return _Country;
            }
            set
            {
                _Country = value;
            }
        }
        #endregion
    }
}