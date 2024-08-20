using UnityEngine;

public enum BulletState
{
    None,
    Player,
    Enemy
}

public class BulletShot : MonoBehaviour
{
    [SerializeField] BulletState State;

    Vector3 power = Vector3.right;
    Player player = null;
    public void SetVector(Vector3 vec) { power = vec; }
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }
    void Update()
    {
        if (State == BulletState.Enemy)
        {
            if (Mathf.Abs(this.transform.position.x - player.transform.transform.position.x) < (player.transform.localScale.x + this.transform.localScale.x) / 2 &&
                Mathf.Abs(this.transform.position.y - player.transform.transform.position.y) < (player.transform.localScale.y + this.transform.localScale.y) / 2)
            {
                player.MinusHP();
                Destroy(gameObject);
            }
        }
        else if (State == BulletState.Player)
        {
            this.transform.position += power * 5 * Time.deltaTime;
            var list = GameObject.FindObjectsOfType<EnemyShot>();
            foreach (var enemy in list)
            {
                if (Mathf.Abs(this.transform.position.x - enemy.transform.transform.position.x) < (enemy.transform.localScale.x + this.transform.localScale.x) / 2 &&
                    Mathf.Abs(this.transform.position.y - enemy.transform.transform.position.y) < (enemy.transform.localScale.y + this.transform.localScale.y) / 2)
                {
                    enemy.MinusHP();
                    Destroy(gameObject);
                }
            }
        }
    }
    void FixedUpdate()
    {
        if (State == BulletState.Enemy) { transform.position += transform.TransformDirection(Vector2.left) * 0.5f; }
        else if (State == BulletState.Player) { transform.position += transform.TransformDirection(Vector2.right) * 0.5f; }
    }
}
