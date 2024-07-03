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
    [SerializeField] Player _player;
    void Update()
    {
        x = transform.position.x;
        y = transform.position.y;
        playerX = _player.transform.position.x;
        playerY = _player.transform.position.y;
        distanceX = playerX - x;
        distanceY = playerY - y;
        if (distanceX < 0){distanceX *= -1;}
        if (distanceY < 0){distanceY *= -1;}
        if (distanceX < 5 && distanceY < 2){Instantiate(obj, new Vector3(x, y, 0), Quaternion.identity);}
        if (hp == 0){this.gameObject.SetActive(false);}
    }
    public void MinusHP(){hp--;}
}
