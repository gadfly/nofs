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

namespace org.apache.commons.collections.bag
{

    /**
     * Decorates another <code>SortedBag</code> to validate that additions
     * match a specified predicate.
     * <p>
     * This bag exists to provide validation for the decorated bag.
     * It is normally created to decorate an empty bag.
     * If an object cannot be added to the bag, an IllegalArgumentException is thrown.
     * <p>
     * One usage would be to ensure that no null entries are added to the bag.
     * <pre>SortedBag bag = PredicatedSortedBag.decorate(new TreeBag(), NotNullPredicate.INSTANCE);</pre>
     * <p>
     * This class is java.io.Serializable from Commons Collections 3.1.
     *
     * @since Commons Collections 3.0
     * @version $Revision$ $Date$
     * 
     * @author Stephen Colebourne
     * @author Paul Jack
     */
    [Serializable]
    public class PredicatedSortedBag
            : PredicatedBag, SortedBag
    {

        /** Serialization version */
        private static readonly long serialVersionUID = 3448581314086406616L;

        /**
         * Factory method to create a predicated (validating) bag.
         * <p>
         * If there are any elements already in the bag being decorated, they
         * are validated.
         * 
         * @param bag  the bag to decorate, must not be null
         * @param predicate  the predicate to use for validation, must not be null
         * @return a new predicated SortedBag
         * @throws IllegalArgumentException if bag or predicate is null
         * @throws IllegalArgumentException if the bag contains invalid elements
         */
        public static SortedBag decorate(SortedBag bag, Predicate predicate)
        {
            return new PredicatedSortedBag(bag, predicate);
        }

        //-----------------------------------------------------------------------
        /**
         * Constructor that wraps (not copies).
         * <p>
         * If there are any elements already in the bag being decorated, they
         * are validated.
         * 
         * @param bag  the bag to decorate, must not be null
         * @param predicate  the predicate to use for validation, must not be null
         * @throws IllegalArgumentException if bag or predicate is null
         * @throws IllegalArgumentException if the bag contains invalid elements
         */
        protected internal PredicatedSortedBag(SortedBag bag, Predicate predicate)
            : base(bag, predicate)
        {
        }

        /**
         * Gets the decorated sorted bag.
         * 
         * @return the decorated bag
         */
        protected SortedBag getSortedBag()
        {
            return (SortedBag)getCollection();
        }

        //-----------------------------------------------------------------------
        public Object first()
        {
            return getSortedBag().first();
        }

        public Object last()
        {
            return getSortedBag().last();
        }

        public java.util.Comparator<Object> comparator()
        {
            return getSortedBag().comparator();
        }

    }
}