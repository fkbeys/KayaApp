using SQLite;

namespace KayaApp.Models.DataModels
{
    public class SyncModel
    {
        [PrimaryKey]

        public int LastSyncID { get; set; }

    }
}
