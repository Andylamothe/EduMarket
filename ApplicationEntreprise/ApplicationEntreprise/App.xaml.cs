using Microsoft.Extensions.DependencyInjection;
using ViewModel.navigationService;
using System.Windows;
using System.Windows.Controls;
using ViewModel.viewmodel;
using WpfApplication.page;
using Model.table;
using Model.repository;
using Model;
using Microsoft.EntityFrameworkCore.Internal;
using static Model.DataBaseContext;

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

        serviceCollection.AddTransient<DataBaseContext>();
        serviceCollection.AddTransient<UserModel>();
        serviceCollection.AddTransient<Item>();
        serviceCollection.AddTransient<Transaction>();
        serviceCollection.AddTransient<Groupe>();
        serviceCollection.AddTransient<Permission>();

        serviceCollection.AddTransient<Repository<UserModel>>();
        serviceCollection.AddTransient<Repository<Admin>>();
        serviceCollection.AddTransient<Repository<Departement>>();
        serviceCollection.AddTransient<Repository<Teacher>>();
        serviceCollection.AddTransient<Repository<Student>>();
        serviceCollection.AddTransient<Repository<Item>>();
        serviceCollection.AddTransient<Repository<Transaction>>();
        serviceCollection.AddTransient<Repository<Groupe>>();
        serviceCollection.AddTransient<Repository<Permission>>();

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
        
        var dbContext = ServiceProvider.GetRequiredService<DataBaseContext>();

        dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();

        DbInitializer.Seed(dbContext);


        navService.RegisterPage(ApplicationPage.SignIn, () =>
        {
            var view = ServiceProvider.GetRequiredService<SignInView>();
            view.DataContext = ServiceProvider.GetRequiredService<SignInViewModel<ApplicationPage, UserControl>>();
            return view;
        }).RegisterPage(ApplicationPage.SignUp, () =>
        {
            var view = ServiceProvider.GetRequiredService<SignUpView>();
            view.DataContext = ServiceProvider.GetRequiredService<SignUpViewModel<ApplicationPage, UserControl>>();
            return view;
        }).RegisterPage(ApplicationPage.Item, () =>
        {
            var view = ServiceProvider.GetRequiredService<ItemView>();
            view.DataContext = ServiceProvider.GetRequiredService<ItemViewModel<ApplicationPage, UserControl>>();
            return view;
        }).RegisterPage(ApplicationPage.Inventory, () =>
        {
            var view = ServiceProvider.GetRequiredService<InventoryView>();
            view.DataContext = ServiceProvider.GetRequiredService<InventoryViewModel<ApplicationPage, UserControl>>();
            return view;
        }).RegisterPage(ApplicationPage.Catalogue, () =>
        {
            var view = ServiceProvider.GetRequiredService<CatalogueView>();
            view.DataContext = ServiceProvider.GetRequiredService<CatalogueViewModel<ApplicationPage, UserControl>>();
            return view;
        }).RegisterPage(ApplicationPage.Calendrier, () =>
        {
            var view = ServiceProvider.GetRequiredService<CalendrierView>();
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

