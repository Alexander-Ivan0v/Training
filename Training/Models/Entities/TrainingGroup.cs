
// http://www.entityframeworktutorial.net/efcore/configure-many-to-many-relationship-in-ef-core.aspx
// http://www.entityframeworktutorial.net/efcore/configure-one-to-many-relationship-using-fluent-api-in-ef-core.aspx

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training.Models.Entities
{
    public class TrainingGroup
    {
        private readonly IList<Training> _training = new List<Training>();

        [Key]
        public virtual int Id { get; set; }
        [Required]
        public virtual string Name { get; set; }
        [ConcurrencyCheck]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //[NotMapped] 
        public virtual string Version { get; set; }

        public IList<Training> Training
        {
            get { return _training; }
        }
    }
}
