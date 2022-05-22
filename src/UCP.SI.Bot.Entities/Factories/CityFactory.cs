using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCP.SI.Bot.Entities.Entities;
using UCP.SI.Bot.Entities.Enums;

namespace UCP.SI.Bot.Entities.Factories
{
    public static class CityFactory
    {
        public static List<City> GetCities()
        {
            var cities = new List<City>();
            var index = 0;

            //MISIONES
            cities.Add(new City
            {
                CityName = "Misiones",
                CityCode = "misiones",
                CityId = index++,
                AnswerEnums = new List<AnswerEnum> {
                    AnswerEnum.VERANO,
                    AnswerEnum.PRIMAVERA,
                    AnswerEnum.TEAM_CALOR,
                    AnswerEnum.SIERRAS,
                    AnswerEnum.LLANURA,
                    AnswerEnum.PUEBLO,
                    AnswerEnum.DIURNO,
                    AnswerEnum.CABAÑA,
                    AnswerEnum.CAMPING,
                    AnswerEnum.FIN_DE_SEMANA,
                    AnswerEnum.SEMANA_COMPLETA,
                    AnswerEnum.SENDERISMO,
                    AnswerEnum.PAISAJISMO,
                    AnswerEnum.URBANISMO,
                    AnswerEnum.CAMPAMENTO,
                    AnswerEnum.CICLISMO,
                    AnswerEnum.CULTURA,
                }
            });
            
            //MAR DEL PLATA
            cities.Add(new City
            {
                CityName = "Mar del Plata",
                CityCode = "mar_del_plata",
                CityId = index++,
                AnswerEnums = new List<AnswerEnum> {
                    AnswerEnum.VERANO,
                    AnswerEnum.TEAM_CALOR,
                    AnswerEnum.LLANURA,
                    AnswerEnum.PLAYA_MAR,
                    AnswerEnum.CIUDAD,
                    AnswerEnum.DIURNO,
                    AnswerEnum.NOCTURNO,
                    AnswerEnum.CASA_DEPARTAMENTO,
                    AnswerEnum.HOTEL,
                    AnswerEnum.SEMANA_COMPLETA,
                    AnswerEnum.QUINCENA_O_MAS,
                    AnswerEnum.PLAYA,
                    AnswerEnum.URBANISMO,
                    AnswerEnum.SHOPPING,
                    AnswerEnum.VIDA_NOCTURNA,
                    AnswerEnum.CULTURA,
                    AnswerEnum.DEPORTES_ACUATICOS,
                    AnswerEnum.PARQUE_DE_DIVERSIONES,
                    AnswerEnum.DEPORTES_EXTREMOS
                }
            });
            
            //SAN JUAN
            cities.Add(new City
            {
                CityName = "San Juan",
                CityCode = "san_juan",
                CityId = index++,
                AnswerEnums = new List<AnswerEnum> {
                    AnswerEnum.OTOÑO,
                    AnswerEnum.INVIERNO,
                    AnswerEnum.TEAM_FRIO,
                    AnswerEnum.MONTAÑA,
                    AnswerEnum.SIERRAS,
                    AnswerEnum.PUEBLO,
                    AnswerEnum.DIURNO,
                    AnswerEnum.CABAÑA,
                    AnswerEnum.CAMPING,
                    AnswerEnum.SEMANA_COMPLETA,
                    AnswerEnum.SENDERISMO,
                    AnswerEnum.PAISAJISMO,
                    AnswerEnum.CAMPAMENTO,
                    AnswerEnum.CICLISMO,
                    AnswerEnum.DEPORTES_ACUATICOS,
                    AnswerEnum.RAFTING,
                    AnswerEnum.ESCALADA,
                    AnswerEnum.DEPORTES_EXTREMOS
                }
            });

            //CIUDAD AUTÓNOMA DE BUENOS AIRES
            cities.Add(new City
            {
                CityName = "Ciudad Autónoma de Buenos Aires",
                CityCode = "ciudad_autonoma_buenos_aires",
                CityId = index++,
                AnswerEnums = new List<AnswerEnum> {
                    AnswerEnum.INVIERNO,
                    AnswerEnum.PRIMAVERA,
                    AnswerEnum.TEAM_FRIO,
                    AnswerEnum.TEAM_CALOR,
                    AnswerEnum.LLANURA,
                    AnswerEnum.CIUDAD,
                    AnswerEnum.DIURNO,
                    AnswerEnum.NOCTURNO,
                    AnswerEnum.CASA_DEPARTAMENTO,
                    AnswerEnum.HOTEL,
                    AnswerEnum.FIN_DE_SEMANA,
                    AnswerEnum.SEMANA_COMPLETA,
                    AnswerEnum.URBANISMO,
                    AnswerEnum.SHOPPING,
                    AnswerEnum.CICLISMO,
                    AnswerEnum.VIDA_NOCTURNA,
                    AnswerEnum.CULTURA,
                    AnswerEnum.PARQUE_DE_DIVERSIONES,
                    AnswerEnum.DEPORTES_EXTREMOS
                }
            });

            //BARILOCHE, RIO NEGRO
            cities.Add(new City
            {
                CityName = "Bariloche, Rio Negro",
                CityCode = "bariloche_rio_negro",
                CityId = index++,
                AnswerEnums = new List<AnswerEnum> {
                    AnswerEnum.INVIERNO,
                    AnswerEnum.PRIMAVERA,
                    AnswerEnum.TEAM_FRIO,
                    AnswerEnum.MONTAÑA,
                    AnswerEnum.PUEBLO,
                    AnswerEnum.DIURNO,
                    AnswerEnum.CABAÑA,
                    AnswerEnum.HOTEL,
                    AnswerEnum.SEMANA_COMPLETA,
                    AnswerEnum.QUINCENA_O_MAS,
                    AnswerEnum.SENDERISMO,
                    AnswerEnum.PAISAJISMO,
                    AnswerEnum.CAMPAMENTO,
                    AnswerEnum.CICLISMO,
                    AnswerEnum.VIDA_NOCTURNA,
                    AnswerEnum.CULTURA,
                    AnswerEnum.DEPORTES_EN_LA_NIEVE,
                    AnswerEnum.ESCALADA,
                    AnswerEnum.DEPORTES_EXTREMOS
                }
            });

            //SANTA CRUZ
            cities.Add(new City
            {
                CityName = "Santa Cruz",
                CityCode = "santa_cruz",
                CityId = index++,
                AnswerEnums = new List<AnswerEnum> {
                    AnswerEnum.INVIERNO,
                    AnswerEnum.TEAM_FRIO,
                    AnswerEnum.SIERRAS,
                    AnswerEnum.LLANURA,
                    AnswerEnum.PUEBLO,
                    AnswerEnum.DIURNO,
                    AnswerEnum.CABAÑA,
                    AnswerEnum.HOTEL,
                    AnswerEnum.CAMPING,
                    AnswerEnum.SEMANA_COMPLETA,
                    AnswerEnum.SENDERISMO,
                    AnswerEnum.PAISAJISMO,
                    AnswerEnum.CAMPAMENTO,
                    AnswerEnum.CULTURA,
                    AnswerEnum.DEPORTES_ACUATICOS,
                    AnswerEnum.DEPORTES_EN_LA_NIEVE,
                    AnswerEnum.DEPORTES_EXTREMOS
                }
            });

            //MENDOZA
            cities.Add(new City
            {
                CityName = "Mendoza",
                CityCode = "mendoza",
                CityId = index++,
                AnswerEnums = new List<AnswerEnum> {
                    AnswerEnum.INVIERNO,
                    AnswerEnum.PRIMAVERA,
                    AnswerEnum.TEAM_FRIO,
                    AnswerEnum.MONTAÑA,
                    AnswerEnum.SIERRAS,
                    AnswerEnum.PUEBLO,
                    AnswerEnum.DIURNO,
                    AnswerEnum.CABAÑA,
                    AnswerEnum.HOTEL,
                    AnswerEnum.CAMPING,
                    AnswerEnum.SEMANA_COMPLETA,
                    AnswerEnum.SENDERISMO,
                    AnswerEnum.PAISAJISMO,
                    AnswerEnum.CAMPAMENTO,
                    AnswerEnum.CICLISMO,
                    AnswerEnum.CULTURA,
                    AnswerEnum.DEPORTES_ACUATICOS,
                    AnswerEnum.DEPORTES_EN_LA_NIEVE,
                    AnswerEnum.RAFTING,
                    AnswerEnum.ESCALADA,
                    AnswerEnum.DEPORTES_EXTREMOS
                }
            });

            //USHUAIA
            cities.Add(new City
            {
                CityName = "Ushuaia",
                CityCode = "ushuaia",
                CityId = index++,
                AnswerEnums = new List<AnswerEnum> {
                    AnswerEnum.VERANO,
                    AnswerEnum.INVIERNO,
                    AnswerEnum.PRIMAVERA,
                    AnswerEnum.TEAM_FRIO,
                    AnswerEnum.MONTAÑA,
                    AnswerEnum.PUEBLO,
                    AnswerEnum.DIURNO,
                    AnswerEnum.CASA_DEPARTAMENTO,
                    AnswerEnum.CABAÑA,
                    AnswerEnum.HOTEL,
                    AnswerEnum.SEMANA_COMPLETA,
                    AnswerEnum.SENDERISMO,
                    AnswerEnum.PAISAJISMO,
                    AnswerEnum.CICLISMO,
                    AnswerEnum.CULTURA,
                    AnswerEnum.DEPORTES_ACUATICOS,
                    AnswerEnum.DEPORTES_EN_LA_NIEVE,
                    AnswerEnum.ESCALADA,
                    AnswerEnum.DEPORTES_EXTREMOS
                }
            });

            //CORRIENTES
            cities.Add(new City
            {
                CityName = "Corrientes",
                CityCode = "corrientes",
                CityId = index++,
                AnswerEnums = new List<AnswerEnum> {
                    AnswerEnum.VERANO,
                    AnswerEnum.PRIMAVERA,
                    AnswerEnum.TEAM_CALOR,
                    AnswerEnum.LLANURA,
                    AnswerEnum.PLAYA_RIO,
                    AnswerEnum.PUEBLO,
                    AnswerEnum.DIURNO,
                    AnswerEnum.HOTEL,
                    AnswerEnum.CAMPING,
                    AnswerEnum.FIN_DE_SEMANA,
                    AnswerEnum.SEMANA_COMPLETA,
                    AnswerEnum.SENDERISMO,
                    AnswerEnum.PLAYA,
                    AnswerEnum.PAISAJISMO,
                    AnswerEnum.CAMPAMENTO,
                    AnswerEnum.CICLISMO,
                    AnswerEnum.CULTURA,
                    AnswerEnum.DEPORTES_ACUATICOS,
                }
            });

            //SALTA
            cities.Add(new City
            {
                CityName = "Salta",
                CityCode = "salta",
                CityId = index++,
                AnswerEnums = new List<AnswerEnum> {
                    AnswerEnum.OTOÑO,
                    AnswerEnum.INVIERNO,
                    AnswerEnum.TEAM_FRIO,
                    AnswerEnum.TEAM_CALOR,
                    AnswerEnum.SIERRAS,
                    AnswerEnum.PUEBLO,
                    AnswerEnum.DIURNO,
                    AnswerEnum.CABAÑA,
                    AnswerEnum.FIN_DE_SEMANA,
                    AnswerEnum.SENDERISMO,
                    AnswerEnum.URBANISMO,
                    AnswerEnum.SHOPPING,
                    AnswerEnum.CICLISMO,
                    AnswerEnum.CULTURA,
                    AnswerEnum.ESCALADA
                }
            });

            //JUJUY
            cities.Add(new City
            {
                CityName = "Jujuy",
                CityCode = "jujuy",
                CityId = index++,
                AnswerEnums = new List<AnswerEnum> {
                    AnswerEnum.INVIERNO,
                    AnswerEnum.TEAM_FRIO,
                    AnswerEnum.MONTAÑA,
                    AnswerEnum.SIERRAS,
                    AnswerEnum.PUEBLO,
                    AnswerEnum.DIURNO,
                    AnswerEnum.CABAÑA,
                    AnswerEnum.HOTEL,
                    AnswerEnum.SEMANA_COMPLETA,
                    AnswerEnum.SENDERISMO,
                    AnswerEnum.PAISAJISMO,
                    AnswerEnum.CULTURA,
                    AnswerEnum.ESCALADA,
                    AnswerEnum.DEPORTES_EXTREMOS
                }
            });

            //CORDOBA CAPITAL
            cities.Add(new City
            {
                CityName = "Córdoba Capital",
                CityCode = "cordoba_capital",
                CityId = index++,
                AnswerEnums = new List<AnswerEnum> {
                    AnswerEnum.OTOÑO,
                    AnswerEnum.PRIMAVERA,
                    AnswerEnum.TEAM_FRIO,
                    AnswerEnum.TEAM_CALOR,
                    AnswerEnum.SIERRAS,
                    AnswerEnum.CIUDAD,
                    AnswerEnum.DIURNO,
                    AnswerEnum.NOCTURNO,
                    AnswerEnum.CASA_DEPARTAMENTO,
                    AnswerEnum.HOTEL,
                    AnswerEnum.FIN_DE_SEMANA,
                    AnswerEnum.SEMANA_COMPLETA,
                    AnswerEnum.URBANISMO,
                    AnswerEnum.SHOPPING,
                    AnswerEnum.CICLISMO,
                    AnswerEnum.VIDA_NOCTURNA,
                    AnswerEnum.CULTURA,
                    AnswerEnum.ESCALADA,
                    AnswerEnum.DEPORTES_EXTREMOS
                }
            });

            //CARLOS PAZ, CORDOBA (FRIO)
            cities.Add(new City
            {
                CityName = "Carlos Paz",
                CityCode = "carlos_paz_frio",
                CityId = index++,
                AnswerEnums = new List<AnswerEnum> {
                    AnswerEnum.OTOÑO,
                    AnswerEnum.INVIERNO,
                    AnswerEnum.TEAM_FRIO,
                    AnswerEnum.MONTAÑA,
                    AnswerEnum.SIERRAS,
                    AnswerEnum.PUEBLO,
                    AnswerEnum.DIURNO,
                    AnswerEnum.NOCTURNO,
                    AnswerEnum.CASA_DEPARTAMENTO,
                    AnswerEnum.CABAÑA,
                    AnswerEnum.HOTEL,
                    AnswerEnum.CAMPING,
                    AnswerEnum.FIN_DE_SEMANA,
                    AnswerEnum.SEMANA_COMPLETA,
                    AnswerEnum.QUINCENA_O_MAS,
                    AnswerEnum.SENDERISMO,
                    AnswerEnum.PAISAJISMO,
                    AnswerEnum.CAMPAMENTO,
                    AnswerEnum.CICLISMO,
                    AnswerEnum.VIDA_NOCTURNA,
                    AnswerEnum.CULTURA,
                    AnswerEnum.ESCALADA,
                    AnswerEnum.PARQUE_DE_DIVERSIONES,
                    AnswerEnum.DEPORTES_EXTREMOS
                }
            });

            //CARLOS PAZ, CORDOBA (CALOR)
            cities.Add(new City
            {
                CityName = "Carlos Paz",
                CityCode = "carlos_paz_calor",
                CityId = index++,
                AnswerEnums = new List<AnswerEnum> {
                    AnswerEnum.VERANO,
                    AnswerEnum.INVIERNO,
                    AnswerEnum.PRIMAVERA,
                    AnswerEnum.TEAM_CALOR,
                    AnswerEnum.MONTAÑA,
                    AnswerEnum.SIERRAS,
                    AnswerEnum.PLAYA_RIO,
                    AnswerEnum.PUEBLO,
                    AnswerEnum.DIURNO,
                    AnswerEnum.NOCTURNO,
                    AnswerEnum.CASA_DEPARTAMENTO,
                    AnswerEnum.CABAÑA,
                    AnswerEnum.HOTEL,
                    AnswerEnum.CAMPING,
                    AnswerEnum.FIN_DE_SEMANA,
                    AnswerEnum.SEMANA_COMPLETA,
                    AnswerEnum.QUINCENA_O_MAS,
                    AnswerEnum.PLAYA,
                    AnswerEnum.PAISAJISMO,
                    AnswerEnum.CAMPAMENTO,
                    AnswerEnum.CICLISMO,
                    AnswerEnum.CULTURA,
                    AnswerEnum.DEPORTES_ACUATICOS,
                    AnswerEnum.RAFTING,
                    AnswerEnum.ESCALADA,
                    AnswerEnum.PARQUE_DE_DIVERSIONES,
                    AnswerEnum.DEPORTES_EXTREMOS
                }
            });

            //Para copiar
            /*
            cities.Add(new City
            {
                CityName = "Misiones",
                CityCode = "misiones",
                CityId = index++,
                AnswerEnums = new List<AnswerEnum> {
                    AnswerEnum.VERANO,
                    AnswerEnum.OTOÑO,
                    AnswerEnum.INVIERNO,
                    AnswerEnum.PRIMAVERA,
                    AnswerEnum.TEAM_FRIO,
                    AnswerEnum.TEAM_CALOR,
                    AnswerEnum.MONTAÑA,
                    AnswerEnum.SIERRAS,
                    AnswerEnum.LLANURA,
                    AnswerEnum.PLAYA_RIO,
                    AnswerEnum.PLAYA_MAR,
                    AnswerEnum.CIUDAD,
                    AnswerEnum.PUEBLO,
                    AnswerEnum.DIURNO,
                    AnswerEnum.NOCTURNO,
                    AnswerEnum.CASA_DEPARTAMENTO,
                    AnswerEnum.CABAÑA,
                    AnswerEnum.HOTEL,
                    AnswerEnum.CAMPING,
                    AnswerEnum.FIN_DE_SEMANA,
                    AnswerEnum.SEMANA_COMPLETA,
                    AnswerEnum.QUINCENA_O_MAS,
                    AnswerEnum.SENDERISMO,
                    AnswerEnum.PLAYA,
                    AnswerEnum.PAISAJISMO,
                    AnswerEnum.URBANISMO,
                    AnswerEnum.CAMPAMENTO,
                    AnswerEnum.SHOPPING,
                    AnswerEnum.CICLISMO,
                    AnswerEnum.VIDA_NOCTURNA,
                    AnswerEnum.CULTURA,
                    AnswerEnum.DEPORTES_ACUATICOS,
                    AnswerEnum.DEPORTES_EN_LA_NIEVE,
                    AnswerEnum.RAFTING,
                    AnswerEnum.ESCALADA,
                    AnswerEnum.PARQUE_DE_DIVERSIONES,
                    AnswerEnum.DEPORTES_EXTREMOS
                }
            });
            */

            return cities;
        }
    }
}
