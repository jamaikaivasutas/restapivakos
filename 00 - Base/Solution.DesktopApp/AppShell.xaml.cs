namespace Solution.DesktopApp
{
    public partial class AppShell : Shell
    {
        public AppShellViewModel ViewModel => this.BindingContext as AppShellViewModel;
        public AppShell(AppShellViewModel viewModel)
        {
            this.BindingContext = viewModel;

            InitializeComponent();

            ConfigureShellNavigation();
        }

        private static void ConfigureShellNavigation()
        {
            Routing.RegisterRoute(MainView.Name, typeof(MainView));
            Routing.RegisterRoute(CreateOrEditChocolateView.Name, typeof(CreateOrEditChocolateView));
            Routing.RegisterRoute(ListChocolateView.Name, typeof(ListChocolateView));
            Routing.RegisterRoute(CreateOrEditBrandView.Name, typeof(CreateOrEditBrandView));
            Routing.RegisterRoute(ListBrandView.Name, typeof(ListBrandView));
        }
    }
}
