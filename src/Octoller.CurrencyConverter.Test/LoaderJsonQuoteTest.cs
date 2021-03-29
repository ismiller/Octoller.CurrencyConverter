
using System;
using System.Text.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Octoller.CurrencyConverter.App.Services;

namespace Octoller.CurrencyConverter.Test
{
    [TestClass]
    public class LoaderJsonQuoteTest
    {
        [TestMethod]
        public void CorrectnessLoadingWithDefaultParameters()
        {
            LoaderJsonQuote loader = new LoaderJsonQuote();

            JsonDocument jsonResult = loader.Load();

            Assert.IsNotNull(jsonResult);

        }
    }
}
