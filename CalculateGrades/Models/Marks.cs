using Microsoft.AspNetCore.Cors;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CalculateGrades.Models
{
    public class Marks
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "יש להכניס את נתוני הניקוד המשוקלל ולשים , בין כל מספר")]
        [DisplayName("ניקוד משוקלל")]
        public string Mark1 { get; set; }

        [Required]
        [DisplayName("משקל מחושב")]
        public decimal Mark2 { get; set; }

        [Required]
        [DisplayName("ממוצע ציונים משוקלל")]
        public decimal Mark3 { get; set; }

        [DisplayName("ציון הבחינה")]
        public decimal TestGrade { get; set; }

        public decimal CalculateTest()
        {
            decimal numToMultiple = 100 / Mark2;
            string numbersString = Mark1;
            char[] delimiterChars = { ',' };
            string[] numbersArray = numbersString.Split(delimiterChars);

            decimal sum = 0;

            foreach (string numberString in numbersArray)
            {
                decimal number;

                if (decimal.TryParse(numberString, out number))
                {
                    sum += number;
                }

            }

            decimal testWeight = Mark3 - sum;
            decimal testGrade = testWeight * numToMultiple;
            if (testGrade > 100)
            {
                testGrade -= 100;
            }

            decimal roundedGrade = Math.Round(testGrade, MidpointRounding.AwayFromZero);

            return roundedGrade;



        }
    }
}
