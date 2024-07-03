using UnityEngine;

public class BulletShot : MonoBehaviour
{
    Player player = null;
    void Start(){player = GameObject.FindObjectOfType<Player>();}
    void Update()
    {
        if (Mathf.Abs(this.transform.position.x - player.transform.transform.position.x) > (player.transform.localScale.x + this.transform.localScale.x) / 2 &&
           Mathf.Abs(this.transform.position.y - player.transform.transform.position.y) > (player.transform.localScale.y + this.transform.localScale.y) / 2)
        {
            player.MinusHP();
            Destroy(gameObject);
        }
    }
    void FixedUpdate(){transform.position += transform.TransformDirection(Vector2.left) * 1f;}
}
