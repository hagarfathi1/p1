// Kruskal's Algorithm
public class Edge : IComparable<Edge>
{
    public int Source, Destination, Weight;

    public int CompareTo(Edge other)
    {
        return this.Weight.CompareTo(other.Weight);
    }
}

public class Kruskal
{
    private int[] parent;

    public List<Edge> FindMST(int vertices, List<Edge> edges)
    {
        edges.Sort();
        parent = new int[vertices];
        for (int i = 0; i < vertices; i++)
            parent[i] = i;

        List<Edge> mst = new List<Edge>();

        foreach (var edge in edges)
        {
            int root1 = Find(edge.Source);
            int root2 = Find(edge.Destination);

            if (root1 != root2)
            {
                mst.Add(edge);
                Union(root1, root2);
            }
        }

        return mst;
    }

    private int Find(int vertex)
    {
        if (parent[vertex] != vertex)
            parent[vertex] = Find(parent[vertex]);

        return parent[vertex];
    }

    private void Union(int root1, int root2)
    {
        parent[root2] = root1;
    }
}

//sorting 0(ElogE)



