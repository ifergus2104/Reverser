using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace FileManager
{
    public class FileFactory<T>
    {
        private readonly Dictionary<string, Type> _factoryDictionary =
            new Dictionary<string, Type>();

        public FileFactory()
        {
            Type[] fileTyepes = Assembly.GetAssembly(typeof(T)).GetTypes();

            foreach (Type type in fileTyepes)
            {
                if (!typeof(T).IsAssignableFrom(type) || type == typeof(T))
                    continue;
                _factoryDictionary.Add(type.Name, type);
            }
        }

        public T Create<F>(params object[] args)
        {
            return (T) Activator.CreateInstance(_factoryDictionary[typeof(F).Name], args);
        }
    }
}
