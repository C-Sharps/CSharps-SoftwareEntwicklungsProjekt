using Unity.VisualScripting;
using UnityEngine;

public class Scene11Logic : MonoBehaviour
{
    [SerializeField]
    private Vector2Int gridSize = new Vector2Int(12, 6);
    [SerializeField]
    private LessonController lessonController;

    private void Start()
    {
        lessonController = GameObject.Find("Interface").GetComponent<LessonController>();
        AssertLessonTargetComplete();
    }

    private void Update()
    {
       /* if (AssertLessonTargetComplete())
        {
            lessonController.CompleteObjective(0);
        }
       */
    }

    // Assert that all tiles are repaired (equaling the intactTile field).
    public bool AssertLessonTargetComplete()
    {
        GameObject tileHolder = GameObject.Find("Tiles");

        for (int y = 0; y < gridSize.y; y++) {
            for (int x = 0; x < gridSize.x; x++)
            {
                Debug.Log("Checking tile " + x + " ," + y);
                if (!tileHolder.transform.GetChild(x + y * gridSize.x).GetComponent<SolarPanel>().IsIntact())
                {
                    Debug.Log("Tile " + x + ", " + y + " is still broken!");
                    return false;
                }
            }
        }
        return true;
    }
}
