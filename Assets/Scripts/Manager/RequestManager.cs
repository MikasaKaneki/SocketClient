using System.Collections.Generic;
using Share;

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


    public void HandleRequest()
    {
    }
}