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
    public partial class Demo2ViewModel : ObservableObject
    {

        public Demo2View View { get; set; }

        [ObservableProperty]
        private CollectionData<Student> collectionData = new CollectionData<Student>();



        private int pageIndex = 1;
        public int PageIndex
        {
            get => pageIndex;
            set {
                SetProperty(ref pageIndex, value);
                CollectionData.CollectionView.Refresh();
            }
        }

        public readonly int PageSize = 10;


        [ObservableProperty]
        private int pageCount = 1;




        public Demo2ViewModel()
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
            CollectionData.CollectionView.Filter = (item) =>
            {
                if (!(item is Student))
                {
                    throw new Exception("属性类型不为Student");
                }
                var index = CollectionData.Data.ToList().IndexOf((Student)item);
                return PageIndex == index / PageSize + 1;

            };
            CollectionData.CollectionView.Refresh();
        }

    }
}
