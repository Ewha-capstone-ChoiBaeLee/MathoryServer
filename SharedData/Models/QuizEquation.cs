using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime;

namespace SharedData.Models
{
    public class QuizEquation
    {
        private static Random random = new Random();
        public static (string result, string subject, string answer) PlusReturn(List<double> numbers)
        {
            double ans = numbers.Sum();
            string result = string.Join(" + ", numbers);
            string subject = "The mathematics topic is arithmetic equation";
            string answer = ans.ToString();
            return (result, subject, answer);
        }
        public static (string result, string subject, string answer) MinusReturn(List<double> numbers)
        {
            numbers.Sort((a, b) => b.CompareTo(a)); // 내림차순 정렬

            double ans = numbers[0] - numbers[1];
            string result = string.Join(" - ", numbers);
            string subject = "The mathematics topic is arithmetic equation";
            string answer = ans.ToString();
            return (result, subject, answer);
        }
        public static (string result, string subject, string answer) MulReturn(List<double> numbers)
        {
            numbers.Sort((a, b) => b.CompareTo(a)); // 내림차순 정렬
            double ans = numbers[0] * numbers[1];
            string result = string.Join(" * ", numbers);
            string subject = "The mathematics topic is arithmetic equation";
            string answer = ans.ToString();
            return (result, subject, answer);
        }
        public static (string result, string subject, string answer) DivmodReturn(List<double> numbers) //division with remainder 
        {
            numbers.Sort((a, b) => b.CompareTo(a)); // 내림차순 정렬
            string subject = "The mathematics topic is arithmetic equation";
            string result = $"divmod({numbers[0]}, {numbers[1]})";
            double c = numbers[0] / numbers[1];
            double quotient = System.Math.Truncate(c); // 몫
            double remainder = numbers[0] % numbers[1];  // 나머지
            string answer = "(" + quotient.ToString() + ", " + remainder.ToString() + ")";
            return (result, subject, answer);
        }
        public static (string result, string subject, string answer) DivReturn(List<double> numbers) //division without remainder 
        {
            string subject = "The mathematics topic is arithmetic equation";
            numbers.Sort((a, b) => b.CompareTo(a)); // 내림차순 정렬
            string result = string.Join(" / ", numbers);
            string answer = (numbers[0] / numbers[1]).ToString();
            return (result, subject, answer);
        }
        public static (string result, string subject, string answer) MixedEquation(List<double> numbers)
        {
            string subject = "The mathematics topic is arithmetic equation";
            numbers.Sort((a, b) => b.CompareTo(a)); // 내림차순 정렬
            Random random = new Random();
            string result = "";
            string answer = "";
            int rand = random.Next(1, 2);
            if (rand == 1)
            {
                result = $"{numbers[0]} * {numbers[1]} - {numbers[2]}";
                answer = (numbers[0] * numbers[1] - numbers[2]).ToString();
            }
            else
            {
                result = $"{numbers[0]} * {numbers[1]} + {numbers[2]}";
                answer = (numbers[0] * numbers[1] + numbers[2]).ToString();
            }

            return (result, subject, answer);
        }
        public static (string result, string subject, string answer) MinReturn(List<double> numbers)
        {
            string subject = "The mathematics topic is number comparison";
            string result = "Min(" + string.Join(", ", numbers) + ")";
            double doubleAnswer = numbers.Min();
            string answer = doubleAnswer.ToString();
            return (result, subject, answer);
        }
        public static (string result, string subject, string answer) MaxReturn(List<double> numbers)
        {
            string subject = "The mathematics topic is number comparison";
            string result = "Max(" + string.Join(", ", numbers) + ")";
            double doubleAnswer = numbers.Max();
            string answer = doubleAnswer.ToString();
            return (result, subject, answer);
        }
        public static (string result, string subject, string answer) LcmReturn(List<double> numbers)
        {
            string subject = "The mathematics topic is divisors and multiples";
            string result = "lcm(" + string.Join(", ", numbers) + ")";
            double answer_double = numbers[0];  // Initialize lcm with the first element
            answer_double = LCM(numbers[0], numbers[1]);

            string answer = answer_double.ToString();
            return (result, subject, answer);
        }
        public static double LCM(double number1, double number2)
        {
            double n = number1;
            double m = number2;
            double temp = 0;
            while (m > 0)
            {
                temp = n % m;
                n = m;
                m = temp;
            }
            return (number1 * number2) / n;
        }
        public static (string result, string subject, string answer) GcdReturn(List<double> numbers)
        {
            string subject = "The mathematics topic is divisors and multiples";
            string result = "gcd(" + string.Join(", ", numbers) + ")";
            double answer_double = numbers[0];
            answer_double = GCD(numbers[0], numbers[1]);

            string answer = answer_double.ToString();
            return (result, subject, answer);
        }
        public static double GCD(double number1, double number2)
        {
            double n = number1;
            double m = number2;
            double temp = 0;
            while (m > 0)
            {
                temp = n % m;
                n = m;
                m = temp;
            }
            return n;
        }
        public static (string result, string subject, string answer) MeanReturn(List<double> numbers)
        {
            double ans = numbers.Sum() / 3;
            string result = "statistics.mean(" + string.Join(", ", numbers) + ")";
            string subject = "The mathematics topic is average";
            string answer = ans.ToString();
            return (result, subject, answer);
        }
        public static (string result, string subject, string answer) FractionPlus(List<double> numbers)
        {
            string subject = "The mathematics topic is arithmetic equation";
            //1,3 + 1,2
            double numerator = numbers[0] * numbers[3] + numbers[1] * numbers[2];
            double denominator = numbers[1] * numbers[3];
            double gcd = GCD(numerator, denominator);
            numerator /= gcd;
            denominator /= gcd;
            string answer = "frac(" + numerator.ToString() + ", " + denominator.ToString() + ")";
            string result = "frac(" + numbers[0].ToString() + ", " + numbers[1].ToString() + ")" + " + " + "frac(" + numbers[2].ToString() + ", " + numbers[3].ToString() + ")";
            return (result, subject, answer);
        }
        public static (string result, string subject, string answer) FractionMinus(List<double> numbers)
        {
            string subject = "The mathematics topic is arithmetic equation";
            //1,3 + 1,2
            double numerator = numbers[0] * numbers[3] - numbers[1] * numbers[2];
            double denominator = numbers[1] * numbers[3];
            double gcd = GCD(numerator, denominator);
            numerator /= gcd;
            denominator /= gcd;
            string answer = "frac(" + numerator.ToString() + ", " + denominator.ToString() + ")";
            string result = "frac(" + numbers[0].ToString() + ", " + numbers[1].ToString() + ")" + " - " + "frac(" + numbers[2].ToString() + ", " + numbers[3].ToString() + ")";
            if (numerator == 0)
                return (result, subject, "0");
            return (result, subject, answer);
        }
        public static (string result, string subject, string answer) FractionMul(List<double> numbers)
        {
            string subject = "The mathematics topic is arithmetic equation";
            //1,3 + 1,2
            double numerator = numbers[0] * numbers[2];
            double denominator = numbers[1] * numbers[3];
            double gcd = GCD(numerator, denominator);
            numerator /= gcd;
            denominator /= gcd;
            string answer = "frac(" + numerator.ToString() + ", " + denominator.ToString() + ")";
            string result = "frac(" + numbers[0].ToString() + ", " + numbers[1].ToString() + ")" + " * " + "frac(" + numbers[2].ToString() + ", " + numbers[3].ToString() + ")";
            return (result, subject, answer);
        }
        public static (string result, string subject, string answer) FractionDiv(List<double> numbers)
        {
            string subject = "The mathematics topic is arithmetic equation";
            //1,3 + 1,2
            double numerator = numbers[0] * numbers[3];
            double denominator = numbers[1] * numbers[2];
            double gcd = GCD(numerator, denominator);
            numerator /= gcd;
            denominator /= gcd;
            string answer = "frac(" + numerator.ToString() + ", " + denominator.ToString() + ")";
            string result = "frac(" + numbers[0].ToString() + ", " + numbers[1].ToString() + ")" + " / " + "frac(" + numbers[2].ToString() + ", " + numbers[3].ToString() + ")";
            return (result, subject, answer);
        }
        public static (string result, string subject, string answer) FractionMin(List<double> numbers)
        {
            string subject = "The mathematics topic is number comparison";
            //1,3 + 1,2
            string answer = "";
            double numerator = numbers[0] * numbers[3] - numbers[1] * numbers[2];
            if (numerator < 0)
            {
                answer = "frac" + numbers[0].ToString() + ", " + numbers[1].ToString() + ")";
            }
            else
            {
                answer = "frac(" + numbers[2].ToString() + ", " + numbers[3].ToString() + ")";
            }

            string result = "Min(frac(" + numbers[0].ToString() + ", " + numbers[1].ToString() + ")" + "," + "frac(" + numbers[2].ToString() + ", " + numbers[3].ToString() + ")" + ")";

            return (result, subject, answer);
        }
        public static (string result, string subject, string answer) FractionMax(List<double> numbers)
        {
            string subject = "The mathematics topic is number comparison";
            //1,3 + 1,2
            string answer = "";
            double numerator = numbers[0] * numbers[3] - numbers[1] * numbers[2];
            if (numerator < 0)
            {
                answer = "frac(" + numbers[2].ToString() + ", " + numbers[3].ToString() + ")";
            }
            else
            {
                answer = "frac(" + numbers[0].ToString() + ", " + numbers[1].ToString() + ")";
            }

            string result = "Max(frac(" + numbers[0].ToString() + ", " + numbers[1].ToString() + ")" + "," + "frac(" + numbers[2].ToString() + ", " + numbers[3].ToString() + ")" + ")";

            return (result, subject, answer);
        }

