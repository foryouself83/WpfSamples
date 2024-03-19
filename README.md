# WpfSamples
A basic sample to learn about WPF.
- [Dependency Injection](<https://learn.microsoft.com/ko-kr/dotnet/core/extensions/dependency-injection>) and [Dependency inversion](<https://learn.microsoft.com/ko-kr/dotnet/architecture/modern-web-apps-azure/architectural-principles#dependency-inversion>).
- [DataTemplate](<https://learn.microsoft.com/ko-kr/dotnet/api/system.windows.datatemplate?view=windowsdesktop-8.0>), [ControlTemplate](<https://learn.microsoft.com/ko-kr/dotnet/api/system.windows.controls.controltemplate?view=windowsdesktop-8.0>).
- [Pub/Sub](<https://learn.microsoft.com/en-us/azure/architecture/patterns/publisher-subscriber>)

## Used nuget
- [Community Toolkit](<https://github.com/CommunityToolkit>)
- [Microsoft.Extensions.DependencyInjection](<https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection>)

## Description
### Dependency Injection
> Dependency is what happens when one class changes to another class.
> Dependency injection loosely couples objects by injecting dependencies from outside rather than creating the objects directly.
#### Advantages
  - Increased extensibility
    - When you add new features or modules, dependency injection allows you to inject new objects to increase scalability.
  - Reduced dependencies
    - Reduced dependencies mean that modifications to an object are less likely to affect other objects, reducing the number of modification points.
  - Increased reusability
    - Injected classes are naturally modularized, improving reusability.
  - Ease of unit testing
    - Dependency injection facilitates unit testing because it is easy to replace the dependent part with a mock object, etc.
    - Unit tests can be separated by object
#### Implementation Methods
  - Nuget
    - Download [Microsoft.Extensions.DependencyInjection](<https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection>)
  - App.xaml.cs
     - Override the "OnStartUp" method
     - Create a "ServiceCollection"
     - Register a service in the "ServiceCollection"
     - Run the "BuildServiceProvider" method of "ServiceCollection"
     - Run the "GetService<T>" method on the Provider
  - Injecting Interface in the constructor
### Templates
> In the dictionary definition, it is generally referred to as a model or format for creating something. For example, in a word processor, a document template is a predefined format or layout used to create new documents.
> In WPF, templates are used to define the appearance and layout of user interface (UI) elements, and you use ControlTemplate or DataTemplate to define appearance and behavior templates.
#### ControlTemplate
- Definition
  - A template used to define the layout and appearance of a UI control.
  - Primarily used to customize or change the appearance and behavior of a control.
- Component
  - Contains several UI elements (Panel, Border, TextBlock, etc.)
  - Completely override the visual appearance and layout of the control
- Advantages
  - Fully customizable appearance and behavior of the control
  - Increases reusability
- Disadvantages
  - Modifying the ControlTemplate also changes the behavior and layout of the control. There is a higher need to set up new behaviors and layouts
  - This makes code difficult to read when constructing complex UIs
- Trigger
  - Allows you to dynamically change the UI by directly accessing the Controls you define

#### DataTemplate
- Definition
  - Used to define how data-bound data will be represented
  - Primarily used to specify the layout for each item in the ItemsControl
- Component
  - Contains the UI elements to display the data Used as a template for each item in the ItemsControl (DataTemplateSelector)
- Advantages
  - Overrides how data is displayed
  - Templates can be created for various data types, making them easy to reuse
- Disadvantages
  - You can't change the appearance or behavior of the control because you're only dealing with the visual representation of the data.
- Trigger
  - Used to dynamically change the UI based on property values of data-bound items
  - To change the UI of the parent control, define a RelativceSource and use it.
   
## Unit Test
### 3A
- Arrange
  - Set up all the prerequisites for the test. In this step, you create the target object to test, set the required input values, and configure the test environment.
test environment.
- Act
  - Call the object or method under test and perform the behavior you want to verify in your test code. This is where the actual execution of the test takes place.
- Assert
  - Validate the results of your test and verify that the expected results match the actual results. This step determines whether the test succeeded or failed. 
### Mock
- Dependency Injection
  - Isolate your code by injecting objects that depend on the code being tested.
  - You can isolate your code for easier control in your tests and inject mock objects in the mock
- Extendability and flexibility of code
  - Interfaces make your code more extensible
  - Changing the behavior of a test case without modifying its code You can change the behavior of a test case without modifying its code

## Design Patterns
### Publish / Subscribe Pattern
- Publishing
  - Publishers or topics generate events or messages and deliver them to subscribers.
  - Publishers create events and notify subscribers about them.
  - Publishers typically publish events for specific topics, and whenever an event occurs, it is broadcasted to all subscribers of that topic.
- Subscribing
  - Subscribers receive events generated by publishers and process them.
  - Subscribers subscribe to specific topics and receive events related to those topics for processing.
  - Each subscriber registers to subscribe to a publisher and defines the processing logic for the events they receive.
- features
  - Loose Coupling
    - Publishers and subscribers are not directly connected; they communicate through an intermediary. This increases the flexibility and scalability of the system.
  - Scalability
    - New publishers or subscribers can be added or removed, and the system can scale by distributing the load.
  - Event-driven
    - Various components of the system react to events asynchronously, allowing for more efficient processing.

## Implement
  - Dependency Injection
    - [ServiceRegister](<https://github.com/foryouself83/WpfSamples/blob/master/CoreSamples/Services/Impl/ServiceRegister.cs>)
    - [NavigationSampleViewModel](<https://github.com/foryouself83/WpfSamples/blob/master/TemplateSamples/ViewModels/NavigationSampleViewModel.cs>)
  - Navigator
    - [NavigatorService](<https://github.com/foryouself83/WpfSamples/blob/master/CoreSamples/Services/Impl/NavigatorService.cs>)
  - Templates
    - [DataTemplate](<https://github.com/foryouself83/WpfSamples/blob/master/TemplateSamples/Views/TemplateView.xaml#L118>)
    - [ControlTemplate](<https://github.com/foryouself83/WpfSamples/blob/master/TemplateSamples/Views/TemplateView.xaml#L71>)
  - Selector
    - [DataTemplateSelector](<https://github.com/foryouself83/WpfSamples/blob/master/TemplateSamples/Presentations/Selectors/ListViewItemTemplateSelector.cs>)
  - Styles
    - [ListView Style](<https://github.com/foryouself83/WpfSamples/blob/master/TemplateSamples/Views/TemplateView.xaml#L11>)    
    - [Unit Test](<https://github.com/foryouself83/WpfSamples/tree/master/CoreSamplesTests>)
  - Design Patterns
    - [Pub/Sub](<https://github.com/foryouself83/WpfSamples/blob/master/CoreSamples/Services/Impl/EventBrokerService.cs>)
## Tips
  - Debugging
    - UI
      - [Live Visual Tree](<https://learn.microsoft.com/en-us/visualstudio/xaml-tools/inspect-xaml-properties-while-debugging?view=vs-2022#look-at-elements-in-the-live-visual-tree>)
      - [Live Property Explorer](<https://learn.microsoft.com/en-us/visualstudio/xaml-tools/inspect-xaml-properties-while-debugging?view=vs-2022#inspect-xaml-properties>)
      - [XAML Live Preview](<https://learn.microsoft.com/en-us/visualstudio/xaml-tools/xaml-live-preview?view=vs-2022>)
      - [XAML binding errors](<https://learn.microsoft.com/en-us/visualstudio/xaml-tools/xaml-data-binding-diagnostics?view=vs-2022>)
      - [Snoop](<https://github.com/snoopwpf/snoopwpf>)
    
