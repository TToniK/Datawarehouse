using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Person_Phone.Models
{
    public partial class Phone
    {
        public long ID { get; set; }
        [StringLength(10)]
        public string Type { get; set; }
        [StringLength(10)]
        public string Number { get; set; }
        public long? PersonID { get; set; }

        [ForeignKey("PersonId")]
        [InverseProperty("Phone")]
        public virtual Person Person { get; set; }
    }
}