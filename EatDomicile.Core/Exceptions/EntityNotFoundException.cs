namespace EatDomicile.Core.Exceptions;

public class EntityNotFoundException<TEntity> : Exception
{
    public EntityNotFoundException(int id) : 
        base($"Entity {typeof(TEntity).Name} not found with id {id}")
    {
    }
}