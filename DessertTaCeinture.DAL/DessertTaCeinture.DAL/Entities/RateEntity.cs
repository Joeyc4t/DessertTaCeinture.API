using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DessertTaCeinture.DAL.Entities
{
    [Table("Rate")]
    public class RateEntity
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
