using b301026;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buoi1
{
    internal class Program
    {
        static void Main(string[] arg)
        {

            //Console.Write("a=");
            //int a = Convert.ToInt32(Console.ReadLine());
            //Console.Write("b=");
            //int b = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("a+b=" + Convert.ToString(a + b));
            //Console.ReadKey();

            #region 23/10/26
            #region nhap n
            //int b = Convert.ToInt32(Console.ReadLine());
            //for (int i = 0; i < b; i++)
            //{ int a = Convert.ToInt32(Console.ReadLine()); }
            #endregion
            #region A[mxn]
            //int m = Convert.ToInt32(Console.ReadLine());
            //int n = Convert.ToInt32(Console.ReadLine());
            //int[,] a = new int[m,n];
            //int j = 0;
            //for(int i=0; i<m;i++)
            //{

            //    for ( j=0; j < n; j++) { a[i, j] = Convert.ToInt32(Console.ReadLine()); } 

            //}
            //for (int i = 0; i < m; i++)
            //{

            //    for (j = 0; j < n; j++) { Console.Write(a[i, j]+" "); }
            //    Console.WriteLine(" ");

            //}
            #endregion
            #endregion
            #region 27/10/2026
            #region nhập A[], tách làm 2 mảng>0,<=0
            //int n = Convert.ToInt32(Console.ReadLine());
            //int[] a = new int[n];
            //int[] b = new int[n];
            //int[] c = new int[n];
            //int x = 0, y = 0;
            //for (int i = 0; i < n; i++)
            //{
            //    a[i] = Convert.ToInt32(Console.ReadLine());
            //    if (a[i] > 0)
            //            { b[x] = a[i];x++; }
            //    else { c[y] = a[i]; y++; }
            //}
            //for(int i = 0;i < n; i++) {Console.Write(a[i]+" ");}
            //Console.WriteLine(" "); 
            //for(int i = 0; i < x; i++) {  Console.Write(b[i]+" ");}
            //Console.WriteLine(" ");
            //for (int i = 0; i < y; i++) { Console.Write(c[i] + " "); }
            #endregion
            #region nhập a[], sắp xếp tăng dần
            //int n = Convert.ToInt32(Console.ReadLine());
            //int[] a = new int[n];
            //for (int i = 0; i < n; i++)
            //{
            //    a[i] = Convert.ToInt32(Console.ReadLine());

            //}
            //for(int i = 0; i < n-1;i++)
            //{ 
            //    for (int j = i; j < n; j++)
            //    {
            //        if (a[i] > a[j]) 
            //        {
            //            int b = a[i];

            //            a[i] = a[j];

            //            a[j] = b;
            //        }
            //    } 
            //}
            //for (int i = 0; i < n; i++)
            //{
            //    Console.Write(a[i]+" ");

            //}
            #endregion
            #endregion
            #region 30/10/2026
            //character tom = new character("tom",100);
            //tom.health = 200;
            //Console.WriteLine("abc=" + tom.health);
            #endregion
            #region 3/11/2026
            List<SV> Dssv = new List<SV>();
            int Soluong = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < Soluong; i++)
            {
                Console.WriteLine("number: " + (i+1));
                SV sv = new SV();
                sv.Tinhdiemtb(sv);
                Dssv.Add(sv);
                Console.WriteLine(" ");
            }
            SV.Inds(Dssv);
            #endregion

        }

    }
}


