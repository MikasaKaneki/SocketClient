using System.Collections.Generic;
using Share;
using UnityEngine;

public class RequestManager : BaseManager
{
    public RequestManager(GameFacade facade) : base(facade)
    {
    }

    private Dictionary<RequestCode, BaseRequest> _requestDict = new Dictionary<RequestCode, BaseRequest>();


    public void AddRequest(RequestCode requestCode, BaseRequest request)
    {
        _requestDict.Add(requestCode, request);
    }

    public void RemoveRequest(RequestCode requestCode)
    {
        _requestDict.Remove(requestCode);
    }


    public void HandleRequest(RequestCode requestCode, string data)
    {
        BaseRequest request = _requestDict.TryGet<RequestCode, BaseRequest>(requestCode);
        if (request == null)
        {
            Debug.LogError("无法得到RequestCode:" + requestCode + "对应的类");
        }

        request.OnResponse(data);
    }
}