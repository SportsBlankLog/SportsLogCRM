using StockSharp.BusinessEntities;
using StockSharp.Configuration;
using StockSharp.Fix.Quik.Lua;
using Ecng.Configuration;
using Ecng.Serialization;
using StockSharp.Logging;
using StockSharp.Algo;
using NetMQ.Sockets;
using Ecng.Common;
using System.Net;
using NetMQ;

namespace StockSharpJoinService;

/// <inheritdoc/>
public class Worker : BackgroundService
{
    //private const string _connectorFile = "ConnectorFile.json";
    readonly ILogger<Worker> _logger;
    readonly ResponseSocket server;
    readonly Connector Connector;

    /// <inheritdoc/>
    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
        server = new("@tcp://localhost:5556");
        Connector = new Connector();
        InitConnector();
    }

    /// <inheritdoc/>
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            string fromClientMessage = server.ReceiveFrameString();
            Console.WriteLine("From Client: {0}", fromClientMessage);
            server.SendFrame("World");
        }
        server.Dispose();
        return Task.CompletedTask;
    }

    private void InitConnector()
    {
        LuaFixMarketDataMessageAdapter luaFixMarketDataMessageAdapter = new(Connector.TransactionIdGenerator)
        {
            Address = "localhost:5001".To<EndPoint>(),
            //Login = "quik",
            //Password = "quik".To<SecureString>(),
            IsDemo = true,
        };
        LuaFixTransactionMessageAdapter luaFixTransactionMessageAdapter = new LuaFixTransactionMessageAdapter(Connector.TransactionIdGenerator)
        {
            Address = "localhost:5001".To<EndPoint>(),
            //Login = "quik",
            //Password = "quik".To<SecureString>(),
            IsDemo = true,
        };
        Connector.Adapter.InnerAdapters.Add(luaFixMarketDataMessageAdapter);
        Connector.Adapter.InnerAdapters.Add(luaFixTransactionMessageAdapter);

        Connector.Adapter.SuppressReconnectingErrors = false;
        Connector.ConnectionRestored += ConnectionRestored;

        // �������� �� ������� ��������� �����������
        Connector.Connected += ConnectedSS; ;

        // �������� �� ������� ������ �����������
        Connector.ConnectionError += ConnectionError; ;

        // �������� �� ������� ����������
        Connector.Disconnected += Disconnected; ;

        // �������� �� ������� ������
        Connector.Error += Error; ;

        // �������� �� ������� ������ �������� �� �������� ������
        Connector.SubscriptionFailed += SubscriptionFailed; ;

        // �������� �� ��������� ������

        // �����������
        Connector.SecurityReceived += SecurityReceived; ;

        // ������� ������
        Connector.TickTradeReceived += TickTradeReceived;

        // ������
        Connector.OrderReceived += OrderReceived;

        // ����������� ������
        Connector.OwnTradeReceived += OwnTradeReceived;

        // �������
        Connector.PositionReceived += PositionReceived;

        // ������ ����������� ������
        Connector.OrderRegisterFailReceived += OrderRegisterFailReceived;

        // ������ ������ ������
        Connector.OrderCancelFailReceived += OrderCancelFailReceived;

        //try
        //{
        //    if (File.Exists(_connectorFile))
        //    {
        //        var ctx = new ContinueOnExceptionContext();
        //        ctx.Error += ex => ex.LogError();
        //        using (new Scope<ContinueOnExceptionContext>(ctx))
        //            Connector.Load(_connectorFile.Deserialize<SettingsStorage>());
        //    }
        //}
        //catch
        //{
        //}

        ConfigManager.RegisterService<IExchangeInfoProvider>(new InMemoryExchangeInfoProvider());
    }

    private void ConnectionRestored(StockSharp.Messages.IMessageAdapter obj)
    {
        throw new NotImplementedException();
    }

    private void OrderCancelFailReceived(Subscription arg1, OrderFail arg2)
    {
        throw new NotImplementedException();
    }

    private void OrderRegisterFailReceived(Subscription arg1, OrderFail arg2)
    {
        throw new NotImplementedException();
    }

    private void PositionReceived(Subscription arg1, Position arg2)
    {
        throw new NotImplementedException();
    }

    private void OwnTradeReceived(Subscription arg1, MyTrade arg2)
    {
        throw new NotImplementedException();
    }

    private void OrderReceived(Subscription arg1, Order arg2)
    {
        throw new NotImplementedException();
    }

    private void TickTradeReceived(Subscription arg1, StockSharp.Messages.ITickTradeMessage arg2)
    {
        throw new NotImplementedException();
    }

    private void SecurityReceived(Subscription arg1, Security arg2)
    {
        throw new NotImplementedException();
    }

    private void SubscriptionFailed(Subscription arg1, Exception arg2, bool arg3)
    {
        throw new NotImplementedException();
    }

    private void Error(Exception obj)
    {
        throw new NotImplementedException();
    }

    private void Disconnected()
    {
        throw new NotImplementedException();
    }

    private void ConnectionError(Exception obj)
    {
        throw new NotImplementedException();
    }

    private void ConnectedSS()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public override void Dispose()
    {
        server.Dispose();
        base.Dispose();
    }
}
