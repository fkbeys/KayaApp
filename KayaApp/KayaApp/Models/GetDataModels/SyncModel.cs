using SQLite;

namespace KayaApp.Models
{
    public class SyncModel
    {
        [PrimaryKey]

        public int LastSyncID { get; set; }

    }
}
