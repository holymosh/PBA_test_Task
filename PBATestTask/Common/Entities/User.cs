using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entities
{
    public class User:AbstractEntity
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public int DepartmentId { get; set; }
    }
}
