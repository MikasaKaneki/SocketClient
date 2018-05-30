using Share;

public class LoginRequest : BaseRequest
{
    private LoginPanel _loginPanel;


    protected override void Awake()
    {
        _requestCode = RequestCode.User;
        _actionCode = ActionCode.Login;
        _loginPanel = GetComponent<LoginPanel>();
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
        string[] strs = data.Split('$');
        ReturnCode returnCode = (ReturnCode) int.Parse(strs[0]);
        _loginPanel.OnLoginResponse(returnCode);
        if (returnCode == ReturnCode.Success)
        {
            string userName = strs[1];
            int totalCount = int.Parse(strs[2]);
            int winCount = int.Parse(strs[3]);
            UserData userData = new UserData(userName, totalCount, winCount);
            _facade.SetUserData(userData);
        }
    }
}