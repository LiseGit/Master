using FreshMvvm;
using Master.PageModels;
using Master.Pages;

namespace Master
{
    class MenuNavigationContainer : FreshMasterDetailNavigationContainer
    {
        public MenuNavigationContainer(string naserviceName) : base(naserviceName)
        {
            Init("Title", "hamburgericon");

            AddPage<SearchAndBrowsePageModel>("Search & Browse");
            AddPage<InventoryPageModel>("Inventory");
            AddPage<ReconciliationPageModel>("Reconciliation");
            AddPage<SDSPageModel>("SDS");
            AddPage<SettingsPageModel>("Settings");

        }

        protected override void CreateMenuPage(string menuPageTitle, string menuIcon = null)
        {
            var master = new MenuPage();
            Master = master;
            Detail = new SearchAndBrowsePage();
            //Detail = new InventoryPage();
            master.PageChanged += delegate (object sender, string pageName)
            {
                Detail = Pages[pageName];
                IsPresented = false;
            };

        }
    }
}
