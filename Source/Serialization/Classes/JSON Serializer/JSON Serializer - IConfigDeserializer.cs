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

#if NETCORE
using System.Text.Json;
using System.Threading.Tasks;
#else
using System.Runtime.Serialization.Json;
#endif

namespace DaanV2.Config.Serialization
{
    public partial class JSONSerializer<T> : IConfigDeserializer<T>
    {
        /// <summary>Deserializes the given stream into the specified object</summary>
        /// <param name="Reader">The stream to reader from</param>
        /// <returns>Deserializes the given stream into the specified object</returns>
        public T Deserialize(Stream Reader)
        {
#if NETCORE
            var Options = new JsonSerializerOptions();
            ValueTask<Object> VTask = JsonSerializer.DeserializeAsync(Reader, this._ForType, Options);
            VTask.AsTask().Wait();

            return (T)VTask.Result;
#else
            var Deserializer = new DataContractJsonSerializer(this._ForType);
            var Out = (T)Deserializer.ReadObject(Reader);
            return Out;
#endif
        }
    }
}
