using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
 /// <summary>
 /// Account.
 /// </summary>
    public class Account
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public int Number { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        #endregion
    }
}
