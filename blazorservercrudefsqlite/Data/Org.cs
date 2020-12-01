using System.Collections.Generic;

namespace blazorservercrudefsqlite.Data
{
    public class Org
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; } = new List<User>();
    }


}