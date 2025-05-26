using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace VendasWebMvc.Models
{
    public class Vendedor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        public String Nome{ get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public Double Salario { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
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
