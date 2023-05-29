using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    #pragma warning disable CS0414
    int integer;
    float floatVar;
    double doubleVar;
    bool myBool = true;
    ExampleScript myObject;
    public GameObject myGameObject;
    [SerializeField]
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        myGameObject = Instantiate(myGameObject,new Vector3( gameObject.transform.position.x, gameObject.transform.position.y + 10f, gameObject.transform.position.z), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 10f)
        {
            Destroy(myGameObject);
        }
    }
}
