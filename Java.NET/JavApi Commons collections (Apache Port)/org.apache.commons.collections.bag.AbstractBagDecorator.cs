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
using org.apache.commons.collections.collection;

namespace org.apache.commons.collections.bag
{

    /**
     * Decorates another <code>Bag</code> to provide additional behaviour.
     * <p>
     * Methods are forwarded directly to the decorated bag.
     *
     * @since Commons Collections 3.0
     * @version $Revision$ $Date$
     * 
     * @author Stephen Colebourne
     */
    public abstract class AbstractBagDecorator : AbstractCollectionDecorator, Bag
    {

        /**
         * Constructor only used in deserialization, do not use otherwise.
         * @since Commons Collections 3.1
         */
        protected AbstractBagDecorator()
            : base()
        {
        }

        /**
         * Constructor that wraps (not copies).
         * 
         * @param bag  the bag to decorate, must not be null
         * @throws IllegalArgumentException if list is null
         */
        protected AbstractBagDecorator(Bag bag)
            : base(bag)
        {
        }

        /**
         * Gets the bag being decorated.
         * 
         * @return the decorated bag
         */
        protected Bag getBag()
        {
            return (Bag)getCollection();
        }

        //-----------------------------------------------------------------------
        public virtual int getCount(Object obj)
        {
            return getBag().getCount(obj);
        }

        public virtual bool add(Object obj, int count)
        {
            return getBag().add(obj, count);
        }

        public virtual bool remove(Object obj, int count)
        {
            return getBag().remove(obj, count);
        }

        public virtual java.util.Set<Object> uniqueSet()
        {
            return getBag().uniqueSet();
        }

    }
}