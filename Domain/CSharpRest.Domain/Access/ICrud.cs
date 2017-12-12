using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRest.Domain.Access
{
    interface ICrud<T>
    {
        T Create(T entity, DateTime createDate);

        T Read(int id);

        T Update(T entity, DateTime updateDate);

        void Delete(T entity);
    }
}
