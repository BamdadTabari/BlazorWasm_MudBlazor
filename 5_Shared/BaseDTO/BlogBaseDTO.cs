using System;

namespace illegible.Shared.BaseDto
{
    public abstract class BlogBaseDto<T>
    {
        public T Id { get; set; }

        // last changes datetime
        // map this shit in your every create and update
        // (keep calm it's done here)
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }

    // this is default for id 
    //you see default id type is long
    // but if need to have different type
    // just depend yor entity directly to ----> BaseEntity<T>
    public abstract class BlogBaseDto : BlogBaseDto<long?>
    {
    }

}
