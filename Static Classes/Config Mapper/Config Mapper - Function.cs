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
using System.Reflection;
using System.Text;

namespace DaanV2.Config {
    public static partial class ConfigMapper {

        /// <summary>Remove the config from the internal list</summary>
        /// <param name="T">DOLATER FILL IN</param>
        /// <exception cref="ArgumentNullException" />
        public static void Remove(Type T) {
            if (ConfigMapper.Configs.ContainsKey(T)) {
                Object Out = null;
                ConfigMapper.Configs.TryRemove(T, out Out);
            }
        }

        /// <summary>Remove the config from the internal list</summary>
        /// <param name="T">DOLATER FILL IN</param>
        /// <exception cref="ArgumentNullException" />
        public static void Remove(Object T) {
            if (ConfigMapper.Configs.ContainsKey(T.GetType())) {
                Object Out = null;
                ConfigMapper.Configs.TryRemove(T.GetType(), out Out);
            }
            else {
            }
        }

        /// <summary>Clears the complete internal list</summary>
        /// <param name="SaveConfigs">DOLATER FILL IN</param>
        public static void Clear(Boolean SaveConfigs = false) {
            if (SaveConfigs) {
                ConfigMapper.SaveAll();
            }

            ConfigMapper.Configs.Clear();
        }

        /// <summary>Returns the name of the given object needed for the process. also checks if the object has the needed attributes</summary>
        /// <param name="T">The type to retrieve the name of</param>
        /// <returns></returns>
        /// <exception cref="AmbiguousMatchException" />
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="NotSupportedException" />
        /// <exception cref="TypeLoadException" />
        public static String GetName(Type T) {
            if (T == null) {
                throw new ArgumentNullException(nameof(T));
            }

            //Retrieve attributes
            ConfigAttribute Ca = (ConfigAttribute)Attribute.GetCustomAttribute(T, typeof(ConfigAttribute));
            String Out = String.Empty;

            if (Ca == null || (Ca.SubFolder == null && Ca.Name == null)) {
                if (T.IsGenericType) {
                    Type[] Types = T.GetGenericArguments();
                    StringBuilder B = new StringBuilder(Types.Length * 20 );
                    B.Append(T.Name.Replace("`", "-"));

                    for (int I = 0; I < Types.Length; I++) {
                        B.Append("_");
                        B.Append(GetName(Types[I]));
                    }

                    return B.ToString();
                }
                else {
                    return T.Name;
                }
            }

            //If category is filled in then make put category in Out
            if (!(Ca.SubFolder == null || Ca.SubFolder == String.Empty)) {
                Out = Ca.SubFolder;

                //Make sure out is ending with \
                if (!Out.EndsWith("\\")) {
                    Out += "\\";
                }
            }

            //Return Out + Name
            return Ca.Name == null || Ca.Name == String.Empty ?
                Out + T.Name :
                Out + Ca.Name;
        }
    }
}
