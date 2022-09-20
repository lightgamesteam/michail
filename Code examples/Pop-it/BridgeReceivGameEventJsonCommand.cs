using System;

public class BridgeReceivGameEventJsonCommand : BaseCommand
{
    public override void Execute()
    {
        var json = eventData.data as string;
        if (string.IsNullOrEmpty(json))
        {
            return;
        }
        Log($"JSON: {json}");
        var converter = new GameEventConverter();
        var gameEventContract = converter.JsonTo(json);
        var transportContract = converter.ToTransport(gameEventContract);
        ReceivDataHandler(transportContract, gameEventContract);
    }

    private void ReceivDataHandler(TransportContract transport, GameEventContract gameEventContract)
    {
        if (transport == null)
        {
            LogError($"{nameof(ReceivDataHandler)}: transport is Null");
            return;
        }

        if (string.IsNullOrEmpty(transport.Method))
        {
            LogError($"{nameof(ReceivDataHandler)}: Method is Null");
            return;
        }

        try
        {
            var method = (TransportNetworkGameMethod)Enum.Parse(typeof(TransportNetworkGameMethod), transport.Method);
            switch (method)
            {
                case TransportNetworkGameMethod.SendPlayerHasEnemyData:
                    var loadContract = Merge(transport.Data, gameEventContract, new PlayerHasEnemtDataConverter());
                    dispatcher.Dispatch(EventGlobal.E_BridgeReceivPlayerHasEnemyDataContract, loadContract);
                    break;
                case TransportNetworkGameMethod.SendPlay:
                    var playContract = Merge(transport.Data, gameEventContract, new PlayConverter());
                    dispatcher.Dispatch(EventGlobal.E_BridgeReceivStartPlayContract, playContract);
                    break;
                case TransportNetworkGameMethod.SendShotData:
                    var shotContract = Merge(transport.Data, gameEventContract, new ShotConverter());
                    dispatcher.Dispatch(EventGlobal.E_BridgeReceivShotContract, shotContract);
                    break;
                case TransportNetworkGameMethod.SendEndGame:
                    var endGameContract = Merge(transport.Data, gameEventContract, new EndGameConverter());
                    dispatcher.Dispatch(EventGlobal.E_BridgeReceivEndGameContract, endGameContract);
                    break;
                case TransportNetworkGameMethod.SendShotHistory:
                    var shotHistoryContract = Merge(transport.Data, gameEventContract, new ShotHistoryConverter());
                    dispatcher.Dispatch(EventGlobal.E_BridgeReceivShotHistoryContract, shotHistoryContract);
                    break;
            }
        }
        catch (Exception ex)
        {
            LogError($"GetDataHandler: Exception: {ex.Message}");
        }
    }

    private T Merge<T>(string jsonData, GameEventContract gameEventContract, ContractConverter<T> converter) where T : UserTransportContract, new()
    {
        var contract = string.IsNullOrEmpty(jsonData) ? new T() : converter.JsonTo(jsonData);
        return contract;
    }
}