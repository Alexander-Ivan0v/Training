using FluentNHibernate.Mapping;

namespace Training.Models.Entities.Map
{
    public class TrainingGroupMap : ClassMap<Entities.TrainingGroup>
    {
        public TrainingGroupMap()
        {
            Id(x => x.Id);
            Map(x => x.Name).Not.Nullable();

            HasManyToMany(x => x.Training)
                    .Access.ReadOnlyPropertyThroughCamelCaseField(Prefix.Underscore)
                    .Table("TrainingGroupTraining")
                    .ParentKeyColumn("TrainingGroupId")
                    .ChildKeyColumn("TrainingId");
        }
    }
}
