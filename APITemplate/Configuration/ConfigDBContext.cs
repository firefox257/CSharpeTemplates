using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration
{
    /// <summary>
    /// Class to hold all the database context creations for dependency creations.
    /// </summary>
    public class ConfigDBContext
    {
        public static Dictionary<string, KeyValuePair<Type, Type>> DbContextList = new Dictionary<string, KeyValuePair<Type, Type>>();  
        public static void Setup(object service, Type extension)
        {
            if (DbContextList.Count > 0)
            {
                var info = extension.GetMethods().Where(m => m.Name == "AddDbContext" && m.IsPublic && m.IsGenericMethod && m.ContainsGenericParameters && m.GetGenericArguments().Count() == 2).First();
                foreach (var i in DbContextList)
                {
                    var addMethod = info.MakeGenericMethod(i.Value.Key, i.Value.Value);
                    addMethod.Invoke(service, new object[] {service, null, null, null});
                }
            }
        }
        public static void AddDbContext<T1, T2>()
        {
            Type t1 = typeof(T1);
            Type t2 = typeof(T2);
            KeyValuePair<Type, Type> t = new KeyValuePair<Type, Type>(t1, t2);
            DbContextList[t1.Name] = t;
        }
    }
}
