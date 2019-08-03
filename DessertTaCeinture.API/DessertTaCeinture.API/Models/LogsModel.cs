using System;
using System.ComponentModel.DataAnnotations;

namespace DessertTaCeinture.API.Models
{
    public class LogsModel
    {
        #region Fields
        private int _Id;
        private Guid _LogGuid;
        private DateTime _LogDate;
        private int _UserId;
        private string _LogMessage;
        private string _ErrorPage;
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

        public Guid LogGuid
        {
            get
            {
                return _LogGuid;
            }
            set
            {
                _LogGuid = value;
            }
        }

        public DateTime LogDate
        {
            get
            {
                return _LogDate;
            }
            set
            {
                _LogDate = value;
            }
        }

        public int UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                _UserId = value;
            }
        }

        public string LogMessage
        {
            get
            {
                return _LogMessage;
            }
            set
            {
                _LogMessage = value;
            }
        }

        public string ErrorPage
        {
            get
            {
                return _ErrorPage;
            }
            set
            {
                _ErrorPage = value;
            }
        }
        #endregion
    }
}