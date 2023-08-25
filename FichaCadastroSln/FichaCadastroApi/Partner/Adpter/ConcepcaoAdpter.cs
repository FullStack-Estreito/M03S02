namespace FichaCadastroApi.Partner.Adpter
{
    /// <summary>
    /// DePara da classe Adapter 
    /// do link https://refactoring.guru/pt-br/design-patterns/adapter/csharp/example
    /// </summary>
    public class ConcepcaoAdpter : ITarget
    {
        private readonly IAdaptee _adaptee;

        public ConcepcaoAdpter(IAdaptee adaptee)
        {
            this._adaptee = adaptee;
        }

        public string GetRequest()
        {
            return $"This is '{this._adaptee.GetSpecificRequest()}'";
        }
    }
}
