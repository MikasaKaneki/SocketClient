public class PlayerMananger : BaseManager
{
    private UserData _userData;

    public UserData UserData
    {
        get { return _userData; }
        set { _userData = value; }
    }

    public PlayerMananger(GameFacade facade) : base(facade)
    {
    }
}