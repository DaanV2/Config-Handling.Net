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

namespace DaanV2.Config {
    public static partial class ConfigOptions {
        /// <summary>Save this class into the config.ini file</summary>
        public static void Save() {
            //Write the config file
            var FI = new FileInfo(FilepathOptions);

            //Ensure directory is created
            FI.Directory.Create();

            var writer = new StreamWriter(ConfigOptions._FilepathOptions, false);
            writer.WriteLine($"Config Extension={ConfigOptions._ConfigExtension}");
            writer.WriteLine($"Config Folder={ConfigOptions._ConfigFolder.Replace(AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\'), String.Empty)}");
            writer.WriteLine($"Config Serializer Name={ConfigOptions._ConfigSerializerName}");
            writer.WriteLine($"Lock Count={ConfigOptions._LockCount}");
            writer.Close();
        }

        /// <summary>Loads the config.ini file</summary>
        public static void Load() {
            //Retrieve all lines from the config
            String[] Lines = File.ReadAllLines(ConfigOptions._FilepathOptions);

            //Loop through all lines
            foreach (String L in Lines) {
                Int32 I = L.IndexOf("=");

                if (I < 0) {
                    continue;
                }

                String Name = L.Substring(0, I);
#if NETCORE
                String Value = L[(I + 1)..].Trim();
#else
                String Value = L.Substring(I + 1, L.Length - (I + 1)).Trim();
#endif

                switch (Name) {
                    case "Config Extension":
                        ConfigOptions._ConfigExtension = Value;
                        break;

                    case "Config Folder":
                        ConfigOptions._ConfigFolder = Value;
                        break;

                    case "Config Serializer Name":
                        ConfigOptions._ConfigSerializerName = Value;
                        break;

                    case "Lock Count":
                        if (Int32.TryParse(Value, out Int32 Out)) {
                            ConfigOptions._LockCount = Out;
                        }
                        break;
                }
            }

            //Relative path
            if (ConfigOptions._ConfigFolder.StartsWith("\\")) {
                ConfigOptions._ConfigFolder = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + ConfigOptions._ConfigFolder;
            }

            //Make sure it ends with '\'
            if (!ConfigOptions._ConfigFolder.EndsWith("\\")) {
                ConfigOptions._ConfigFolder += "\\";
            }
        }

        /// <summary>checks if the config.ini file exists</summary>
        /// <returns>Returns a <see cref="Boolean"/></returns>
        private static Boolean HasFile() {
            return File.Exists(ConfigOptions._FilepathOptions);
        }
    }
}
