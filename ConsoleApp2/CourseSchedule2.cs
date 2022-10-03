using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class CourseSchedule2
    {
        public static int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            Dictionary<int, List<int>> prereq = CreateAdjList(prerequisites);
            int[] result = new int[numCourses];
            IList<int> res = new List<int>();

            for (int i = 0; i < numCourses; i++)
            {
                bool foundCycle = DFS(i, prereq, res, new HashSet<int>());
                if (foundCycle)
                    return new int[0];
            }

            int count = 0;

            foreach (int val in res)
                result[count++] = val;

            return result;
        }

        private static bool DFS(int course, Dictionary<int, List<int>> prereq, IList<int> res,
                               HashSet<int> hash)
        {
            Queue<(int item1, int item2)> abc = new Queue<(int item1, int item2)>();
            abc.Enqueue((1, 2));
            if (hash.Contains(course))
                return true;

            hash.Add(course);


            for (int i = 0; prereq.ContainsKey(course) && i < prereq[course].Count; i++)
            {
                if (DFS(prereq[course][i], prereq, res, hash))
                    return true;

            }
            if (!res.Contains(course))
            {
                res.Add(course);
            }

            hash.Remove(course);

            return false;
        }

        private static Dictionary<int, List<int>> CreateAdjList(int[][] prereq)
        {
            Dictionary<int, List<int>> res = new Dictionary<int, List<int>>();

            for (int i = 0; i < prereq.Length; i++)
            {
                if (!res.ContainsKey(prereq[i][0]))
                {
                    res.Add(prereq[i][0], new List<int>());
                }

                res[prereq[i][0]].Add(prereq[i][1]);
            }

            return res;
        }
    }
}
