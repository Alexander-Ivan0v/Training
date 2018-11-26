using FluentNHibernate.Mapping;

namespace Training.Models.Entities.Map
{
    public class TrainingMap : ClassMap<Entities.Training>
    {   
        public TrainingMap()
        {
            Id(x => x.Id);
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Descr).Not.Nullable();
            Map(x => x.Program).Nullable();
            Map(x => x.Duration).Not.Nullable();
        }
    }
}
