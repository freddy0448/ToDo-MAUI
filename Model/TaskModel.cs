
using SQLite;

namespace ToDo_MAUI.Model
{
    public class TaskModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Task { get; set; }
    }
}
