using DAL.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public abstract class RepositoryBLL<T> where T : BaseEntity
    {
       
            Repository<T> repo = new Repository<T>();

            public void AddBll(T obj)
            {
                try
                {
                    repo.AddDal(obj);
                }
                catch (Exception)
                {

                    throw;
                }

            }

            public void DeleteBll(T obj)
            {
                try
                {
                    repo.DeleteDal(obj);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            public List<T> ListBll()
            {
                try
                {
                    return repo.ListDal();
                }
                catch (Exception)
                {

                    throw;
                }

            }
            public T GetByIdBll(int id)
            {
                try
                {
                    return repo.GetbyIdDal(id);
                }
                catch (Exception)
                {

                    throw;
                }


            }

            public void UpdateBll(int id, T obj)
            {
                try
                {
                    repo.UpdateDal(id, obj);
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }
}
