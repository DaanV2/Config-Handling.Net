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
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using DaanV2.Config.Serialization;

namespace DaanV2.Config
{
    public static partial class ConfigLoader
    {
        /// <summary>Loads the specified object from file storage or creates a new instance</summary>
        /// <param name="T">The type of the object to retrieve</param>
        /// <param name="Filename">the name of the config</param>
        /// <returns>A <see cref="Object"/> is returned</returns>
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
        /// <exception cref="UnauthorizedAccessException" />
        /// <exception cref="TargetInvocationException" />
        /// <exception cref="TypeLoadException" />
        public static Object LoadConfig(Type T, String Filename)
        {
            //Create the filepath of where the config file could be found
            String Filepath = ConfigOptions.ConfigFolder + Filename + ConfigOptions.ConfigExtension;
            EventWaitHandle Lock = ConfigLoader.GetLock(Filepath);
            Object Out = null;

            //Check if file exists
            if (File.Exists(Filepath))
            {
                //Setup
                IConfigDeserializer<Object> deserializer;
                FileStream reader = null;

                Lock.WaitOne();
#if !DEBUG
                try {
#endif
                //Create the deserializer and stream
                deserializer = ConfigLoader._SerializerFactory.GetDeserializer(T);
                reader = new FileStream(Filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                //Deserialize file into object
                Out = deserializer.Deserialize(reader);
                reader.Close();
#if !DEBUG
                }
                catch (Exception ex) {
                    //Close of the stream, write error report
                    if (reader != null) {
                        reader.Close();
                    }

                    ErrorLoading(Filepath, ex);
                }
#endif
                Lock.Set();
            }

            //Checks if object has not been succesfully been deserialized.
            if (Out == null)
            {
                //Create new instance of the object
                Out = Activator.CreateInstance(T);

                //Check if the object has the given object
                if (Out.GetType().GetInterface(nameof(INewConfig)) != null)
                {
                    var Temp = (INewConfig)Out;
                    Temp.SetNewInformation();
                }

#if !DEBUG
                Task.Run(() => SaveConfig(Out, Filename));
#else
                SaveConfig(Out, Filename);
#endif
            }

            return Out;
        }

        /// <summary>Loads the given config into an object from the xml file in the config folder</summary>
        /// <typeparam name="T">The object type to be returned and loaded</typeparam>
        /// <param name="Filename">The name of the config</param>
        /// <returns>Loads the given config into an object from the xml file in the config folder</returns>
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
        /// <exception cref="UnauthorizedAccessException" />
        /// <exception cref="TargetInvocationException" />
        /// <exception cref="TypeLoadException" />
        public static T LoadConfig<T>(String Filename)
        {
            String Filepath = ConfigOptions.ConfigFolder + Filename + ".xml";
            EventWaitHandle Lock = ConfigLoader.GetLock(Filepath);
            T Out = default;

            if (File.Exists(Filepath))
            {
                IConfigDeserializer<T> deserializer;
                FileStream reader = null;

                Lock.WaitOne();
#if !DEBUG
                try {
#endif
                deserializer = ConfigLoader._SerializerFactory.GetDeserializer<T>();
                reader = new FileStream(Filepath, FileMode.Open);

                Out = deserializer.Deserialize(reader);
                reader.Close();
#if !DEBUG
                }
                catch (Exception ex) {
                    if (reader != null) {
                        reader.Close();
                    }

                    ErrorLoading(Filepath, ex);
                }
#endif
                Lock.Set();
            }

            if (Out == null)
            {
                Out = Activator.CreateInstance<T>();

                if (Out.GetType().GetInterface(nameof(INewConfig)) != null)
                {
                    var Temp = (INewConfig)Out;
                    Temp.SetNewInformation();
                }

#if Debug
                Task.Run(() => SaveConfig(Out, Filename));
#else
                SaveConfig(Out, Filename);
#endif
            }

            return Out;
        }
    }
}
