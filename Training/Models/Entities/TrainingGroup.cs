﻿
// http://www.entityframeworktutorial.net/efcore/configure-many-to-many-relationship-in-ef-core.aspx
// http://www.entityframeworktutorial.net/efcore/configure-one-to-many-relationship-using-fluent-api-in-ef-core.aspx

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training.Models.Entities
{
    public class TrainingGroup
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IList<TrainingGroupTraining> TrainingGroupTraining { get; set; }
    }
}
