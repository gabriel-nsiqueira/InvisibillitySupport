using Impostor.Api.Net;
using Impostor.Api.Net.Custom;
using Impostor.Api.Net.Inner;
using Impostor.Api.Net.Messages;
#pragma warning disable CS1998

namespace InvisibilitySupport;

public class ToggleInvisibilityRpc : ICustomRpc
{
    public byte Id => 234;
    public bool IsInvisible { get; private set; }

    public async ValueTask<bool> HandleRpcAsync(IInnerNetObject innerNetObject,
        IClientPlayer sender,
        IClientPlayer? target,
        IMessageReader reader)
    {
        IsInvisible = reader.ReadBoolean();
        return true;
    }
}