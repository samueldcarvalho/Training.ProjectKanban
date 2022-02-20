using Training.Kanban.Core.Domain.Exceptions;

namespace Training.Kanban.Domain.Models.Entities
{
    public class DadosContato
    {
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public bool AceitaWhatsapp { get; private set; }

        public DadosContato(string email, string telefone, bool aceitaWhatsapp)
        {
            Email = email;
            Telefone = telefone;
            AceitaWhatsapp = aceitaWhatsapp;

            Validar();
        }

        public void AlterarEmail(string email) => Email = Email;
        public void AlterarTelefone(string telefone) => Telefone = telefone;
        public void AlterarAceitacaoWhatsapp(bool aceita) => AceitaWhatsapp = aceita;

        private void Validar()
        {
            Validation.ValidaEmail(Email, "E-mail inválido");
            Validation.ValidarStringTamanho(Telefone, 10, 15, "Telefone inválido");
        }
    }
}
