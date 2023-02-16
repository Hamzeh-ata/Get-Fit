using System.ComponentModel.DataAnnotations;

namespace get_fit.Models
{
    public class Trainee_information
    {
      
        [Key]
        public string UserId { get; set; }
     
        [Display(Name = "birthday")]
        public string BirthDay { get; set; }
   
        [Display(Name = "weight")]
        public int Weight { get; set; }
        [Display(Name = "height")]
        public int Height { get; set; }

        [Display(Name = "workoutplace")]
        public string WorkoutPlace { get; set; }

        [Display(Name = "workoutplace")]
        public string Goal { get; set; }

        [Display(Name = "workoutdays")]
        public string WorkoutDays { get; set; }

        [Display(Name = "workouthours")]
        public string WorkoutHours { get; set; }
    }
}
