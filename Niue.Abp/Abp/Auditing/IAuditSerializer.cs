namespace Niue.Abp.Abp.Auditing
{
    public interface IAuditSerializer
    {
        string Serialize(object obj);
    }
}