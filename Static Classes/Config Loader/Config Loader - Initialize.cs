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
using DaanV2.Config.Serialization;
using System;
using System.Collections.Concurrent;
using System.Reflection;

namespace DaanV2.Config {
    /// <summary>The static class responsible for serializing/deserializing object into the files</summary>
    public static partial class ConfigLoader {
        /// <summary>Initializes the instance of <see cref="ConfigLoader"/></summary>
        static ConfigLoader() {
            ConfigLoader._Factories = new ConcurrentDictionary<String, IConfigSerializerFactory>();

            Assembly[] Assemblies = AppDomain.CurrentDomain.GetAssemblies();

            for (Int32 I = 0; I < Assemblies.Length; I++) {
                ConfigLoader.AddFactories(Assemblies[I]);
            }

            ConfigLoader.SwitchFactory();
        }
    }
}
