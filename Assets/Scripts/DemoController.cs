using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoController : MonoBehaviour {
    public MapData mapData;
    public Graph graph;
    public Pathfinder pathfinder;
    public int startX ;
    public int startY;
    public int goalX;
    public int goalY;

    public GameObject startGenerateButton;

    public float timeStep = 1f;
    private void Start() {
        
        startX = int.Parse(PlayerPrefs.GetString("StartXPos"));
        startY = int.Parse(PlayerPrefs.GetString("StartYPos"));
        goalX = int.Parse(PlayerPrefs.GetString("EndXPos"));
        goalY = int.Parse(PlayerPrefs.GetString("EndYPos"));

        startGenerateButton.SetActive(true);

        if (mapData != null && graph != null) {
            int[,] mapInstance = mapData.MakeMap();
            graph.Init(mapInstance);
            GraphView graphView = graph.gameObject.GetComponent<GraphView>();
            if(graph != null) {
                graphView.Init(graph);
            }
            if(graph.IsWithinBounds(startX,startY) && graph.IsWithinBounds(goalX, goalY) && pathfinder!=null) {
                Node startNode = graph.nodes[startX, startY];
                Node goalNode = graph.nodes[goalX, goalY];
                pathfinder.Init(graph, graphView, startNode, goalNode);
            }
        }
    }

    public void OnClickStartGenerate()
    {
        StartCoroutine(pathfinder.SearchRoutine(timeStep));
        startGenerateButton.SetActive(false);
    }

    public void OnClickRegenerate()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
