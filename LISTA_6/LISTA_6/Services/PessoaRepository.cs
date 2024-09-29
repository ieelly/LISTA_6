
using LISTA_6.Models;
namespace LISTA_6.Services
{
    public class PessoaRepository : IPessoaRepository
    {
        private static List<Pessoa> listaPessoas = new List<Pessoa>();

        public PessoaRepository() { }

        public void Adicionar(Pessoa pessoa)
        {
            listaPessoas.Add(pessoa);
        }
        public Pessoa BuscarPorCPF(string cpf)
        {
            return listaPessoas.Where(p => p.CPF == cpf).FirstOrDefault();
        }
        public Pessoa BuscarPorNome(string nome)
        {
            return listaPessoas.Where(P => P.Nome == nome).FirstOrDefault();
        }
        public Pessoa Atualizar(string cpf, Pessoa pessoa)
        {
            var pessoaPesquisada = listaPessoas.Where(p => p.CPF == cpf).FirstOrDefault();


            pessoaPesquisada.Nome = pessoa.Nome;
            pessoaPesquisada.Altura = pessoa.Altura;
            pessoaPesquisada.Peso = pessoa.Peso;

            return pessoaPesquisada;

        }
        public List<Pessoa> MostrarLista()
        {
            return listaPessoas;
        }
        public List<Pessoa> MostrarIMCBom()
        {
            return listaPessoas.Where(p => p.IMC >= 18.5 && p.IMC < 25).ToList();
        }
        public void Deletar(string cpf)
        {
            var pessoaPesquisada = listaPessoas.Where(p => p.CPF == cpf).FirstOrDefault();

            listaPessoas.Remove(pessoaPesquisada);
        }

    }
}
