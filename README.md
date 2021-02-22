# XamarinMvvm

### Mvvm framework built for Xamarin forms application. 

When we are implementing mvvm based architecture first thing to fallow is, our **Logic** should not involve the **Views** and **Views** should be independent of Navigations. With this in main focus this Framework is built. This contains Built-In IOC container based on TinyIoc which is super lite, dependency injection is done through constructor injection. ViewModel logic is Unit Testable.

### Main Features
1. Provides ViewModel Navigation
2. Auto wire Binding Context for view
3. Provides Built-In and Cusomizable Navigation Containers
4. Contains built-in IOC
5. Easy to Adopt and very minimal configurations
6. Customizable setting Binding Context logic (used during Auto-Wiring)

To get started, It is as easy as in default Xamarin.Forms applications, Very minimal confgurations required.

### Initialization and Start
Extend App.Xaml.cs class from IApplication and start the application.

```csharp

    public partial class App : Application, IApplication
    {
        public App()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            base.OnStart();
            MvvmIoc.NavigationService.StartApplication<LoginViewModel>(this, true);
        }
    }
```

Provide two interfaces
```csharp
    public interface INavigationService {}
    public interface IPageNavigation {}
```

**INavigationService** Handles application start and the container navigations.
```csharp
    void StartApplication(IApplication application);
    void StartApplication(IApplication application, IPageContainer pageContainer);
    void StartApplication<TViewModel>(IApplication application, bool navigatable, object parameter = null) where TViewModel : LifeCycleAwareViewModel;
    void SwitchRoot(IPageContainer pageContainer);
    void SwitchRoot<TViewModel>(object parameter = null) where TViewModel : LifeCycleAwareViewModel;
    void SwitchRootWithNavigation<TViewModel>(object parameter = null) where TViewModel : LifeCycleAwareViewModel;
```

