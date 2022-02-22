using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SquaresWebApi.Models
{
    public class PointsCollection : Entity
    {
        [Required]
        public string Name { get; set; }
        public List<Point> Points { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
