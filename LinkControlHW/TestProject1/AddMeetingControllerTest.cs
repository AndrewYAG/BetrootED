using LinkControlHW;
using Xunit;

namespace TestProject1
{
    public class AddMeetingControllerTest
    {
        [Fact]
        public void AddMeetingController_ExecuteAction_ShouldReturnMenuItemController()
        {
            var sut = new AddMeetingController();

            var nextController = sut.ExecuteAction();

            Assert.NotNull(nextController);
            Assert.IsType<MenuItemController>(nextController);
            Assert.IsAssignableFrom<IController>(nextController);
        }
    }
}