using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvmDemo.Models
{
    public class CollectionViewList<T>
    {

        public IEnumerable<T> Items { get; set; }

        public ICollectionView CollectionView { get; set; }

        
    }
}
