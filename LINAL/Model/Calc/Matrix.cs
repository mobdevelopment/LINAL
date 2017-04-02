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

            //
        }
    }
}
