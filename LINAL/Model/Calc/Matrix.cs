using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINAL.Model.Calc
{
    public class Matrix
    {
        private double[,] scalar;
        /* Matrix constructor */
        public Matrix(double[,] s)
        {
            scalar = s;
        }
        /* Matrixes  */
        public static Matrix operator *(Matrix m1, Matrix m2)
        {

        }

        /*
        TODO:
        - Matrix Scalar
        - Matrix Translate
        - Rotate
        ...
        */
    }
}
