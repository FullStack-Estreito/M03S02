namespace FichaCadastroApi.Partner.Singleton
{
    public class ConcepcaoSingleton
    {
        private static ConcepcaoSingleton singleton;
        private static DateTime dataHora;

        private ConcepcaoSingleton()
        {
        }

        public static ConcepcaoSingleton InstanciaClasseLocal()
        {
            if (singleton == null)
            {
                singleton = new ConcepcaoSingleton();
                dataHora = DateTime.Now;
            }

            return singleton;
        }

        public string Mensagem()
        {
            return $"Mensagem da Classe Singleton - {GetHashCode()} - DateTime {dataHora}";
        }
    }


    public class Teste
    {
        public void MetodoTemporario()
        {
            ConcepcaoSingleton xpto = ConcepcaoSingleton.InstanciaClasseLocal();
            var mensagem = xpto.Mensagem();

            ConcepcaoSingleton xpto2 = ConcepcaoSingleton.InstanciaClasseLocal();
            var mensagem2 = xpto2.Mensagem();

        }
    }
}
