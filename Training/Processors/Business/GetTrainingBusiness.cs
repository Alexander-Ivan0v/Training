using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Training.Processors.Business
{
    public class GetTrainingBusiness : IGetTrainingBusiness
    {
        private readonly IGetTrainingProcessor _training;
        private readonly IMapper _mapper;

        public GetTrainingBusiness(IGetTrainingProcessor training, IMapper mapper)
        {
            _training = training;
            _mapper = mapper;
        }

        public async Task<IList<Models.Views.Training>> GetAsync()
        {
            List<Models.Views.Training> ret = new List<Models.Views.Training>();
            await Task.Run(() => _training.GetAsync().Result.ToList().ForEach(x => ret.Add(_mapper.Map<Models.Entities.Training, Models.Views.Training>(x))));

            return ret;
        }
        public async Task<Models.Views.Training> GetAsync(int Id)
        {
            return null;
        }
        public async Task<Models.Views.Training> GetAsync(string Name)
        {
            return null;
        }
        public async Task<List<Models.Views.Training>> GetByGroupAsync(string Group)
        {
            List<Models.Views.Training> ret = new List<Models.Views.Training>();
            await Task.Run(() => _training.GetByGroupAsync(Group).Result.ToList().ForEach(x => ret.Add(_mapper.Map<Models.Entities.Training, Models.Views.Training>(x))));

            return ret;
        }
    }
}
