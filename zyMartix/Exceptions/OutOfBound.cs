using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zyMartix.Exceptions
{
    class OutOfBoundException:Exception
    {
        /// <summary>
        /// 矩阵访问越界
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="M"></param>
        /// <param name="n"></param>
        public OutOfBoundException(int x,int y,int M,int n) : base("矩阵访问越界") { }
    }
}
