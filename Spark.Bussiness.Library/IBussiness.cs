using System.Collections.Generic;

namespace Spark.Bussiness.Library
{
    public interface IBussiness
    {
        string AmountInWords(float amount);
        bool VatCheck();
        bool UeVatCheck();
        


    }

}