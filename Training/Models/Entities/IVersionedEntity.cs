namespace Training.Models.Entities
{
    public interface IVersionedEntity
    {
        uint xmin { get; set; }
    }
}