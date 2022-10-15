using System;
using FluentValidation;

namespace FluentValidation_Example.Models
{
    public class AlunoValidator : AbstractValidator<Aluno>
    {
       public AlunoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Informe o nome do aluno")
                .Length(3, 100).WithMessage("O nome do aluno deve ter no mínimo 3 caracteres e no máximo 100 caracteres");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Informe o e-mail do aluno")
                .EmailAddress().WithMessage("E-mail inválido");

            RuleFor(x => x.DataNascimento)
            .NotEmpty().WithMessage("Informe a data de nascimento do aluno")
            .Must(AlunoMaiorDeIdade).WithMessage("O aluno deve ser maior de 18 anos");
        }

        private static bool AlunoMaiorDeIdade(System.DateTime dataNascimento)
        {
            return dataNascimento <= System.DateTime.Now.AddYears(-18);
        }
    }
}