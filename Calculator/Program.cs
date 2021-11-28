using System;
using System.Collections.Generic;

namespace Calculator
{
    public class Calculator
    {
        public virtual double Calculate(List<Operation> operations, List<double> numbers)
        {
            if (!CheckCorectlyInput(operations, numbers))
                throw new Exception("Количество операций не равно количеству чисел");
            
            double result = default;
            for (int i = 0; i < operations.Count; i++)
            {
                var operation = operations[i];
                result = operation.Calculate(numbers[i], numbers[i + 1]);
                numbers[i + 1] = result;
            }

            return result;
        }

        bool CheckCorectlyInput(List<Operation> operations, List<double> numbers) => operations.Count == numbers.Count - 1;
    }

    public abstract class Operation
    {
        public abstract double Calculate(double x, double y);
    }

    public class Plus : Operation
    {
        public override double Calculate(double x, double y) => x + y;
    }

    public class Minus : Operation
    {
        public override double Calculate(double x, double y) => x - y;
    }
    public class Multiplication : Operation
    {
        public override double Calculate(double x, double y) => x * y;
    }
    public class Division : Operation
    {
        public override double Calculate(double x, double y) => x / y;
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            List<Operation> operations = new List<Operation>{new Plus(), new Plus(), new Division()};
            List<double> numbers = new List<double>() {1, 3, 2, 3};
            Console.WriteLine(new Calculator().Calculate(operations,numbers));
        }
    }
}