        //first grade
        static (string result, string subject, string answer) first_grade()
        {
            List<double> numbers = new List<double>(); // List<double> 생성
            double subject = random.Next(1, 4);
            /*
             * 1. 한자리 수의 덧셈 뺄셈 => 사칙
             * 2. 계산 결과가 두자리수인 세수의 덧셈/뺄셈 => 사칙
             * 3. 십의 자리 수의 크기 비교 => 크기비교
             */
            switch (subject)
            {
                case 1: // 한자리수 덧셈 뺄셈
                    numbers.AddRange(new double[] { random.Next(1, 10), random.Next(1, 10) });
                    numbers.Sort((a, b) => b.CompareTo(a)); //내림차순
                    return random.Next(0, 2) == 0 ? PlusReturn(numbers) : MinusReturn(numbers);
                case 2: // 한자리수 덧셈 3개
                    numbers.AddRange(new double[] { random.Next(1, 10), random.Next(1, 10), random.Next(1, 10) });
                    numbers.Sort((a, b) => b.CompareTo(a)); //내림차순
                    return PlusReturn(numbers);
                case 3: // 두자리수 크기 비교
                    numbers.AddRange(new double[] { random.Next(1, 100), random.Next(1, 100) });
                    return random.Next(0, 2) == 0 ? MinReturn(numbers) : MaxReturn(numbers);
                default:
                    throw new NotImplementedException("Subject not implemented.");
            }
        }

