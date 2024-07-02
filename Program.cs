using System.IO.IsolatedStorage;
using ClassLibrary;

namespace DomainIsolatedStorageBug
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateDir();
            LibraryClass.ReadDir(GetStore);
        }

        public static void CreateDir()
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