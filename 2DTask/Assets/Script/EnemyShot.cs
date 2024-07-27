using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] int hp = 3;
    [SerializeField] float x = 0f;
    [SerializeField] float y = 0f;
    [SerializeField] float playerX = 0f;
    [SerializeField] float playerY = 0f;
    [SerializeField] float distanceX = 0f;
    [SerializeField] float distanceY = 0f;
    float time = 0f; //Œo‰ßŽžŠÔ ( 0.0 -> 1.0 )
    Player player;

    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }
    void Update()
    {
        x = transform.position.x;
        y = transform.position.y;
        playerX = player.transform.position.x;
        playerY = player.transform.position.y;
        distanceX = playerX - x;
        distanceY = playerY - y;
        if (distanceX < 0) { distanceX *= -1; }
        if (distanceY < 0) { distanceY *= -1; }
        if (distanceX < 5 && distanceY < 2)
        {
            time += Time.deltaTime;
            if (time >= 1)
            {
                time = 0;
                Instantiate(obj, new Vector3(x, y, 0), Quaternion.identity);
            }
        }
        if (hp == 0)
        {
            Destroy(gameObject);
        }
    }
    public void MinusHP() { hp--; }
}
