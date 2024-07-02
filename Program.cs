using System;
using System.IO.IsolatedStorage;
using ClassLibrary;

namespace AssemblyIsolatedStorageBug
{
    public class Program
    {
        private const bool FixEnabled = false;

        public static void Main(string[] args)
        {
            CreateDir();
            LibraryClass.ReadDir(GetProgramStore);
        }

        private static void CreateDir()
        {
            var store = GetProgramStore();
            store.CreateDirectory(LibraryClass.Test);
        }

        private static IsolatedStorageFile GetProgramStore()
        {
            var isolatedStorageFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

            // Isolated storage appears to use the call stack to determine what assembly is calling GetStore in order
            // to perform assembly-level isolation for storage. When this line is optimised away, GetProgramStore is
            // removed from the call stack after GetStore is called, that way the IsolatedStorageFile gets returned
            // directly to the caller of GetProgramStore, which is obviously faster, but breaks isolated storage's
            // caller detection.
            if (FixEnabled) Console.Beep();

            return isolatedStorageFile;
        }
    }
}