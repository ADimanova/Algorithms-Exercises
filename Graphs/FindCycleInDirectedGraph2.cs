public class FindCicleInDirectedGraph
    {
        public bool HasCycle(int nodeCount, int[,] edges)
        {
            var childMap = new Dictionary<int, HashSet<int>>();

            for (int i = 0; i < edges.GetLength(0); i++)
            {
                var currentParent = edges[i, 0];
                var currentChild = edges[i, 1];
                if (!childMap.ContainsKey(currentParent))
                {
                    childMap.Add(currentParent, new HashSet<int>());
                }

                childMap[currentParent].Add(currentChild);
            }

            var notVisited = new HashSet<int>();
            for (int i = 0; i < nodeCount; i++)
            {
                notVisited.Add(i);
            }

            var visiting = new HashSet<int>();
            var visited = new HashSet<int>();

            while (notVisited.Count > 0)
            {
                var current = notVisited.First();
                if (HasCycle(current, notVisited, visiting, visited, childMap))
                {
                    return false;
                }
            }

            return true;
        }

        private bool HasCycle(int node, HashSet<int> notVisited, HashSet<int> visiting, HashSet<int> visited, Dictionary<int, HashSet<int>> childMap)
        {
            notVisited.Remove(node);
            visiting.Add(node);

            if (childMap.ContainsKey(node))
            {
                foreach (var child in childMap[node])
                {
                    if (visiting.Contains(child))
                    {
                        return true;
                    }

                    if (!visited.Contains(child))
                    {
                        if (HasCycle(child, notVisited, visiting, visited, childMap))
                        {
                            return true;
                        }
                    }
                }
            }            

            visiting.Remove(node);
            visited.Add(node);

            return false;
        }
    }
