using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamApplication.Model
{
    public class TransactionHeader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TransactionHeader()
        {
            this.TransactionDetails = new HashSet<TransactionDetail>();
        }

        public int id { get; set; }
        public System.DateTime date { get; set; }
        public int user_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransactionDetail> TransactionDetails { get; set; }
        public virtual User User { get; set; }
    }
}