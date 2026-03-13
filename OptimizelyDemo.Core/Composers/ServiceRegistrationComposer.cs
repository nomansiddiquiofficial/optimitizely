using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Reflection;

namespace OptimizelyDemo.Core.Composers
{
    public static class ServiceRegistrationComposer
    {
        public static IServiceCollection AddOptimizelyDemoCoreServices(this IServiceCollection services)
        {
            try
            {
                // Get the current assembly
                Assembly assembly = Assembly.GetExecutingAssembly();

                // Get all types in the assembly
                var classesInNamespace = assembly.GetTypes();

                foreach (var repositoryClass in classesInNamespace)
                {
                    string _namespace = repositoryClass.DeclaringType == null ? repositoryClass.FullName : repositoryClass.DeclaringType.FullName;
                    
                    // Exclude base/common classes, interfaces, abstract classes, and compiler-generated classes
                    if (repositoryClass is { IsAbstract: false, IsClass: true, IsInterface: false } &&
                        _namespace != null && 
                        _namespace.Contains(".Repositories.") && 
                        !_namespace.Contains("Common") && 
                        !repositoryClass.Name.Contains("<>"))
                    {
                        // Register interfaces implemented by this class
                        var interfaces = repositoryClass.GetInterfaces();
                        foreach (var iface in interfaces)
                        {
                            services.AddScoped(iface, repositoryClass);
                        }
                        
                        // Register the concrete type itself (mirroring DFGCComposer behaviour)
                        services.AddScoped(repositoryClass);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error registering core repository services in ServiceRegistrationComposer");
                throw;
            }

            return services;
        }
    }
}
