﻿using LinkControlHW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class ShowRoomsControllerTest
    {
        [Fact]
        public void FindMeetingByRoomTest_ExecuteAction_ShouldReturnMenuItemController()
        {
            var sut = new ShowRoomsController();

            var nextController = sut.ExecuteAction();

            Assert.NotNull(nextController);
            Assert.IsType<MenuItemController>(nextController);
            Assert.IsAssignableFrom<IController>(nextController);
        }
    }
}
