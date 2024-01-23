using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asteroidsAPI.Models
{
    public class Asteroid
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Diameter { get; set; }
        public double Velocity { get; set; }
        public DateTime Date { get; set; }
        public string Planet { get; set; }
        public bool IsPotentiallyHazardous { get; set; }
    }
}
