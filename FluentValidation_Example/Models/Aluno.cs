﻿using System;
namespace FluentValidation_Example.Models
{
    public class Aluno
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public System.DateTime DataNascimento { get; set; }
    }
}