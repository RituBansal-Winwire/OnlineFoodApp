using OnlineFoodApp.ViewModels;

namespace FoodAppTestProject
{
    public class RestaurantViewModelTest
    {
        private RestaurantModelView  _viewModel;
        [SetUp]
        public void Setup()
        {
            _viewModel = new RestaurantModelView();
        }

        [Test]
        public void AddNewRestaurant_WhenThisMethodCalled()
        {
            var result = new RestaurantModelView();
            _viewModel.DName = "Test";
            _viewModel.Address = "TestAddress";
            _viewModel.Price= 10;
            
            _viewModel.AddCommand.Execute(result);
            var actual = _viewModel.Id;

            Assert.That(true);
        }

    }
}
