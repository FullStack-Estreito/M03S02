namespace FichaCadastroApi.Partner.Adpter
{
    public class Adaptee : IAdaptee
    {
        public string GetSpecificRequest()
        {
            return $"Specific request. {DateTime.Now}";
        }
    }
}
