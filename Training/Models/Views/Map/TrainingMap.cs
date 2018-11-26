using FluentNHibernate.Mapping;


namespace Training.Models.Views.Map
{
    public class TrainingMap : ClassMap<Views.Training>
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
