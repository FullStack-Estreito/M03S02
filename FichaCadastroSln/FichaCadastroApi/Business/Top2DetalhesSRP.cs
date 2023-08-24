using FichaCadastroApi.Model;

namespace FichaCadastroApi.Business
{
    public class Top2DetalhesSRP
    {
        private readonly List<DetalheModel> _detalheModel;

        public int MediaTop2Notas { get; set; }
        public string Justificativa { get; set; }

        public Top2DetalhesSRP(List<DetalheModel> detalheModel)
        {
            this._detalheModel = detalheModel;
        }

        public void CalcularTopDois()
        {
            //Novo Metodo buscar o TAKE da lista 
            BuscarTakeList();
            
            //Novo Metodo para concatenar uma string da justificativa
            ConcatenarJustificativa();
        }

        private void BuscarTakeList()
        {
            var modelTake2 = this._detalheModel.Take(2).ToList();
            MediaTop2Notas = modelTake2.Sum(s => s.Nota.GetHashCode()) / 2;
        }

        private void ConcatenarJustificativa()
        {
            var concatenado = this._detalheModel.Select(s => s.Feedback).ToList();
            Justificativa = string.Join(" ", concatenado);
        }

        public override string ToString()
        {
            return "OLÁ MUNDO";
        }
    }
}
