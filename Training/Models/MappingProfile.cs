using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Training.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Entities.Training, Views.Training>().ForMember(opt => opt.Links, x => x.Ignore()); ;
            CreateMap<Entities.TrainingGroup, Views.TrainingGroup>().ForMember(opt => opt.Links, x => x.Ignore()); ;
        }
    }
}
