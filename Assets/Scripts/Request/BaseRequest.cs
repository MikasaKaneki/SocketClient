using Share;
using UnityEngine;

public class BaseRequest : MonoBehaviour
{
    private RequestCode _requestCode = RequestCode.None;

    protected virtual void Awake()
    {
        GameFacade.Instance.AddRequest(_requestCode, this);
    }

    public virtual void SendRequest()
    {
    }

    public virtual void OnResponse(string data)
    {
    }

    private void OnDestroy()
    {
        GameFacade.Instance.RemoveRequest(_requestCode);
    }
}