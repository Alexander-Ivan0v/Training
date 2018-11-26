using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Training.Processors
{
    public interface IGetTrainingProcessor
    {
        Task<IList<Models.Entities.Training>> GetAsync();
        Task<Models.Entities.Training> GetAsync(int Id);
        Task<Models.Entities.Training> GetAsync(string Name);
        Task<List<Models.Entities.Training>> GetByGroupAsync(string Group);
    }
}
