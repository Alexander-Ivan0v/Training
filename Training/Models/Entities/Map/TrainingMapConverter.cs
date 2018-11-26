// https://github.com/AutoMapper/AutoMapper.Extensions.Microsoft.DependencyInjection/issues/11

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Training.Models.Entities.Map
{
    public class TrainingMapConverter : ITypeConverter<Entities.Training, Views.Training>
    {
        private readonly ITrainingRepository _repo;
        private readonly IMapper _mapper;
        public TrainingMapConverter(ITrainingRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public Views.Training Convert(Entities.Training source, Views.Training destination, ResolutionContext context)
        {
            if (context == null || source == null) return null;

            List<Views.TrainingGroup> tg = new List<Views.TrainingGroup>();            
            GetTrainingGroupsForTraining(source.Id).ForEach(x => tg.Add(_mapper.Map<Entities.TrainingGroup, Views.TrainingGroup>(x)));

            Views.Training ret = new Views.Training()
            {
                Id = source.Id,
                Name = source.Name,
                Descr = source.Descr,
                Program = source.Program,
                Duration = source.Duration,
                TrainingGroup = tg
            };

            return ret;
        }

        private List<Entities.TrainingGroup> GetTrainingGroupsForTraining(int trainingId)
        {
            List<Entities.TrainingGroup> tg = new List<Entities.TrainingGroup>();
            _repo.TrainingGroupTraining.Where(x => x.TrainingId == trainingId)
                                       .Select(y => y.TrainingGroupId)
                                       .ToList().ForEach(z => tg.Add(_repo.TrainingGroup.Where(a => a.Id == z).SingleOrDefault()));
            return tg;
        }
    }
}
