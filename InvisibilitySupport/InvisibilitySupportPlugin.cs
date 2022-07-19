using Impostor.Api.Events;
using Impostor.Api.Events.Managers;
using Impostor.Api.Net.Custom;
using Impostor.Api.Plugins;
using Microsoft.Extensions.Logging;

namespace InvisibilitySupport;

[ImpostorPlugin("InvisibilitySupport")]
public class InvisibilitySupportPlugin : PluginBase
{
    private readonly ILogger<InvisibilitySupportPlugin> _logger;
    private readonly ICustomMessageManager<ICustomRpc> _customRpcManager;
    private IDisposable? _disposable;

    public InvisibilitySupportPlugin(ILogger<InvisibilitySupportPlugin> logger, ICustomMessageManager<ICustomRpc> customRpcManager)
    {
        _logger = logger;
        _customRpcManager = customRpcManager;
    }

    public override ValueTask EnableAsync()
    {
        _disposable = _customRpcManager.Register(new ToggleInvisibilityRpc());
        return default;
    }

    public override ValueTask DisableAsync()
    {
        _disposable?.Dispose();
        return default;
    }
}