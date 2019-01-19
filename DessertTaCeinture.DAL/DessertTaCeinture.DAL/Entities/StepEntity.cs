using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DessertTaCeinture.DAL.Entities
{
    [Table("Step")]
    public class StepEntity
    {
        #region Fields
        private int _Id;
        private int _StepOrder;
        private string _Description;
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

        public int StepOrder
        {
            get
            {
                return _StepOrder;
            }
            set
            {
                _StepOrder = value;
            }
        }

        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }
        #endregion
    }
}
