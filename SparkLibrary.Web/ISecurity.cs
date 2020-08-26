namespace SparkLibrary.Web
{
    public interface ISecurity
    {
        string GetStringToHash(string @string);
        string GetEncryptString(string plainText, string password);
        string GetDecryptedString(string plainText, string password);

    }
}