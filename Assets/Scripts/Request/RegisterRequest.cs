using Share;

public class RegisterRequest : BaseRequest
{
    private RegisterPanel _registerPanel;

    protected override void Awake()
    {
        _requestCode = RequestCode.User;
        _actionCode = ActionCode.Register;
        _registerPanel = GetComponent<RegisterPanel>();
        base.Awake();
    }

    public void SendRequest(string username, string password)
    {
        string data = username + "$" + password;
        base.SendRequest(data);
    }

    public override void OnResponse(string data)
    {
        base.OnResponse(data);
        ReturnCode returnCode = (ReturnCode) int.Parse(data);
        _registerPanel.OnRegisterResponse(returnCode);
    }
}