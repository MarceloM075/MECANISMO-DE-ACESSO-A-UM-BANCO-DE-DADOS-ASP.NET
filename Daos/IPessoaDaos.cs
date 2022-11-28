using PIM_VIII_SQLSERVER.Models;

namespace PIM_VIII_SQLSERVER.Daos
{
    public interface IPessoaDaos
    {
        Pessoa BuscaPorCpf(long cpf); //Pesquisar no banco de dados pelo CPF.
        List<Pessoa> BuscarTodos(); //Ao acessar o menu Lista de Pessoas.
        Pessoa Adicionar(Pessoa pessoa); //dicionar um cadastro de pessoa ao DB.
        Pessoa ListarPorId(int? id); //Listagem por Id para a página de edição de dados e para a função de apagar os dados.    
        Pessoa Editar(Pessoa pessoa); //Salvar os dados editados no DB.
        bool Apagar(int id); //Apagar os dados no DB.
    }
}
