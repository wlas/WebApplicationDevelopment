namespace WebApplicationDevelopment.Interfaces
{
	public interface IEntityService<Entity>
	{
		IEnumerable<Entity> GetEntitys();
		Entity? GetEntity(int id);
		void SaveEntity(Entity entity);
		bool DeleteEntity(int id);
	}
}
