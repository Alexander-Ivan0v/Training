using System.Collections.Generic;
using System.Threading.Tasks;

namespace Training.Processors.Business
{
    public interface IGetTrainingBusiness
    {
        Task<IList<Models.Views.Training>> GetAsync();
        Task<Models.Views.Training> GetAsync(int Id);
        Task<Models.Views.Training> GetAsync(string Name);
        Task<List<Models.Views.Training>> GetByGroupAsync(string Group);
    }
}
