using System.ComponentModel.DataAnnotations;

namespace UniversityAPIBackend.Models.DataModels
{
    public abstract class BaseEntity
    {
        [Required]
        [Key]
        public int ID { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public string DeteledBy { get; set; } = string.Empty;
        public DateTime? DeletedAt { get; set; } = DateTime.Now;
        public  bool IsDeleted { get; set;
        }
    }
}
