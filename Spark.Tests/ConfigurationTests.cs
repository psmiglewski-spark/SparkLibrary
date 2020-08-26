using System;
using System.IO;
using Spark.Setup;
using Xunit;


namespace Spark.Tests
{
    public class ConfigurationTests
    {
        [Fact]
        public void SetupTest()
        {
            ConfigFile file = new ConfigFile(Directory.GetCurrentDirectory() + "\\config.ini");
            file.SetProperties();
           
            Assert.Equal("1",file.GetConnectionString());
          
        }
       
     
        
    }
}
