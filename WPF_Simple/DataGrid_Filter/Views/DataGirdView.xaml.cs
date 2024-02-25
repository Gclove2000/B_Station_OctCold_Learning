using DataGrid_Filter.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataGrid_Filter.Views
{
    /// <summary>
    /// DataGirdView.xaml 的交互逻辑
    /// </summary>
    public partial class DataGirdView : UserControl
    {
        
        public DataGirdView()
        {
            InitializeComponent();
            //将主要的代码逻辑放在ViewModel里面
            ViewModel.DataGirdView = this;
        }

 
    }
}
