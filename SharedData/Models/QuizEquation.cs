using System;
using System.Collections.Generic;
using System.Linq;

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
        //public static (string result, string subject) PlusReturn(List<string> numbers)
        //{
        //	string result = string.Join(" + ", numbers);
        //	string subject = "The mathematics topic is arithmetic equation";
        //	return (result, subject);
        //}

        public static (string result, string subject, string answer) MinusReturn(List<double> numbers)
        {
            numbers.Sort((a, b) => b.CompareTo(a)); // 내림차순 정렬

            double ans = numbers[0] - numbers[1];
            string result = string.Join(" - ", numbers);
            string subject = "The mathematics topic is arithmetic equation";
            string answer = ans.ToString();
            return (result, subject, answer);
        }
        //public static (string result, string subject) MinusReturn(List<string> numbers)
        //{
        //	numbers.Sort((a, b) => b.CompareTo(a)); // 내림차순 정렬
        //	string result = string.Join(" - ", numbers);
        //	string subject = "The mathematics topic is arithmetic equation";
        //	return (result, subject);
        //}
        public static (string result, string subject, string answer) MulReturn(List<double> numbers)
        {
            numbers.Sort((a, b) => b.CompareTo(a)); // 내림차순 정렬
            double ans = numbers[0] * numbers[1];
            string result = string.Join(" * ", numbers);
            string subject = "The mathematics topic is arithmetic equation";
            string answer = ans.ToString();
            return (result, subject, answer);
        }

        //작동X
        public static (string result, string subject) DivmodReturn(List<double> numbers)
        {
            numbers.Sort((a, b) => b.CompareTo(a)); // 내림차순 정렬
            string subject = "The mathematics topic is arithmetic equation";
            string result = $"divmod({numbers[0]}, {numbers[1]})";
            return (result, subject);
        }
        
        //작동X
        public static (string result, string subject) DivReturn(List<double> numbers)
        {
            string subject = "The mathematics topic is arithmetic equation";
            numbers.Sort((a, b) => b.CompareTo(a)); // 내림차순 정렬
            string result = string.Join(" / ", numbers);
            return (result, subject);
        }

        public static (string result, string subject) GenerateExpression(List<double> numbers)
        {
            string subject = "The mathematics topic is arithmetic equation";
            numbers.Sort((a, b) => b.CompareTo(a)); // 내림차순 정렬
            Random random = new Random();
            string result = random.Next(2) == 0 ?
               $"{numbers[0]} * {numbers[1]} - {numbers[2]}" :
               $"{numbers[0]} * {numbers[1]} + {numbers[2]}";
            return (result, subject);
        }

        //number comparison
        public static (string result, string subject, string answer) MinReturn(List<double> numbers)
        {
            string subject = "The mathematics topic is number comparison";
            string result = "min(" + string.Join(", ", numbers) + ")";
            double doubleAnswer = numbers.Min();
            string answer = doubleAnswer.ToString();
            return (result, subject, answer);
        }

        //number comparison
        public static (string result, string subject, string answer) MaxReturn(List<double> numbers)
        {
            string subject = "The mathematics topic is number comparison";
            string result = "max(" + string.Join(", ", numbers) + ")";
            double doubleAnswer = numbers.Max();
            string answer = doubleAnswer.ToString();
            return (result, subject, answer);
        }
        //divisors and multiples
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
        //divisors and multiples
        public static (string result, string subject) GcdReturn(List<double> numbers)
        {
            string subject = "The mathematics topic is divisors and multiples";
            string result = "gcd(" + string.Join(", ", numbers) + ")";
            return (result, subject);
        }
        //average
        public static (string result, string subject, string answer) MeanReturn(List<double> numbers)
        {
            double ans = numbers.Sum() / 3;
            string result = "statistics.mean(" + string.Join(", ", numbers) + ")";
            string subject = "The mathematics topic is average";
            string answer = ans.ToString();
            return (result, subject, answer);
        }
        static (string result, string subject, string answer) first_grade()
        {
            List<double> numbers = new List<double>(); // List<double> 생성
            double subject = random.Next(1, 4);
            /*
			 * 1. 한자리 수의 덧셈 뺄셈 => 사칙The mathematics topic is arithmetic equation
			 * 2. 계산 결과가 두자리수인 세수의 덧셈/뺄셈 => 사칙The mathematics topic is arithmetic equation
			 * 3. 십의 자리 수의 크기 비교 => 크기비교
			 */
            switch (subject)
            {
                case 1: // 한자리수 덧셈 뺄셈
                    numbers.AddRange(new double[] { random.Next(1, 10), random.Next(1, 10) }); // 배열을 List에 추가
                    numbers.Sort((a, b) => b.CompareTo(a)); //내림차순
                    return random.Next(0, 2) == 0 ? PlusReturn(numbers) : MinusReturn(numbers);

                case 2: // 한자리수 덧셈 3개
                    numbers.AddRange(new double[] { random.Next(1, 10), random.Next(1, 10), random.Next(1, 10) }); // 배열을 List에 추가
                    numbers.Sort((a, b) => b.CompareTo(a)); //내림차순
                    return PlusReturn(numbers);
                case 3: // 두자리수 크기 비교
                    numbers.AddRange(new double[] { random.Next(1, 100), random.Next(1, 100) }); // 배열을 List에 추가
                    return random.Next(0, 2) == 0 ? MinReturn(numbers) : MaxReturn(numbers);
                default:
                    throw new NotImplementedException("Subject not implemented.");
            }
        }
        //static (string result, string subject) second_grade()
        //{
        //	List<double> numbers = new List<double>(); // List<double> 생성

        //	double subject = random.Next(1, 5);
        //	/*
        //	 * 1. 세자리수 크기비교
        //	 * 2. 네자리수 크기비교
        //	 * 3. 한자리수 곱셈
        //	 * 4. 두자리수 덧셈
        //	 */
        //	switch (subject)
        //	{
        //		case 1: // 세자리수 크기비교
        //			numbers.AddRange(new double[] { random.Next(100, 1000), random.Next(100, 1000), random.Next(100, 1000) }); // 배열을 List에 추가
        //			return random.Next(0, 2) == 0 ? MinReturn(numbers) : MaxReturn(numbers);
        //		case 2: // 네자리수 크기비교
        //			numbers.AddRange(new double[] { random.Next(1000, 10000), random.Next(1000, 10000), random.Next(1000, 10000), random.Next(1000, 10000) }); // 배열을 List에 추가
        //			return random.Next(0, 2) == 0 ? MinReturn(numbers) : MaxReturn(numbers);
        //		case 3: // 한자리수 곱셈
        //			numbers.AddRange(new double[] { random.Next(1, 10), random.Next(1, 10) }); // 배열을 List에 추가
        //			return MulReturn(numbers);
        //		case 4: // 두자리수 덧셈
        //			numbers.AddRange(new double[] { random.Next(1, 100), random.Next(1, 100) }); // 배열을 List에 추가
        //			return PlusReturn(numbers);
        //		default:
        //			throw new NotImplementedException("Subject not implemented.");
        //	}
        //}
        //static (string result, string subject) third_grade()
        //{
        //	List<double> numbers = new List<double>(); // List<double> 생성

        //	double subject = random.Next(1, 7);
        //	/*
        //	 * 1.세자리 수 덧셈/뺄셈
        //	 * 2. (두자리 수)%(한자리 수) 나눗셈
        //	 * 3. (세자리 수)*(한자리 수) 곱셈
        //	 * 4. (두자리 수)*(두자리 수) 곱셈
        //	 * 5. 분모가 같은 분수 크기 비교
        //	 * 6. 소수 두자리 수 크기 비교
        //	*/
        //	switch (subject)
        //	{
        //		case 1: // 세자리 수 덧셈/뺄셈
        //			numbers.AddRange(new double[] { random.Next(100, 1000), random.Next(100, 1000) }); // 배열을 List에 추가
        //			return random.Next(0, 2) == 0 ? PlusReturn(numbers) : MinusReturn(numbers);
        //		case 2: // (두자리 수)%(한자리 수) 나눗셈
        //			numbers.AddRange(new double[] { random.Next(10, 99), random.Next(2, 9) }); // 배열을 List에 추가
        //			return DivmodReturn(numbers);
        //		case 3: // (세자리 수)*(한자리 수) 곱셈
        //			numbers.AddRange(new double[] { random.Next(100, 1000), random.Next(2, 10) }); // 배열을 List에 추가
        //			return MulReturn(numbers);
        //		case 4: // (두자리 수)*(두자리 수) 곱셈
        //			numbers.AddRange(new double[] { random.Next(10, 100), random.Next(10, 100) }); // 배열을 List에 추가
        //			return MulReturn(numbers);
        //		case 5: // 분모가 같은 분수 크기 비교
        //			string subject1 = "The mathematics topic is number comparison";
        //			int number = random.Next(2, 10);
        //			string number1 = "fraction(" + random.Next(2, 10).ToString() + "," + number.ToString() + ")";
        //			string number2 = "fraction(" + random.Next(2, 10).ToString() + "," + number.ToString() + ")";
        //			string result = "min(" + number1 + ", " + number2 + ")";
        //			return (result, subject1);

        //		case 6: // 소수 두자리 수 크기 비교
        //			numbers.AddRange(new double[] { (double)random.Next(1, 100) / 100, (double)random.Next(1, 100) / 100 }); // 배열을 List에 추가
        //			return random.Next(0, 2) == 0 ? MinReturn(numbers) : MaxReturn(numbers);
        //		default:
        //			throw new NotImplementedException("Subject not implemented.");
        //	}
        //}
        //static (string result, string subject, string answer) forth_grade()
        //{
        //	List<double> numbers = new List<double>(); // List<double> 생성
        //	List<string> numbers_string = new List<string>();

        //	double subject = random.Next(1, 5);
        //	/*
        //	 * 1. 분모가 같은 분수 덧셈 뺄셈 (분모가 한자리수)
        //	 * 2. 소수 두자리수 덧셈과 뺄셈
        //	 * 3. (세자리수)*(두자리수) 곱셈/나눗셈
        //	 * 4. 소수 세자리수 크기 비교
        //	*/
        //	switch (subject)
        //	{
        //		case 1: // 분모가 같은 분수 덧셈 뺄셈 (분모가 한자리수)
        //			int number_case1 = random.Next(2, 10);
        //			string number1 = "fraction(" + random.Next(2, 10).ToString() + "," + number_case1.ToString() + ")";
        //			string number2 = "fraction(" + random.Next(2, 10).ToString() + "," + number_case1.ToString() + ")";
        //			numbers_string.AddRange(new string[] { number1, number2 });
        //			return random.Next(0, 2) == 0 ? PlusReturn(numbers_string) : MinusReturn(numbers_string);
        //		case 2: // 소수 두자리수 덧셈과 뺄셈
        //			numbers.AddRange(new double[] { (double)random.Next(1, 99) / 100, (double)random.Next(1, 99) / 100 }); // 배열을 List에 추가
        //			return random.Next(0, 2) == 0 ? PlusReturn(numbers) : MinusReturn(numbers);
        //		case 3: // (세자리수)*(두자리수) 곱셈/나눗셈
        //			numbers.AddRange(new double[] { random.Next(100, 1000), random.Next(10, 100) }); // 배열을 List에 추가
        //			return random.Next(0, 2) == 0 ? MulReturn(numbers) : DivReturn(numbers);
        //		case 4: // 소수 세자리수 크기 비교
        //			numbers.AddRange(new double[] { (double)random.Next(100, 1000) / 1000, (double)random.Next(100, 1000) / 1000 }); // 배열을 List에 추가
        //			return random.Next(0, 2) == 0 ? MinReturn(numbers) : MaxReturn(numbers);
        //		default:
        //			throw new NotImplementedException("Subject not implemented.");
        //	}
        //}

        public static Tuple<string, string, string> Generate()
        {
            var (equation, subject, answer) = first_grade();
            Console.WriteLine($"Result: {equation}");
            Console.WriteLine($"Result: {subject}");

            return Tuple.Create(equation, subject, answer);
        }
    }
}   