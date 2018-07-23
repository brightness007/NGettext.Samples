using NGettext;

namespace AndroidDemo
{
    public class DemoMessages
    {
        private ICatalog _Catalog = null;

        public DemoMessages(ICatalog catalog)
        {
            _Catalog = catalog;
        }

        public string HELLO_WORLD()
        {
            return _Catalog.GetString("Hello, World!");
        }

        public string APPLE_COUNT_MESAGE(long n)
        {
            return _Catalog.GetPluralString("You have {0} apple.", "You have {0} apples.", n, n);
        }

        public string TREE_COUNT_MESAGE(long n)
        {
            return _Catalog.GetPluralString("You have {0} tree.", "You have {0} trees.", n, n);
        }
    }
}
