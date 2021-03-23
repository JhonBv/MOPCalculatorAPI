using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOP.CalculatorTests
{
    public class BaseTestClass
    {
        public TestConfiguration config;
        [SetUp]
        public void Setup()
        {
            config = new TestConfiguration();
        }
    }
}
