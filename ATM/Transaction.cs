using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    /// <summary>
    /// Transaction
    /// </summary>
    public class Transaction
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        public int CardId { get; set; }
        public string Vendor { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public virtual Card Card { get; set; }
        #endregion 
    }
}
