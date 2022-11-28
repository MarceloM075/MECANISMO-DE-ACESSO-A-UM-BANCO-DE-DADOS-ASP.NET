using PIM_VIII_SQLSERVER.Data;
using PIM_VIII_SQLSERVER.Models;

namespace PIM_VIII_SQLSERVER.Daos
{
    public class PessoaRepositorio : IPessoaDaos
    {
        private readonly BancoContext _bancoContext;

        public PessoaRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        //MÉTODOS PRIVATE:
        private Enderecos BuscarEndereco(int? id)
        {
            return _bancoContext.Enderecos.FirstOrDefault(x => x.Id == id);
        }

        private Telefones BuscarTelefone(int? id)
        {
            return _bancoContext.Telefones.FirstOrDefault(x => x.Id == id);
        }

        private static Pessoa JuntarDados(Enderecos endereco, Telefones telefone, Pessoa pessoa)
        {
            pessoa.Endereco.Cidade = endereco.Cidade;
            pessoa.Endereco.Bairro = endereco.Bairro;
            pessoa.Endereco.Logradouro = endereco.Logradouro;
            pessoa.Endereco.Numero = endereco.Numero;
            pessoa.Endereco.Cep = endereco.Cep;
            pessoa.Endereco.Estado = endereco.Estado;
            pessoa.Telefone.Ddd = telefone.Ddd;
            pessoa.Telefone.Numero = telefone.Numero;

            return pessoa;
        }

        //MÉTODOS PUBLIC
        public List<Pessoa> BuscarTodos()
        {
            List<Pessoa> pessoas = _bancoContext.Pessoa.ToList();
            foreach (Pessoa pessoa in pessoas)
            {
                Enderecos endereco = BuscarEndereco(pessoa.EnderecoId);
                Telefones telefone = BuscarTelefone(pessoa.TelefoneId);
                JuntarDados(endereco, telefone, pessoa);
            }
            return pessoas;
        }

        public Pessoa Adicionar(Pessoa pessoa)
        {
            pessoa.Telefone.TipoTelefone.Tipo = pessoa.Telefone.Numero.ToString();

            //gravar no db
            _bancoContext.Pessoa.Add(pessoa);
            _bancoContext.SaveChanges();

            return pessoa;
        }

        public Pessoa BuscaPorCpf(long cpf)
        {
            Pessoa pessoa = _bancoContext.Pessoa.FirstOrDefault(x => x.Cpf == cpf);
            

            if(pessoa != null)
            {
                Enderecos endereco = BuscarEndereco(pessoa.EnderecoId);
                Telefones telefone = BuscarTelefone(pessoa.TelefoneId);
                JuntarDados(endereco, telefone, pessoa);
                return pessoa;
            }
            else
            {
                return pessoa = new Pessoa();
            }
        }

        public Pessoa ListarPorId(int? id)
        {
            Pessoa pessoa = _bancoContext.Pessoa.FirstOrDefault(x => x.Id == id);

            Enderecos endereco = BuscarEndereco(pessoa.EnderecoId);
            Telefones telefone = BuscarTelefone(pessoa.TelefoneId);
            JuntarDados(endereco, telefone, pessoa);

            return pessoa;
        }

        public Pessoa Editar(Pessoa pessoa)
        {
            Pessoa pessoaDB = ListarPorId(pessoa.Id);

            if (pessoaDB == null) throw new System.Exception("Houve um erro na atualização dos dados!");

            pessoaDB.Nome = pessoa.Nome;
            pessoaDB.Cpf = pessoa.Cpf;
            pessoaDB.Telefone.Ddd = pessoa.Telefone.Ddd;
            pessoaDB.Telefone.Numero = pessoa.Telefone.Numero;
            pessoaDB.Endereco.Cidade = pessoa.Endereco.Cidade;
            pessoaDB.Endereco.Cep = pessoa.Endereco.Cep;
            pessoaDB.Endereco.Bairro = pessoa.Endereco.Bairro;
            pessoaDB.Endereco.Numero = pessoa.Endereco.Numero;
            pessoaDB.Endereco.Logradouro = pessoa.Endereco.Logradouro;
            pessoaDB.Endereco.Estado = pessoa.Endereco.Estado;

            _bancoContext.Pessoa.Update(pessoaDB);
            _bancoContext.SaveChanges();

            return pessoaDB;
        }

        public bool Apagar(int id)
        {
            Pessoa pessoaDB = ListarPorId(id);

            if (pessoaDB == null) throw new System.Exception("Houve um erro ao tentar apagar dos dados!");

            _bancoContext.Pessoa.Remove(pessoaDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
