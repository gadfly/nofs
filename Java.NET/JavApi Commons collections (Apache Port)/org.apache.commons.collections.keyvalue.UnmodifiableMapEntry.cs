/*
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at 
 * 
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 *  
 */

using System;
using java = biz.ritter.javapi;
using org.apache.commons.collections;

namespace org.apache.commons.collections.keyvalue
{

    /**
     * A {@link java.util.Map.Entry Map.Entry} that throws
     * UnsupportedOperationException when <code>setValue</code> is called.
     *
     * @since Commons Collections 3.0
     * @version $Revision$ $Date$
     * 
     * @author Stephen Colebourne
     */
    public sealed class UnmodifiableMapEntry : AbstractMapEntry, Unmodifiable
    {

        /**
         * Constructs a new entry with the specified key and given value.
         *
         * @param key  the key for the entry, may be null
         * @param value  the value for the entry, may be null
         */
        public UnmodifiableMapEntry(Object key, Object value)
            : base(key, value)
        {
        }

        /**
         * Constructs a new entry from the specified <code>KeyValue</code>.
         *
         * @param pair  the pair to copy, must not be null
         * @throws NullPointerException if the entry is null
         */
        public UnmodifiableMapEntry(KeyValue pair)
            : base(pair.getKey(), pair.getValue())
        {
        }

        /**
         * Constructs a new entry from the specified <code>Map.Entry</code>.
         *
         * @param entry  the entry to copy, must not be null
         * @throws NullPointerException if the entry is null
         */
        public UnmodifiableMapEntry(java.util.MapNS.Entry<Object, Object> entry)
            : base(entry.getKey(), entry.getValue())
        {
        }

        /**
         * Throws UnsupportedOperationException.
         * 
         * @param value  the new value
         * @return the previous value
         * @throws UnsupportedOperationException always
         */
        public override Object setValue(Object value)
        {
            throw new java.lang.UnsupportedOperationException("setValue() is not supported");
        }

    }
}