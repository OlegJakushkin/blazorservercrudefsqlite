using System.Collections.Generic;

namespace blazorservercrudefsqlite.Data
{
    public class Org
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Relation> Relations { get; set; }
    }
}