        //second grade
        static (string result, string subject, string answer) second_grade()
        {
            List<double> numbers = new List<double>(); // List<double> 생성

            double subject = random.Next(1, 5);
            /*
             * 1. 세자리수 크기비교
             * 2. 네자리수 크기비교
             * 3. 한자리수 곱셈
             * 4. 두자리수 덧셈
             */
            switch (subject)
            {
                case 1: // 세자리수 크기비교
                    numbers.AddRange(new double[] { random.Next(100, 1000), random.Next(100, 1000), random.Next(100, 1000) });
                    return random.Next(0, 2) == 0 ? MinReturn(numbers) : MaxReturn(numbers);
                case 2: // 네자리수 크기비교
                    numbers.AddRange(new double[] { random.Next(1000, 10000), random.Next(1000, 10000), random.Next(1000, 10000), random.Next(1000, 10000) });
                    return random.Next(0, 2) == 0 ? MinReturn(numbers) : MaxReturn(numbers);
                case 3: // 한자리수 곱셈
                    numbers.AddRange(new double[] { random.Next(1, 10), random.Next(1, 10) });
                    return MulReturn(numbers);
                case 4: // 두자리수 덧셈
                    numbers.AddRange(new double[] { random.Next(1, 10), random.Next(1, 10) });
                    return PlusReturn(numbers);
                default:
                    throw new NotImplementedException("Subject not implemented.");
            }
        }

