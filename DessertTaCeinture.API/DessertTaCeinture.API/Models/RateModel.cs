using System.ComponentModel.DataAnnotations;

namespace DessertTaCeinture.API.Models
{
    public class RateModel
    {
        #region Fields
        private int _Id;
        private int _RateOnFive;
        #endregion

        #region Properties
        [Key]
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

        [Required]
        [Range(0, 5)]
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