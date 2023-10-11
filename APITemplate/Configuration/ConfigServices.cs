using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace Configuration
{

    /// <summary>
    /// A place to hold all configuration services to be configured at a later time. 
    /// </summary>
    public class ConfigServices
    {

        static public Dictionary<string, KeyValuePair<Type, Type>> InterfaceSingletonList = new Dictionary<string, KeyValuePair<Type, Type>>();
        static public Dictionary<string, Type> SingletonList = new Dictionary<string, Type>();

        static public Dictionary<string, KeyValuePair<Type, Type>> InterfaceScopeList = new Dictionary<string, KeyValuePair<Type, Type>>();
        static public Dictionary<string, Type> ScopeList = new Dictionary<string, Type>();

        static public Dictionary<string, KeyValuePair<Type, Type>> InterfaceTransientList = new Dictionary<string, KeyValuePair<Type, Type>>();
        static public Dictionary<string, Type> TransientList = new Dictionary<string, Type>();

        static public void Setup(object service, Type extension)
        {
            Add("AddSingleton", service, extension, SingletonList);
            Add("AddSingleton", service, extension, InterfaceSingletonList);
            
            Add("AddScoped", service, extension, ScopeList);
            Add("AddScoped", service, extension, InterfaceScopeList);

            Add("AddTransient", service, extension, TransientList);
            Add("AddTransient", service, extension, InterfaceTransientList);

        }

        static protected void Add(string name, object service, Type extension, Dictionary<string, Type> list)
        {
            if (list.Count > 0)
            {
                var info = extension.GetMethods().Where(m => m.Name == name && m.IsPublic && m.IsGenericMethod && m.ContainsGenericParameters && m.GetGenericArguments().Count() == 1).First();
                foreach (var i in list)
                {
                    var addMethod = info.MakeGenericMethod(i.Value);
                    addMethod.Invoke(service, new object[] { service });
                }
            }
        }

        static protected void Add(string name, object service, Type extension, Dictionary<string, KeyValuePair<Type, Type>> list)
        {
            if (list.Count > 0)
            {
                Console.WriteLine(name);
                var methods = extension.GetMethods();
                var info = methods.Where(m => m.Name == name && m.IsPublic && m.IsGenericMethod && m.ContainsGenericParameters && m.GetGenericArguments().Count() == 2).First();
                foreach (var i in list)
                {
                    var addMethod = info.MakeGenericMethod(i.Value.Key, i.Value.Value);
                    addMethod.Invoke(service, new object[] { service });
                }
            }
        }

        static public void AddSingleton<T>()
        {
            Type t = typeof(T);
            SingletonList[t.Name] = t;
        }
        static public void AddSingleton<T1,T2>()
        {
            Type t1 = typeof(T1);
            Type t2 = typeof(T2);
            KeyValuePair<Type, Type> t = new KeyValuePair<Type, Type>(t1, t2);
            InterfaceSingletonList[t1.Name] = t;
        }

        static public void AddScoped<T>()
        {
            Type t = typeof(T);
            ScopeList[t.Name] = t;
        }
        static public void AddScoped<T1, T2>()
        {
            Type t1 = typeof(T1);
            Type t2 = typeof(T2);
            KeyValuePair<Type, Type> t = new KeyValuePair<Type, Type>(t1, t2);
            InterfaceScopeList[t1.Name] = t;
        }

        static public void AddTransient<T>()
        {
            Type t = typeof(T);
            TransientList[t.Name] = t;
        }
        static public void AddTransient<T1, T2>()
        {
            Type t1 = typeof(T1);
            Type t2 = typeof(T2);
            KeyValuePair<Type, Type> t = new KeyValuePair<Type, Type>(t1, t2);
            InterfaceTransientList[t1.Name] = t;
        }


    }

}