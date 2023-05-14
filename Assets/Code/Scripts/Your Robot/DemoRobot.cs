using UnityEngine;
public class DemoRobot : MonoBehaviour
{
    public DemoRobot()
    {
        GameObject.Instantiate(FindObjectOfType<Scene0Logic>().RobotObject);
    }
}
