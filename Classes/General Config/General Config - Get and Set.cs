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

namespace DaanV2.Config {
    public partial class GeneralConfig {
        /// <summary>returns the specified <see cref="String"/> that is associtated with a given key</summary>
        /// <param name="Key">The key of the specified item</param>
        /// <returns>an saved item</returns>
        public String this[String Key] {
            get => this.Items[Key];
            set => this.Items[Key] = value;
        }

        /// <summary>Adds an items with the specified key to this <see cref="GeneralConfig"/></summary>
        /// <param name="Key">The key of the specified item</param>
        /// <param name="Item">The contents of the specified item</param>
        public void Add(String Key, String Item) {
            this.Items[Key] = Item;
        }

        /// <summary>Returns the contents of the specified item</summary>
        /// <param name="Key">The key of the specified item</param>
        public String Get(String Key) {
            return this.Items[Key];
        }

        ///DOLATER <summary>Add Description</summary>
        /// <param name="Key"></param>
        /// <param name="IfMissing"></param>
        /// <returns></returns>
        public String Get(String Key, String IfMissing) {
            if (!this.Items.ContainsKey(Key)) {
                this.Items[Key] = IfMissing;
            }

            return this.Items[Key];
        }
    }
}
