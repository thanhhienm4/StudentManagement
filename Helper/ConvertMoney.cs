using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Helper
{
    public class ConvertMoney
    {

        public static string threeNumber(int n)
        {
            int first, second, third;

            first = n % 10;
            n /= 10;
            second = n % 10;
            n /= 10;
            third = n % 10;

            string[] allNumbers = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string ans = "";

            if(third > 0)
            {
                ans += allNumbers[third] + " trăm ";
            }
            

            if(second > 0)
            {
                if(second == 1)
                {
                    ans += "mười ";
                }
                else
                {
                    ans += allNumbers[second] + " mươi ";
                }
            }

            if(first > 0)
            {
                if(second == 0 && third != 0)
                {
                    ans += "lẻ ";
                }
                if (first == 1 && second != 0)
                {
                    ans += "mốt";
                }
                else if (first == 5 && (second != 0 || third != 0))
                {
                    ans += "lăm";
                }
                else if (first == 5 && (second == 0 || third != 0))
                {
                    ans += "năm";
                }
                else
                {
                    ans += allNumbers[first];
                }
                    
            }
            return ans;
        }
        public static string NumberToString(int inputNumber)
        {
            string ans = "";
            int unit = 0, thousand = 0, million = 0, billion = 0;

            if (inputNumber == 0)
            {
                return "Không";
            }
            else {
                unit = inputNumber % 1000;
                inputNumber /= 1000;
                thousand = inputNumber % 1000;
                inputNumber /= 1000;
                million = inputNumber % 1000;
                inputNumber /= 1000;
                billion = inputNumber % 1000;
                inputNumber /= 1000;

                if(billion > 0)
                {
                    ans += threeNumber(billion) + " tỷ ";
                }
                if (million > 0)
                {
                    ans += threeNumber(million) + " triệu ";
                }
                if (thousand > 0)
                {
                    ans += threeNumber(thousand) + " nghìn ";
                }
                if (unit > 0)
                {
                    ans += threeNumber(unit);
                }
            }
            ans = ans.Substring(0, 1).ToUpper() + ans.Substring(1, ans.Length - 1);
            return ans.Trim() + " Việt Nam Đồng";
        }
    }
}
