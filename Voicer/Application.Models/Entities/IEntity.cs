namespace DataAccessLayer.Models.Entities
{
    public interface IEntity<TId>
    {
        TId Id { get; set; }
    }
}