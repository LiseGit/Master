using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Master.Pages
{
    public class MenuItem : INotifyPropertyChanged
    {
        private bool _isSelected;

        public string Title {get;set;}

        public string ImagePath { get; set; }

        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        private List<MenuItem> _items;
        public event EventHandler<string> PageChanged;
        public MenuPage()
        {
            InitializeComponent();
            _items = new List<MenuItem>
            {
                new MenuItem {Title="Search & Browse", ImagePath="resource://Master.Resources.SvgImages.icon_search.svg", IsSelected=true},
                new MenuItem {Title="Inventory", ImagePath="resource://Master.Resources.SvgImages.inventory_icon.svg"},
                new MenuItem {Title="Reconciliation", ImagePath="resource://Master.Resources.SvgImages.icon_reconciliation.svg"},
                new MenuItem {Title="SDS", ImagePath="resource://Master.Resources.SvgImages.SmartSuite_light_gold_icon.svg"},
                new MenuItem {Title="VSDS", ImagePath="resource://Master.Resources.SvgImages.SmartSuite_sky_blue_icon.svg"},
                new MenuItem {Title="INI", ImagePath="resource://Master.Resources.SvgImages.SmartSuite_apple_icon.svg"},
                new MenuItem {Title="COBRA", ImagePath="resource://Master.Resources.SvgImages.SmartSuite_grapefruit_icon.svg"},
                new MenuItem {Title="ER", ImagePath="resource://Master.Resources.SvgImages.SmartSuite_orangeish_icon.svg"},
                new MenuItem {Title="Settings", ImagePath="resource://Master.Resources.SvgImages.settings_icon.svg"}
            };
            BindableLayout.SetItemsSource(list, _items);
        }


        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var selectedGrid = sender as Grid;
            var selectedItem = selectedGrid.BindingContext as MenuItem;
            _items.ForEach(x => x.IsSelected = false);
            selectedItem.IsSelected = true;
            PageChanged?.Invoke(this, selectedItem.Title);

        }
    }
}