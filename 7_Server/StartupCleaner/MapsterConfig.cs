using System;
using ExpressionDebugger;
using illegible.Entity.BlogEntity.Post;
using illegible.Shared.SharedDto.BlogPost;
using Mapster;
using System.Linq.Expressions;
using System.Reflection;

namespace illegible.Server.StartupCleaner
{
    // this class method's defined for config diffrent and common ways of mapster mapping
    // and method's define as singlton Services in
    //===>> StartUpCleaner.ServicesCollectionExtensions.AddConventionalService
    public static class MapsterConfig
    {
        public static TypeAdapterConfig GetConfiguredMappingConfig()
        {
            // config mapster type adapter 
            // according mapster gitHub CoreSampleProject (see docs and beyond for more detail)
            // i'm  using ExpressionDebugger.dll (system.linq additional library)
            // ==> installed on core layer
            // to compile mapster mapping with debug info 
            // so i have more easier debugging on mapping
            var config = new TypeAdapterConfig
            {
                Compiler = exp => exp.CompileWithDebugInfo(
                    new ExpressionCompilationOptions
                    {
                        EmitFile = true,
                        ThrowOnFailedCompilation = true
                    })
            };
            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetEntryAssembly());

            #region BlogPost 

            //twoWays Method is like reverseMap method in AutoMapper
            config.NewConfig<BlogPostDto, BlogPost>();
                //.PreserveReference(true);// this method (PreserveReference(true)) enable nested object mapping in mapster
            
            #endregion

            return config;
        }
    }
}
