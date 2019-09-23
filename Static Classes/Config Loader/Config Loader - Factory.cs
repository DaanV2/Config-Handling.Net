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
using System.Reflection;

namespace DaanV2.Config {

    public static partial class ConfigLoader {

        ///DOLATER <summary>Add Description</summary>
        /// <param name="assembly"></param>
        public static void AddFactories(Assembly assembly) {
            Type[] Types = assembly.GetTypes();
            Type T;

            for (Int32 I = 0; I < Types.Length; I++) {
                T = Types[I];

                if (T.GetInterface(nameof(IConfigSerializerFactory)) != null) {
                    AddFactory((IConfigSerializerFactory)Activator.CreateInstance(T));
                }
            }
        }

        ///DOLATER <summary>Add Description</summary>
        /// <param name="Factory"></param>
        public static void AddFactory(IConfigSerializerFactory Factory) {

            if (Factory == null) {
                throw new ArgumentNullException(nameof(Factory));
            }

            ConfigLoader._WaitHandle.WaitOne();
            ConfigLoader._Factories[Factory.Name] = Factory;
            ConfigLoader._WaitHandle.Set();
        }

        ///DOLATER <summary>Add Description</summary>
        public static void SwitchFactory() {
            String Key = ConfigOptions.ConfigSerializerName;

            ConfigLoader._WaitHandle.WaitOne();

            if (ConfigLoader._Factories.ContainsKey(Key)) {
                ConfigLoader._SerializerFactory = ConfigLoader._Factories[Key];
            }
            else if (ConfigLoader._SerializerFactory == null) {
                ConfigLoader._SerializerFactory = new Serialization.XmlSerializerFactory();
            }

            ConfigLoader._WaitHandle.Set();
        }
    }
}
