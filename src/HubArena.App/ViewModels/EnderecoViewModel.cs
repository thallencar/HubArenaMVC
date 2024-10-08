﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HubArena.App.ViewModels
{
    public class EnderecoViewModel
    {
        [Key]
        public int IdEndereco { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(8, ErrorMessage = "O campo Cep deve conter {1} caracteres.", MinimumLength = 8)]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(2, ErrorMessage = "O campo Estado deve conter {1} caracteres.", MinimumLength = 2)]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo Cidade deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo Bairro deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Logradouro deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Logradouro { get; set; }

        [DisplayName("Número")]
        public int? Numero { get; set; }

        [StringLength(50, ErrorMessage = "O campo Complemento deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string? Complemento { get; set; }

        [StringLength(100, ErrorMessage = "O campo Ponto de Referência deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        [DisplayName("Ponto de Referência")]
        public string? PontoReferencia { get; set; }

        [DisplayName("Tipo de Endereço")]
        public int TipoEndereco { get; set; }

        [HiddenInput]
        public int IdFuncionario { get; set; }

    }
}