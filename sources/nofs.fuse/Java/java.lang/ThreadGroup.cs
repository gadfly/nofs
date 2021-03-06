﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using biz.ritter.javapi.lang;


namespace javapi.lang
{
    // <summary>
    //   This is used to share information about breakpoints and signal handlers
    //   between different invocations of the same target.
    // </summary>
    public sealed class ThreadGroup 
    {
        string name;
        Hashtable threads;
        bool Daemon;

        static ThreadGroup global = new ThreadGroup("global");
        static ThreadGroup system = new ThreadGroup("system");

        public ThreadGroup(string name)
        {
            this.name = name;
            this.threads = Hashtable.Synchronized(new Hashtable());
        }

        internal static ThreadGroup CreateThreadGroup(string name)
        {
            if ((name == "global") || (name == "system"))
                throw new InvalidOperationException();

            return new ThreadGroup(name);
        }

        public void AddThread(Thread thread)
        {
            if (IsSystem)
                throw new InvalidOperationException();

            if (!threads.Contains(thread.ManagedThreadId))
                threads.Add(thread.ManagedThreadId, thread);
        }

        public void RemoveThread(int id)
        {
            if (IsSystem)
                throw new InvalidOperationException();

            threads.Remove(id);
        }

        public int[] Threads
        {
            get
            {
                lock (this)
                {
                    int[] retval = new int[threads.Keys.Count];
                    threads.Keys.CopyTo(retval, 0);
                    return retval;
                }
            }
        }

        public string Name
        {
            get { return name; }
        }

        public static ThreadGroup Global
        {
            get { return global; }
        }

        public static ThreadGroup System
        {
            get { return system; }
        }

        public bool IsGlobal
        {
            get { return this == global; }
        }

        public bool IsSystem
        {
            get { return this == global || this == system; }
        }

        public override string ToString()
        {
            return String.Format("{0} ({1})", GetType(), name);
        }

        public void setDaemon(bool daemon)
        {
            Daemon = daemon;
            foreach (Thread item in threads.Values)
            {
                item.setDaemon(daemon);
            }
        }

        public int activeCount()
        {
            lock (this)
            {
                return threads.Keys.Count;
            }
        }

        public string getName()
        {
            return name;
        }

        public void enumerate(Thread[] threads)
        {
            foreach (Thread item in threads)
            {
                AddThread(item);
            }
        }
    }
}
