using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace illegible.DataStructure.DataDefineExtentions
{
    public static class DataDefineExtentions
    {
        public static void RegisterAllEntities<BaseType>
            (this ModelBuilder modelBuilder
            , params Assembly[] assemblies)
        {
            IEnumerable<Type> types =
                assemblies.SelectMany(a => a.GetExportedTypes())
                .Where(c => c.IsClass &&
                !c.IsAbstract &&
                c.IsPublic &&
                typeof(BaseType).IsAssignableFrom(c));

            foreach (Type type in types)
            {
                modelBuilder.Entity(type);
            }
        }

        public static void RegisterEntityTypeConfiguration
            (this ModelBuilder modelBuilder,
            params Assembly[] assemblies)
        {
            MethodInfo applyGenericMethod = typeof(ModelBuilder).GetMethods()
                .First(m => m.Name == nameof(ModelBuilder.ApplyConfiguration));

            IEnumerable<Type> types = assemblies.SelectMany(a => a.GetExportedTypes())
                .Where(c => c.IsClass && !c.IsAbstract && c.IsPublic);

            foreach (Type type in types)
            {
                foreach (Type iface in type.GetInterfaces())
                {
                    if (iface.IsConstructedGenericType && iface.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                    {
                        MethodInfo applyConcreteMethod = applyGenericMethod.MakeGenericMethod(iface.GenericTypeArguments[0]);
                        applyConcreteMethod.Invoke(modelBuilder, new object[] { Activator.CreateInstance(type) });
                    }
                }
            }
        }
    }
}
