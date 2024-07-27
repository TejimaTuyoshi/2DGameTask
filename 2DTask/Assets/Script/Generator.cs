using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    GameObject child;

    [SerializeField] bool islive = false;
    [SerializeField] float time = 0f;
    [SerializeField] float livetime = 3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Debug.Log(enemy.activeSelf);
        if (time >= livetime && islive == false)
        {
            time = 0;
            GameObject gameObj = Instantiate
            (enemy, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity) as GameObject;
            gameObj.transform.parent = this.transform;
            child = transform.Find("Enemy(Clone)").gameObject;
            islive = true;
        }

        if (child == null)
        {
            islive = false;
        }
    }
}
