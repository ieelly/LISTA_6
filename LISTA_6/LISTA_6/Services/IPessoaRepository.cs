using LISTA_6.Models;
namespace LISTA_6.Services
{
    public interface IPessoaRepository
    {
        public void Adicionar(Pessoa pessoa);
        public void Deletar(string cpf);
        public List<Pessoa> MostrarLista();
        public List<Pessoa> MostrarIMCBom();
        public Pessoa BuscarPorCPF(string cpf);
        public Pessoa BuscarPorNome(string nome);
        public Pessoa Atualizar(string cpf, Pessoa pessoa);
    }
}
