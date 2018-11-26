// http://www.entityframeworktutorial.net/efcore/configure-many-to-many-relationship-in-ef-core.aspx
// http://www.entityframeworktutorial.net/efcore/configure-one-to-many-relationship-using-fluent-api-in-ef-core.aspx

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training.Models.Entities
{
    public class TrainingGroupTraining
    {
        [Required]
        public int TrainingGroupId { get; set; }
        public TrainingGroup TrainingGroup { get; set; }

        [Required]
        public int TrainingId { get; set; }
        public Training Training { get; set; }
        
    }
}
