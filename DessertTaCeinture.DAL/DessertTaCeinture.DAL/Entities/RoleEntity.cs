using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DessertTaCeinture.DAL.Entities
{
    [Table("Role")]
    public class RoleEntity
    {
        #region Fields
        private int _Id;
        private string _Function;
        private int _Level;
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

        public string Function
        {
            get
            {
                return _Function;
            }
            set
            {
                _Function = value;
            }
        }

        public int Level
        {
            get
            {
                return _Level;
            }
            set
            {
                _Level = value;
            }
        }
        #endregion

    }
}
