using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TigerHallKittensWebAPI.Models
{
    public interface ITigerHallKittensContext : IDisposable
    {
        DbSet<Tiger> Tigers { get; }
        int SaveChanges();
        void MarkAsModified(Tiger item);
    }
}
