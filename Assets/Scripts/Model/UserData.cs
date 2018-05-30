public class UserData
{
    public string UserName { get; private set; }
    public int TotalCount { get; private set; }
    public int WinCount { get; private set; }


    public UserData(string userName, int totalCount, int winCount)
    {
        this.UserName = userName;
        this.TotalCount = totalCount;
        this.WinCount = winCount;
    }
}