namespace EatDomicile.Core.Exceptions;

public class EntityCollectionPropertyIsEmptyException<TEntity> : Exception
{
    public EntityCollectionPropertyIsEmptyException(string propertyName) : 
        base($"{typeof(TEntity).Name} collection property {propertyName} is empty. Please add at least one {typeof(TEntity).Name}")
    {
    }
}