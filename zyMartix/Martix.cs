using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zyMartix
{
    class DoubleMartix
    {
        double[,] data;
        public int M { get; private set; }

        public int N { get; private set; }


        /// <summary>
        /// 矩阵有M行N列
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        public DoubleMartix(int m,int n)
        {
            data = new double[m, n];
            M = m;
            N = n;
        }
        public void Set(int x,int y,double val)
        {
            if (x >= M || y >= N || x < 0 || y < 0) throw new Exceptions.OutOfBoundException(x, y, M, N);
            data[x, y] = val;
        }
        public double[,] Data 
        { 
            get
            {
                return data;
            }
            
        }

        /// <summary>
        /// 重载加号
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static DoubleMartix operator+ (DoubleMartix m1,DoubleMartix m2)
        {
            if (m1.M != m2.M || m1.N != m2.N) throw new Exception();
            DoubleMartix result = new DoubleMartix(m1.M, m1.N);
            for (int i = 0 ; i < m1.M;i++)
            {
                for (int j = 0 ; j < m1.N;j++)
                {
                    result.Data[i, j] = m1.Data[i, j] + m2.Data[i, j];
                }
            }
            return result;
        }

        /// <summary>
        /// 重置减号
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static DoubleMartix operator -(DoubleMartix m1, DoubleMartix m2)
        {
            if (m1.M != m2.M || m1.N != m2.N) throw new Exception();
            DoubleMartix result = new DoubleMartix(m1.M, m1.N);
            for (int i = 0; i < m1.M; i++)
            {
                for (int j = 0; j < m1.N; j++)
                {
                    result.Data[i, j] = m1.Data[i, j] - m2.Data[i, j];
                }
            }
            return result;
        }
        /// <summary>
        /// 重载乘号
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static DoubleMartix operator *(DoubleMartix m1, DoubleMartix m2)
        {
            if (m1.N != m2.M) throw new Exception();
            DoubleMartix result = new DoubleMartix(m1.M, m2.N);
            for (int i = 0 ; i < m1.M;i++)
            {
                for (int j = 0 ; j < m2.N;i++)
                {
                    double s = 0;
                    for (int k = 0 ; k < m1.N;i++)
                    {
                        s += m1.Data[i, k] * m2.Data[k, j];
                    }
                    result.Data[i, j] = s;
                }
            }
            return result;
        }
        
        /// <summary>
        /// 获取删掉m行，n列后的余子式
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public DoubleMartix GetCofactor(int m,int n)
        {
            DoubleMartix result = new DoubleMartix(this.M-1, this.N - 1);
            for (int i = 0 ; i < M;i++)
            {
                for (int j = 0 ; j < N ; j++)
                {
                    if (i == m || j == n) continue;
                    int x = i > m ? i - 1 : i;
                    int y = j > n ? j - 1 : j;
                    result.Data[x, y] = data[i, j];
                }
            }
            return result;
        }

        /// <summary>
        /// 获取行列式的值
        /// </summary>
        /// <returns></returns>
        public double GetDet()
        {
            if (this.M != this.N) throw new Exception();
            if (this.M == 1) return data[0, 0];
            double result = 0;
            for (int i = 0 ; i < M ; i++)
            {
                result += data[i, 0] * Math.Pow(-1, i) * GetCofactor(i, 0).GetDet();
            }
            return result;
        }
    }
}
