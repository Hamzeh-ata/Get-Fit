using System.ComponentModel.DataAnnotations;

namespace get_fit.Models
{
    public class workoutSummaryModel
    {
        [Key]
        public string id { get; set; }
        public string workoutGoal { get; set; }
        public string place { get; set; }
        public string workoutTimeNeed { get; set; }
        public string workoutDaysneed { get; set; }
        public int workoutTotalSets { get; set; }
        public string workoutLevel { get; set; }



    }
}
