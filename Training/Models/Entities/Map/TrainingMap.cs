using AutoMapper;

namespace Training.Models.Entities.Map
{
    public class TrainingMap : Profile
    {   
        public TrainingMap()
        {
            CreateMap<Entities.Training, Views.Training>(); //.ConvertUsing<TrainingMapConverter>();
        }
    }
}
