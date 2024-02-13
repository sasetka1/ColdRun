using OperationResult;

namespace ColdRun.API.Services.Interfaces
{
    public interface IDataValidatorService<T, TU>
        where T : class, new()
        where TU : class, new()
    {
        /// <summary>
        /// Validates an entity fields.
        /// </summary>
        /// <param name="entity">An  entity</param>
        /// <returns>Returns Ok if field has valid fields, otherwise returns an Error with list of error descriptions</returns>
        public bool ValidateEntity(T? currentEntity, TU newEntity );

    }
}
