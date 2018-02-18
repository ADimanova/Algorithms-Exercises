using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
class Solution {

    static void Main(String[] args) {
        var maze = new int[,] 
        {  //0  1  2  3  4  5  6  7  8
            {0, 0, 0, 0, 0, 0, 1, 0, 0}, //0
            {0, 1, 1, 1, 0, 1, 1, 1, 0}, //1
            {0, 1, 0, 1, 0, 1, 1, 1, 0}, //2
            {0, 1, 1, 1, 0, 0, 1, 1, 0}, //3
            {0, 1, 1, 1, 1, 0, 1, 1, 0}, //4
            {0, 1, 0, 0, 1, 1, 1, 0, 0}, //5
            {0, 1, 0, 0, 0, 0, 1, 0, 0}, //6
            {0, 1, 1, 1, 1, 1, 1, 0, 0}, //7
            {0, 0, 0, 0, 1, 0, 0, 0, 0}, //8
            {0, 0, 0, 0, 1, 0, 0, 0, 0}, //9
            {0, 1, 0, 0, 1, 0, 1, 0, 0}, //10
            {0, 1, 1, 1, 1, 1, 1, 1, 0}, //11
            {0, 0, 0, 0, 0, 0, 1, 0, 0}  //12
        };  
        
        var maze2 = new int[,] 
        {  //0  1  2  3  4  
            {0, 1, 0, 0, 0, }, //0
            {0, 1, 1, 1, 0, }, //1
            {0, 1, 0, 1, 0, }, //2
            {0, 1, 1, 1, 0, }, //3
            {0, 1, 1, 0, 0, }, //4
            {0, 1, 0, 0, 0, }  //5
        }; 
        
        var maze3 = new int[,] 
        {
            {0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
            {0, 1, 1, 1, 1, 1, 1, 1, 1, 0},
            {0, 1, 0, 0, 0, 0, 1, 0, 1, 0},
            {0, 1, 1, 1, 0, 1, 1, 0, 1, 0},
            {0, 1, 0, 1, 0, 1, 0, 0, 1, 0},
            {0, 1, 1, 1, 1, 1, 0, 1, 1, 0},
            {0, 0, 0, 0, 0, 1, 0, 0, 0, 0},
            {0, 1, 0, 1, 0, 1, 0, 0, 1, 0},
            {0, 1, 1, 1, 1, 1, 1, 1, 1, 0},
            {0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
        };
        
        var maze4 = new int[,] 
        {
            {0, 0, 0, 1, 0},
            {0, 1, 1, 1, 0},
            {0, 1, 0, 1, 0},
            {0, 1, 1, 1, 0},
            {0, 0, 1, 0, 0}
        };
        
        var graph = new Graph();
        var lastFoundNodes = new Dictionary<int, Vertex>();
        
        var rowsCount = maze.GetLength(0);
        var columnsCount = maze.GetLength(1);      
        for(var i = 1; i < columnsCount - 1; i++)
        {
            if(maze[0, i] == 1)
            {
                graph.StartVertex = new Vertex(0, i);
                lastFoundNodes.Add(i, graph.StartVertex);
                break;
            }
        }
                
        for(var row = 1; row < rowsCount - 1; row++)
        {
            var lastInRow = default(Vertex);
            for(var col = 1; col < columnsCount - 1; col++)
            {   
                if (IsVertex(maze, row, col))
                {
                    var vertex = new Vertex(row, col); 
                    if(maze[row - 1, col] == 1) 
                    {                       
                        vertex.ConnectedVertexes.Add(lastFoundNodes[col]);
                        lastFoundNodes[col].ConnectedVertexes.Add(vertex);
                    }
                    
                    if(maze[row, col - 1] == 1)
                    {
                        vertex.ConnectedVertexes.Add(lastInRow);
                        lastInRow.ConnectedVertexes.Add(vertex);
                    }
                                      
                    lastFoundNodes[col] = vertex; 
                    lastInRow = vertex;
                } 
            }
        }

        var lastRowIndex = rowsCount - 1;
        for(var i = 1; i < columnsCount - 1; i++)
        {
            if(maze[lastRowIndex, i] == 1)
            {
                graph.EndVertex = new Vertex(lastRowIndex, i);
                if(maze[lastRowIndex - 1, i] == 1) 
                {                       
                    graph.EndVertex.ConnectedVertexes.Add(lastFoundNodes[i]);
                    lastFoundNodes[i].ConnectedVertexes.Add(graph.EndVertex);
                }
                
                break;
            }
        }
        
        //var dfs = new DFS(graph);
        //var visited = algo.Traverse();
        //visited = visited.OrderBy(v => v.Row).ThenBy(v => v.Column);
        //foreach(var item in visited)
        //{
        //   Console.WriteLine(item);
        //}
        
        // run only a single traverse on a graph so not to mess up 
        // or keep distances separately in Dictionary with key = node and value = distance
        //PrintDFS(graph);      
        PrintBFS(graph);
    }
    
    static void PrintDFS(Graph graph)
    {
        var dfs = new DFS(graph);
        var pathDFS = dfs.ShortestPath();
        foreach(var item in pathDFS)
        {
           Console.WriteLine(item);
        }
    }
    
    static void PrintBFS(Graph graph)
    {
        var bfs = new BFS(graph);
        var pathBFS = bfs.ShortestPath();
        foreach(var item in pathBFS)
        {
           Console.WriteLine(item);
        }
    }
    
    public static bool IsVertex(int[,] matrix, int row, int col)
    {
        if(matrix[row, col] == 0)
        {
            return false;
        }
        
        if(matrix[row, col - 1] == matrix[row, col + 1] &&
            matrix[row - 1, col] == matrix[row + 1, col] &&
                matrix[row - 1, col] != matrix[row, col + 1]) 
        {
            return false;
        }

        return true;
    }
    
    public class Graph 
    {
        public Vertex StartVertex {get; set;}
        public Vertex EndVertex {get; set;}
        
        public int CalculateDistance(Vertex currentNode, Vertex child)
        {
            // * (newDistance = distance of previous element + edge length) 
            var edgeLength = Math.Abs(currentNode.Row - child.Row) +
                Math.Abs(currentNode.Column - child.Column);
            return currentNode.Distance + edgeLength;
        }
    }
    
    public class Vertex
    {
        public Vertex(int row, int col)
        {
            this.Row = row;
            this.Column = col;
            this.Distance = int.MaxValue;
            
            this.ConnectedVertexes = new List<Vertex>();
        }
        
        public int Row {get; set;}
        public int Column {get; set;}
        public int Distance {get; set;}
        public Vertex Previous {get; set;}
        
        public List<Vertex> ConnectedVertexes {get; set;}
        
        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach(var v in this.ConnectedVertexes)
            {
                builder.Append($"[{v.Row}, {v.Column}] ");
            }   
            
            //return $"[{this.Row}, {this.Column}] -> {builder.ToString()}";
            return $"[{this.Row}, {this.Column}]";
        }
    }
    
    public class BFS
    {        
        private Graph graph;
        
        public BFS(Graph graph)
        {
            this.graph = graph;
        }
        
        public IEnumerable<Vertex> ShortestPath()
        { 
            // add start to queue and set it's distance to 0
            // while there are items in queue, pop item
                // foreach child of item
                    // calculate distance from parent to child
                    // if new distance is smaller than Distance of child
                        // child Distance = new distance
                        // child Previous = parent
                        // push child to queque
            
            this.graph.StartVertex.Distance = 0;
            var queue = new Queue<Vertex>();
            queue.Enqueue(this.graph.StartVertex);
                       
            while(queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                foreach(var child in vertex.ConnectedVertexes)
                {
                    var distance = this.graph.CalculateDistance(vertex, child);
                    if(distance < child.Distance)
                    { 
                        child.Distance = distance;
                        child.Previous = vertex;
                        queue.Enqueue(child);
                    }
                }
            }
            
            // traverse back starting from end to start getting previous element
            var result = new Stack<Vertex>();
            var vertexInPath = this.graph.EndVertex;
            result.Push(vertexInPath);
            while(vertexInPath.Previous != null)
            {
                result.Push(vertexInPath.Previous);
                vertexInPath = vertexInPath.Previous;
            }
           
            return result;
        }
    }
    
    public class DFS
    {       
        private Dictionary<Tuple<int, int>, Vertex> visited =
            new Dictionary<Tuple<int, int>, Vertex>();
        private Graph graph;
        private Stack<Vertex> bestPath;
        private Stack<Vertex> path;
        private int bestDistance = int.MaxValue;
        
        public DFS(Graph graph)
        {
            this.graph = graph;
        }

        public IEnumerable<Vertex> Traverse()
        {
            TraverseRecursion(this.graph.StartVertex);
            return visited.Values;
        }
        
        private void TraverseRecursion(Vertex startNode)
        {
            var item = Tuple.Create(startNode.Row, startNode.Column);
            if(visited.ContainsKey(item))
            {
                return;
            }
            
            visited.Add(item, startNode);
            
            foreach(var node in startNode.ConnectedVertexes)
            {
                TraverseRecursion(node);
            }
        }
        
        public IEnumerable<Vertex> ShortestPath()
        {
            this.graph.StartVertex.Distance = 0;
            this.bestPath = new Stack<Vertex>();
            this.path = new Stack<Vertex>();;
            this.bestDistance = int.MaxValue;
            
            ShortestPathTraverse(this.graph.StartVertex);
            return bestPath;
            
            // - start node set distance to 0 
            // - initialize bestDistanceFound to max int
            // - initialize empty bestStack
            // - traverse node           
        }
        
        private void ShortestPathTraverse(Vertex currentNode)
        {
            // - push node to stack
                // - end recursion if cur node == end node
                    // *  bestDistance = distance of node
                    // *  save a copy of stack into bestStack
                    // *  return
                // or node distance > bestDistance 
                    // return
                // - for each child of node calculate the distance from node
                    // *if newDistance is less than Distance, save new distance as
                    // distance and traverse child
                    // *pop child from stack
            
            this.path.Push(currentNode);
            if(currentNode == this.graph.EndVertex)
            {
                this.bestDistance = currentNode.Distance;
                this.bestPath = new Stack<Vertex>(this.path);
                
                return;
            }
            
            if(currentNode.Distance > this.bestDistance)
            {
                return;
            }

            foreach(var child in currentNode.ConnectedVertexes)
            {     
                var distance = this.graph.CalculateDistance(currentNode, child);
                if(distance < child.Distance)
                {
                    child.Distance = distance;
                    ShortestPathTraverse(child);
                    this.path.Pop();
                }
            }
        }       
    }
}
