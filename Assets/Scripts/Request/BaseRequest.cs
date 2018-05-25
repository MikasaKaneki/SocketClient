using Share;
using UnityEngine;

public class BaseRequest : MonoBehaviour
{
    protected RequestCode _requestCode = RequestCode.None;
    protected ActionCode _actionCode = ActionCode.None;
    protected GameFacade _facade;


    protected virtual void Awake()
    {
        this._facade = GameFacade.Instance;
        this._facade.AddRequest(_actionCode, this);
    }

    public virtual void SendRequest(string data)
    {
        this._facade.SendRequest(_requestCode, _actionCode, data);
    }

    public virtual void OnResponse(string data)
    {
    }


    private void OnDestroy()
    {
        this._facade.RemoveRequest(_actionCode);
    }
}