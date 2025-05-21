////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using SharedLib;

namespace ConnectorSportsLogApiService;

/// <summary>
/// MQ listen
/// </summary>
public static class RegisterMqListenerExtension
{
    /// <summary>
    /// RegisterMqListeners
    /// </summary>
    public static IServiceCollection ApiBreezRuRegisterMqListeners(this IServiceCollection services)
    {
        return services
            //.RegisterMqListener<, , >()
            ;
    }
}