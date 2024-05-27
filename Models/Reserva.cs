namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite == null) throw new Exception("Cadastre uma suite antes de adicionar hospedes");
            bool cabe = hospedes.Count <= Suite.Capacidade;
            if (cabe)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("A quantidade de hospedes não pode ser maior que a capacidade da suite");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            if (Hospedes != null)
            {
                return Hospedes.Count;
            }
            return 0;
        }

        public decimal CalcularValorDiaria()
        {
            // verifica se possui alguma suite cadastrada
            if (Suite == null)
                throw new Exception("A reserva precisa de uma suite");
            //verifica se possui algum hospede cadastrado
            if (Hospedes == null)
                throw new Exception("A reserva precisa de pelo menos um hospede");

            decimal valorDiaria = Suite.ValorDiaria;
            decimal valor = DiasReservados * valorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            if (DiasReservados > 9)
            {
                valor *= 0.9M;
            }

            return valor;
        }
    }
}