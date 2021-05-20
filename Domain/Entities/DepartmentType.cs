using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class DepartmentType : AuditableBaseEntity
    {
        [Key]
        public int DepartmentTypeId { get; set; }

        //[Required]
        [Column(TypeName = "nvarchar(100)")]
        [StringLength(250)]
        public string DepartmentTypeName { get; set; } 
    }
}
