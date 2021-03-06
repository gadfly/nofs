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

namespace org.apache.commons.collections.iterators
{

    /** 
     * An {@link Iterator} over an array of objects.
     * <p>
     * This iterator does not support {@link #remove}, as the object array cannot be
     * structurally modified.
     * <p>
     * The iterator implements a {@link #reset} method, allowing the reset of the iterator
     * back to the start if required.
     *
     * @since Commons Collections 3.0
     * @version $Revision$ $Date$
     * 
     * @author James Strachan
     * @author Mauricio S. Moura
     * @author Michael A. Smith
     * @author Neil O'Toole
     * @author Stephen Colebourne
     * @author Phil Steitz
     */
    public class ObjectArrayIterator
            : java.util.Iterator<Object>, ResettableIterator
    {

        /** The array */
        protected Object[] array = null;
        /** The start index to loop from */
        protected int startIndex = 0;
        /** The end index to loop to */
        protected int endIndex = 0;
        /** The current iterator index */
        protected int index = 0;

        /**
         * Constructor for use with <code>setArray</code>.
         * <p>
         * Using this constructor, the iterator is equivalent to an empty iterator
         * until {@link #setArray} is  called to establish the array to iterate over.
         */
        public ObjectArrayIterator()
            : base()
        {
        }

        /**
         * Constructs an ObjectArrayIterator that will iterate over the values in the
         * specified array.
         *
         * @param array the array to iterate over
         * @throws NullPointerException if <code>array</code> is <code>null</code>
         */
        public ObjectArrayIterator(Object[] array) :
            this(array, 0, array.Length)
        {
        }

        /**
         * Constructs an ObjectArrayIterator that will iterate over the values in the
         * specified array from a specific start index.
         *
         * @param array  the array to iterate over
         * @param start  the index to start iterating at
         * @throws NullPointerException if <code>array</code> is <code>null</code>
         * @throws IndexOutOfBoundsException if the start index is out of bounds
         */
        public ObjectArrayIterator(Object[] array, int start) :
            this(array, start, array.Length)
        {
        }

        /**
         * Construct an ObjectArrayIterator that will iterate over a range of values 
         * in the specified array.
         *
         * @param array  the array to iterate over
         * @param start  the index to start iterating at
         * @param end  the index (exclusive) to finish iterating at
         * @throws IndexOutOfBoundsException if the start or end index is out of bounds
         * @throws IllegalArgumentException if end index is before the start
         * @throws NullPointerException if <code>array</code> is <code>null</code>
         */
        public ObjectArrayIterator(Object[] array, int start, int end)
            : base()
        {
            if (start < 0)
            {
                throw new java.lang.ArrayIndexOutOfBoundsException("Start index must not be less than zero");
            }
            if (end > array.Length)
            {
                throw new java.lang.ArrayIndexOutOfBoundsException("End index must not be greater than the array length");
            }
            if (start > array.Length)
            {
                throw new java.lang.ArrayIndexOutOfBoundsException("Start index must not be greater than the array length");
            }
            if (end < start)
            {
                throw new java.lang.IllegalArgumentException("End index must not be less than start index");
            }
            this.array = array;
            this.startIndex = start;
            this.endIndex = end;
            this.index = start;
        }

        // Iterator interface
        //-------------------------------------------------------------------------

        /**
         * Returns true if there are more elements to return from the array.
         *
         * @return true if there is a next element to return
         */
        public virtual bool hasNext()
        {
            return (this.index < this.endIndex);
        }

        /**
         * Returns the next element in the array.
         *
         * @return the next element in the array
         * @throws NoSuchElementException if all the elements in the array
         *    have already been returned
         */
        public virtual Object next()
        {
            if (hasNext() == false)
            {
                throw new java.util.NoSuchElementException();
            }
            return this.array[this.index++];
        }

        /**
         * Throws {@link UnsupportedOperationException}.
         *
         * @throws UnsupportedOperationException always
         */
        public virtual void remove()
        {
            throw new java.lang.UnsupportedOperationException("remove() method is not supported for an ObjectArrayIterator");
        }

        // Properties
        //-------------------------------------------------------------------------

        /**
         * Gets the array that this iterator is iterating over. 
         *
         * @return the array this iterator iterates over, or <code>null</code> if
         * the no-arg constructor was used and {@link #setArray} has never
         * been called with a valid array.
         */
        public virtual Object[] getArray()
        {
            return this.array;
        }

        /**
         * Sets the array that the ArrayIterator should iterate over.
         * <p>
         * This method may only be called once, otherwise an IllegalStateException
         * will occur.
         * <p>
         * The {@link #reset} method can be used to reset the iterator if required.
         *
         * @param array  the array that the iterator should iterate over
         * @throws IllegalStateException if the <code>array</code> was set in the constructor
         * @throws NullPointerException if <code>array</code> is <code>null</code>
         */
        public virtual void setArray(Object[] array)
        {
            if (this.array != null)
            {
                throw new java.lang.IllegalStateException("The array to iterate over has already been set");
            }
            this.array = array;
            this.startIndex = 0;
            this.endIndex = array.Length;
            this.index = 0;
        }

        /**
         * Gets the start index to loop from.
         * 
         * @return the start index
         */
        public virtual int getStartIndex()
        {
            return this.startIndex;
        }

        /**
         * Gets the end index to loop to.
         * 
         * @return the end index
         */
        public virtual int getEndIndex()
        {
            return this.endIndex;
        }

        /**
         * Resets the iterator back to the start index.
         */
        public virtual void reset()
        {
            this.index = this.startIndex;
        }

    }
}