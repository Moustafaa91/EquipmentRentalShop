namespace Utilities.Language
{
    public interface ILanguageMang
    {
        string CurrLanguage { get; set; }
        bool IsLanguageAvailable(string lang);
        
        string GetDefaultLanguage();
        void SetLanguage(string lang);
    }
}
