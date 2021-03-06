﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nofs.Fuse.Util;
using biz.ritter.javapi.nio.charset;
using biz.ritter.javapi.nio;

namespace Nofs.Fuse
{

    /**
     * Created by IntelliJ IDEA.
     * User: peter
     * Date: Jan 1, 2006
     * Time: 6:29:47 PM
     * To change this template use File | Settings | File Templates.
     */
    public class FuseFSFillDir : Struct, FuseFillDir
    {
        private Charset cs;   // charset to use for encoding file names
        private long buf;     // native buffer pointer stored in 64 bit long
        private long fillDir; // native pointer to fuse_fill_dir_t function stored in 64 bit long
        
        FuseFSFillDir(Charset cs, long buf, long fillDir)
        {
            this.cs = cs;
            this.buf = buf;
            this.fillDir = fillDir;
        }


        /**
         * Method to add an entry in a readdir() operation
         *
         * @param name       the name of the entry
         * @param inode      the inode number of the entry (optional)
         * @param mode       the entry type bits (from fuse.FuseFtypeConstants)
         * @param nextOffset the offset of next entry (in streaming mode) or zero (in buffering mode)
         * @return true if successfull (allways if buffering) or false if buffer full (in streaming mode)
         */
        public Boolean fill(String name, long inode, int mode, long nextOffset)
        {
            // encode into native ByteBuffer terminated with (byte)0
            ByteBuffer bb = cs.encode(name);
            ByteBuffer nbb = ByteBuffer.allocate(bb.remaining() + 1);
            nbb.put(bb);
            nbb.put((byte)0);
            nbb.flip();

            return fill(nbb, inode, mode, nextOffset, buf, fillDir);
        }

        /**
         * Native method that uses fillDir value as a pointer to fuse_fill_dir_t function and
         * calls that function with converted parameters...
         *
         * @param name the name of the entry encoded in given charset as a direct ByteBuffer
         * @param inode the inode number of the entry (optional)
         * @param mode the entry type bits (from fuse.FuseFtypeConstants)
         * @param nextOffset the offset of next entry (in streaming mode) or zero (in buffering mode)
         * @param buf native buffer pointer stored in 64 bit long
         * @param fillDir native pointer to fuse_fill_dir_t function stored in 64 bit long
         * @return true if successfull (allways if buffering) or false if buffer full (in streaming mode)
         */
        private Boolean fill(ByteBuffer name, long inode, int mode, long nextOffset, long buf, long fillDir)
        {
            throw new NotImplementedException();
        }


        //
        // Struct subclass
        protected override Boolean appendAttributes(StringBuilder buff, Boolean isPrefixed)
        {
            buff.Append(base.appendAttributes(buff, isPrefixed) ? ", " : " ");

            buff.Append("cs=").Append(cs)
                .Append(", buf=").Append(buf)
                .Append(", fillDir=").Append(fillDir);

            return true;
        }
    }

}
