using System.Collections.Generic;

namespace blazorservercrudefsqlite.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Org> Orgs { get; } = new List<Org>();
    }
}