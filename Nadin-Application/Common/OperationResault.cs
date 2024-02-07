using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadin_Application.Common
{
    public class OperationResault<T>
    {
        public T PayLoad { get; set; }
        public bool IsError { get; set; }
        public List<Error> Errors { get; set; } = new List<Error>();
        
      

   
    }
}
