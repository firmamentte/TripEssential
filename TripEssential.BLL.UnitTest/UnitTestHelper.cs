using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripEssential.BLL.UnitTest
{
    public class UnitTestHelper
    {
        public static string ConnectionString
        {
            get
            {
                return "Server=.\\SQLEXPRESS;Database=TripEssential;Integrated Security=True;MultipleActiveResultSets=True";
            }
        }
    }
}
