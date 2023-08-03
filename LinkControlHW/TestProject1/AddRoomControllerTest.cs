using LinkControlHW;
using Xunit;

namespace TestProject1
{
    public class AddRoomControllerTest
    {
        [Fact]
        public void AddRoomController_ExecuteAction_ShouldReturnMenuItemController()
        {
            var sut = new AddRoomController();

            var nextController = sut.ExecuteAction();

            Assert.NotNull(nextController);
            Assert.IsType<MenuItemController>(nextController);
            Assert.IsAssignableFrom<IController>(nextController);
        }
    }
}