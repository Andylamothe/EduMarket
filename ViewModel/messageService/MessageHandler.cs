

using CommunityToolkit.Mvvm.Messaging;

namespace ViewModel.messageService;

public class MessageHandler<T>
{
    private readonly IMessenger _messenger = WeakReferenceMessenger.Default;
    private readonly Dictionary<string, Action<string, T>> _channelCallBack = new();

    public void  Send<K>(string channel, K value)
    {
        _messenger.Send(new ChannelMessage<K>(channel, value));
    }

    public void Listen(object Receiver)
    {
        _messenger.Register<ChannelMessage<T>>(Receiver, (r, m) =>
        {
            if(_channelCallBack.TryGetValue(m.Channel, out var CallBack))
            {
                CallBack.Invoke(m.Channel, m.Value);
            }
        });
    }

    public MessageHandler<T> RegisterChannel(string Channel, Action<string, T> CallBack)
    {
        _channelCallBack[Channel] = CallBack;
        return this;
    }
}