//using Mapster;
//using MapsterMapper;
//using System;

//namespace illegible.Shared.SharedServices.Service
//{
//    // you see i inherit from mapper object 
//    // mapper object inherit from IMapper Interface (it's defined in mapster assembly)
//    // We Define IMapper Again
//    // To Have more access to mapster method's
//    // (in case of add additional methods and more(actually he do it for having fun during learning : illegible said))
//    public class ServiceMapper : Mapper
//    {
//        // ok , i'm not sure but it seems this const string
//        // define Mapster Global Configuration with Dependency Injection
//        // i think "sp" in the end of it stand's for stored procedure
//        internal const string DI_KEY = "Mapster.DependencyInjection.sp";
//        private readonly IServiceProvider _serviceProvider;

//        public ServiceMapper(IServiceProvider serviceProvider,
//            TypeAdapterConfig config) : base(config)
//        {
//            _serviceProvider = serviceProvider;
//        }


//        // this method get's source of mapping  operation object
//        // by adding ProjectToType method in the end of that and passing TDestination
//        // It's Complete mapping operation
//        // we can use it for additional inline configs during mapping
//        public override TypeAdapterBuilder<TSource> From<TSource>(TSource source)
//        {
//            return base.From(source)
//                .AddParameters(DI_KEY, _serviceProvider);
//        }

//        // actually these are defined in Mapster.DependencyInjection Library
//        // yeah now i can see you was right i'm doing it just for fun during learning 
//        #region Related Method's that Config MapsterDependencies Injection

//        public override TDestination Map<TDestination>(object source)
//        {
//            using var scope = new MapContextScope();
//            scope.Context.Parameters[DI_KEY] = _serviceProvider;
//            return base.Map<TDestination>(source);
//        }

//        public override TDestination Map<TSource, TDestination>(TSource source)
//        {
//            using var scope = new MapContextScope();
//            scope.Context.Parameters[DI_KEY] = _serviceProvider;
//            return base.Map<TSource, TDestination>(source);
//        }

//        public override TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
//        {
//            using var scope = new MapContextScope();
//            scope.Context.Parameters[DI_KEY] = _serviceProvider;
//            return base.Map(source, destination);
//        }

//        public override object Map(object source, Type sourceType, Type destinationType)
//        {
//            using var scope = new MapContextScope();
//            scope.Context.Parameters[DI_KEY] = _serviceProvider;
//            return base.Map(source, sourceType, destinationType);
//        }

//        public override object Map(object source, object destination, Type sourceType, Type destinationType)
//        {
//            using var scope = new MapContextScope();
//            scope.Context.Parameters[DI_KEY] = _serviceProvider;
//            return base.Map(source, destination, sourceType, destinationType);
//        }

//        #endregion

//    }
//}
