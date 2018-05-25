using System.Collections.Generic;
using Share;
using UnityEngine;

public class RequestManager : BaseManager
{
    public RequestManager(GameFacade facade) : base(facade)
    {
    }

    private Dictionary<ActionCode, BaseRequest> _requestDict = new Dictionary<ActionCode, BaseRequest>();


    public void AddRequest(ActionCode actionCode, BaseRequest request)
    {
        _requestDict.Add(actionCode, request);
    }

    public void RemoveRequest(ActionCode actionCode)
    {
        _requestDict.Remove(actionCode);
    }


    public void HandleRequest(ActionCode actionCode, string data)
    {
        BaseRequest request = _requestDict.TryGet<ActionCode, BaseRequest>(actionCode);
        if (request == null)
        {
            Debug.LogError("无法得到ActionCode:" + actionCode + "对应的Request类");
        }

        request.OnResponse(data);
    }
}