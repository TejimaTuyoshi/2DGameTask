using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyAssault : MonoBehaviour
{
    [SerializeField] int hp = 3;
    [SerializeField] float x = 0f;
    [SerializeField] float y = 0f;
    [SerializeField] float playerX = 0f;
    [SerializeField] float playerY = 0f;
    [SerializeField] float distanceX = 0f;
    [SerializeField] float distanceY = 0f;
    [SerializeField] float _speed = 5.0f;
    [SerializeField] bool isAttack = false;
    Camera mainCamera;
    Vector3 _movePower = Vector3.zero;
    float time = 0f; //Œo‰ßŽžŠÔ ( 0.0 -> 1.0 )
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        mainCamera = GameObject.FindObjectOfType<Camera>();
    }

    // Update is called once per frame
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
        if (distanceX < 5 && distanceY < 2 && isAttack == false)
        {
            isAttack = true;
            _movePower = player.transform.position - this.transform.position;
        }
        else if (isAttack == true)
        {
            this.transform.position += _movePower * _speed * Time.deltaTime;
        }
        if (hp == 0)
        {
            Destroy(gameObject);
        }
        else if (distanceX <= 1 && distanceY <= 1)
        {
            Destroy(gameObject);
            player.MinusHP();
        }
    }
    public void MinusHP() { hp--; }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}


