using System.IO.IsolatedStorage;
using ClassLibrary;

namespace AssemblyIsolatedStorageBug
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateDir();
            LibraryClass.ReadDir(GetStore);
        }

        private static void CreateDir()
        {
            var store = GetStore();
            store.CreateDirectory(LibraryClass.Test);
        }

        private static IsolatedStorageFile GetStore()
        {
            return IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
        }
    }
}