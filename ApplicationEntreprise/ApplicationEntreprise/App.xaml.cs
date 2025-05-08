using Microsoft.Extensions.DependencyInjection;
using ViewModel.navigationService;
using System.Windows;
using System.Windows.Controls;
using ViewModel.viewmodel;
using WpfApplication.page;

namespace ApplicationEntreprise;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>

public partial class App : Application
{
    public static IServiceProvider? ServiceProvider { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddSingleton<MainWindow>();
        serviceCollection.AddSingleton<MainViewModel<ApplicationPage, UserControl>>();
        serviceCollection.AddSingleton<INavigationService<ApplicationPage, UserControl>, NavigationService<ApplicationPage, UserControl>>();

        serviceCollection.AddSingleton<SignInViewModel<ApplicationPage, UserControl>>();
        serviceCollection.AddTransient<SignInView>();
        serviceCollection.AddSingleton<SignUpViewModel<ApplicationPage, UserControl>>();
        serviceCollection.AddTransient<SignUpView>();
        serviceCollection.AddSingleton<ItemViewModel<ApplicationPage, UserControl>>();
        serviceCollection.AddTransient<ItemView>();
        serviceCollection.AddSingleton<InventoryViewModel<ApplicationPage, UserControl>>();
        serviceCollection.AddTransient<InventoryView>();
        serviceCollection.AddSingleton<CatalogueViewModel<ApplicationPage, UserControl>>();
        serviceCollection.AddTransient<CatalogueView>();
        serviceCollection.AddSingleton<CalendrierViewModel<ApplicationPage, UserControl>>();
        serviceCollection.AddTransient<CalendrierView>();


        ServiceProvider = serviceCollection.BuildServiceProvider();
        var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        var navService = ServiceProvider.GetRequiredService<INavigationService<ApplicationPage, UserControl>>();

        navService.RegisterPage(ApplicationPage.SignIn, () =>
        {
            var view = ServiceProvider.GetRequiredService<SignInView>();
            view.DataContext = ServiceProvider.GetRequiredService<SignInViewModel<ApplicationPage, UserControl>>();
            return view;
        }).RegisterPage(ApplicationPage.SignUp, () =>
        {
<<<<<<< HEAD
            var view = ServiceProvider.GetRequiredService<SignUp>();
=======
            var view = ServiceProvider.GetRequiredService<SignUpView>();
>>>>>>> 8f655e4ec8a345384633f47e78bb404759f39923
            view.DataContext = ServiceProvider.GetRequiredService<SignUpViewModel<ApplicationPage, UserControl>>();
            return view;
        }).RegisterPage(ApplicationPage.Item, () =>
        {
<<<<<<< HEAD
            var view = ServiceProvider.GetRequiredService<Item>();
=======
            var view = ServiceProvider.GetRequiredService<ItemView>();
>>>>>>> 8f655e4ec8a345384633f47e78bb404759f39923
            view.DataContext = ServiceProvider.GetRequiredService<ItemViewModel<ApplicationPage, UserControl>>();
            return view;
        }).RegisterPage(ApplicationPage.Inventory, () =>
        {
<<<<<<< HEAD
            var view = ServiceProvider.GetRequiredService<Inventory>();
=======
            var view = ServiceProvider.GetRequiredService<InventoryView>();
>>>>>>> 8f655e4ec8a345384633f47e78bb404759f39923
            view.DataContext = ServiceProvider.GetRequiredService<InventoryViewModel<ApplicationPage, UserControl>>();
            return view;
        }).RegisterPage(ApplicationPage.Catalogue, () =>
        {
<<<<<<< HEAD
            var view = ServiceProvider.GetRequiredService<Catalogue>();
=======
            var view = ServiceProvider.GetRequiredService<CatalogueView>();
>>>>>>> 8f655e4ec8a345384633f47e78bb404759f39923
            view.DataContext = ServiceProvider.GetRequiredService<CatalogueViewModel<ApplicationPage, UserControl>>();
            return view;
        }).RegisterPage(ApplicationPage.Calendrier, () =>
        {
<<<<<<< HEAD
            var view = ServiceProvider.GetRequiredService<Calendrier>();
=======
            var view = ServiceProvider.GetRequiredService<CalendrierView>();
>>>>>>> 8f655e4ec8a345384633f47e78bb404759f39923
            view.DataContext = ServiceProvider.GetRequiredService<CalendrierViewModel<ApplicationPage, UserControl>>();
            return view;
        });


        navService.OnNavigate = page =>
        {
            mainWindow.MainContent.Content = page;
        };

        mainWindow.Show();

        navService.NavigateTo(ApplicationPage.SignUp);

        base.OnStartup(e);
    }
}

