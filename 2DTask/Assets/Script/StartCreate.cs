using UnityEngine;

public class StartCreate : MonoBehaviour
{
    [SerializeField] GameObject obj;
    // Start is called before the first frame update
    void Start(){Instantiate(obj, new Vector3(-5, 0, 0), Quaternion.identity);}

    // Update is called once per frame
    void Update()
    {

    }
}
