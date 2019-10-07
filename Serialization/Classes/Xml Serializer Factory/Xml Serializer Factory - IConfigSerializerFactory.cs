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

namespace DaanV2.Config.Serialization {
    public partial class XmlSerializerFactory : IConfigSerializerFactory {
        /// <summary>The name used for identifying this factory</summary>
        private readonly String _Name = "Xml";

        /// <summary>The name used for identifying this factory</summary>
        public String Name => this._Name;

        /// <summary>Returns a serializer that is capable of deserializing the given object type</summary>
        /// <typeparam name="TOut">The object type to deserialize</typeparam>
        ///DOLATER <returns>Returns a <see cref="FILLIN"/></returns>
        public IConfigDeserializer<TOut> GetDeserializer<TOut>() {
            return new XmlSerializer<TOut>();
        }

        /// <summary>Returns a serializer that is capable of deserializing the given object type</summary>
        /// <param name="ForType">The object type to serialize</param>
        ///DOLATER <returns>Returns a <see cref="FILLIN"/></returns>
        public IConfigDeserializer<Object> GetDeserializer(Type ForType) {
            return new XmlSerializer<Object>(ForType);
        }


        /// <summary>Returns a serializer that is capable of serializing the given object type</summary>
        /// <typeparam name="TIn">The object type to serialize</typeparam>
        ///DOLATER <returns>Returns a <see cref="FILLIN"/></returns>
        public IConfigSerializer<TIn> GetSerializer<TIn>() {
            return new XmlSerializer<TIn>();
        }

        /// <summary>Returns a serializer that is capable of serializing the given object type</summary>
        /// <param name="ForType">The object type to serialize</param>
        ///DOLATER <returns>Returns a <see cref="FILLIN"/></returns>
        public IConfigSerializer<Object> GetSerializer(Type ForType) {
            return new XmlSerializer<Object>(ForType);
        }
    }
}
