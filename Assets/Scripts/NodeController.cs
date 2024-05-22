using System.Collections;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    public int index;
    [SerializeField] private int weightNumb;
    [SerializeField] private SimplyLinkedList<NodeController> adjacentNodes = new SimplyLinkedList<NodeController>();
    

    public void AddAdjacentNode(NodeController node)
    {
        adjacentNodes.InsertNodeAtEnd(node);
    }
    public NodeController SelecRandomAdjancent()
    {
         index = Random.Range(0, adjacentNodes.length);
        return adjacentNodes.ObtainNodeAtPosition(index);
    }
    public void SetWeight(int weight)
    {
        weightNumb = weight;
    }
    public int GetNodeWeight()
    {
        return weightNumb;
    }
}