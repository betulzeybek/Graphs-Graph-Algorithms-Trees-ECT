using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace _05200000092_05210000282
{

    public class Node
    {
        public int key, height;
        public Node left;
        public Node right;

        public Node(int d)
        {
            key = d;
            height = 1;
        }
    }

    public class AVLTree
    {
        public Node root;

        public AVLTree()
        {
            root = null;
        }

        private static int GetHeight(Node N) //function to get the height of the tree
        {
            if (N == null)
            {
                return 0;
            }

            return N.height;
        }

        private static int GetMax(int a, int b) //function to get the maximum of two integers
        {
            return (a > b) ? a : b;
        }

        private static Node RightRotate(Node y) //function for right rotate
        {
            Node x = y.left;
            Node T2 = x.right;

            x.right = y;
            y.left = T2;

            y.height = GetMax(GetHeight(y.left), GetHeight(y.right)) + 1;
            x.height = GetMax(GetHeight(x.left), GetHeight(x.right)) + 1;

            return x;
        }

        private static Node LeftRotate(Node x)
        {
            Node y = x.right;
            Node T2 = y.left;

            y.left = x;
            x.right = T2;

            x.height = GetMax(GetHeight(x.left), GetHeight(x.right)) + 1;
            y.height = GetMax(GetHeight(y.left), GetHeight(y.right)) + 1;

            return y;
        }

        private static int GetBalance(Node N)
        {
            if (N == null)
            {
                return 0;
            }

            return GetHeight(N.left) - GetHeight(N.right);
        }

        public Node AVLInsert(Node node, int key)
        {
            if (node == null)
            {
                return (new Node(key));
            }

            if (key < node.key)
            {
                node.left = AVLInsert(node.left, key);
            }
            else if (key > node.key)
            {
                node.right = AVLInsert(node.right, key);
            }
            else
            {
                return node;
            }

            node.height = 1 + GetMax(GetHeight(node.left), GetHeight(node.right));

            int balance = GetBalance(node);

            //if this node becomes unbalanced, then there are 4 cases
            if (balance > 1 && key < node.left.key) //left left case
            {
                return RightRotate(node);
            }
            if (balance < -1 && key > node.right.key) //right right case
            {
                return LeftRotate(node);
            }
            if (balance > 1 && key > node.left.key) //left right case
            {
                node.left = LeftRotate(node.left);
                return RightRotate(node);
            }
            if (balance < -1 && key < node.right.key) //right left case
            {
                node.right = RightRotate(node.right);
                return LeftRotate(node);
            }

            return node;
        }

        public void preOrder(Node node)
        {
            Console.WriteLine(node.key + " ");
            preOrder(node.left);
            preOrder(node.right);
        }
    }

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

    public class PrimsMSP
    {
        static int V = 5;

        static int minKey(int[] key, bool[] mstSet)
        {
            int min = int.MaxValue;
            int min_index = -1;

            for (int v = 0; v < V; v++)
            {
                if (mstSet[v] == false && key[v] < min)
                {
                    min = key[v];
                    min_index = v;
                }
            }
            return min_index;
        }
        public static void printMST(int[] parent, int[,] graph)
        {
            Console.WriteLine("Edge \tWeight");
            for (int i = 1; i < V; i++)
            {
                Console.WriteLine(parent[i] + " - " + i + "\t" + graph[i, parent[i]]);
            }
        }

        public static void primMST(int[,] graph)
        {
            int[] parent = new int[V];
            int[] key = new int[V];
            bool[] mstSet = new bool[V];

            for (int i = 0; i < V; i++)
            {
                key[i] = int.MaxValue;
                mstSet[i] = false;
            }

            key[0] = 0;
            parent[0] = -1;

            for (int count = 0; count < V; count++)
            {
                int u = minKey(key, mstSet);
                mstSet[u] = true;
                for (int v = 0; v < V; v++)
                {
                    if (graph[u, v] != 0 && mstSet[v] == false && graph[u, v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = graph[u, v];
                    }
                }
            }
            printMST(parent, graph);
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
            Console.WriteLine("Vertex     Distance "
                              + "from Source\n");
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
    internal class Program
    {
        static void Main(string[] args)
        {
            AVLTree tree = new AVLTree();


            tree.root = tree.AVLInsert(tree.root, 10);
            tree.root = tree.AVLInsert(tree.root, 20);
            tree.root = tree.AVLInsert(tree.root, 30);
            tree.root = tree.AVLInsert(tree.root, 40);

            Console.WriteLine("Preorder trevarsal" + " of constructed tree is : ");
            tree.preOrder(tree.root);

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

            /*int[,] graph2 = new int[,] { { 0, 2, 0, 6, 0 },
                                      { 2, 0, 3, 8, 5 },
                                      { 0, 3, 0, 0, 7 },
                                      { 6, 8, 0, 0, 9 },
                                      { 0, 5, 7, 9, 0 } };

            primMST(graph2);*/


            BFT b = new BFT(4);

            b.addEdge(0, 1);
            b.addEdge(0, 2);
            b.addEdge(1, 2);
            b.addEdge(2, 0);
            b.addEdge(2, 3);
            b.addEdge(3, 3);

            Console.WriteLine("Following is the BFT (starting from vertex 2)\n");

            b.BFS(2);

            Console.ReadLine();
        }
    }
}
