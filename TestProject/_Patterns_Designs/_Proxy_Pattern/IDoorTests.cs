namespace Test._Patterns_Designs._Proxy_Pattern
{
    using Client._Patterns_Designs._Proxy_Pattern;
    using System;
    using Xunit;
    using Client._Patterns_Designs._State_Pattern;
    using System.Windows.Forms;

    public class IDoorTests
    {
        private class TestIDoor : IDoor
        {
            public override void Request()
            {
            }

            public override void createDoor(State state)
            {
            }

            public override void setPicBox(PictureBox pickBox)
            {
            }

            public override PictureBox getPicBox()
            {
                return default(PictureBox);
            }

            public override void setState(State state)
            {
            }

            public override State getState()
            {
                return default(State);
            }
        }

        private TestIDoor _testClass;

        public IDoorTests()
        {
            _testClass = new TestIDoor();
        }
    }
}