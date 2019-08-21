using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfotechVision.Models.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        INewsRepository News { get; }
        IContentDetailRepository ContentDetail { get; }
        int Complete();
    }
}
