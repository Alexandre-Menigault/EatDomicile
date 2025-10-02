namespace EatDomicile.Core.Exceptions;

public class EntityAlreadyExistsException<TEntity> : Exception
{
    public EntityAlreadyExistsException(string propertyName, string name)
    : base($"Entity {typeof(TEntity).Name} alraedy exists with {propertyName} = {name}")
    {
        
    }
}