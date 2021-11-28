using System;
using System.Collections.Generic;

namespace Calculator
{
    public class Calculator
    {
        public virtual double Calculate(List<Operation> operations, List<double> numbers)
        {
            if (CheckCorectlyInput(operations, numbers))
                throw new Exception("Количество чисел неверно");
            
            double result = numbers[0];
            for (int i = 0; i < operations.Count; i++)
            {
                var operation = operations[i];
                result = operation.Calculate(result, numbers[i + 1]);
            }

            return result;
        }

        bool CheckCorectlyInput(List<Operation> operations, List<double> numbers) => operations.Count != numbers.Count - 1;
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
            List<Operation> operations = new List<Operation>{new Plus(), new Plus(), new Multiplication()};
            List<double> numbers = new List<double>() {1, 3, 2, 5};
            Console.WriteLine(new Calculator().Calculate(operations,numbers));
        }
    }
}