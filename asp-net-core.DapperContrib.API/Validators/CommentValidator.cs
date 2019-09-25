using asp_net_core.DapperContrib.API.Models;
using FluentValidation;


namespace asp_net_core.DapperContrib.API.Validators
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        private const string ALERTA_NOME = "Informe um 'Nome' com tamanho entre 5 e 50 caracteres";
        private const string ALERTA_MENSAGEM = "Informe uma 'Mensagem' com tamanho entre 20 e 1000 caracteres";

        public CommentValidator()
        {
            RuleFor(c => c.Nome).NotEmpty().WithMessage("Preencha o campo 'Nome'")
                .MinimumLength(5).WithMessage("O campo 'Nome' deve possuir no mínimo 5 caracteres")
                .MaximumLength(50).WithMessage("O campo 'Nome' deve possuir no máximo 50 caracteres");

            RuleFor(c => c.Mensagem).NotEmpty().WithMessage("Preencha o campo 'Mensagem'")
                .MinimumLength(20).WithMessage("O campo 'Mensagem' deve possuir no mínimo 20 caracteres")
                .MaximumLength(1000).WithMessage("O campo 'Mensagem' deve possuir no máximo 1000 caracteres");
        }
    }
}