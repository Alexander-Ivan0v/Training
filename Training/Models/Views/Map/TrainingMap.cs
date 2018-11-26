using AutoMapper;

namespace Training.Models.Views.Map
{
    public class TrainingMap : Profile
    {   
        public TrainingMap()
        {
            CreateMap<Views.Training, Entities.Training>();
        }
    }
}
