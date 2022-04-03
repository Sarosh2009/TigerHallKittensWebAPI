using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TigerHallKittensWebAPI.Models;

namespace TigerHallKittensWebAPI.Tests
{
    class TestTigerDbSet: TestDbSet<Tiger>
    {
        public override Tiger Find(params object[] keyValues)
        {
            return this.SingleOrDefault(tiger => tiger.ID == (int)keyValues.Single());
        }
    }
}
