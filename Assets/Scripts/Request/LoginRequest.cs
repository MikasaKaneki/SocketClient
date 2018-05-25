using Share;

public class LoginRequest : BaseRequest
{
    private void Start()
    {
        _requestCode = RequestCode.User;
        _actionCode = ActionCode.Login;
    }

    public void SendRequest(string username, string password)
    {
        string data = username + "$" + password;
        base.SendRequest(data);
    }
}