using BLL.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class EmployeeManager : RepositoryBLL<Employee>, IEmployeeManager
    {
    }
}
