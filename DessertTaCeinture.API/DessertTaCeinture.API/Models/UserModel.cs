using System;
using System.ComponentModel.DataAnnotations;

namespace DessertTaCeinture.API.Models
{
    public class UserModel
    {
        #region Fields
        private int _Id;
        private string _Email;
        private string _Password;
        private string _Salt;
        private string _LastName;
        private string _FirstName;
        private bool? _Gender;
        private DateTime _InscriptionDate;
        private bool _IsActive;
        private int _RoleId;
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
        [StringLength(50)]
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }

        [Required]
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }

        [Required]
        [StringLength(90)]
        public string Salt
        {
            get
            {
                return _Salt;
            }
            set
            {
                _Salt = value;
            }
        }

        [Required]
        [StringLength(50)]
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
            }
        }

        [Required]
        [StringLength(50)]
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
            }
        }

        public bool? Gender
        {
            get
            {
                return _Gender;
            }
            set
            {
                _Gender = value;
            }
        }

        [Required]
        public DateTime InscriptionDate
        {
            get
            {
                return _InscriptionDate;
            }
            set
            {
                _InscriptionDate = value;
            }
        }

        [Required]
        public bool IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                _IsActive = value;
            }
        }

        [Required]
        public int RoleId
        {
            get
            {
                return _RoleId;
            }
            set
            {
                _RoleId = value;
            }
        }
        #endregion
    }
}