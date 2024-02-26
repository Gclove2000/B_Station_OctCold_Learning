using Bogus;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfMvvmDemo.ViewModels
{
    public partial class DemoViewModel:ObservableObject
    {
        [ObservableProperty]
        private List<Models.Person> people = new List<Models.Person>();


        [ObservableProperty]
        private ICollectionView peopleView;

        [RelayCommand]
        public void AddItem()
        {
           
            People.Add(Models.Person.FakerOne);
            //没有效果
            //OnPropertyChanged(nameof(People));

            //没有效果
            //SetProperty(ref people, people);

            //直接更新整个视图源
            PeopleView.Refresh();
            
        }
        [RelayCommand]
        public void UpId()
        {
            foreach (var item in People)
            {
                item.Id += 10;
            }
            PeopleView.Refresh();

        }

        public DemoViewModel() {
            People = Models.Person.FakerMany(5).ToList();
            PeopleView = CollectionViewSource.GetDefaultView(People);
        }

       
    }
}
