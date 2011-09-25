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

namespace org.apache.commons.collections
{

    /**
     * The BufferOverflowException is used when the buffer's capacity has been
     * exceeded.
     *
     * @since Commons Collections 2.1
     * @version $Revision$ $Date$
     * 
     * @author Avalon
     * @author <a href="mailto:bloritsch@apache.org">Berin Loritsch</a>
     * @author <a href="mailto:jefft@apache.org">Jeff Turner</a>
     * @author Paul Jack
     * @author Stephen Colebourne
     */
    public class BufferOverflowException : java.lang.RuntimeException
    {

        /** The root cause throwable */
        private readonly java.lang.Throwable throwable;

        /**
         * Constructs a new <code>BufferOverflowException</code>.
         */
        public BufferOverflowException()
            : base()
        {
            throwable = null;
        }

        /** 
         * Construct a new <code>BufferOverflowException</code>.
         * 
         * @param message  the detail message for this exception
         */
        public BufferOverflowException(String message)
            : this(message, null)
        {
        }

        /** 
         * Construct a new <code>BufferOverflowException</code>.
         * 
         * @param message  the detail message for this exception
         * @param exception  the root cause of the exception
         */
        public BufferOverflowException(String message, java.lang.Throwable exception)
            : base(message)
        {
            throwable = exception;
        }

        /**
         * Gets the root cause of the exception.
         *
         * @return the root cause
         */
        public override java.lang.Throwable getCause()
        {
            return throwable;
        }

    }
}
