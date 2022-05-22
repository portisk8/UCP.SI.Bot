using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCP.SI.Bot.Entities.Enums
{
    public enum AnswerEnum
    {
        [Description("Verano")]
        VERANO = 1,
        [Description("Otoño")]
        OTOÑO = 2,
        [Description("Invierno")]
        INVIERNO = 3,
        [Description("Primavera")]
        PRIMAVERA = 4,
        [Description("Team Frío")]
        TEAM_FRIO = 5,
        [Description("Team Calor")]
        TEAM_CALOR = 6,
        [Description("Montaña")]
        MONTAÑA = 7,
        [Description("Sierras")]
        SIERRAS = 8,
        [Description("Llanura")]
        LLANURA = 9,
        [Description("Playa Río")]
        PLAYA_RIO = 10,
        [Description("Playa Mar")]
        PLAYA_MAR = 11,
        [Description("Ciudad")]
        CIUDAD = 12,
        [Description("Pueblo")]
        PUEBLO = 13,
        [Description("Diurno")]
        DIURNO = 14,
        [Description("Nocturno")]
        NOCTURNO = 15,
        [Description("Casa/Departamento")]
        CASA_DEPARTAMENTO = 16,
        [Description("Cabaña")]
        CABAÑA = 17,
        [Description("Hotel")]
        HOTEL = 18,
        [Description("Camping")]
        CAMPING = 19,
        [Description("Fin de semana")]
        FIN_DE_SEMANA = 20,
        [Description("Semana Completa")]
        SEMANA_COMPLETA = 21,
        [Description("Quincena o más")]
        QUINCENA_O_MAS = 22,
        [Description("Senderismo")]
        SENDERISMO = 23,
        [Description("Playa")]
        PLAYA = 24,
        [Description("Paisajismo")]
        PAISAJISMO = 25,
        [Description("Urbanismo")]
        URBANISMO = 26,
        [Description("Campamento")]
        CAMPAMENTO = 27,
        [Description("Shopping")]
        SHOPPING = 28,
        [Description("Ciclismo")]
        CICLISMO = 29,
        [Description("Vida Nocturna")]
        VIDA_NOCTURNA = 30,
        [Description("Cultura")]
        CULTURA = 31,
        [Description("Deportes Acuáticos")]
        DEPORTES_ACUATICOS = 32,
        [Description("Deportes de nieve")]
        DEPORTES_EN_LA_NIEVE = 33,
        [Description("Rafting")]
        RAFTING = 34,
        [Description("Escalada")]
        ESCALADA = 35,
        [Description("Parque de diversiones")]
        PARQUE_DE_DIVERSIONES = 36,
        [Description("Deportes extremos")]
        DEPORTES_EXTREMOS = 37,

    }

    public static class AnswerEnumExtension
    {
        public static string GetEnumDescription(this Enum enumValue)
        {
            var field = enumValue.GetType().GetField(enumValue.ToString());
            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
            {
                return attribute.Description;
            }
            throw new ArgumentException("Item not found.", nameof(enumValue));
        }

        public static bool IsAnswerEnum(this int enumValue)
        {
            try
            {
                var a = (AnswerEnum)enumValue;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
