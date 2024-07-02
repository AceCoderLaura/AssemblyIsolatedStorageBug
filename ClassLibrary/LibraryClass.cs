using System;
using System.IO.IsolatedStorage;

namespace ClassLibrary
{
    public static class LibraryClass
    {
        public const string Test = "test";

        public static void ReadDir(Func<IsolatedStorageFile> getStore)
        {
            var store = getStore();
            if (store.DirectoryExists(Test))
            {
                Console.WriteLine("Store is same, no bug.");
            }
            else
            {
                Console.WriteLine("STORE IS DIFFERENT THIS IS A BUG!");
            }
        }
    }
}