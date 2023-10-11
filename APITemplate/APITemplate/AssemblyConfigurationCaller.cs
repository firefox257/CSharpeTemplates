using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace APITemplate
{
    /// <summary>
    /// Handel the abbelity for when project references are added, 
    /// to handel adding services, mappers and database contects in a more local way.
    /// </summary>
    public class AssemblyConfigurationCaller
    {
        public static void Setup()
        {

            Assembly[] assemblies = GetSolutionAssemblies();
            foreach (var i in assemblies)
            {
                HandelAssembly(i);
            }
        }
        protected static void HandelAssembly(Assembly i)
        {
            var t1 = i.GetTypes();
            var t = i.GetTypes().Where(t => t.Name == "ConfigInit").ToArray();
            foreach (var m in t)
            {
                var serviceMethod = m.GetMethod("AddServices");
                if (serviceMethod != null)
                {
                    serviceMethod.Invoke(null, null);
                }
                var mapperMethod = m.GetMethod("AddMappers");
                if (mapperMethod != null)
                {
                    mapperMethod.Invoke(null, null);
                }
                var dbContextMethod = m.GetMethod("AddDbContexts");
                if (dbContextMethod != null)
                {
                    dbContextMethod.Invoke(null, null);
                }
                
            }

        }

        protected static Assembly[] GetSolutionAssemblies()
        {
            var assemblies = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
                                .Select(x => Assembly.Load(AssemblyName.GetAssemblyName(x)));
            return assemblies.ToArray();
        }
    }
}
