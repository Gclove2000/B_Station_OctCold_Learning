using Bogus;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataGrid_Filter.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace DataGrid_Filter.ViewModels
{
    public partial class DataGridViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title = "DataGird Tttle";

        [ObservableProperty]
        private ObservableCollection<Models.Person> peopleList = new();

        [ObservableProperty]
        private ICollectionView collectionView;

        [ObservableProperty]
        private string filterStr = "";


        private DataGrid_Filter.Views.DataGirdView dataGirdView;
        public DataGrid_Filter.Views.DataGirdView DataGirdView
        {
            get => dataGirdView;
            set {
                dataGirdView = value;
                ViewInit();
            }
        }

        public static int OrderId = 1;


        /// <summary>
        /// 生成模拟的数据
        /// </summary>
        public static Faker<Models.Person> Faker = new Faker<Models.Person>()
            .RuleFor(t => t.Id, f => OrderId++)
            .RuleFor(t => t.FirstName, f => f.Name.FirstName())
            .RuleFor(t => t.LastName, f => f.Name.LastName())
            .RuleFor(t => t.FullName, f => f.Name.FullName())
            .RuleFor(t => t.BirthDay, f => f.Date.Between(new DateTime(1990, 1, 1), new DateTime(2010, 1, 1)));

        public DataGridViewModel()
        {
            PeopleList = new ObservableCollection<Models.Person>(Faker.Generate(10));

        }

        [RelayCommand]
        public void AddItem()
        {
            var item = Faker.Generate();
            PeopleList.Add(item);
        }

        public void ViewInit()
        {
            //获取ItemSource的CollectionView
            CollectionView = CollectionViewSource.GetDefaultView(DataGirdView.PeopleDataGrid.ItemsSource);
            //给CollectionView添加过滤规则
            CollectionView.Filter = (item) =>
            {
                if (string.IsNullOrEmpty(FilterStr))
                {
                    return true;
                }
                else
                {
                    var model = item as Models.Person;
                    return model.FirstName.Contains(FilterStr) || model.LastName.Contains(FilterStr) || model.FullName.Contains(FilterStr);
                }
            };
            
            //在TextChanged的时候，实时更新
            DataGirdView.FilterBox.TextChanged += (s, e) =>
            {
                CollectionView.Refresh();
            };
            
        }

    }
}
