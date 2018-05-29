public class BaseManager
{
    protected GameFacade _facade;

    public BaseManager(GameFacade facade)
    {
        this._facade = facade;
    }

    public virtual void OnInit()
    {
    }

    public virtual void OnDesory()
    {
    }

    public virtual void Update()
    {
    }
}