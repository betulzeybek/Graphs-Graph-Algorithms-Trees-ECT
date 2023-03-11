using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace _05200000092_05210000282_Proje4
{
    internal class Program
    {

        public class BFT
        {
            private int _V;

            LinkedList<int>[] adj;

            public BFT(int V)
            {
                adj = new LinkedList<int>[V];
                for (int i = 0; i < adj.Length; i++)
                {
                    adj[i] = new LinkedList<int>();
                }
                _V = V;
            }

            public void addEdge(int v, int w)
            {
                adj[v].AddLast(w);
            }

            public void BFS(int s)
            {
                bool[] visited = new bool[_V];
                for (int i = 0; i < _V; i++)
                {
                    visited[i] = false;
                }

                LinkedList<int> queue = new LinkedList<int>();

                visited[s] = true;
                queue.AddLast(s);

                while (queue.Any())
                {
                    s = queue.First();
                    Console.WriteLine(s + " ");
                    queue.RemoveFirst();

                    LinkedList<int> list = adj[s];

                    foreach (var val in list)
                    {
                        if (!visited[val])
                        {
                            visited[val] = true;
                            queue.AddLast(val);
                        }
                    }
                }
            }
        }
       
        public class Dijkstra
        {
            static int V = 9;
            int minDistance(int[] dist, bool[] sptSet)
            {
                int min = int.MaxValue, min_index = -1;

                for (int v = 0; v < V; v++)
                {
                    if (sptSet[v] == false && dist[v] <= min)
                    {
                        min = dist[v];
                        min_index = v;
                    }
                }
                return min_index;
            }

            void printsolution(int[] dist, int n)
            {
                Console.WriteLine("Köşe     Köşeye "
                                  + "olan uzaklık\n");
                for (int i = 0; i < V; i++)
                {
                    Console.WriteLine(i + " \t\t " + dist[i] + "\n");
                }
            }

            public void dijkstra(int[,] graph, int src)
            {
                int[] dist = new int[V];

                bool[] sptSet = new bool[V];

                for (int i = 0; i < V; i++)
                {
                    dist[i] = int.MaxValue;
                    sptSet[i] = false;
                }
                dist[src] = 0;

                for (int count = 0; count < V - 1; count++)
                {
                    int u = minDistance(dist, sptSet);
                    sptSet[u] = true;
                    for (int v = 0; v < V; v++)
                    {
                        if (!sptSet[v] && graph[u, v] != 0 && dist[u] != int.MaxValue
                            && dist[u] + graph[u, v] < dist[v])
                        {
                            dist[v] = dist[u] + graph[u, v];
                        }
                    }
                }
                printsolution(dist, V);
            }

        }
    
        public static void Main(string[] args)
        {
            
            Console.WriteLine("Dijkstra: ");
            int[,] graph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                                      { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                                      { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                      { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                      { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                      { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                      { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                      { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                      { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };
            Dijkstra t = new Dijkstra();
            t.dijkstra(graph, 0);


            BFT b = new BFT(4);

            b.addEdge(0, 1);
            b.addEdge(0, 2);
            b.addEdge(1, 2);
            b.addEdge(2, 0);
            b.addEdge(2, 3);
            b.addEdge(3, 3);

            Console.WriteLine("2. Vertex'ten başlayarak BFT: \n");

            b.BFS(2);

            Console.ReadLine();
        }
    }
}
