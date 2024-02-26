using Bogus;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataGrid_Filter.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DataGrid_Filter.ViewModels
{
    public partial class DataGrid2ViewModel : ObservableObject
    {
        [ObservableProperty]
        private List<Models.Person> people = new List<Models.Person>();

        [ObservableProperty]
        private ICollectionView collectionView;

        private string filterStr = "";

        public string FilterStr
        {
            get
            {
                return filterStr;
            }
            set
            {
                SetProperty(ref filterStr, value);
                CollectionView.Refresh();
            }
        }


        [RelayCommand]
        public void AddItem()
        {
            var item = DataGridViewModel.Faker.Generate();
            People.Add(item);
            CollectionView.Refresh();
        }

        public DataGrid2ViewModel()
        {
            People = DataGridViewModel.Faker.Generate(10).ToList();
            CollectionView = CollectionViewSource.GetDefaultView(People);
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

        }
    }
}
