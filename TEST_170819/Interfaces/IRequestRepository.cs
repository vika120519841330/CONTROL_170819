using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST_170819.Models;

namespace TEST_170819.Interfaces
{
    public interface IRequestRepository
    {
        void FixLog(FixRequest entry);
    }
}
