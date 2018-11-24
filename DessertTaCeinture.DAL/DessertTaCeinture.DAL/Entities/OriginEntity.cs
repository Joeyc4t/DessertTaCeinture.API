using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DessertTaCeinture.DAL.Entities
{
    [Table("Origin")]
    public class OriginEntity
    {
        #region Fields
        private int _Id;
        private string _Country;
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
