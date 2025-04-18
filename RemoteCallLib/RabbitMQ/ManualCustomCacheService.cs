﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using Microsoft.Extensions.Caching.Distributed;
using SharedLib;

namespace RemoteCallLib;

/// <summary>
/// Сервис IDistributedCache
/// </summary>
/// <remarks>
/// Конструктор
/// </remarks>
public class ManualCustomCacheService(IDistributedCache set_cache)
    : IManualCustomCacheService
{
    private readonly IDistributedCache _cache = set_cache;

    #region get
    /// <inheritdoc/>
    public async Task<string?> GetStringValueAsync(MemCacheComplexKeyModel mem_key, CancellationToken token = default)
        => await _cache.GetStringAsync(mem_key.ToString(), token: token);

    /// <inheritdoc/>
    public async Task<string?> GetStringValueAsync(MemCachePrefixModel pref, string id = "", CancellationToken token = default)
        => await GetStringValueAsync(new MemCacheComplexKeyModel(id, pref), token);

    /// <inheritdoc/>
    public async Task<T?> GetObjectAsync<T>(MemCacheComplexKeyModel mem_key, CancellationToken token = default)
        => System.Text.Json.JsonSerializer.Deserialize<T?>(await _cache.GetAsync(mem_key.ToString(), token));

    /// <inheritdoc/>
    public async Task<T?> GetObjectAsync<T>(MemCachePrefixModel pref, string id = "", CancellationToken token = default)
        => await GetObjectAsync<T>(new MemCacheComplexKeyModel(id, pref), token);

    /// <inheritdoc/>
    public async Task<T?> GetObjectAsync<T>(string mem_key, CancellationToken token = default)
    {
        byte[]? br = await _cache.GetAsync(mem_key, token);
        if (br is null)
            return default;

        T? res = System.Text.Json.JsonSerializer.Deserialize<T?>(br);

        return res;
    }

    /// <inheritdoc/>
    public async Task<byte[]?> GetBytesAsync(string mem_key, CancellationToken token = default)
    {
        return await _cache.GetAsync(mem_key, token);
    }

    /// <inheritdoc/>
    public async Task<byte[]?> GetBytesAsync(MemCacheComplexKeyModel mem_key, CancellationToken token = default)
    {
        return await GetBytesAsync(mem_key.ToString(), token);
    }

    /// <inheritdoc/>
    public async Task<byte[]?> GetBytesAsync(MemCachePrefixModel pref, string id = "", CancellationToken token = default)
    {
        return await GetBytesAsync(new MemCacheComplexKeyModel(id, pref), token);
    }
    #endregion

    #region set/update
    /// <inheritdoc/>
    public async Task WriteBytesAsync(MemCacheComplexKeyModel key, byte[] valueData, TimeSpan? expiry = null, CancellationToken token = default)
    {
        await _cache.SetAsync(key.ToString(), valueData, token: token);
    }

    /// <inheritdoc/>
    public async Task<bool> SetStringAsync(MemCacheComplexKeyModel key, string value, TimeSpan? expiry = null, CancellationToken token = default)
    {
        try
        {
            await _cache.SetStringAsync(key.ToString(), value, new DistributedCacheEntryOptions() { SlidingExpiration = expiry }, token: token);
        }
        catch
        {
            return false;
        }

        return true;
    }

    /// <inheritdoc/>
    public async Task<bool> SetStringAsync(MemCachePrefixModel pref, string id, string value, TimeSpan? expiry = null, CancellationToken token = default)
        => await SetStringAsync(new MemCacheComplexKeyModel(id, pref), value, expiry, token);

    /// <inheritdoc/>
    public async Task SetObjectAsync<T>(MemCacheComplexKeyModel key, T value, TimeSpan? expiry = null, CancellationToken token = default)
    {
        DistributedCacheEntryOptions? opt = expiry is null
            ? null
            : new() { SlidingExpiration = expiry.Value };

        if (opt is null)
            await _cache.SetAsync(key.ToString(), System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(value, RabbitClient.SerializerOptions), token: token);
        else
            await _cache.SetAsync(key.ToString(), System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(value, RabbitClient.SerializerOptions), options: opt, token: token);
    }

    /// <inheritdoc/>
    public async Task SetObjectAsync<T>(MemCachePrefixModel pref, string id, T value, TimeSpan? expiry = null, CancellationToken token = default)
        => await SetObjectAsync(new MemCacheComplexKeyModel(id, pref), value, token: token);

    /// <inheritdoc/>
    public async Task SetObjectAsync<T>(string mem_key, T value, TimeSpan? expiry = null, CancellationToken token = default)
    {
        DistributedCacheEntryOptions? opt = expiry is null
           ? null
           : new() { SlidingExpiration = expiry };

        if (opt is null)
            await _cache.SetAsync(mem_key, System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(value, RabbitClient.SerializerOptions), token: token);
        else
            await _cache.SetAsync(mem_key, System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(value, RabbitClient.SerializerOptions), options: opt, token: token);
    }
    #endregion

    #region remove
    /// <inheritdoc/>
    public async Task<bool> RemoveAsync(MemCacheComplexKeyModel key, CancellationToken token = default)
        => await RemoveAsync(key.ToString(), token);

    /// <inheritdoc/>
    public async Task<bool> RemoveAsync(MemCachePrefixModel pref, string id, CancellationToken token = default)
        => await RemoveAsync(new MemCacheComplexKeyModel(id, pref), token);

    /// <inheritdoc/>
    public async Task<bool> RemoveAsync(string key, CancellationToken token = default)
    {
        try
        {
            await _cache.RemoveAsync(key, token);
        }
        catch
        {
            return false;
        }

        return true;
    }
    #endregion
}