﻿/*ISC License

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
            StreamWriter writer = new StreamWriter(ConfigOptions.FilepathOptions, false);
            writer.WriteLine($"Config Extension={ConfigOptions.ConfigExtension}");
            writer.WriteLine($"Config Folder={ConfigOptions.ConfigFolder.Replace(AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\'), String.Empty)}");
            writer.WriteLine($"Config Serializer Name={ConfigOptions.ConfigSerializerName}");
            writer.Close();
        }

        /// <summary>Loads the config.ini file</summary>
        public static void Load() {
            //Retrieve all lines from the config
            String[] Lines = File.ReadAllLines(ConfigOptions.FilepathOptions);

            //Loop through all lines
            foreach (String L in Lines) {
                if (L.StartsWith("Config Extension=")) {
                    ConfigOptions.ConfigExtension = L.Remove(0, 17).Trim();
                }
                else if (L.StartsWith("Config Folder=")) {
                    ConfigOptions.ConfigFolder = L.Remove(0, 14).Trim();
                }
                else if (L.StartsWith("Config Serializer Name=")) {
                    ConfigOptions.ConfigSerializerName = L.Remove(0, 23).Trim();
                }
            }

            //Relative path
            if (ConfigOptions.ConfigFolder.StartsWith("\\")) {
                ConfigFolder = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + ConfigFolder;
            }

            //Make sure it ends with '\'
            if (!ConfigOptions.ConfigFolder.EndsWith("\\")) {
                ConfigOptions.ConfigFolder += "\\";
            }
        }

        /// <summary>checks if the config.ini file exists</summary>
        ///DOLATER <returns>Add return description</returns>
        private static Boolean HasFile() {
            return File.Exists(ConfigOptions.FilepathOptions);
        }
    }
}
