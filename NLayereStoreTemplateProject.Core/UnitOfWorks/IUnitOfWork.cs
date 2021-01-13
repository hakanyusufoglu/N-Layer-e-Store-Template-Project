using NLayereStoreTemplateProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Core.UnitOfWorks
{
   public interface IUnitOfWork
    {
        IOrderRepository Order { get; }
        Task CommitAsync(); //eğer database'e savechangeAsync() metodu istenirse bu metotla çağırılacak.
        void Commit(); //eğer database'e savechange() metodu istenirse bu metotla çağırılacak.
    }
}
