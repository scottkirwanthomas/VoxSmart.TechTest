using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VoxSmart.TechTest.FinancialEntities.Utilities
{
    public static class StaticData
    {
        public static List<string> AgriculturalCommodities
        {
            get
            {
                return new List<string>{
                        "Corn",
                        "Oats",
                        "Rough",
                        "Rice",
                        "Soybeans",
                        "Rapeseed",
                        "Soybean Meal",
                        "Soy Meal",
                        "Soybean Oil",
                        "Wheat",
                        "Milk",
                        "Cocoa",
                        "Coffee",
                        "Cotton No.2",
                        "Sugar No.11",
                        "Sugar No.14",
                        "Frozen Concentrated Orange Juice",
                        "Adzuki bean",
                        "Robusta coffee",
                        "Lean Hogs",
                        "Live Cattle",
                        "Feeder Cattle"
                }; ;
            }
        }

        public static List<string> MetalCommodities
        {
            get
            {
                return new List<string>
                    {
                        "LME Copper",
                        "Lead",
                        "Zinc",
                        "Tin",
                        "Aluminium",
                        "Aluminium alloy",
                        "LME Nickel",
                        "Cobalt",
                        "Molybdenum",
                        "Gold",
                        "Platinum",
                        "Palladium",
                        "Silver"
                    };
            }
        }

        public static List<string> CurrencyCodes
        {
            get
            {
                return new List<string>
            {
                "ARS",
                "AUD",
                "BRL",
                "GBP",
                "CAD",
                "CLP",
                "COP",
                "HRK",
                "CZK",
                "EGP",
                "EUR",
                "HKD",
                "HUF",
                "ISK",
                "INR",
                "IDR",
                "ILS",
                "JMD",
                "JPY",
                "KWD",
                "MYR",
                "MXN",
                "TWD",
                "NZD",
                "NGN",
                "NOK",
                "PKR",
                "PEN",
                "PHP",
                "PLN",
                "QAR",
                "CNY",
                "RON",
                "RUB",
                "SAR",
                "SGD",
                "ZAR",
                "KRW",
                "SEK",
                "CHF",
                "THB",
                "TRY",
                "UAH",
                "AED",
                "USD",
                "VND"
            };
            }
        }

        public static List<string> EnergyCommodities
        {
            get
            {
                return new List<string>
                {
                    "Crude Oil",
                    "Brent Crude",
                    "Ethanol",
                    "Natural gas",
                    "Natural gas",
                    "Heating Oil",
                    "Gulf Coast Gasoline",
                    "RBOB Gasoline",
                    "Propane",
                    "Purified Terephthalic Acid",
                    "PTA"

                };
            }
        }
    }
}
