using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    /// <summary>
    /// Customer.
    /// </summary>
    public class User
    {
        #region field
        public static int lastid = 0;
        #endregion
    
        #region Properties
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public long PhoneNumber { get; set; }
        public int SSN { get; set; }
        public string EmailAddress { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        #endregion
        }
    }
