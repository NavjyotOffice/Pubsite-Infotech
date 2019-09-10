using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfotechVision.Models.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IContentDetailRepository ContentDetail { get; }
        INewsRepository News { get; }
        IEventsRepository Events { get; }
        int Complete();
    }
}
