using HubArena.App.ViewModels;
using HubArena.Business.Enums;
using HubArena.Business.Interfaces;
using HubArena.Business.Models;
using Microsoft.AspNetCore.Mvc.Razor;

namespace HubArena.App.Extensions
{
    public static class RazorExtensions
    {

        public static string StatusDoEquipamento(this RazorPage page, int statusEquipamento)
        {
            return statusEquipamento switch
            {
                (int)StatusEquipamentoEnum.Disponivel => "Disponível",
                (int)StatusEquipamentoEnum.EmUso => "Em Uso",
                (int)StatusEquipamentoEnum.Reservado => "Reservado",
                (int)StatusEquipamentoEnum.Manutencao => "Em Manutenção",
                (int)StatusEquipamentoEnum.Danificado => "Danificado",
                (int)StatusEquipamentoEnum.Indisponivel => "Indisponível",
            };
        }
        
        public static string StatusDaQuadra(this RazorPage page, int statusQuadra)
        {
            return statusQuadra switch
            {
                (int)StatusQuadraEnum.Disponivel => "Disponível",
                (int)StatusQuadraEnum.Reservada => "Reservada",
                (int)StatusQuadraEnum.Ocupada => "Em Uso",
                (int)StatusQuadraEnum.Manutencao => "Em Manutenção",
                (int)StatusEquipamentoEnum.Indisponivel => "Indisponível",
            };
        } 

    }
}

