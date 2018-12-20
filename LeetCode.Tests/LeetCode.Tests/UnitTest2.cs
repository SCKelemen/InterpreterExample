using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LeetCode.Tests
{
    
    public class UnitTest2
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
            RomanParser parser = new RomanParser();
            Assert.AreEqual(parser.Parse(roman), target);
        }

        
        public class RomanParser
        {
            public RomanParser()
            {

            }
            
            public int Parse(string roman)
            {
                char[] arr = roman.ToCharArray();
                int index = 0;
                while(index < arr.Length)
                {

                }

                return 0;
            }
        }
        
        

        

    }
}