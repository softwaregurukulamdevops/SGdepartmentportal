using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DepartmentPortel.Models
{
    public partial class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [StringLength(100)]
        public string DepartmentName { get; set; }
        public bool? IsActive { get; set; }
    }
}
