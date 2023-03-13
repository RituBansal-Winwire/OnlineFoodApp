using OnlineFoodApp.ViewModels;

namespace FoodAppTestProject
{
    public class LoginViewModelTest
    {
        private LoginViewModel _viewModel;
        [SetUp]
        public void Setup()
        {
            _viewModel = new LoginViewModel();
        }

        [Test]
        public void CheckLoginUserSuccessFully__WhenThisMethodCalled()
        {
                var result = new LoginViewModel();
                _viewModel.UName = "ritub";
                _viewModel.Password= "password";
           
                _viewModel.SubmitCommand.Execute(result);
                var actual = _viewModel.isLogin;

                Assert.IsTrue(actual);
        }

    }
}