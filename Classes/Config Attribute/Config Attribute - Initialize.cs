/*ISC License

Copyright(c) 2019, Daan Verstraten, daanverstraten@hotmail.com

Permission to use, copy, modify, and/or distribute this software for any
purpose with or without fee is hereby granted, provided that the above
copyright notice and this permission notice appear in all copies./git a

THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES
WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF
MERCHANTABILITY AND FITNESS.IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR
ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES
WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN
ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF
OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.*/
using System;

namespace DaanV2.Config {
    /// <summary>The attribute responsible for giving the system its information</summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
    [Serializable]
    public partial class ConfigAttribute : Attribute {
        /// <summary>Creates a new instance of <see cref="ConfigAttribute"/></summary>
        public ConfigAttribute() : this(String.Empty, String.Empty, String.Empty) { }

        /// <summary>Creates a new instance of <see cref="ConfigAttribute"/></summary>
        /// <param name="Name">The name of this config object</param>
        public ConfigAttribute(String Name) : this(Name, String.Empty, String.Empty) { }

        /// <summary>Creates a new instance of <see cref="ConfigAttribute"/></summary>
        /// <param name="Name">The name of this config object</param>
        /// <param name="Category">The catergory this config objects fall under, use \ for sub categories</param>
        /// <example>[ConfigAttribute("Example", "DaanV2\\General")]</example>
        public ConfigAttribute(String Name, String Category) : this(Name, Category, String.Empty) { }

        /// <summary>Creates a new instance of <see cref="ConfigAttribute"/></summary>
        /// <param name="Name">The name of this config object</param>
        /// <param name="Category">The catergory this config objects fall under, use \ for sub categories</param>
        /// <param name="SubFolder">The subfolder the config loader needs to save/load from. 
        /// relative fromt he config folder, use \ to create even deeper folder structures</param>
        public ConfigAttribute(String Name, String Category, String SubFolder) {
            this.Category = Category;
            this.Name = Name;
            this.SubFolder = SubFolder;
        }
    }
}
