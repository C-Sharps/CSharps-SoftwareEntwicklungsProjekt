using UnityEngine;

public class Robot : MonoBehaviour
{
    
    public Robot(Color color)
    {
        var Robot = GameObject.Instantiate(FindObjectOfType<Scene0Logic>().RobotObject, new Vector3(5.75f, 8f, 0f), Quaternion.identity);
        Robot.GetComponentsInChildren<MeshRenderer>()[5].material.color = color;
        Robot.transform.Rotate(0f, 180f, 0f);
    }
}
