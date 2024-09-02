namespace SimpleEFCoreAPITemplate.Data.Interfaces
{
    public interface IDatabaseFactory
    {
        DBCtx GetContext();
    }
}
