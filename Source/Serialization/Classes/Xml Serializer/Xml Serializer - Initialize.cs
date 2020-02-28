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
using System.Xml.Serialization;

namespace DaanV2.Config.Serialization {
    /// <summary>The class that is responisble binding the .net xml serializer to the interface</summary>
    public partial class XmlSerializer<T> : XmlSerializer {
        /// <summary>Creates a new instance of <see cref="XmlSerializer"/></summary>
        public XmlSerializer() : base(typeof(T)) { }

        /// <summary>Creates a new instance of <see cref="XmlSerializer"/></summary>
        /// <param name="ForceType">The type the serializer has to serialize</param>
        public XmlSerializer(Type ForceType) : base(ForceType) {  }
    }
}
