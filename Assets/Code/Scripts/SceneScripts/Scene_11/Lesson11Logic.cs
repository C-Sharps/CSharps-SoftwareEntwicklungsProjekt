/**
 * Author: Robin Intrieri
 * C-Sharps Software-Entwicklungsprojekt SS 2023
*/
using UnityEngine;

public class Lesson11Logic : MonoBehaviour
{
    [SerializeField]
    private Vector2Int gridSize = new Vector2Int(10, 5);
    private LessonController lessonController;
    private Robot robot;

    private void Start()
    {
        lessonController = GameObject.Find("Interface").GetComponent<LessonController>();
        robot = GameObject.FindObjectOfType<Robot>();
        robot.OnQueueEmpty += OnQueueEmpty;
    }

    // Assert that all tiles are repaired (equaling the intactTile field).
    private bool AssertLessonTargetComplete()
    {
        GameObject tileHolder = GameObject.Find("Tiles");

        for (int y = 0; y < gridSize.y; y++)
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                var tile = tileHolder.transform.GetChild(x + y * gridSize.x);

                Debug.Log("Checking tile " + tile.name);

                if (!tile.GetComponent<SolarPanel>().IsIntact())
                {
                    Debug.Log("Tile " + tile.name + " is still broken!");
                    return false;
                }
            }
        }
        return true;
    }

    private void OnQueueEmpty()
    {
        if (AssertLessonTargetComplete())
        {
            lessonController.CompleteObjective(0);
        }
    }
}
