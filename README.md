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

Each ViewModel has to extend from LifeCycleAwareViewModel and LifeCycleAwareViewModel contains two interfaces which helps in initializations and navigations

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

**IPageNavigation** Handles navigation between pages through viewmodel navigation.
```csharp

    Task NavigateToAsync(IPageContainer pageContainer, bool animate = true);
    
    Task NavigateToAsync<TViewModel>(object parameter = null, bool animate = true) where TViewModel : LifeCycleAwareViewModel;
    
    Task NavigateToModalAsync<TViewModel>(object parameter = null, bool animate = true) where TViewModel : LifeCycleAwareViewModel;
    
    Task NavigateBackAsync();
    
    Task NavigateBackAsync(object parameter);
    
    Task NavigateToRootAsync();
    
    Task StartNewNavigationAsync<TViewModel>(object parameter = null, bool animate = true) where TViewModel : LifeCycleAwareViewModel;
```

### Page Container

**IPageContainer** provides just one method **GetPage()**. Customize and implement your own page container by inheriting this interface.

### Simple Built-In Navigation containers

**NavigationPageContainer**
Generates Xamarin.Forms NavigationPage object for the provided TViewModel Type, which in turn can be used for further navigation.

```csharp
    public class NavigationPageContainer<TViewModel> : NavigationPage, IPageContainer where TViewModel : LifeCycleAwareViewModel
```

**TabbedPageContainer**
Simple TabbedPage without Navigatable tabs. Provides **AddTabs()** method to add your Viewmodel as tabs.

```csharp
    public class TabbedPageContainer : TabbedPage, IPageContainer
```

```csharp
    /// <summary>
    /// Adds the tab.
    /// </summary>
    /// <typeparam name="TViewModel">The type of the view model.</typeparam>
    /// <param name="parameter">The parameter.</param>
    /// <param name="title">The title.</param>
    /// <param name="icon">The icon.</param>
    public void AddTab<TViewModel>(object parameter, string title, string icon) where TViewModel : LifeCycleAwareViewModel
    {
        var page = MvvmIoc.Container.Resolve<IPageNavigation>().FindAndCreatePage<TViewModel>(parameter);
        page.Title = title;
        page.IconImageSource = icon;
        Children.Add(page);
    }
```

**TabbedNavigationPageContainer**
Tabbed page with dedicated navation container for each tab. 

```csharp
    public class TabbedNavigationPageContainer : TabbedPage, IPageContainer
```

```csharp
    /// <summary>
    /// Adds the tab.
    /// </summary>
    /// <typeparam name="TViewModel">The type of the view model.</typeparam>
    /// <param name="parameter">The parameter.</param>
    /// <param name="title">The title.</param>
    /// <param name="icon">The icon.</param>
    public void AddTab<TViewModel>(object parameter, string title, string icon) where TViewModel : LifeCycleAwareViewModel
    {
        Children.Add(new NavigationPageContainer<TViewModel>(parameter) { Title = title, IconImageSource = icon }.GetPage());
    }
```

### Navigations

Navigate to new page with or without paramerter through Viewmodel
```csharp
    /// <summary>
    /// Navigates to new page asynchronously.
    /// </summary>
    /// <typeparam name="TViewModel">The type of the view model.</typeparam>
    /// <param name="parameter">The parameter.</param>
    /// <param name="animate">if set to <c>true</c> [animate].</param>
    /// <returns></returns>
    Task NavigateToAsync<TViewModel>(object parameter = null, bool animate = true) where TViewModel : LifeCycleAwareViewModel;
```

Navigate to new page with new page container
```csharp
    /// <summary>
    /// Navigates to new page asynchronously with new page container.
    /// </summary>
    /// <param name="pageContainer">The page container.</param>
    /// <param name="animate">if set to <c>true</c> [animate].</param>
    /// <returns></returns>
    Task NavigateToAsync(IPageContainer pageContainer, bool animate = true);
```

Navigate to new page with new Navigation container
```charp
    /// <summary>
    /// Starts the new navigation asynchronously.
    /// </summary>
    /// <typeparam name="TViewModel">The type of the view model.</typeparam>
    /// <param name="parameter">The parameter.</param>
    /// <param name="animate">if set to <c>true</c> [animate].</param>
    /// <returns></returns>
    Task StartNewNavigationAsync<TViewModel>(object parameter = null, bool animate = true) where TViewModel : LifeCycleAwareViewModel;
```

### Root Navigations
```charp
    /// <summary>
    /// Switches the root.
    /// </summary>
    /// <param name="pageContainer">The page container.</param>
    void SwitchRoot(IPageContainer pageContainer);
    
    
    /// <summary>
    /// Switches the root.
    /// </summary>
    /// <typeparam name="TViewModel">The type of the view model.</typeparam>
    /// <param name="parameter">The parameter.</param>
    void SwitchRoot<TViewModel>(object parameter = null) where TViewModel : LifeCycleAwareViewModel;
    
    
    /// <summary>
    /// Switches the root with navigation.
    /// </summary>
    /// <typeparam name="TViewModel">The type of the view model.</typeparam>
    /// <param name="parameter">The parameter.</param>
    void SwitchRootWithNavigation<TViewModel>(object parameter = null) where TViewModel : LifeCycleAwareViewModel;
```
