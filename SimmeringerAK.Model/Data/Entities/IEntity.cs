using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimmeringerAK.Model.Data.Entities
{
    interface IEntity<T>
    {
        void Add(T entity);
        void Remove(T entity);
    }
}
