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

namespace DaanV2.Config {
    public static partial class ConfigOptions {
        /// <summary>Initializes a new instance of <see cref="ConfigOptions"/></summary>
        static ConfigOptions() {
            ConfigOptions._ConfigFolder = AppDomain.CurrentDomain.BaseDirectory + "configs\\";
            ConfigOptions._ConfigExtension = ".config";
            ConfigOptions._FilepathOptions = AppDomain.CurrentDomain.BaseDirectory + "config.ini";
            ConfigOptions._ConfigSerializerName = "json";
            ConfigOptions._LockCount = Environment.ProcessorCount;

            //If the .ini file doesnt exists then make it else load it
            if (!HasFile()) {
                Save();
            }
            else {
                Load();
            }
        }
    }
}
