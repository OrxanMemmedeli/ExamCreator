namespace DataAccess.Abstract.Generic
{
    public interface IGenericDal<T> : IGenericBaseDal<T> where T : class
    {
        //Task Update(T t, Guid id);
        Task Delete(T t);

    }
}
