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
using System.Threading;
using DaanV2.Config.Serialization;

namespace DaanV2.Config
{
    public static partial class ConfigLoader
    {
        /// <summary>Save the given object into a file</summary>
        /// <param name="ConfigObject">The object to save</param>
        /// <param name="Filename">The filename the objects should get</param>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="DirectoryNotFoundException" />
        /// <exception cref="FileNotFoundException" />
        /// <exception cref="IOException" />
        /// <exception cref="InvalidOperationException" />
        /// <exception cref="NotSupportedException" />
        /// <exception cref="PathTooLongException" />
        /// <exception cref="UnauthorizedAccessException" />
        /// <exception cref="System.Security.SecurityException" />
        public static void SaveConfig(Object ConfigObject, String Filename)
        {
            //Get file info on the file to save to
            String Filepath = ConfigOptions.ConfigFolder + Filename + ConfigOptions.ConfigExtension;
            var FI = new FileInfo(Filepath);
            EventWaitHandle Lock = ConfigLoader.GetLock(Filepath);

            //Check parent directory
            DirectoryInfo DI = FI.Directory;

            //Create if missing
            if (!DI.Exists)
            {
                DI.Create();
            }

            //Setup
            IConfigSerializer<Object> serializer = null;
            FileStream writer = null;

            Lock.WaitOne();
#if !DEBUG
            try {
#endif
            //Assign serializer and stream
            serializer = ConfigLoader._SerializerFactory.GetSerializer(ConfigObject.GetType());
            writer = new FileStream(FI.FullName, FileMode.Create);

            //Serialize object
            serializer.Serialize(ConfigObject, writer);

            //Flush and close
            writer.Flush();
            writer.Close();
#if !DEBUG
            }
#pragma warning disable 168
            catch (Exception ex) {
#pragma warning restore 168
                //Close stream if open
                if (writer != null) {
                    writer.Close();
                }

                ErrorSaving(Filepath, ex);
            }
#endif

            Lock.Set();
        }
    }
}
