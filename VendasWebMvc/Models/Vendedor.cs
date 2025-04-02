using System.Linq;

namespace VendasWebMvc.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public String Nome{ get; set; }
        public String Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public Double Salario { get; set; }
        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }
        public ICollection<RegistroVenda> Vendas { get; set; } = new List<RegistroVenda>();

        public Vendedor()
        {
        }

        public Vendedor(int id, string nome, string email, DateTime dataNascimento, double salario, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Salario = salario;
            this.Departamento = departamento;
        }

        public void AddVenda(RegistroVenda rv)
        {
            Vendas.Add(rv);
        }

        public void RemoverVenda(RegistroVenda rv) 
        {
            Vendas.Remove(rv);
        }

        public double VendasTotais(DateTime dataInicial, DateTime dataFinal)
        {
            return Vendas.Where(rv => rv.Data >= dataInicial && rv.Data <= dataFinal).Sum(rv => rv.Quantia);
        }
    }



}
