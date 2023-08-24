namespace FichaCadastroApi.Business
{
    public interface IBalconista
    {
        void Atender();
        void DispensarCliente();
    }

    public interface ICaixa
    {
        void Cobrar();
    }

    public class Caixa : ICaixa
    {
        public void Cobrar()
        {
            /*codigo do caixa*/
        }
    }

    public class Balconista : IBalconista
    {
        public void Atender()
        {
            /*Codigo*/
        }

        public void DispensarCliente()
        {
            /*Codigo*/
        }
    }
}
