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

namespace DaanV2.Config {
    public static partial class ConfigMapper {
        /// <summary>Pre initializes the values inside of this class</summary>
        /// <param name="LoadConfigObjects">Marks if it should load the given objects from the loaded assemblies</param>
        /// <exception cref="AppDomainUnloadedException" />
        /// <exception cref="AmbiguousMatchException" />
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FileNotFoundException" />
        /// <exception cref="NotSupportedException" />
        /// <exception cref="OverflowException" />
        /// <exception cref="TypeLoadException" />
        public static void Preload(Boolean LoadConfigObjects = true) {
            //Preload the config loader
            ConfigLoader.Preload();

            if (LoadConfigObjects) {
                //Load config objects from assemblies
                Assembly[] Assemblies = AppDomain.CurrentDomain.GetAssemblies();

                for (Int32 I = 0; I < Assemblies.Length; I++) {
                    Preload(Assemblies[I]);
                }
            }
        }

        /// <summary>Looks through the given assembly looking for config objects and load them into memory. Creating files if they are not present.</summary>
        /// <param name="assembly">The assembly to preload</param>
        /// <exception cref="AmbiguousMatchException" />
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FileNotFoundException" />
        /// <exception cref="NotSupportedException" />
        /// <exception cref="OverflowException" />
        /// <exception cref="TypeLoadException" />
        public static void Preload(Assembly assembly) {
            Type[] Types = assembly.GetExportedTypes();

            //Loop through types looking for the config
            for (Int32 I = 0; I < Types.Length; I++) {
                if (Types[I].GetCustomAttribute(typeof(ConfigAttribute)) != null && Types[I].IsClass) {
                    ConfigMapper.Get(Types[I]);
                }
            }
        }
    }
}