        //third grade
        static (string result, string subject, string answer) third_grade()
        {
            List<double> numbers = new List<double>(); // List<double> 생성

            double subject = random.Next(1, 7);
            /*
              1.세자리 수 덧셈/뺄셈
              2. (두자리 수)%(한자리 수) 나눗셈
              3. (세자리 수)*(한자리 수) 곱셈
              4. (두자리 수)*(두자리 수) 곱셈
              5. 분모가 같은 분수 크기 비교
              6. 소수 두자리 수 크기 비교
            */
            switch (subject)
            {
                case 1: // 세자리 수 덧셈/뺄셈
                    numbers.AddRange(new double[] { random.Next(100, 1000), random.Next(100, 1000) });
                    return random.Next(0, 2) == 0 ? PlusReturn(numbers) : MinusReturn(numbers);
                case 2: // (두자리 수)%(한자리 수) 나눗셈
                    numbers.AddRange(new double[] { random.Next(10, 99), random.Next(2, 9) });
                    return DivmodReturn(numbers);
                case 3: // (세자리 수)*(한자리 수) 곱셈
                    numbers.AddRange(new double[] { random.Next(100, 1000), random.Next(2, 10) });
                    return MulReturn(numbers);
                case 4: // (두자리 수)*(두자리 수) 곱셈
                    numbers.AddRange(new double[] { random.Next(10, 100), random.Next(10, 100) });
                    return MulReturn(numbers);
                case 5: // 분모가 같은 분수 크기 비교
                    int number = random.Next(2, 10);
                    numbers.AddRange(new double[] { random.Next(1, 10), number, random.Next(1, 10), number });
                    return random.Next(0, 2) == 0 ? FractionMin(numbers) : FractionMax(numbers);
                case 6: // 소수 두자리 수 크기 비교
                    numbers.AddRange(new double[] { (double)random.Next(1, 100) / 100, (double)random.Next(1, 100) / 100 });
                    return random.Next(0, 2) == 0 ? MinReturn(numbers) : MaxReturn(numbers);
                default:
                    throw new NotImplementedException("Subject not implemented.");
            }
        }

        //fourth grade 
        static (string result, string subject, string answer) fourth_grade()
        {
            List<double> numbers = new List<double>(); // List<double> 생성

            double subject = random.Next(1, 5);

            /*
             * 1. 분모가 같은 분수 덧셈 뺄셈 (분모가 한자리수)
             * 2. 소수 두자리수 덧셈과 뺄셈
             * 3. (세자리수)*(두자리수) 곱셈/나눗셈
             * 4. 소수 세자리수 크기 비교
            */
            switch (subject)
            {
                case 1: // 분모가 같은 분수 덧셈 뺄셈 (분모가 한자리수)
                    int number = random.Next(2, 10);
                    numbers.AddRange(new double[] { random.Next(5, 10), number, random.Next(1, 4), number });
                    return random.Next(0, 2) == 0 ? FractionPlus(numbers) : FractionMinus(numbers);
                case 2: // 소수 두자리수 덧셈과 뺄셈
                    numbers.AddRange(new double[] { (double)random.Next(1, 99) / 100, (double)random.Next(1, 99) / 100 });
                    return random.Next(0, 2) == 0 ? PlusReturn(numbers) : MinusReturn(numbers);
                case 3: // (세자리수)*(두자리수) 곱셈/나눗셈
                    numbers.AddRange(new double[] { random.Next(100, 1000), random.Next(10, 100) });
                    return random.Next(0, 2) == 0 ? MulReturn(numbers) : DivReturn(numbers);
                case 4: // 소수 세자리수 크기 비교
                    numbers.AddRange(new double[] { (double)random.Next(100, 1000) / 1000, (double)random.Next(100, 1000) / 1000 });
                    return random.Next(0, 2) == 0 ? MinReturn(numbers) : MaxReturn(numbers);
                default:
                    throw new NotImplementedException("Subject not implemented.");
            }
        }

