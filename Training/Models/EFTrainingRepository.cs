using System.Collections.Generic;
using System.Linq;
namespace Training.Models
{
    public class EFTrainingRepository : ITrainingRepository
    {
        private readonly ApplicationDbContext _context;
        public EFTrainingRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Entities.Training> Training => _context.Training;
        public IQueryable<Entities.TrainingGroup> TrainingGroup => _context.TrainingGroup;
        public IQueryable<Entities.TrainingGroupTraining> TrainingGroupTraining => _context.TrainingGroupTraining;
    }
}