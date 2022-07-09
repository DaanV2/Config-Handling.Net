/*ISC License

Copyright(c) 2019, Daan Verstraten, daanverstraten@hotmail.com

Permission to use, copy, modify, and/or distribute this software for any
purpose with or without fee is hereby granted, provided that the above
copyright notice and this permission notice appear in all copies.


THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES
WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF
MERCHANTABILITY AND FITNESS.IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR
ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES
WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN
ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF
OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.*/
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;

namespace DaanV2.Config
{
    public static partial class ConfigMapper
    {
        /// <summary>Sets the given config under the given key</summary>
        /// <param name="Key">The key to set the config under, use the configs own type! but this function allows to bypass that</param>
        /// <param name="ConfigObject">The config object to set under the given key</param>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        public static void Set(Type Key, Object ConfigObject)
        {
            ConfigMapper._Configs[Key] = ConfigObject;
        }

        /// <summary>Sets the given config</summary>
        /// <param name="ConfigObject">DOLATER FILL IN</param>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        public static void Set(Object ConfigObject)
        {
            Type T = ConfigObject.GetType();

            ConfigMapper._Configs[T] = ConfigObject;
        }

        /// <summary>Retrieves the config using the given type, either loads it from memory or from the file, if none are succesfull a new instance is created and saved</summary>
        /// <param name="T">the object type to get</param>
        /// <returns>Returns a <see cref="Object"/></returns>
        /// <exception cref="AmbiguousMatchException" />
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="COMException" />
        /// <exception cref="DirectoryNotFoundException" />
        /// <exception cref="FileNotFoundException" />
        /// <exception cref="InvalidComObjectException" />
        /// <exception cref="IOException" />
        /// <exception cref="MethodAccessException" />
        /// <exception cref="MemberAccessException" />
        /// <exception cref="MissingMethodException" />
        /// <exception cref="NotSupportedException" />
        /// <exception cref="PathTooLongException" />
        /// <exception cref="SecurityException" />
        /// <exception cref="TypeLoadException" />
        /// <exception cref="TargetInvocationException" />
        /// <exception cref="UnauthorizedAccessException" />
        public static Object Get(Type T)
        {
            if (!ConfigMapper._Configs.ContainsKey(T))
            {
                Load(T);
            }

            return ConfigMapper._Configs[T];
        }

        /// <summary>Retrieves the config using the given type, either loads it from memory or from the file, if none are succesfull a new instance is created and saved</summary>
        /// <typeparam name="T">The config object to be returned</typeparam>
        /// <returns>Retrieves the config using the given type, either loads it from memory or from the file, if none are succesfull a new instance is created and saved</returns>
        /// <exception cref="AmbiguousMatchException" />
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="COMException" />
        /// <exception cref="DirectoryNotFoundException" />
        /// <exception cref="FileNotFoundException" />
        /// <exception cref="InvalidComObjectException" />
        /// <exception cref="IOException" />
        /// <exception cref="MethodAccessException" />
        /// <exception cref="MemberAccessException" />
        /// <exception cref="MissingMethodException" />
        /// <exception cref="NotSupportedException" />
        /// <exception cref="PathTooLongException" />
        /// <exception cref="SecurityException" />
        /// <exception cref="TypeLoadException" />
        /// <exception cref="TargetInvocationException" />
        /// <exception cref="UnauthorizedAccessException" />
        public static T Get<T>()
        {
            Type Temp = typeof(T);

            if (!ConfigMapper._Configs.ContainsKey(Temp))
            {
                Load(Temp);
            }

            return (T)ConfigMapper._Configs[Temp];
        }

        /// <summary>Retrieves the config using the given type, either loads it from memory or from the file, if none are succesfull a new instance is created and saved</summary>
        /// <param name="T">the object type to get</param>
        /// <param name="PresistObject">If true the object is stored in memory, if false then the config is just loaded from the file</param>
        /// <returns>Returns a <see cref="Object"/></returns>
        /// <exception cref="AmbiguousMatchException" />
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="COMException" />
        /// <exception cref="DirectoryNotFoundException" />
        /// <exception cref="FileNotFoundException" />
        /// <exception cref="InvalidComObjectException" />
        /// <exception cref="IOException" />
        /// <exception cref="MethodAccessException" />
        /// <exception cref="MemberAccessException" />
        /// <exception cref="MissingMethodException" />
        /// <exception cref="NotSupportedException" />
        /// <exception cref="PathTooLongException" />
        /// <exception cref="SecurityException" />
        /// <exception cref="TypeLoadException" />
        /// <exception cref="TargetInvocationException" />
        /// <exception cref="UnauthorizedAccessException" />
        public static Object Get(Type T, Boolean PresistObject)
        {
            if (PresistObject)
            {
                if (!ConfigMapper._Configs.ContainsKey(T))
                {
                    Load(T);
                }

                return ConfigMapper._Configs[T];
            }

            String Name = GetName(T);
            return ConfigLoader.LoadConfig(T, Name);
        }

        /// <summary>Retrieves the config using the given type, either loads it from memory or from the file, if none are succesfull a new instance is created and saved</summary>
        /// <typeparam name="T">The config object to be returned</typeparam>
        /// <param name="PresistObject">If true the object is stored in memory, if false then the config is just loaded from the file</param>
        /// <returns>Retrieves the config using the given type, either loads it from memory or from the file, if none are succesfull a new instance is created and saved</returns>
        /// <exception cref="AmbiguousMatchException" />
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="COMException" />
        /// <exception cref="DirectoryNotFoundException" />
        /// <exception cref="FileNotFoundException" />
        /// <exception cref="InvalidComObjectException" />
        /// <exception cref="IOException" />
        /// <exception cref="MethodAccessException" />
        /// <exception cref="MemberAccessException" />
        /// <exception cref="MissingMethodException" />
        /// <exception cref="NotSupportedException" />
        /// <exception cref="PathTooLongException" />
        /// <exception cref="SecurityException" />
        /// <exception cref="TypeLoadException" />
        /// <exception cref="TargetInvocationException" />
        /// <exception cref="UnauthorizedAccessException" />
        public static T Get<T>(Boolean PresistObject)
        {
            Type Temp = typeof(T);

            if (PresistObject)
            {
                if (!ConfigMapper._Configs.ContainsKey(Temp))
                {
                    Load(Temp);
                }

                return (T)ConfigMapper._Configs[Temp];
            }

            String Name = GetName(Temp);
            return ConfigLoader.LoadConfig<T>(Name);
        }
    }
}
