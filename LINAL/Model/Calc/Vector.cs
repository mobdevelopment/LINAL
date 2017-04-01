using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINAL.Model.Calc
{
    public class Vector
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }

        /* Vector constructor for 2d object */
        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        /* Vector constructor for 3d object */
        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        /* 2d Vector information */
        public string get2dInfo()
        {
            return "" + this.x + ", " + this.y + "";
        }
        /* 3d Vector information */
        public string get3dInfo()
        {
            return "" + this.x + ", " + this.y + ", " + this.z + "";
        }

        public double get2dLength()
        {
            return Math.Sqrt(Math.Pow(this.x, 2) + Math.Pow(this.y, 2));
        }

        public double get3dLength()
        {
            return Math.Sqrt(Math.Pow(this.x, 2) + Math.Pow(this.y, 2) + Math.Pow(this.z, 2));
        }
    }
}
