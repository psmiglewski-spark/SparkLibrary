using System;
using System.Collections.Generic;
using System.Text;
using Spark.Bussiness.Library;
using Xunit;


namespace Spark.Tests
{
    public class FeatureTests
    {
        [Fact]
        public void AmountInWordsTest()
        {
            var kwotaTest = new PolishBussiness();
            var slownie = kwotaTest.AmountInWords(20.50f);

            Assert.NotEmpty(slownie);
            Assert.Equal("dwadzieściazłotych, pięćdziesiątgroszy", slownie);
        }

        [Fact]
        public void WlClientByNipTest()
        {
            var klient = new PolishBussiness();
            var clientData = klient.GetClientDataFromWhiteList("6972171117","2020-07-02");

            Assert.NotEmpty(clientData.Name);
            Assert.Equal("PIOTR ŚMIGLEWSKI", clientData.Name);
        }

        [Fact]
        public void WlAccountCjeckTest()
        {
            var klient = new PolishBussiness();
            var clientData = klient.WhiteListCheck("6972171117", "67187010452078106494350001");

            Assert.NotEmpty(clientData.AccountAssigned);
            Assert.Equal("TAK", clientData.AccountAssigned);
        }
    }
}
