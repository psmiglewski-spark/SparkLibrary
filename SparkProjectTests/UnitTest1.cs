using System;
using System.IO;
using Spark.Invoice.Data.Services;
using Xunit;
using Spark.Setup;

namespace SparkProjectTests
{
    public class UnitTest1
    {
       
            [Fact]
            public void DBCompanyGetAllCheck()
            {
                var setup = new ConfigFile(Directory.GetCurrentDirectory() + "\\config.ini");
                var data = new DbCompanyData(setup.GetConnectionString());
              //  Assert.NotEmpty(data.GetAll());
              Assert.Equal(@"Server=ACERLAP1TOP\SPARKDBENGINE;Database=InvoiceManager;User Id=sa;Password=PIotreck1;", setup.GetConnectionString());
            }
        
    }
}
