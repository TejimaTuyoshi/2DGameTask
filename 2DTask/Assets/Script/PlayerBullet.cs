using UnityEngine;
public class PlayerBullet : MonoBehaviour
{
    Vector3 power = Vector3.right;
    public void SetVector(Vector3 vec){power = vec;}
    void Update()
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
    void FixedUpdate(){transform.position += transform.TransformDirection(Vector2.right) * 0.5f;}
}
