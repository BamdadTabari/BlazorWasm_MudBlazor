using System;

namespace illegible.Shared.BaseDTO
{
    public abstract class BlogBaseDTO<T>
    {
        public T Id { get; set; }

        // last changes datetime
        // map this shiit in your every create and update
        // (keep calm it's done automaticly here)
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }

    // this is defualt for id 
    //you see default id type is long
    // but if need to have diffrent type
    // just depend yor entity directly to ----> BaseEntity<T>
    public abstract class BlogBaseDTO : BlogBaseDTO<long>
    {
    }

}
