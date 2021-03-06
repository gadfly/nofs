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

namespace org.apache.commons.collections.iterators
{

    /**
     * <code>SingletonIterator</code> is an {@link ListIterator} over a single 
     * object instance.
     *
     * @since Commons Collections 2.1
     * @version $Revision$ $Date$
     * 
     * @author Stephen Colebourne
     * @author Rodney Waldhoff
     */
    public class SingletonListIterator : java.util.ListIterator<Object>, ResettableListIterator
    {

        private bool beforeFirst = true;
        private bool nextCalled = false;
        private bool removed = false;
        private Object obj;

        /**
         * Constructs a new <code>SingletonListIterator</code>.
         *
         * @param object  the single object to return from the iterator
         */
        public SingletonListIterator(Object obj)
            : base()
        {
            this.obj = obj;
        }

        /**
         * Is another object available from the iterator?
         * <p>
         * This returns true if the single object hasn't been returned yet.
         * 
         * @return true if the single object hasn't been returned yet
         */
        public bool hasNext()
        {
            return beforeFirst && !removed;
        }

        /**
         * Is a previous object available from the iterator?
         * <p>
         * This returns true if the single object has been returned.
         * 
         * @return true if the single object has been returned
         */
        public bool hasPrevious()
        {
            return !beforeFirst && !removed;
        }

        /**
         * Returns the index of the element that would be returned by a subsequent
         * call to <tt>next</tt>.
         *
         * @return 0 or 1 depending on current state. 
         */
        public int nextIndex()
        {
            return (beforeFirst ? 0 : 1);
        }

        /**
         * Returns the index of the element that would be returned by a subsequent
         * call to <tt>previous</tt>. A return value of -1 indicates that the iterator is currently at
         * the start.
         *
         * @return 0 or -1 depending on current state. 
         */
        public int previousIndex()
        {
            return (beforeFirst ? -1 : 0);
        }

        /**
         * Get the next object from the iterator.
         * <p>
         * This returns the single object if it hasn't been returned yet.
         *
         * @return the single object
         * @throws NoSuchElementException if the single object has already 
         *    been returned
         */
        public Object next()
        {
            if (!beforeFirst || removed)
            {
                throw new java.util.NoSuchElementException();
            }
            beforeFirst = false;
            nextCalled = true;
            return obj;
        }

        /**
         * Get the previous object from the iterator.
         * <p>
         * This returns the single object if it has been returned.
         *
         * @return the single object
         * @throws NoSuchElementException if the single object has not already 
         *    been returned
         */
        public Object previous()
        {
            if (beforeFirst || removed)
            {
                throw new java.util.NoSuchElementException();
            }
            beforeFirst = true;
            return obj;
        }

        /**
         * Remove the object from this iterator.
         * @throws IllegalStateException if the <tt>next</tt> or <tt>previous</tt> 
         *        method has not yet been called, or the <tt>remove</tt> method 
         *        has already been called after the last call to <tt>next</tt>
         *        or <tt>previous</tt>.
         */
        public void remove()
        {
            if (!nextCalled || removed)
            {
                throw new java.lang.IllegalStateException();
            }
            else
            {
                obj = null;
                removed = true;
            }
        }

        /**
         * Add always throws {@link UnsupportedOperationException}.
         *
         * @throws UnsupportedOperationException always
         */
        public void add(Object obj)
        {
            throw new java.lang.UnsupportedOperationException("add() is not supported by this iterator");
        }

        /**
         * Set sets the value of the singleton.
         *
         * @param obj  the object to set
         * @throws IllegalStateException if <tt>next</tt> has not been called 
         *          or the object has been removed
         */
        public void set(Object obj)
        {
            if (!nextCalled || removed)
            {
                throw new java.lang.IllegalStateException();
            }
            this.obj = obj;
        }

        /**
         * Reset the iterator back to the start.
         */
        public void reset()
        {
            beforeFirst = true;
            nextCalled = false;
        }

    }
}