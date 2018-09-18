using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_scales_of_notation
{
    class DigitWithNotation
    {
        private string strRecord;
        private int scalebase;
        private int Length;

        //конструкторы
        public DigitWithNotation()
        {
            strRecord = "";
            scalebase = 10;
            Length = StrRecord.Length;
        }

        public DigitWithNotation(string inRec, int inB)
        {
            strRecord = Convert.ToString(inRec.Clone());
            scalebase = inB;
            Length = StrRecord.Length;
        }

        //свойства
        public string StrRecord { get => strRecord; }
        public int SysBase { get => scalebase; }

        //функции
        public override string ToString()
        {
            return "" + strRecord + " в системе с основанием " + scalebase;
        }

        public int ToDenary()
        {
            int denaryDigit = 0;
            for (int i = Length - 1; i >= 0; i--)
            {
                denaryDigit += (int)Char.GetNumericValue(strRecord[Length - 1 - i]) * Convert.ToInt32(Math.Pow(Convert.ToDouble(scalebase), Convert.ToDouble(i))); 
            }

            return denaryDigit;
        }

        public static DigitWithNotation ToNewScale(int denaryDigit, int scalBase)
        {
            string rec = "";
            int div = denaryDigit;

            while (div > 0)
            {
                rec += Convert.ToString(div % scalBase);
                div = div / scalBase;
            }

            DigitWithNotation newDWN = new DigitWithNotation(new string(rec.ToCharArray().Reverse().ToArray()), scalBase);
            return newDWN;
        }

        //операторы
        //должно быть исключение для чисел с разными основаниями
        public static DigitWithNotation operator +(DigitWithNotation d1, DigitWithNotation d2)
        {
            return ToNewScale(d1.ToDenary() + d2.ToDenary(), d1.SysBase);
        }

        public static DigitWithNotation operator -(DigitWithNotation d1, DigitWithNotation d2)
        {
           return ToNewScale(d1.ToDenary() - d2.ToDenary(), d1.SysBase);
        }

        public static bool operator >(DigitWithNotation d1, DigitWithNotation d2)
        {
            if (d1.ToDenary() > d2.ToDenary())
                return true;
            else return false;
        }

        public static bool operator <(DigitWithNotation d1, DigitWithNotation d2)
        {
            if (d1.ToDenary() < d2.ToDenary())
                return true;
            else return false;
        }

        public static DigitWithNotation operator *(DigitWithNotation d1, DigitWithNotation d2)
        {
            return ToNewScale(d1.ToDenary() * d2.ToDenary(), d1.SysBase);
        }
    }
}
