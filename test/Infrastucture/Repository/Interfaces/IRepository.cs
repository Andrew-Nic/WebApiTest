using CQRStest.Application.DTOs.ModulesDTO;

namespace CQRStest.Infrastucture.Repository.Interfaces
{
    /// <summary>
    /// asdadasdadauyfsdgugg
    /// </summary>
    /// <typeparam name="T">Entidad General</typeparam>
    /// <typeparam name="S">Entidad para actualizar</typeparam>
    public interface IRepository<T, S> where T : class where S : class
    {

        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        Task<T> Create(T entity);
        Task<S> Update(S entity);
        Task<bool> Delete(int id);

    }
}
