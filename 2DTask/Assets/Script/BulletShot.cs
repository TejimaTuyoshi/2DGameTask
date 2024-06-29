using UnityEngine;

public class BulletShot : MonoBehaviour
{
    Player _player = null;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindObjectOfType<Player>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(this.transform.position.x - _player.transform.transform.position.x) > (_player.transform.localScale.x + this.transform.localScale.x) / 2 &&
           Mathf.Abs(this.transform.position.y - _player.transform.transform.position.y) > (_player.transform.localScale.y + this.transform.localScale.y) / 2)
        {
            _player.MinusHP();
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        transform.position += transform.TransformDirection(Vector2.left) * 1f;
    }
}
