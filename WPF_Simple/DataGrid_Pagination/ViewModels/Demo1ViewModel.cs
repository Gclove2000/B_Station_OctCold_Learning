using CommunityToolkit.Mvvm.ComponentModel;
using DataGrid_Pagination.Models;
using DataGrid_Pagination.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid_Pagination.ViewModels
{
    public partial class Demo1ViewModel : ObservableObject
    {

        public Demo1View View { get; set; }

        [ObservableProperty]
        private CollectionData<Student> collectionData = new CollectionData<Student>();

        [ObservableProperty]
        private int pageIndex = 1;

        public readonly int PageSize = 10;


        [ObservableProperty]
        private int pageCount = 1;




        public Demo1ViewModel()
        {
            CollectionData = new CollectionData<Student>()
            {
                Data = new Student().FakeMany(150)
            };
            CollectionData.Binding();
            CollectionData.CollectionView.CollectionChanged += (s, e) =>
            {
                var count = CollectionData.Data.ToList().Count;
                PageCount = (int)Math.Ceiling((decimal)(count / PageSize));
            };
            CollectionData.CollectionView.Refresh();
        }

    }
}
