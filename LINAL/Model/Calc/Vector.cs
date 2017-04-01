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
            this.z = 0;
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
        /* get the length of the vector */
        public double getLength()
        {
            return Math.Sqrt(Math.Pow(this.x, 2) + Math.Pow(this.y, 2) + Math.Pow(this.z, 2));
        }
        /* enlarge or shrink vector by inputted value */
        public static Vector operator *(Vector v, double factor)
        {
            return new Vector(v.x * factor, v.y * factor, v.z * factor);
        }
        /* add two vectors with eachother */
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }
        /* subtract vector1 from vector2 */
        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

    }
}
