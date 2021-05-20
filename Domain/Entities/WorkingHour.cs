using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class WorkingHour : AuditableBaseEntity 
    {
        [Key]
        public int WorkingHourId { get; set; }

        //[Required]
        [Column(TypeName = "nvarchar(100)")]
        [StringLength(250)]
        public string WorkingHourDuration { get; set; } 
    }
}
