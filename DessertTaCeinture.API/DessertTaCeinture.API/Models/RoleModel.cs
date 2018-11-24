using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DessertTaCeinture.API.Models
{
    public class RoleModel
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

        [Required]
        [StringLength(20)]
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

        [Required]
        [Range(0,5)]
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