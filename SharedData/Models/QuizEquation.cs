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

        public static int Year;

        public static (string result, string subject, string answer, int subjectID) DecimalPlusReturn(List<double> numbers, string DP)
        {
            double ans = numbers.Sum();
            string result = string.Join(" + ", numbers);
            string subject = "The mathematics topic is arithmetic equation";
            int subjectID = 1;
            string answer = ans.ToString(DP);
            return (result, subject, answer, subjectID);
        }
        public static (string result, string subject, string answer, int subjectID) PlusReturn(List<double> numbers)
        {
            double ans = numbers.Sum();
            string result = string.Join(" + ", numbers);
            string subject = "The mathematics topic is arithmetic equation";
            int subjectID = 1;
            string answer = ans.ToString();
            return (result, subject, answer, subjectID);
        }
        public static (string result, string subject, string answer, int subjectID) DecimalMinusReturn(List<double> numbers, string DP)
        {
            numbers.Sort((a, b) => b.CompareTo(a)); // 내림차순 정렬

            double ans = numbers[0] - numbers[1];
            string result = string.Join(" - ", numbers);
            string subject = "The mathematics topic is arithmetic equation";
            int subjectID = 1;
            string answer = ans.ToString(DP);
            return (result, subject, answer, subjectID);
        }
        public static (string result, string subject, string answer, int subjectID) MinusReturn(List<double> numbers)
        {
            numbers.Sort((a, b) => b.CompareTo(a)); // 내림차순 정렬

            double ans = numbers[0] - numbers[1];
            string result = string.Join(" - ", numbers);
            string subject = "The mathematics topic is arithmetic equation";
            int subjectID = 1;
            string answer = ans.ToString();
            return (result, subject, answer, subjectID);
        }
        public static (string result, string subject, string answer, int subjectID) DecimalMulReturn(List<double> numbers, string DP)
        {
            numbers.Sort((a, b) => b.CompareTo(a)); // 내림차순 정렬
            double ans = numbers[0] * numbers[1];
            string result = string.Join(" * ", numbers);
            string subject = "The mathematics topic is arithmetic equation";
            int subjectID = 1;
            string answer = ans.ToString(DP);
            return (result, subject, answer, subjectID);
        }
        public static (string result, string subject, string answer, int subjectID) MulReturn(List<double> numbers)
        {
            numbers.Sort((a, b) => b.CompareTo(a)); // 내림차순 정렬
            double ans = numbers[0] * numbers[1];
            string result = string.Join(" * ", numbers);
            string subject = "The mathematics topic is arithmetic equation";
            int subjectID = 1;
            string answer = ans.ToString();
            return (result, subject, answer, subjectID);
        }
        public static (string result, string subject, string answer, int subjectID) DivmodReturn(List<double> numbers) //division with remainder 
        {
            numbers.Sort((a, b) => b.CompareTo(a)); // 내림차순 정렬
            string subject = "The mathematics topic is arithmetic equation";
            int subjectID = 1;
            string result = $"divmod({numbers[0]}, {numbers[1]})";
            double c = numbers[0] / numbers[1];
            double quotient = System.Math.Truncate(c); // 몫
            double remainder = numbers[0] % numbers[1];  // 나머지
            string answer = "(" + quotient.ToString() + ", " + remainder.ToString() + ")";
            return (result, subject, answer, subjectID);
        }
        public static (string result, string subject, string answer, int subjectID) DecimalDivReturn(List<double> numbers, string DP)
        {
            string subject = "The mathematics topic is arithmetic equation";
            int subjectID = 1;
            numbers.Sort((a, b) => b.CompareTo(a)); // 내림차순 정렬
            string result = string.Join(" / ", numbers);
            string answer = (numbers[0] / numbers[1]).ToString(DP);
            return (result, subject, answer, subjectID);
        }
        public static (string result, string subject, string answer, int subjectID) DivReturn(List<double> numbers) //division without remainder 
        {
            string subject = "The mathematics topic is arithmetic equation";
            int subjectID = 1;
            numbers.Sort((a, b) => b.CompareTo(a)); // 내림차순 정렬
            string result = string.Join(" / ", numbers);
            string answer = (numbers[0] / numbers[1]).ToString();
            return (result, subject, answer, subjectID);
        }
        public static (string result, string subject, string answer, int subjectID) MixedEquation(List<double> numbers)
        {
            string subject = "The mathematics topic is arithmetic equation";
            int subjectID = 1;
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

            return (result, subject, answer, subjectID);
        }
        public static (string result, string subject, string answer, int subjectID) MinReturn(List<double> numbers)
        {
            string subject = "The mathematics topic is number comparison";
            int subjectID = 2;
            string result = "Min(" + string.Join(", ", numbers) + ")";
            double doubleAnswer = numbers.Min();
            string answer = doubleAnswer.ToString();
            return (result, subject, answer, subjectID);
        }
        public static (string result, string subject, string answer, int subjectID) MaxReturn(List<double> numbers)
        {
            string subject = "The mathematics topic is number comparison";
            int subjectID = 2;
            string result = "Max(" + string.Join(", ", numbers) + ")";
            double doubleAnswer = numbers.Max();
            string answer = doubleAnswer.ToString();
            return (result, subject, answer, subjectID);
        }
        public static (string result, string subject, string answer, int subjectID) LcmReturn(List<double> numbers)
        {
            string subject = "The mathematics topic is divisors and multiples";
            int subjectID = 3;
            string result = "lcm(" + string.Join(", ", numbers) + ")";
            double answer_double = numbers[0];  // Initialize lcm with the first element
            answer_double = LCM(numbers[0], numbers[1]);

            string answer = answer_double.ToString();
            return (result, subject, answer, subjectID);
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
        public static (string result, string subject, string answer, int subjectID) GcdReturn(List<double> numbers)
        {
            string subject = "The mathematics topic is divisors and multiples";
            int subjectID = 3;
            string result = "gcd(" + string.Join(", ", numbers) + ")";
            double answer_double = numbers[0];
            answer_double = GCD(numbers[0], numbers[1]);

            string answer = answer_double.ToString();
            return (result, subject, answer, subjectID);
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
        public static (string result, string subject, string answer, int subjectID) MeanReturn(List<double> numbers)
        {
            double ans = numbers.Sum() / 3;
            string result = "statistics.mean(" + string.Join(", ", numbers) + ")";
            string subject = "The mathematics topic is average";
            int subjectID = 4;
            string answer = ans.ToString();
            return (result, subject, answer, subjectID);
        }
        public static (string result, string subject, string answer, int subjectID) FractionPlus(List<double> numbers)
        {
            string subject = "The mathematics topic is arithmetic equation";
            int subjectID = 1;
            //1,3 + 1,2
            double numerator = numbers[0] * numbers[3] + numbers[1] * numbers[2];
            double denominator = numbers[1] * numbers[3];
            double gcd = GCD(numerator, denominator);
            numerator /= gcd;
            denominator /= gcd;
            string answer = "Fraction(" + numerator.ToString() + ", " + denominator.ToString() + ")";
            string result = "Fraction(" + numbers[0].ToString() + ", " + numbers[1].ToString() + ")" + " + " + "Fraction(" + numbers[2].ToString() + ", " + numbers[3].ToString() + ")";
            return (result, subject, answer, subjectID);
        }
        public static (string result, string subject, string answer, int subjectID) FractionMinus(List<double> numbers)
        {
            string subject = "The mathematics topic is arithmetic equation";
            int subjectID = 1;
            //1,3 + 1,2
            double numerator = numbers[0] * numbers[3] - numbers[1] * numbers[2];
            double denominator = numbers[1] * numbers[3];
            double gcd = GCD(numerator, denominator);
            numerator /= gcd;
            denominator /= gcd;
            string answer = "Fraction(" + numerator.ToString() + ", " + denominator.ToString() + ")";
            string result = "Fraction(" + numbers[0].ToString() + ", " + numbers[1].ToString() + ")" + " - " + "Fraction(" + numbers[2].ToString() + ", " + numbers[3].ToString() + ")";
            if (numerator == 0)
                return (result, subject, "0", subjectID);
            return (result, subject, answer, subjectID);
        }
        public static (string result, string subject, string answer, int subjectID) FractionMul(List<double> numbers)
        {
            string subject = "The mathematics topic is arithmetic equation";
            int subjectID = 1;
            //1,3 + 1,2
            double numerator = numbers[0] * numbers[2];
            double denominator = numbers[1] * numbers[3];
            double gcd = GCD(numerator, denominator);
            numerator /= gcd;
            denominator /= gcd;
            string answer = "Fraction(" + numerator.ToString() + ", " + denominator.ToString() + ")";
            string result = "Fraction(" + numbers[0].ToString() + ", " + numbers[1].ToString() + ")" + " * " + "Fraction(" + numbers[2].ToString() + ", " + numbers[3].ToString() + ")";
            return (result, subject, answer, subjectID);
        }
        public static (string result, string subject, string answer, int subjectID) FractionDiv(List<double> numbers)
        {
            string subject = "The mathematics topic is arithmetic equation";
            int subjectID = 1;
            //1,3 + 1,2
            double numerator = numbers[0] * numbers[3];
            double denominator = numbers[1] * numbers[2];
            double gcd = GCD(numerator, denominator);
            numerator /= gcd;
            denominator /= gcd;
            string answer = "Fraction(" + numerator.ToString() + ", " + denominator.ToString() + ")";
            string result = "Fraction(" + numbers[0].ToString() + ", " + numbers[1].ToString() + ")" + " / " + "Fraction(" + numbers[2].ToString() + ", " + numbers[3].ToString() + ")";
            return (result, subject, answer, subjectID);
        }
        public static (string result, string subject, string answer, int subjectID) FractionMin(List<double> numbers)
        {
            string subject = "The mathematics topic is number comparison";
            int subjectID = 2;
            //1,3 + 1,2
            string answer = "";
            double numerator = numbers[0] * numbers[3] - numbers[1] * numbers[2];
            if (numerator < 0)
            {
                answer = "frac" + numbers[0].ToString() + ", " + numbers[1].ToString() + ")";
            }
            else
            {
                answer = "Fraction(" + numbers[2].ToString() + ", " + numbers[3].ToString() + ")";
            }

            string result = "Min(Fraction(" + numbers[0].ToString() + ", " + numbers[1].ToString() + ")" + "," + "Fraction(" + numbers[2].ToString() + ", " + numbers[3].ToString() + ")" + ")";

            return (result, subject, answer, subjectID);
        }
        public static (string result, string subject, string answer, int subjectID) FractionMax(List<double> numbers)
        {
            string subject = "The mathematics topic is number comparison";
            int subjectID = 2;
            //1,3 + 1,2
            string answer = "";
            double numerator = numbers[0] * numbers[3] - numbers[1] * numbers[2];
            if (numerator < 0)
            {
                answer = "Fraction(" + numbers[2].ToString() + ", " + numbers[3].ToString() + ")";
            }
            else
            {
                answer = "Fraction(" + numbers[0].ToString() + ", " + numbers[1].ToString() + ")";
            }

            string result = "Max(Fraction(" + numbers[0].ToString() + ", " + numbers[1].ToString() + ")" + "," + "Fraction(" + numbers[2].ToString() + ", " + numbers[3].ToString() + ")" + ")";

            return (result, subject, answer, subjectID);
        }

        //first grade
        static (string result, string subject, string answer, int subjectID) first_grade()
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
                    int num1 = random.Next(1, 100);
                    int num2;
                    do
                    {
                        num2 = random.Next(1, 100);
                    } while (num1 == num2);
                    numbers.AddRange(new double[] { num1, num2 });
                    return random.Next(0, 2) == 0 ? MinReturn(numbers) : MaxReturn(numbers);
                default:
                    throw new NotImplementedException("Subject not implemented.");
            }
        }

        //second grade
        static (string result, string subject, string answer, int subjectID) second_grade()
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
                    int num1 = random.Next(100, 1000);
                    int num2; int num3;
                    do
                    {
                        num2 = random.Next(100, 1000);
                        num3 = random.Next(100, 1000);
                    } while ((num1 == num2) && (num2 == num3));

                    numbers.AddRange(new double[] { num1, num2, num3 });
                    return random.Next(0, 2) == 0 ? MinReturn(numbers) : MaxReturn(numbers);
                case 2: // 네자리수 크기비교
                    int Num1 = random.Next(1000, 10000);
                    int Num2; int Num3; int Num4;
                    do
                    {
                        Num2 = random.Next(1000, 10000);
                        Num3 = random.Next(1000, 10000);
                        Num4 = random.Next(1000, 10000);
                    } while ((Num1 == Num2) && (Num2 == Num3) && (Num3 == Num4));

                    numbers.AddRange(new double[] { Num1, Num2, Num3, Num4 });
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
        static (string result, string subject, string answer, int subjectID) third_grade()
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
                    double number = random.Next(2, 10);
                    double num0 = random.Next(1, 10);
                    double num2;
                    do
                    {
                        num2 = random.Next(1, 10);
                    } while (num0 == num2);

                    numbers.AddRange(new double[] { num0, number, num2, number });
                    return random.Next(0, 2) == 0 ? FractionMin(numbers) : FractionMax(numbers);
                case 6: // 소수 두자리 수 크기 비교
                    double No0 = random.Next(1, 100);
                    double No1;
                    do
                    {
                        No1 = random.Next(1, 100);
                    } while (No0 == No1);

                    numbers.AddRange(new double[] { No0 / 100, No1 / 100 });
                    return random.Next(0, 2) == 0 ? MinReturn(numbers) : MaxReturn(numbers);
                default:
                    throw new NotImplementedException("Subject not implemented.");
            }
        }

        //fourth grade 
        static (string result, string subject, string answer, int subjectID) fourth_grade()
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
                    return random.Next(0, 2) == 0 ? DecimalPlusReturn(numbers, "F2") : DecimalMinusReturn(numbers, "F2");
                case 3: // (세자리수)*(두자리수) 곱셈/나눗셈
                    numbers.AddRange(new double[] { random.Next(100, 1000), random.Next(10, 100) });
                    return random.Next(0, 2) == 0 ? MulReturn(numbers) : DivmodReturn(numbers);
                case 4: // 소수 세자리수 크기 비교
                    double num0 = random.Next(100, 1000);
                    double num1;
                    do
                    {
                        num1 = random.Next(100, 1000);
                    } while (num0 == num1);
                    numbers.AddRange(new double[] { num0 / 1000, num1 / 1000 });
                    return random.Next(0, 2) == 0 ? MinReturn(numbers) : MaxReturn(numbers);
                default:
                    throw new NotImplementedException("Subject not implemented.");
            }
        }

        //fifth grade
        static (string result, string subject, string answer, int subjectID) fifth_grade()
        {
            List<double> numbers = new List<double>(); // List<double> 생성

            double subject = random.Next(1, 7);
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
                case 2: // 최대공약수
                    numbers.AddRange(new double[] { random.Next(6, 100), random.Next(6, 100) });
                    return GcdReturn(numbers);
                case 3: // 최소공배수
                    numbers.AddRange(new double[] { random.Next(5, 40), random.Next(5, 40) });
                    return LcmReturn(numbers);
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
                    return DecimalMulReturn(numbers, "F4");
                case 6: //평균
                    while (true)
                    {
                        numbers.Clear();
                        numbers.AddRange(new double[] { random.Next(1, 100), random.Next(1, 100), random.Next(1, 100) });
                        if (numbers.Sum() % 3 == 0) break;
                    }
                    return MeanReturn(numbers);
                default:
                    throw new NotImplementedException("Subject not implemented.");
            }
        }

        //sixth grade
        static (string result, string subject, string answer, int subjectID) sixth_grade()
        {
            List<double> numbers = new List<double>(); // List<double> 생성

            //double subject = random.Next(1, 5);
            double subject = 1;
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
                    return DecimalDivReturn(numbers, "F2");
                case 3: //  분모가 같은 (분수)%(분수)
                    int number = random.Next(2, 20);
                    numbers.AddRange(new double[] { random.Next(1, 20), number, random.Next(1, 20), number });
                    return FractionDiv(numbers);
                case 4: // (소수)%(소수) 소숫점 두자리 둘 다
                    double dub_num = (double)random.Next(1, 99) / 100;
                    numbers.AddRange(new double[] { dub_num * random.Next(2, 20), dub_num });
                    return DecimalDivReturn(numbers, "F1");
                default:
                    throw new NotImplementedException("Subject not implemented.");
            }
        }


        public static (string result, string subject, string answer, int subjectID) Generate()
        {

            if (Year == 1)
            {
                (string equation, string subject, string answer, int subjectID) = first_grade();
                Console.WriteLine($"Result: {equation}");
                Console.WriteLine($"Result: {subject}");
                Console.WriteLine($"Result: {answer}");

                return (equation, subject, answer, subjectID);
            }
            else if (Year == 2)
            {
                (string equation, string subject, string answer, int subjectID) = second_grade();
                Console.WriteLine($"Result: {equation}");
                Console.WriteLine($"Result: {subject}");
                Console.WriteLine($"Result: {answer}");

                return (equation, subject, answer, subjectID);
            }
            else if (Year == 3)
            {
                (string equation, string subject, string answer, int subjectID) = third_grade();
                Console.WriteLine($"Result: {equation}");
                Console.WriteLine($"Result: {subject}");
                Console.WriteLine($"Result: {answer}");

                return (equation, subject, answer, subjectID);
            }
            else if (Year == 4)
            {
                (string equation, string subject, string answer, int subjectID) = fourth_grade();
                Console.WriteLine($"Result: {equation}");
                Console.WriteLine($"Result: {subject}");
                Console.WriteLine($"Result: {answer}");

                return (equation, subject, answer, subjectID);
            }
            else if (Year == 5)
            {
                (string equation, string subject, string answer, int subjectID) = fifth_grade();
                Console.WriteLine($"Result: {equation}");
                Console.WriteLine($"Result: {subject}");
                Console.WriteLine($"Result: {answer}");

                return (equation, subject, answer, subjectID);
            }
            else 
            {
                (string equation, string subject, string answer, int subjectID) = sixth_grade();
                Console.WriteLine($"Result: {equation}");
                Console.WriteLine($"Result: {subject}");
                Console.WriteLine($"Result: {answer}");

                return (equation, subject, answer, subjectID);
            }
        }
    }
}   