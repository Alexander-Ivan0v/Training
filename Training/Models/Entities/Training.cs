// http://www.entityframeworktutorial.net/efcore/configure-many-to-many-relationship-in-ef-core.aspx
// http://www.entityframeworktutorial.net/efcore/configure-one-to-many-relationship-using-fluent-api-in-ef-core.aspx

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training.Models.Entities
{
    public class Training : IVersionedEntity
    {
        [Key]
        public virtual int Id { get; set; }
        [Required]
        public virtual string Name { get; set; }
        [Required]
        public virtual string Descr { get; set; }        
        public virtual string Program { get; set; }
        [Required]
        public virtual int Duration { get; set; }
        [ConcurrencyCheck]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //[NotMapped] 
        public virtual uint xmin { get; set; }

        // For EF (Migration)
        //public IList<TrainingGroupTraining> TrainingGroupTraining { get; set; }
    }
}
