using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using AutoMapper;
namespace Configuration
{
    /// <summary>
    /// A place to hold all configuration mappers to be configured at a later time. 
    /// </summary>
    public class ConfigMappers
    {
        public static Dictionary<string, KeyValuePair<Type, Type>> ConfigMapper = new Dictionary<string, KeyValuePair<Type, Type>>();
        public static void Setup(object service, Type extension)
        {
            if (ConfigMapper.Count > 0)
            {
                var info = extension.GetMethods().Where(m => m.Name == "CreateMap" && m.IsPublic && m.IsGenericMethod && m.ContainsGenericParameters && m.GetGenericArguments().Count() == 2).First();
                foreach (var i in ConfigMapper)
                {
                    var addMethod = info.MakeGenericMethod(i.Value.Key, i.Value.Value);
                    addMethod.Invoke(service, null);
                }
            }
        }
        public static void CreateMap<T1, T2>()
        {
            Type t1 = typeof(T1); 
            Type t2 = typeof(T2);
            KeyValuePair<Type, Type> t = new KeyValuePair<Type, Type>(t1, t2);
            ConfigMapper[$"{t1.FullName},{t2.FullName}"] = t;
        }
    }
}
