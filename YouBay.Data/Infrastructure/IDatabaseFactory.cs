using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouBay.Data.Models;

namespace YouBay.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable 
    {
    fusiondbContext DataContext { get; } 
    }
}
