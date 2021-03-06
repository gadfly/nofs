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
 */

using System;
using java = biz.ritter.javapi;
using org.apache.commons.collections;

namespace org.apache.commons.collections.functors
{

    /**
     * Predicate implementation that returns true if none of the
     * predicates return true.
     * If the array of predicates is empty, then this predicate returns true.
     * <p>
     * NOTE: In versions prior to 3.2 an array size of zero or one
     * threw an exception.
     *
     * @since Commons Collections 3.0
     * @version $Revision$ $Date$
     *
     * @author Stephen Colebourne
     * @author Matt Benson
     */
    public sealed class NonePredicate : Predicate, PredicateDecorator, java.io.Serializable
    {

        /** Serial version UID */
        private static readonly long serialVersionUID = 2007613066565892961L;

        /** The array of predicates to call */
        private readonly Predicate[] iPredicates;

        /**
         * Factory to create the predicate.
         * <p>
         * If the array is size zero, the predicate always returns true.
         *
         * @param predicates  the predicates to check, cloned, not null
         * @return the <code>any</code> predicate
         * @throws IllegalArgumentException if the predicates array is null
         * @throws IllegalArgumentException if any predicate in the array is null
         */
        public static Predicate getInstance(Predicate[] predicates)
        {
            FunctorUtils.validate(predicates);
            if (predicates.Length == 0)
            {
                return TruePredicate.INSTANCE;
            }
            predicates = FunctorUtils.copy(predicates);
            return new NonePredicate(predicates);
        }

        /**
         * Factory to create the predicate.
         * <p>
         * If the collection is size zero, the predicate always returns true.
         *
         * @param predicates  the predicates to check, cloned, not null
         * @return the <code>one</code> predicate
         * @throws IllegalArgumentException if the predicates array is null
         * @throws IllegalArgumentException if any predicate in the array is null
         */
        public static Predicate getInstance(java.util.Collection<Object> predicates)
        {
            Predicate[] preds = FunctorUtils.validate((java.util.Collection<Predicate>)predicates);
            if (preds.Length == 0)
            {
                return TruePredicate.INSTANCE;
            }
            return new NonePredicate(preds);
        }

        /**
         * Constructor that performs no validation.
         * Use <code>getInstance</code> if you want that.
         * 
         * @param predicates  the predicates to check, not cloned, not null
         */
        public NonePredicate(Predicate[] predicates)
            : base()
        {
            iPredicates = predicates;
        }

        /**
         * Evaluates the predicate returning false if any stored predicate returns false.
         * 
         * @param object  the input object
         * @return true if none of decorated predicates return true
         */
        public bool evaluate(Object obj)
        {
            for (int i = 0; i < iPredicates.Length; i++)
            {
                if (iPredicates[i].evaluate(obj))
                {
                    return false;
                }
            }
            return true;
        }

        /**
         * Gets the predicates, do not modify the array.
         * 
         * @return the predicates
         * @since Commons Collections 3.1
         */
        public Predicate[] getPredicates()
        {
            return iPredicates;
        }

    }
}