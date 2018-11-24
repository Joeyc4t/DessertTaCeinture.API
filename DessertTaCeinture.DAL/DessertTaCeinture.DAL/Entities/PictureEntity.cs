using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DessertTaCeinture.DAL.Entities
{
    [Table("Picture")]
    public class PictureEntity
    {
        #region Fields
        private int _Id;
        private string _Name;
        private string _Path;
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

        public string Path
        {
            get
            {
                return _Path;
            }
            set
            {
                _Path = value;
            }
        }
        #endregion
    }
}
