using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MECS.Chapter5.Item44
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input Number: ");
            int num=0;
            int.TryParse(Console.ReadLine(),out num);
            Console.Write("Input '>'or '<' : ");
            char t = (Console.ReadLine())[0];
            ExpressionType than = (t == '>') ? ExpressionType.GreaterThan : ExpressionType.LessThan;
            Console.Write("Input {0} then : ",t);
            int r = 0;
            int.TryParse(Console.ReadLine(), out r);
            Console.Write("Input var % 2 == ");
            int p = 0;
            int.TryParse(Console.ReadLine(), out p);

            Console.WriteLine(num.Tester(p,r,than));

            Console.ReadKey();
        }

        /// <summary>
        /// Test int by parametrs
        /// </summary>
        /// <param name="number">INput number</param>
        /// <param name="par1">var % par3 == ?</param>
        /// <param name="par2">var > ?</param>
        /// <param name="par3">var % ?</param>
        /// <returns>bool</returns>
        static bool Tester(this int number,int par1,int par2,ExpressionType type= ExpressionType.GreaterThan, int par3=2)
        {
            
            ParameterExpression parm = Expression.Parameter(
            typeof(int), "val");
            
            ConstantExpression threeHundred = Expression.Constant(par2,
            typeof(int));
            ConstantExpression one = Expression.Constant(par1, typeof(int));
            ConstantExpression two = Expression.Constant(par3, typeof(int));
            
            BinaryExpression largeNumbers =
            Expression.MakeBinary(type,
            parm, threeHundred);
            
            BinaryExpression modulo = Expression.MakeBinary(
            ExpressionType.Modulo,
            parm, two);
            
            BinaryExpression isOdd = Expression.MakeBinary(
            ExpressionType.Equal,
            modulo, one);
            
            BinaryExpression lambdaBody =
            Expression.MakeBinary(ExpressionType.AndAlso,
            isOdd, largeNumbers);
            
            LambdaExpression lambda = Expression.Lambda(lambdaBody, parm);
            
            Func<int, bool> compiled = lambda.Compile() as
            Func<int, bool>;

            return compiled(number);
        }

        
    }
}
