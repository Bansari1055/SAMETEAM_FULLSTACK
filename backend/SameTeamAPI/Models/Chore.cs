using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SameTeamAPI.Models
{
    public class Chore
    {
        [Key]
        public int ChoreID { get; set; }

        [Required]
        public string ChoreName { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public int AssignedToUserID { get; set; }

        public bool IsCompleted { get; set; }

        public string Message { get; set; } // Optional message field

        // Navigation property (Not required in the request body)
        [ForeignKey("AssignedToUserID")]
        [NotMapped] // Ensures it's not required in the request body
        public AppUser? AssignedToUser { get; set; }
    }
}
