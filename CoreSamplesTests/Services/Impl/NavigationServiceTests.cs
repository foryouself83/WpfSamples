using Moq;
using Xunit;

namespace CoreSamples.Services.Impl.Tests
{
    public class NavigationServiceTests
    {
        // Helper class for testing
        private class SampleView { }

        // Helper class for testing
        private class AnotherView { }

        [Fact]
        public void NavigateTo_ClearsViewsAndSetsCurrentView()
        {
            // Arrange
            var serviceRegistryMock = new Mock<IServiceRegister>();
            serviceRegistryMock.Setup(sr => sr.GetService<SampleView>()).Returns(new SampleView());
            var navigationService = new NavigationService(serviceRegistryMock.Object);

            // Act
            navigationService.NavigateTo<SampleView>();

            // Assert
            Assert.Empty(navigationService.Views);
            Assert.IsType<SampleView>(navigationService.CurrentView);
        }

        [Fact]
        public void Push_SetsCurrentViewAndPushesToViews()
        {
            // Arrange
            var serviceRegistryMock = new Mock<IServiceRegister>();
            var sampleView = new SampleView();
            var anotherView = new AnotherView();
            serviceRegistryMock.Setup(sr => sr.GetService<SampleView>()).Returns(sampleView);
            serviceRegistryMock.Setup(sr => sr.GetService<AnotherView>()).Returns(anotherView);
            var navigationService = new NavigationService(serviceRegistryMock.Object);

            // Act
            navigationService.NavigateTo<SampleView>();
            var pushedView = navigationService.Push<AnotherView>();

            // Assert
            Assert.Single(navigationService.Views);
            Assert.Equal(pushedView, navigationService.CurrentView);
            Assert.IsType<AnotherView>(navigationService.CurrentView);
        }

        [Fact]
        public void Pop_PopsFromViewsAndSetsCurrentView()
        {
            // Arrange
            var serviceRegistryMock = new Mock<IServiceRegister>();

            var sampleView = new SampleView();
            var anotherView = new AnotherView();

            serviceRegistryMock.Setup(sr => sr.GetService<SampleView>()).Returns(sampleView);
            serviceRegistryMock.Setup(sr => sr.GetService<AnotherView>()).Returns(anotherView);
            var navigationService = new NavigationService(serviceRegistryMock.Object);

            navigationService.NavigateTo<SampleView>();
            navigationService.Push<AnotherView>();

            // Act
            var poppedView = navigationService.Pop();

            // Assert
            Assert.Equal(sampleView, navigationService.CurrentView);
            Assert.Equal(sampleView, poppedView);
        }

        [Fact]
        public void Pop_ReturnsCurrentViewIfViewsEmpty()
        {
            // Arrange
            var serviceRegistryMock = new Mock<IServiceRegister>();
            var sampleView = new SampleView();
            serviceRegistryMock.Setup(sr => sr.GetService<SampleView>()).Returns(sampleView);
            var navigationService = new NavigationService(serviceRegistryMock.Object);

            navigationService.NavigateTo<SampleView>();
            navigationService.Push<SampleView>();

            // Act
            var poppedView = navigationService.Pop();

            // Assert
            Assert.Equal(sampleView, poppedView);
        }

        [Fact]
        public void Peek_ReturnsCurrentViewIfViewsEmpty()
        {
            // Arrange
            var serviceRegistryMock = new Mock<IServiceRegister>();
            var sampleView = new SampleView();
            serviceRegistryMock.Setup(sr => sr.GetService<SampleView>()).Returns(sampleView);
            var navigationService = new NavigationService(serviceRegistryMock.Object);

            navigationService.NavigateTo<SampleView>();
            navigationService.Push<SampleView>();

            // Act
            var peekedView = navigationService.Peek();

            // Assert
            Assert.Equal(sampleView, peekedView);
        }

        [Fact]
        public void Peek_ReturnsTopView()
        {
            // Arrange
            var serviceRegistryMock = new Mock<IServiceRegister>();
            var sampleView = new SampleView();
            var anotherView = new AnotherView();
            serviceRegistryMock.Setup(sr => sr.GetService<SampleView>()).Returns(sampleView);
            serviceRegistryMock.Setup(sr => sr.GetService<AnotherView>()).Returns(anotherView);
            var navigationService = new NavigationService(serviceRegistryMock.Object);

            navigationService.NavigateTo<SampleView>();
            navigationService.Push<AnotherView>();

            // Act
            var peekedView = navigationService.Peek();

            // Assert
            Assert.Equal(sampleView, peekedView);
        }

        [Fact]
        public void Clear_ClearsViews()
        {
            // Arrange
            var serviceRegistryMock = new Mock<IServiceRegister>();
            serviceRegistryMock.Setup(sr => sr.GetService<SampleView>()).Returns(new SampleView());
            serviceRegistryMock.Setup(sr => sr.GetService<AnotherView>()).Returns(new AnotherView());
            var navigationService = new NavigationService(serviceRegistryMock.Object);

            navigationService.NavigateTo<SampleView>();
            navigationService.Push<SampleView>();
            navigationService.Push<AnotherView>();

            // Act
            navigationService.Clear();

            // Assert
            Assert.Empty(navigationService.Views);
        }
    }
}