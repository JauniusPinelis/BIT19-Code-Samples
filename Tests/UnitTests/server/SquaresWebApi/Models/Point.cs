using System.ComponentModel.DataAnnotations;

namespace SquaresWebApi.Models
{
    public class Point : Entity
    {
        [Required]
        [Range(-5000, 5000)]
        public int X { get; set; }
        [Required]
        [Range(-5000, 5000)]
        public int Y { get; set; }
        public int PointsCollectionId { get; set; }
        public PointsCollection PointsCollection { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
