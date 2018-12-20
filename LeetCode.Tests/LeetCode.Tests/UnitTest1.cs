using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LeetCode.Tests
{
    
    public class UnitTest1
    {
        [Test]
        [TestCase("I",      1,      TestName = "I")]
        [TestCase("III",    3,      TestName = "III")]
        [TestCase("IV",     4,      TestName = "IV")]
        [TestCase("V",      5,      TestName = "V")]
        [TestCase("VI",     6,      TestName = "VI")]
        [TestCase("IX",     9,      TestName = "IX")]
        [TestCase("X",      10,     TestName = "X")]
        [TestCase("XI",     11,     TestName = "XI")]        

        [TestCase("III", 3, TestName = "Test 1")]
        [TestCase("IV",  4, TestName = "Test 2")]
        [TestCase("V",   5, TestName = "Test 3")]
        [TestCase("VI",  6, TestName = "Test 4")]
        [TestCase("IX",  9, TestName = "Test 5")]
        [TestCase("X",  10, TestName = "Test 6")]
        [TestCase("XI", 11, TestName = "Test 7")]
        [TestCase("XXI", 21, TestName = "Test 8")]
        [TestCase("XIX", 19, TestName = "Test 9")]
        [TestCase("M", 1000, TestName = "Test 10")]
        [TestCase("D", 500, TestName = "Test 11")]
        [TestCase("C", 100, TestName = "Test 12")]
        [TestCase("L", 50, TestName = "Test 13")]
        [TestCase("I", 1, TestName = "Test 14")]
        [TestCase("MDCLXVI", 1666, TestName = "MDCLXVI")]
        public void Problem(string roman, int target)
        {
            RomanInterpreter interpreter = new RomanInterpreter();
            Assert.AreEqual(interpreter.Interpret(roman), target);
        }

        public class RomanInterpreter
        {
            public int Interpret(string roman)
            {
                Context ctx = new Context(roman);
                List<Expression> tree = new List<Expression> { new ThousandExpression(), new HundredExpression(), new TenExpression(), new OneExpression() };
                foreach (Expression expression in tree)
                {
                    expression.Interpret(ctx);
                }
                return ctx.Output;
            }

            class Context
            {
                public Context(string input)
                {
                    Input = input;
                }

                public string Input;
                public int Output;
            }

            abstract class Expression
            {

                public void Interpret(Context ctx)
                {
                    if (ctx.Input.Length == 0) { return; }

                    if (ctx.Input.StartsWith(Nine()))
                    {
                        ctx.Output += (9 * Multiplier()); 
                        ctx.Input = ctx.Input.Substring(2); // move the cursor to skip 'IX'
                    } 
                    else if (ctx.Input.StartsWith(Four()))
                    {
                        ctx.Output += (4 * Multiplier());
                        ctx.Input = ctx.Input.Substring(2); // move the cursor to skip 'IV'
                    }
                    else if (ctx.Input.StartsWith(Five()))
                    {
                        ctx.Output += (5 * Multiplier());
                        ctx.Input = ctx.Input.Substring(1); // move cursor to to skip 'V'
                    }

                    // consume the rest of the 'I's
                    while (ctx.Input.StartsWith(One()))
                    {
                        ctx.Output += (1 * Multiplier());
                        ctx.Input = ctx.Input.Substring(1); // move cursor to skip 'I'
                    }                  
                    
                    
                }


                public abstract string One();
                public abstract string Four();
                public abstract string Five();
                public abstract string Nine();
                public abstract int Multiplier();
            }

            class OneExpression : Expression
            {
                public override string One() { return "I"; }
                public override string Four() { return "IV"; }
                public override string Five() { return "V"; }
                public override string Nine() { return "IX"; }
                public override int Multiplier() { return 1; }
            }
            class TenExpression : Expression
            {
                public override string One() { return "X"; }
                public override string Four() { return "XL"; }
                public override string Five() { return "L"; }
                public override string Nine() { return "XC"; }
                public override int Multiplier() { return 10; }
            }

            class HundredExpression : Expression
            {
                public override string One() { return "C"; }
                public override string Four() { return "CD"; }
                public override string Five() { return "D"; }
                public override string Nine() { return "CM"; }
                public override int Multiplier() { return 100; }
            }
            class ThousandExpression : Expression
            {
                public override string One() { return "M"; }
                public override string Four() { return " "; }
                public override string Five() { return " "; }
                public override string Nine() { return " "; }
                public override int Multiplier() { return 1000; }
            }
        }

        

    }
}