using System.Linq;

namespace DEPRECATED
{
    class DBInit
    {
        public FileManager _fm;

        public DBInit(FileManager fileManager)
        {
            _fm = fileManager;
        }

        public void Initialize(DBC dbc)
        {
            if (!dbc.Mods.Any())
            {
                var r = _fm.GetFiles();
                foreach (var item in r)
                {
                    dbc.Mods.Add(new ModEntity(item.Key.Name, (int)item.Key.Length / 1024, item.Value));
                }
                dbc.SaveChanges();
            }
        }
    }
}
