using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSpreadsheet
{
    class Operations
    {
        private float firstNumber, secondNumber;

        public float FirstNumber { get => firstNumber; set => firstNumber = value; }
        public float SecondNumber { get => secondNumber; set => secondNumber = value; }

        public float Sum()
        {
            return firstNumber + secondNumber;
        }
        public float Multiply()
        {
            return firstNumber * secondNumber;
        }
        public float Mean()
        {
            return (firstNumber + secondNumber) / 2;
        }
        public float Median()
        {
            return (2 + 1) / 2;
        }
        public float Mode()
        {
            return 0;
        }
    }
}
