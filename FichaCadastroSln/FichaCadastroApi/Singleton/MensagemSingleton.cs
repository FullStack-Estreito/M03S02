namespace FichaCadastroApi.Singleton
{
    public class MensagemSingleton
    {
        private static MensagemSingleton singleton;

        private MensagemSingleton()
        {

        }

        public static MensagemSingleton InstanciaClasseLocal() 
        {
            if (singleton == null)
            {
                singleton = new MensagemSingleton();
            }

            return singleton;
        }

        public string Mensagem()
        {
            return $"Mensagem da Classe Singleton - {this.GetHashCode()}";
        }
    }


    public class Teste
    {
        public void MetodoTemporario()
        {
            MensagemSingleton xpto = MensagemSingleton.InstanciaClasseLocal();
            var mensagem = xpto.Mensagem();

            MensagemSingleton xpto2 = MensagemSingleton.InstanciaClasseLocal();
            var mensagem2 = xpto2.Mensagem();

        }
    }
}
