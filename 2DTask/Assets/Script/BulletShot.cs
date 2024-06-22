using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BulletShot : MonoBehaviour
{
    Player player;
    // Start is called before the first frame update
    void Start()
    {

    }

    bool isHitRect(Transform target)
    {
        if (Mathf.Abs(this.transform.position.x - target.transform.position.x) < (target.localScale.x + this.transform.localScale.x) / 2 &&
           Mathf.Abs(this.transform.position.y - target.transform.position.y) < (target.localScale.y + this.transform.localScale.y) / 2)
        {
            Debug.Log(target.name);
            //player = GetComponent<Player>();
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHitRect(transform))
        {
            //player.MinusHP();
        }
    }
    void FixedUpdate()
    {
        transform.position += transform.TransformDirection(Vector2.left) * 1f;
    }
}
