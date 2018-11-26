// https://www.learnentityframeworkcore.com/dbset/querying-data

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.Models;

namespace Training.Processors
{
    public class GetTrainingProcessor : IGetTrainingProcessor
    {
        private readonly ITrainingRepository _repo;

        public GetTrainingProcessor(ITrainingRepository repo)
        {
            _repo = repo;
        }

        public async Task<IList<Models.Entities.Training>> GetAsync()
        {
            return await _repo.Training.ToListAsync();
        }
        public async Task<Models.Entities.Training> GetAsync(int Id)
        {
            return await Task.Run( () => _repo.Training.Where(x => x.Id == Id).FirstOrDefault());
        }
        public async Task<Models.Entities.Training> GetAsync(string Name)
        {
            return await Task.Run( () => _repo.Training.Where(x => x.Name == Name).FirstOrDefault());
        }
        public async Task<List<Models.Entities.Training>> GetByGroupAsync(string Group)
        {
            var tgt = Task.Run(() => _repo.TrainingGroupTraining.Where(y => y.TrainingGroup.Name == Group).FirstOrDefault()).Result;
            if (tgt != null)
            {
                return await Task.Run( () => _repo.Training.Where(x => x.Id == tgt.TrainingId).ToList());
            }
            else return null;
        }
    }
}