        //fifth grade
        static (string result, string subject, string answer) fifth_grade()
        {
            List<double> numbers = new List<double>(); // List<double> 생성

            double subject = random.Next(2, 4);

            /*5학년 용
            1. 사칙연산이 섞인 식 (나눗셈은 딱 떨어져야함)
            2. 최대공약수
            3. 최소공배수
            4. 분모가 다른 분수의 덧셈과 뺄셈(분모 2자릿수)
            5. 두자리수 소수의 곱셈
            6. 평균*/
            switch (subject)
            {
                case 1: // 사칙연산이 섞인 식 (나눗셈은 딱 떨어져야함)
                    numbers.AddRange(new double[] { random.Next(1, 10), random.Next(1, 10), random.Next(1, 10) });
                    return MixedEquation(numbers);
                case 2: //평균
                    while (true)
                    {
                        numbers.Clear();
                        numbers.AddRange(new double[] { random.Next(1, 100), random.Next(1, 100), random.Next(1, 100) });
                        if (numbers.Sum() % 3 == 0) break;
                    }
                    return MeanReturn(numbers);
                case 3:  // 최대공약수
                    numbers.AddRange(new double[] { random.Next(6, 100), random.Next(6, 100) });
                    return GcdReturn(numbers);
                case 4: // 분모가 다른 분수의 덧셈과 뺄셈(분모 2자릿수)
                    numbers.AddRange(new double[] { random.Next(1, 20), random.Next(2, 20), random.Next(1, 20), random.Next(2, 20) });
                    if (numbers[0] * numbers[3] < numbers[1] * numbers[2])
                    {
                        double temp0, temp1;
                        temp0 = numbers[0]; temp1 = numbers[1];
                        numbers[0] = numbers[2];
                        numbers[1] = numbers[3];
                        numbers[2] = temp0;
                        numbers[3] = temp1;
                    }
                    return random.Next(0, 2) == 0 ? FractionPlus(numbers) : FractionMinus(numbers);
                case 5: //두자리수 소수의 곱셈
                    numbers.AddRange(new double[] { (double)random.Next(1, 99) / 100, (double)random.Next(1, 99) / 100 });
                    return MulReturn(numbers);
                case 6:// 최소공배수
                    numbers.AddRange(new double[] { random.Next(5, 40), random.Next(5, 40) });
                    return LcmReturn(numbers);
                default:
                    throw new NotImplementedException("Subject not implemented.");
            }
        }

        //sixth grade
        static (string result, string subject, string answer) sixth_grade()
        {
            List<double> numbers = new List<double>(); // List<double> 생성

            double subject = random.Next(1, 5);
            /*6학년 용
            1. (분수)%(자연수) 분모가 두 자릿 수, 한자리 자연수
            2. (소수)%(자연수) 소숫점 두자리, 한자리 자연수
            3. 분모가 같은 (분수)%(분수)
            4. (소수)%(소수) 소숫점 두자리 둘 다*/
            switch (subject)
            {
                case 1: // (분수)%(자연수) 분모가 두 자릿 수, 한자리 자연수
                    numbers.AddRange(new double[] { random.Next(1, 20), random.Next(1, 20), random.Next(1, 20), 1 });
                    return FractionDiv(numbers);
                case 2: // (소수)%(자연수) 소숫점 두자리, 한자리 자연수
                    int num = random.Next(1, 10);
                    numbers.AddRange(new double[] { (double)random.Next(1, 99) / 100 * num, num });
                    return DivReturn(numbers);
                case 3: //  분모가 같은 (분수)%(분수)
                    int number = random.Next(2, 20);
                    numbers.AddRange(new double[] { random.Next(1, 20), number, random.Next(1, 20), number });
                    return FractionDiv(numbers);
                case 4: // (소수)%(소수) 소숫점 두자리 둘 다
                    double dub_num = (double)random.Next(1, 99) / 100;
                    numbers.AddRange(new double[] { dub_num * random.Next(2, 20), dub_num });
                    return DivReturn(numbers);
                default:
                    throw new NotImplementedException("Subject not implemented.");
            }
        }


        public static Tuple<string, string, string> Generate()
        {
            var (equation, subject, answer) = fifth_grade();
            Console.WriteLine($"Result: {equation}");
            Console.WriteLine($"Result: {subject}");
            Console.WriteLine($"Result: {answer}");

            return Tuple.Create(equation, subject, answer);
        }
    }
}   