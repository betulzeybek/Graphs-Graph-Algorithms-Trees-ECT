package com.company;

public class MSTandBTreeInsertion {

    public static void main(String[] args) {

        Graph theGraph = new Graph();
        theGraph.addVertex('A'); // 0 (start for mst)
        theGraph.addVertex('B'); // 1
        theGraph.addVertex('C'); // 2
        theGraph.addVertex('D'); // 3theGraph.addVertex(‘E’); // 4
        theGraph.addEdge(0, 1); // AB
        theGraph.addEdge(0, 2); // AC
        theGraph.addEdge(0, 3); // AD
        theGraph.addEdge(0, 4); // AE
        theGraph.addEdge(1, 2); // BC
        theGraph.addEdge(1, 3); // BD
        theGraph.addEdge(1, 4); // BE
        theGraph.addEdge(2, 3); // CD
        theGraph.addEdge(2, 4); // CE
        theGraph.addEdge(3, 4); // DE
        System.out.print("Minimum spanning tree: ");
        theGraph.mst(); // minimum spanning tree
        System.out.println();

        System.out.println("BTree Insertion and Display Methods:");

        BTree b = new BTree(3);
        b.insert(8);
        b.insert(9);
        b.insert(10);
        b.insert(11);
        b.insert(15);
        b.insert(20);
        b.insert(17);

        b.display();
    }
}
