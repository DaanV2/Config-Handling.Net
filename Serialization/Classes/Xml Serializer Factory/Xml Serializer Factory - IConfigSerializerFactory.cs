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
    public partial class XmlSerializerFactory : DaanV2.Config.Serialization.IConfigSerializerFactory {
        ///DOLATER <summary>Add Description</summary>
        private readonly String _Name = "Xml";

        ///DOLATER <summary>Add Description</summary>
        public String Name => this._Name;

        ///DOLATER <summary>Add Description</summary>
        /// <typeparam name="TOut"></typeparam>
        /// <returns></returns>
        public IConfigDeserializer<TOut> GetDeserializer<TOut>() {
            return new XmlSerializer<TOut>();
        }

        ///DOLATER <summary>Add Description</summary>
        /// <param name="T"></param>
        /// <returns></returns>
        public IConfigDeserializer<Object> GetDeserializer(Type T) {
            return new XmlSerializer<Object>(T);
        }


        ///DOLATER <summary>Add Description</summary>
        /// <typeparam name="TIn"></typeparam>
        /// <returns></returns>
        public IConfigSerializer<TIn> GetSerializer<TIn>() {
            return new XmlSerializer<TIn>();
        }

        ///DOLATER <summary>Add Description</summary>
        /// <param name="ForType"></param>
        /// <returns></returns>
        public IConfigSerializer<Object> GetSerializer(Type ForType) {
            return new XmlSerializer<Object>(ForType);
        }
    }
}
