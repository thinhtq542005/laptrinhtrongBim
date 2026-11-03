using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buoi1
{
    public class SV
    {
        string hoten { get; set; }
        string quequan { get; set; }
        double toan { get; set; }
        double ly { get; set; }
        double hoa { get; set; }
        double dtb { get; set; }
        public SV(string Hoten,string Quequan,double Toan,double Ly,double Hoa)
        {
            hoten = Hoten;
            quequan = Quequan;
            toan = Toan;
            ly = Ly;
            hoa= Hoa;

        }
        public void Tinhdiemtb(SV sv)
        {
            dtb = (toan+ly+hoa)/3;
        }
        public void Inds(SV sv)
        {
            Console.WriteLine($"Ho ten:{sv.hoten} | Que quan :{sv.quequan}| Toan: {sv.toan} Ly: {sv.ly}| Hoa: {sv.hoa}| dtb:{sv.dtb}");
        }
        public static void Inds(List<SV> dssv)
        {
            foreach(SV sv in dssv)
            {
                sv.Inds(sv);
            }
        }
        public SV()
        {
            Console.Write("hoten:");
            hoten = Console.ReadLine();
            Console.Write("quequan:");
            quequan = Console.ReadLine();
            Console.Write("toan:");
            toan = Convert.ToDouble(Console.ReadLine());
            Console.Write("ly:");
            ly = Convert.ToDouble(Console.ReadLine());
            Console.Write("hoa:");
            hoa = Convert.ToDouble(Console.ReadLine());

        }

    }
}
