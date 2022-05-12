using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IRepository<T> where T : BaseEntity
    {
        void AddBll(T obje);
        void UpdateBll(int id, T obje);
        void DeleteBll(T obje);
        List<T> ListBll();
        T GetByIdBll(int id);
    }
}
