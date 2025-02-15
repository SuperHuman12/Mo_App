﻿using Android.Content;
using System;
using Tulsi.ForDeveloper;

namespace Tulsi.Droid.DeveloperService {
    public class MemoryHelper {

        /// <summary>
        ///     ctor().
        /// </summary>
        public MemoryHelper() {
        }

        public static void MemoryCheck(Context context) {
            Console.WriteLine("MemoryHelper.MemoryCheck.{0} - {1}", "Start", context.ToString());
            long maxMemory = Java.Lang.Runtime.GetRuntime().MaxMemory();
            long freeMemory = Java.Lang.Runtime.GetRuntime().FreeMemory();
            double percentUsed = (double)(maxMemory - freeMemory) / (double)maxMemory;
            Console.WriteLine("free memory: {0:N}", freeMemory);
            Console.WriteLine("max memory: {0:N}", maxMemory);
            Console.WriteLine("% used: {0:P}", percentUsed);
            Console.WriteLine("MemoryHelper.MemoryCheck.{0} {3:P} {1} out of {2}", "End", freeMemory, maxMemory, percentUsed);
        }

        public static long GetFreeMemory(Context context) {

            long freeMemory = Java.Lang.Runtime.GetRuntime().FreeMemory();

            return freeMemory;

        }

        public static MemoryInfo GetMemoryInfo(Context context) {
            MemoryInfo retVal = new MemoryInfo();

            retVal.MaxMemory = Java.Lang.Runtime.GetRuntime().MaxMemory();
            retVal.FreeMemory = Java.Lang.Runtime.GetRuntime().FreeMemory();
            retVal.TotalMemory = Java.Lang.Runtime.GetRuntime().TotalMemory();

            return retVal;
        }
    }
}