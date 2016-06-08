using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScreeningSample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreeningSample.Tests
{
    [TestClass()]
    public class ScreeningRefactoringTests
    {
        [TestMethod()]
        public void AMethodTest()
        {
            ScreeningRefactoring rbc = new ScreeningRefactoring();
            // case	1: !first && second && third								OptionOne
            Assert.AreEqual(1, rbc.AMethod(false, true, true), "!first && second && third must be 1");

            // case 2: !first && second && !third && !second --- invalid		OptionTwo

            // case 3: !first && second && !third && second						OptionOne
            Assert.AreEqual(1, rbc.AMethod(false, true, false), " !first && second && !third && second must be 1");

            // case 4: !first && !second										OptionOne
            Assert.AreEqual(1, rbc.AMethod(false, false, true), "!first && !second must be 1");
            Assert.AreEqual(1, rbc.AMethod(false, false, false), "!first && !second must be 1");


            // case 5: first && !third && !second								OptionTwo
            Assert.AreEqual(2, rbc.AMethod(true, false, false), "first && !third && !second must be 2");

            // case 6: first && third && !second								OptionTwo
            Assert.AreEqual(2, rbc.AMethod(true, false, true), "first && third && !second must be 2");

            // case 7: true true false			OptionTwo
            Assert.AreEqual(2, rbc.AMethod(true, true, false), "case 7 must be 2");
            // case 8: true true true			OptionOne
            Assert.AreEqual(1, rbc.AMethod(true, true, true), "case 8");
        }
    }
}