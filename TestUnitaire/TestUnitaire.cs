using ViewModel.messageService;

namespace TestUnitaire
{
    public class MessageHandlerTests
    {
        public record TestMessage(string Name);

        private class TestReceiver { }

        [Fact]
        public void RegisterChannel_ShouldStoreCallback()
        {
            var handler = new MessageHandler<TestMessage>();
            bool wasCalled = false;

            handler.RegisterChannel("test", (_, _) => wasCalled = true);

            handler.Send("test", new TestMessage("Hello"));

            Assert.False(wasCalled);
        }

        [Fact]
        public void Listen_And_Send_ShouldInvokeCorrectCallback()
        {
            var handler = new MessageHandler<TestMessage>();
            var receiver = new TestReceiver();

            string? receivedChannel = null;
            TestMessage? receivedValue = null;

            handler.RegisterChannel("myChannel", (channel, value) =>
            {
                receivedChannel = channel;
                receivedValue = value;
            });

            handler.Listen(receiver);

            var message = new TestMessage("World");
            handler.Send("myChannel", message);

            Assert.Equal("myChannel", receivedChannel);
            Assert.Equal("World", receivedValue?.Name);
        }

        [Fact]
        public void Send_ToUnknownChannel_ShouldNotThrow()
        {
            var handler = new MessageHandler<TestMessage>();
            var receiver = new TestReceiver();

            handler.Listen(receiver);

            var ex = Record.Exception(() => handler.Send("unknown", new TestMessage("data")));
            Assert.Null(ex);
        }

        [Fact]
        public void RegisterChannel_ShouldOverridePreviousCallback()
        {
            var handler = new MessageHandler<TestMessage>();
            var receiver = new TestReceiver();

            string result = "";

            handler.RegisterChannel("same", (_, _) => result = "first");
            handler.RegisterChannel("same", (_, _) => result = "second");

            handler.Listen(receiver);
            handler.Send("same", new TestMessage(""));

            Assert.Equal("second", result);
        }
    }
}