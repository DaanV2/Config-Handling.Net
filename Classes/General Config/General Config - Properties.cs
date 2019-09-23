/*ISC License


Copyright (c) 2018, Daan Verstraten, daanverstraten@hotmail.com

Permission to use, copy, modify, and/or distribute this software for any
purpose with or without fee is hereby granted, provided that the above
copyright notice and this permission notice appear in all copies.

THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES
WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF
MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR
ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES
WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN
ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF
OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.*/
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DaanV2.Config {
    public partial class GeneralConfig {
        /// <summary>The collection of items stored in class</summary>       
        [XmlIgnore, IgnoreDataMember]
        public ConcurrentDictionary<String, String> Items { get; set; }

        /// <summary>Do not use this property, its used to serialize/deserialize the dictionary</summary>
        [XmlArray("Items"), XmlArrayItem("Item"), DataMember(Name = "Items")]
        public List<GeneralItemConfig> SerializeItems {
            get {
                List<GeneralItemConfig> Items = new List<GeneralItemConfig>(this.Items.Count);

                foreach (KeyValuePair<String, String> Item in this.Items) {
                    Items.Add(new GeneralItemConfig(Item.Key, Item.Value));
                }

                return Items;
            }
            set {
                this.Items.Clear();

                for (Int32 I = 0; I < value.Count; I++) {
                    this.Items[value[I].Key] = value[I].Value;
                }
            }
        }

    }
}
