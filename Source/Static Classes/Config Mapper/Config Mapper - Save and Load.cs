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
        /// <summary>Loads a given type from the file</summary>
        /// <param name="T">DOLATER FILL IN</param>
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
        public static void Load(Type T)
        {
            String Name = GetName(T);
            Object Temp = ConfigLoader.LoadConfig(T, Name);

            ConfigMapper._Configs[T] = Temp;
        }

        /// <summary>Saves the given type into a file</summary>
        /// <param name="T">DOLATER FILL IN</param>
        /// <exception cref="AmbiguousMatchException" />
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="DirectoryNotFoundException" />
        /// <exception cref="FileNotFoundException" />
        /// <exception cref="IOException" />
        /// <exception cref="InvalidOperationException" />
        /// <exception cref="NotSupportedException" />
        /// <exception cref="PathTooLongException" />
        /// <exception cref="SecurityException" />
        /// <exception cref="UnauthorizedAccessException" />
        public static void Save(Type T)
        {
            if (ConfigMapper._Configs.ContainsKey(T))
            {
                ConfigLoader.SaveConfig(_Configs[T], GetName(T));
            }
        }

        /// <summary>saves all the config in memory to a file</summary>
        /// <exception cref="AmbiguousMatchException" />
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="DirectoryNotFoundException" />
        /// <exception cref="FileNotFoundException" />
        /// <exception cref="IOException" />
        /// <exception cref="InvalidOperationException" />
        /// <exception cref="NotSupportedException" />
        /// <exception cref="PathTooLongException" />
        /// <exception cref="SecurityException" />
        /// <exception cref="UnauthorizedAccessException" />
        public static void SaveAll()
        {
            var Keys = new Type[ConfigMapper._Configs.Count];
            ConfigMapper._Configs.Keys.CopyTo(Keys, 0);
            Type Key;
            Object Item;

            for (Int32 I = 0; I < Keys.Length; I++)
            {
                Key = Keys[I];

                if (ConfigMapper._Configs.ContainsKey(Key))
                {
                    Item = ConfigMapper._Configs[Key];

                    ConfigLoader.SaveConfig(Item, GetName(Key));
                }
            }
        }
    }
}
