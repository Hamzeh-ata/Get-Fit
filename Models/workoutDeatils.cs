using System.ComponentModel.DataAnnotations;

namespace get_fit.Models
{
    public class workoutDeatils
    {
        [Key]
        public string workoutId { get; set; }
        public string bodyPart { get; set; }
        public string exerciseName { get; set; }
        public int reps { get; set; }
        public int sets { get; set; }
        public string videoLink { get; set; }

    }
}
