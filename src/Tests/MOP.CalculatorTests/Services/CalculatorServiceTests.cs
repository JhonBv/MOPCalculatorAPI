using Microsoft.VisualStudio.TestTools.UnitTesting;
using MOP.CalculatorTests;
using Moq;
using NUnit.Framework;
using System;
using Assert = NUnit.Framework.Assert;

namespace MOP.Calculator.API.Services.Tests
{
   [TestFixture]
    public class CalculatorServiceTests:BaseTestClass
    {
        private IPluginLoaderService _pluginLoader;
        private ICalculatorService _calc;
        private readonly Uri uri = new Uri(@"Plugins\CSharpCalculatorPlugin\bin\Debug\net5.0\CSharpCalculatorPlugin.dll");
        public CalculatorServiceTests(IPluginLoaderService pluginLoader, ICalculatorService calc)
        {
            _pluginLoader = pluginLoader;
            _calc = calc;
        }

        [Test]
        public void CalculatorServiceTest()
        {
            var services = new TestConfiguration().returnServiceCollection();
            var pluginpath = _pluginLoader.LoadPlugin(uri.LocalPath);
            Assert.That(pluginpath, Is.Not.Null.Or.Empty,"Assembly path must not be empty");
        }

        [Test]
        public void ExecuteCalculatorTest()
        {
            var calculator = _calc.ExecuteCalculator(uri.LocalPath, new Models.CalculatorInputModel() { Operation = 1, FirstNumber = 5, SecondNumber = 5 });
            Assert.AreEqual(calculator, 10);
        }
    }
}