using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoListApp.Models
{
    public class TodoTask
    {
        [Key]
        public int IDTask { get; set; }
        [Column(TypeName ="nvarchar(250)")]
        [Required]        
        public string Description { get; set; }

        [Column(TypeName = "bit")]
        [Display(Name = "Completed")]
        public bool IsDone { get; set; }
    }
}
