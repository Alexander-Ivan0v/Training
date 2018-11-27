using AutoMapper;

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
