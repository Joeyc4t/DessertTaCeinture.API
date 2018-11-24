using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DessertTaCeinture.DAL.Entities
{
    [Table("Theme")]
    public class ThemeEntity
    {
        #region Fields
        private int _Id;
        private string _Name;
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

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        #endregion
    }
}
