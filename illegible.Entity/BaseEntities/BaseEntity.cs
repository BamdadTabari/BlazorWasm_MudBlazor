using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace illegible.Entity.BaseEntities
{
    //defined for reflection
    public interface IBaseEntity
    {
    }
    public abstract class BaseEntity<T> : IBaseEntity
    {
        public T Id { get; set; }

        // last changes datetime
        // map this shiit in your every create and update
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }

    // this is defualt for id 
    //you see default id type is long
    // but if need to have diffrent type
    // just depend yor entity directly to ----> BaseEntity<T>
    public abstract class BaseEntity : BaseEntity<long>
    {
    }
}
