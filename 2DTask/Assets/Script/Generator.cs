using UnityEngine;

public enum Enemys
{
    Nolmal,
    Assault
}

public class Generator : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Enemys enemys;
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
        if (time >= livetime && islive == false)
        {
            time = 0;
            GameObject gameObj = Instantiate
            (enemy, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity) as GameObject;
            gameObj.transform.parent = this.transform;
            if (enemys == Enemys.Nolmal)
            {
                child = transform.Find("Enemy(Clone)").gameObject;
            }
            else if (enemys == Enemys.Assault)
            {
                child = transform.Find("BoarEnemy(Clone)").gameObject;
            }
            islive = true;
        }

        if (child == null)
        {
            islive = false;
        }
    }
}
