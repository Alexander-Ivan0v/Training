using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Training.Models.Views
{
    public class Training
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descr { get; set; }
        public string Program { get; set; }
        public int Duration { get; set; }

        public IList<Views.TrainingGroup> TrainingGroup { get; set; }
    }
}
