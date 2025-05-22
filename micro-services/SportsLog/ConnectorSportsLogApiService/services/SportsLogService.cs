////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using Microsoft.EntityFrameworkCore;
using SharedLib;
using DbcLib;
using System.Net.Http.Json;

namespace ConnectorSportsLogApiService;

/// <summary>
/// SportsLog
/// </summary>
public class SportsLogService(IHttpClientFactory HttpClientFactory,
    ILogger<SportsLogService> logger,
    IDbContextFactory<SportsLogContext> dbFactory)
    : ISportsLogService
{
    /// <inheritdoc/>
    public async Task<ResponseBaseModel> DownloadAndSaveAsync(BodyRequestSportsLogModel req, CancellationToken token = default)
    {
        using HttpClient httpClient = HttpClientFactory.CreateClient(HttpClientsNamesSportsLogEnum.Fantasy402.ToString());

        AuthenticateCustomerSportsLogResultModel? _jwt = await GetJWT(httpClient, req.Authorize, token);

        if (_jwt is null || string.IsNullOrWhiteSpace(_jwt.Code))
            return ResponseBaseModel.CreateError("Authorization error");

        IDictionary<string, object> postData = req.Payload.ToDictionary();
        using FormUrlEncodedContent content = new(postData.Select(x => new KeyValuePair<string, string>(x.Key, x.Value.ToString()!)));

        content.Headers.Clear();
        content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
        content.Headers.Add("Authorization", $"Bearer {_jwt.Code}");

        HttpResponseMessage response = await httpClient.PostAsync("Manager/getCustomerAdmin", content, token);

        TLISTResponseSportsLogModel<CustomerSportsLogModel>? customersGet = await response.Content.ReadFromJsonAsync<TLISTResponseSportsLogModel<CustomerSportsLogModel>>(cancellationToken: token);
        if (customersGet is null)
            return ResponseBaseModel.CreateError("`Manager/getCustomerAdmin` error");

        return ResponseBaseModel.CreateInfo("Ok");
    }

    static async Task<AuthenticateCustomerSportsLogResultModel?> GetJWT(HttpClient httpClient, AuthenticateCustomerRequestModel authorize, CancellationToken token = default)
    {
        IDictionary<string, object> postData = authorize.ToDictionary();
        using FormUrlEncodedContent content = new(postData.Select(x => new KeyValuePair<string, string>(x.Key, x.Value.ToString()!)));

        content.Headers.Clear();
        content.Headers.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

        HttpResponseMessage response = await httpClient.PostAsync("System/authenticateCustomer", content, token);
        var v = await response.Content.ReadAsStringAsync(token);
        var v2 = await response.RequestMessage!.Content!.ReadAsStringAsync(token);
        return await response.Content.ReadFromJsonAsync<AuthenticateCustomerSportsLogResultModel>(cancellationToken: token);
    }
}