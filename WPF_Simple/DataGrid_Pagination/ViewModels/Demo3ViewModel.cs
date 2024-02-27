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
    public partial class Demo3ViewModel : ObservableObject
    {
        public Demo3View View { get; set; }

        [ObservableProperty]
        private CollectionData<Student> collectionData = new CollectionData<Student>();

        private int pageIndex = 1;
        public int PageIndex
        {
            get => pageIndex;
            set
            {
                SetProperty(ref pageIndex, value);
                CollectionData.CollectionView.Refresh();
            }
        }

        public readonly int PageSize = 10;


        [ObservableProperty]
        private int pageCount = 1;

        public readonly List<Student> Students = new Student().FakeMany(150).ToList();


        public Demo3ViewModel()
        {
            CollectionData = new CollectionData<Student>()
            {
                Data = Students.Take(PageSize),
            };
            CollectionData.Binding();
            CollectionData.CollectionView.CollectionChanged += (s, e) =>
            {
                var count = Students.Count;
                PageCount = (int)Math.Ceiling((decimal)(count / PageSize));
                CollectionData.Data = Students.Skip((PageIndex - 1) * PageSize).Take(PageSize);
            };


        }
    }
}
