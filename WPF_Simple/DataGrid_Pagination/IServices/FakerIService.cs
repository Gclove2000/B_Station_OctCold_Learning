using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid_Pagination.IServices
{
    public interface FakerIService<T>
    {

        public T FakeOne();
        public IEnumerable<T> FakeMany(int count);
    }
}
