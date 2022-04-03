using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TigerHallKittensWebAPI.Models;

namespace TigerHallKittensWebAPI.Tests
{
    public class TestdbContextTigerhallKittens : ITigerHallKittensContext
    {
        public TestdbContextTigerhallKittens()
        {
            this.Tigers = new TestTigerDbSet();
        }

        public DbSet<Tiger> Tigers { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Tiger item) { }
        public void Dispose() { }
    }
}
