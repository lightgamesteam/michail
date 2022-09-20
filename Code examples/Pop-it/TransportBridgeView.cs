using System;

public abstract class TransportBridgeView : BaseView, InputProtocolTransportBridge, OutputProtocolTransportBridge
{
    public virtual void LoadView()
    {
        IsLoad = true;
    }

    public virtual void RemoveView()
    {
        IsLoad = false;
    }

    public abstract void Connect(Action successCallback, Action<Exception> errorCallback);
    public abstract void Disconnect();

    //Input Protocol
    public abstract void onStart(string json);

    public abstract void gameEvent(string json);


    //OutputProtocol
    public abstract void onReady(string json, Action<string> successCalback, Action<ErrorTransportContract> errorCalback);

    public abstract void playerVideoFrames(string json, Action<string> successCalback, Action<ErrorTransportContract> errorCalback);

    public abstract void gameEvent(string json, Action<string> successCalback, Action<ErrorTransportContract> errorCalback);

    public abstract void onCommand(string json, Action<string> successCalback, Action<ErrorTransportContract> errorCalback);

    protected ErrorTransportContract CreateError(Exception ex)
    {
        return CreateError(ex, string.Empty);
    }

    protected ErrorTransportContract CreateError(Exception ex, string data)
    {
        var error = new ErrorTransportContract();
        error.Data = data;
        error.Exception = ex;

        return error;
    }

    public bool IsConnect { get; protected set; }
    public bool IsLoad { get; protected set; }
}