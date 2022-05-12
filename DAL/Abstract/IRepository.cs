using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IRepository<T> where T : BaseEntity
    {
        void AddDal(T obje);
        void UpdateDal(int id, T obje);
        void DeleteDal(T obje);
        List<T> ListDal();
        T GetbyIdDal(int id);
    }
}
