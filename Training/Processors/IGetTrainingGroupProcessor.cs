using System.Collections.Generic;
using System.Threading.Tasks;

namespace Training.Processors
{
    public interface IGetTrainingGroupProcessor
    {
        Task<IList<Models.Entities.TrainingGroup>> GetAsync();
        Task<Models.Entities.TrainingGroup> GetAsync(int Id);
        Task<Models.Entities.TrainingGroup> GetAsync(string Name);
    }
}
