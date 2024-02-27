using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DataGrid_Pagination.Models
{
    public partial class CollectionData<T>:ObservableObject where T : class
    {
        [ObservableProperty]
        private IEnumerable<T> data = new List<T>();

        public ICollectionView CollectionView { get; set; }
        public CollectionData() { }

        

        public void Binding()
        {
            CollectionView = CollectionViewSource.GetDefaultView(Data);
        }


    }
}
