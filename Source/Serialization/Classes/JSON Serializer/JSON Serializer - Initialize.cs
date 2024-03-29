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

namespace DaanV2.Config.Serialization
{
    /// <summary>The class responsible for forming the contract between the interface and the json serializer</summary>
    public partial class JSONSerializer<T>
    {
        /// <summary>Creates a new instance of <see cref="JSONSerializer{T}"/></summary>
        public JSONSerializer()
        {
            this._ForType = typeof(T);
        }

        /// <summary>Creates a new instance of <see cref="JSONSerializer{T}"/></summary>
        /// <param name="ForceType">Force the serializer to use this type instead of its generic type</param>
        public JSONSerializer(Type ForceType)
        {
            this._ForType = ForceType;
        }
    }
}
