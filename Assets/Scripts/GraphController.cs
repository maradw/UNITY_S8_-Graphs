using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphController : MonoBehaviour
{
    public GameObject nodePrefabs;
    public TextAsset nodePositionTxt;
    public string[] arrayNodePositions;
    public string[] currentNodePositions;
    public SimplyLinkedList<GameObject> allNodes = new SimplyLinkedList<GameObject>();
    public TextAsset nodeConectionsTxt;
    public string[] arrayNodeConections;
    public string[] currentNodeConections;
    public EnemyController enemy;
    public int initialIndex;
    public TextAsset nodeWeight;
    public string[] arrayWeight;
    
    void Start()
    {
        CreateNode();
        CreateConnections();
        SelecInitialNode();
    }

    void CreateNode()
    {
        if (nodePositionTxt != null && arrayWeight !=null)
        {
            arrayNodePositions = nodePositionTxt.text.Split('\n');

            arrayWeight = nodeWeight.text.Split("\n");
            for (int i = 0; i < arrayNodePositions.Length; i++)
            {
                currentNodePositions = arrayNodePositions[i].Split(',');
                Vector2 position = new Vector2(float.Parse(currentNodePositions[0]), float.Parse(currentNodePositions[1]));
                GameObject tmp = Instantiate(nodePrefabs, position, transform.rotation);
                NodeController currentNode = tmp.GetComponent<NodeController>();
                //
                float weight = float.Parse(arrayWeight[i]);
                currentNode.SetWeight(weight);

                allNodes.InsertNodeAtEnd(tmp);
            }
        }
    }
    void CreateConnections()
    {
        if(nodeConectionsTxt != null)
        {
            arrayNodeConections = nodeConectionsTxt.text.Split("\n");
            for(int i = 0;i < arrayNodeConections.Length; i++)
            {
                currentNodeConections = arrayNodeConections[i].Split(",");
                for(int j = 0; j < currentNodeConections.Length; j++)
                {
                    allNodes.ObtainNodeAtPosition(i).GetComponent<NodeController>().AddAdjacentNode(allNodes.ObtainNodeAtPosition(int.Parse(currentNodeConections[j])).GetComponent<NodeController>());
                }
            }
        }
    }
    
    void SelecInitialNode()
    {
       initialIndex = Random.Range(0, allNodes.length);
        enemy.objective = allNodes.ObtainNodeAtPosition(initialIndex);
    }
}