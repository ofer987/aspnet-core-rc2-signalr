using Xunit;

using WebApplication.Models.ManageViewModels;

namespace WebApplication.Tests.Models.ManageViewModels
{
    public class ChangePasswordTests
    {
        [Fact]
        public void PasswordMatches()
        {
            var model = new ChangePasswordViewModel
            {
                OldPassword = "hello_kitty"
            };

            model.NewPassword = "bye_kitty";
            model.ConfirmPassword = "bye_kitty";

            Assert.Equal(true, model.IsValid());
        }

        public void PasswordIsNull()
        {
        }
    }
}
