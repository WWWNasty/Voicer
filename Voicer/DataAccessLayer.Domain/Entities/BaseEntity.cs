namespace DataAccessLayer.Models.Entities
{
    public abstract class Entity<TId>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public TId Id { get; set; }

    }
}