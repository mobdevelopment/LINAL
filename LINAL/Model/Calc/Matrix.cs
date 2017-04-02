using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINAL.Model.Calc
{
    public class Matrix
    {
        private double[,] matrixContent;
        /* Matrix constructor */
        public Matrix(double[,] s)
        {
            matrixContent = s;
        }
        /* Matrixes  */
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            double[,] result = new double[m2.matrixContent.GetLength(0), m2.matrixContent.GetLength(1)];

            for (int x = 0; x < m2.matrixContent.GetLength(0); x++)
            {
                for (int y = 0; y < m2.matrixContent.GetLength(1); y++)
                {
                    double tempRes = 0;

                    for (int z = 0; z < m1.matrixContent.GetLength(1); z++)
                    {
                        tempRes += m1.matrixContent[x, z] * m2.matrixContent[z, y];
                    }
                    result[x, y] = tempRes;
                }
            }
            return new Matrix(result);
        }

        public double[,] getMatrix()
        {
            return matrixContent;
        }
        /*
        TODO:
        - Matrix Scalar
        - Matrix Translate
        - Rotate
        ... 
        */

        /* translates degrees to radians */
        public static double degreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }
        /*
        |  1  0  0  dx || x |   | x + dx |
        |  0  1  0  dy || y |   | y + dy |
        |  0  0  1  dz || z | = | z + dz |
        |  0  0  0   1 || 1 |   | 1      |
         */
        public static Matrix translateMatrix(double x, double y, double z)
        {
            // standard matrix translation
            return new Matrix(
                new double[4, 4] {
                    { 1, 0, 0, x },
                    { 0, 1, 0, y },
                    { 0, 0, 1, z },
                    { 0, 0, 0, 1 }
            });
        }

        public static Matrix rotateMatrix(Vector v, double degrees)
        {
            // convert degrees to radians
            var radians = degreesToRadians(degrees);
            var tOne = Math.Atan2(v.z, v.x);
            var tTwo = Math.Atan2(v.y, Math.Sqrt(Math.Pow(v.x, 2) + Math.Pow(v.z, 2)));

            // Terug naar de ruimte en startpositie
            Matrix m7 = translateMatrix(v.x, v.y, v.z);
            Matrix m6 = new Matrix(new double[4, 4] {
                { Math.Cos(tOne), 0, -Math.Sin(tOne), 0 },
                { 0, 1, 0, 0  },
                { Math.Sin(tOne), 0, Math.Cos(tOne), 0 },
                { 0, 0, 0, 1 }
            });
            // Rotatie-as naar de x-as, roteren om de x-as en terug naar xy-vlak
            Matrix m5 = new Matrix(new double[4, 4] {
                { Math.Cos(tTwo), -Math.Sin(tTwo), 0, 0 },
                { Math.Sin(tTwo),  Math.Cos(tTwo), 0, 0 },
                { 0, 0, 1, 0 },
                { 0, 0, 0, 1 }
            });
            Matrix m4 = new Matrix(new double[4, 4] {
                { 1, 0, 0, 0 },
                { 0, Math.Cos(radians), -Math.Sin(radians), 0 },
                { 0, -Math.Sin(radians), Math.Cos(radians), 0 },
                { 0, 0, 0, 1 }
            });
            Matrix m3 = new Matrix(new double[4, 4] {
                { Math.Cos(tTwo), Math.Sin(tTwo), 0, 0 },
                { -Math.Sin(tTwo), Math.Cos(tTwo), 0, 0 },
                { 0, 0, 1, 0 },
                { 0, 0, 0, 1 }
            });

            // Breng de rotatie as door O en naar xy-vlak
            Matrix m2 = new Matrix(new double[4, 4] {
                { Math.Cos(tOne), 0, Math.Sin(tOne), 0 },
                { 0, 1, 0, 0 },
                { -Math.Sin(tOne), 0, Math.Cos(tOne), 0 },
                { 0, 0, 0, 1 }
            });
            Matrix m1 = new Matrix(new double[4, 4] {
                { 1, 0, 0, (v.x * -1) },
                { 0, 1, 0, (v.y * -1) },
                { 0, 0, 1, (v.z * -1) },
                { 0, 0, 0, 1 }
            });
            return m7 * (m6 * (m5 * (m4 * (m3 * (m2 * m1)))));
        }
    }
}
