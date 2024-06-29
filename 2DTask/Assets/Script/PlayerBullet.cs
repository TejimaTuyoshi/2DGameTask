using UnityEngine;
public class PlayerBullet : MonoBehaviour
{
    Vector3 _power = Vector3.right;
    // Start is called before the first frame update

    public void SetVector(Vector3 vec)
    {
        _power = vec;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += _power * 5 * Time.deltaTime;

        var enList = GameObject.FindObjectsOfType<EnemyShot>();
        foreach (var enemy in enList)
        {
            if (Mathf.Abs(this.transform.position.x - enemy.transform.transform.position.x) < (enemy.transform.localScale.x + this.transform.localScale.x) / 2 &&
                Mathf.Abs(this.transform.position.y - enemy.transform.transform.position.y) < (enemy.transform.localScale.y + this.transform.localScale.y) / 2)
            {
                enemy.MinusHP();
                Destroy(gameObject);
            }
        }
    }

    void FixedUpdate()
    {
        transform.position += transform.TransformDirection(Vector2.right) * 1f;
    }
}
