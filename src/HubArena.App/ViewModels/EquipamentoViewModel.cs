﻿using HubArena.Business.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HubArena.App.ViewModels
{
    public class EquipamentoViewModel
    {
        [Key]
        public int IdEquipamento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Nome deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(4, ErrorMessage = "O campo Quantidade deve conter entre {2} e {1} caracteres.", MinimumLength = 1)]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Status")]
        public int StatusEquipamento { get; set; }

        //N..1
        public IEnumerable<EsporteViewModel> Esportes { get; set; }

        //N..1
        public IEnumerable<ReservaEquipamentoViewModel> ReservaEquipamentos { get; set; }
    }
}
