namespace InventoryControlTRDWeb.Application.Interface
{
    public interface IAppSecurityService
    {
        string CreateMD5(string word);
        bool MD5IsMatch(string word, string hash);
    }
}
