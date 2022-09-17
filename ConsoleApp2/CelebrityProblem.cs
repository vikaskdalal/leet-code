using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class CelebrityProblem
    {
        static int[,] MATRIX = { { 0, 0, 1, 0 },
                              { 0, 0, 1, 0 },
                              { 0, 0, 0, 0 },
                              { 0, 0, 1, 0 } };

        static int knows(int a, int b) { return MATRIX[a, b]; }
        public static int findPotentialCelebrity(int n)
        {

            // base case - when n reaches 0 , returns -1
            // since n represents the number of people,
            // 0 people implies no celebrity(= -1)
            if (n == 0)
                return -1;

            // find the celebrity with n-1
            // persons
            int id = findPotentialCelebrity(n - 1);

            // if there are no celebrities
            if (id == -1)
                return n - 1;

            // if the id knows the nth person
            // then the id cannot be a celebrity, but nth person
            // could be one
            else if (knows(id, n - 1) == 1)
            {
                return n - 1;
            }

            // if the nth person knows the id,
            // then the nth person cannot be a celebrity and the
            // id could be one
            else if (knows(n - 1, id) == 1)
            {
                return id;
            }

            // if there is no celebrity
            return -1;
        }
    }
}
