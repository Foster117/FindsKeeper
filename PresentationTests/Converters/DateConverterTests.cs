using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Presentation.Converters.Tests
{
    [TestClass()]
    public class DateConverterTests
    {
        [TestMethod()]
        public void Convert_CorrectDate_ExpectedResult()
        {
            DateTime date = new DateTime(2020, 12, 5, 20, 10, 50, 300);
            string expected = "05.12.2020";
            object result;
            DateConverter converter = new DateConverter();
            result = converter.Convert(date);

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        [DataRow("NotDateTime")]
        [DataRow(null)]
        public void Convert_IncorrectDate_ExpectedDoNothing(object argument)
        {
            object result = Binding.DoNothing;
            DateConverter converter = new DateConverter();
            result = converter.Convert(argument);

            Assert.AreEqual(Binding.DoNothing, result);
        }
    }
}