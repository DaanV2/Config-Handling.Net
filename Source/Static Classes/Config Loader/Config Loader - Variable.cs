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
using System.Collections.Concurrent;
using System.Threading;
using DaanV2.Config.Serialization;

namespace DaanV2.Config
{
    public static partial class ConfigLoader
    {
        /// <summary>The locks used for to make sure config files can only be accesed by 1 thread at a time</summary>
        private static readonly EventWaitHandle[] _Locks;

        /// <summary>The current serializing factory that is being used</summary>
        private static IConfigSerializerFactory _SerializerFactory;

        /// <summary>The internal dictionary of factories</summary>
        private static readonly ConcurrentDictionary<String, IConfigSerializerFactory> _Factories;
    }
}
