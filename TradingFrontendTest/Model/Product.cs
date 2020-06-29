using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingFrontendTest.Model
{
    class Product
    {
        private String name;
        private String group;
        private List<String> months;
        private List<Double> baseValues;


        private static readonly Random random = new Random();

        public Product(String name)
        {
            this.name = name;
            this.group = name +"1";
            this.months = new List<string>();
            this.baseValues = new List<double>();

            months.Add("Jan 2020");
            months.Add("Feb 2020");
            months.Add("Mar 2020");
            months.Add("Apr 2020");
            months.Add("May 2020");
            months.Add("Jun 2020");

            for (int i = 0; i < 6; i++)
            {
                baseValues.Add(GenerateRandomNumberBetween(-99.99, 99.99));
            }
           
        }

        public string Name { get { return name; } set { } }
        public string Group { get { return group; } set { } }
        public List<String> Months { get { return months; } set { } }
        public List<Double> BaseValues { get { return baseValues; } set { } }

        public static Double GenerateRandomNumberBetween(Double min, Double max)
        {
            return Math.Round((random.NextDouble() * (max - min + min)) * 100) / 100; 
        }
    }
}
