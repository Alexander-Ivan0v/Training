using System.Linq;

namespace Training.Models
{
    public interface ITrainingRepository
    {
        IQueryable<Entities.Training> Training { get; }
        IQueryable<Entities.TrainingGroup> TrainingGroup { get; }
        // IQueryable<Entities.TrainingGroupTraining> TrainingGroupTraining { get; }
    }
}