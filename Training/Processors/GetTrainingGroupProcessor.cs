// https://www.learnentityframeworkcore.com/dbset/querying-data

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.Models;

namespace Training.Processors
{
    public class GetTrainingGroupProcessor : IGetTrainingGroupProcessor
    {
        private readonly ITrainingRepository _repo;

        public GetTrainingGroupProcessor(ITrainingRepository repo)
        {
            _repo = repo;
        }

        public async Task<IList<Models.Entities.TrainingGroup>> GetAsync()
        {
            return await _repo.TrainingGroup.ToListAsync();
        }
        public async Task<Models.Entities.TrainingGroup> GetAsync(int Id)
        {
            return await Task.Run(() => _repo.TrainingGroup.Where(x => x.Id == Id).FirstOrDefault());
        }
        public async Task<Models.Entities.TrainingGroup> GetAsync(string Name)
        {
            return await Task.Run(() => _repo.TrainingGroup.Where(x => x.Name == Name).FirstOrDefault());
        }
    }
}
