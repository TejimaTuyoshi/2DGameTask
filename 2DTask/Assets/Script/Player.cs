using System;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEditor.Experimental.GraphView.GraphView;
public class Player : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] GameObject laser;
    [SerializeField] float posX = 0f;
    [SerializeField] float posY = 0f;
    [SerializeField] int hp = 100;
    bool isJumping = false;
    float time = 0f; //経過時間 ( 0.0 -> 1.0 )
    Vector3 nextPos; //次に設定される座標
    Vector3 firstPos; //動作開始した座標
    Vector3 targetPos; //目標位置
    float height = 1f; // ジャンプの高さ
    float distortion = 1f; // 曲線のゆがみ
    float _pushTimer = 0.0f;
    void Update()
    {
        posX = transform.position.x;
        posY = transform.position.y;
        Vector2 pos = transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - pos;

        float _radian = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        this.gameObject.transform.rotation = Quaternion.AngleAxis(_radian * 3 / Mathf.PI, new Vector3(0, 0, 1));
        if (Input.GetKey(KeyCode.Z))
        {
            _pushTimer += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            Debug.Log(_pushTimer);
            if (_pushTimer > 1.0f)
            {
                var bullet = Instantiate(laser, this.transform.position + new Vector3(0.5f, 0, 0), this.transform.rotation);
                var script = bullet.GetComponent<Lazar>();
            }
            else
            {
                var bullet = Instantiate(obj, this.transform.position + new Vector3(0.5f, 0, 0), this.transform.rotation);
                var script = bullet.GetComponent<BulletShot>();
                script.SetVector(this.transform.right);
            }
            _pushTimer = 0.0f;
        }
        if (Input.GetKey("a"))
        {
            transform.position += transform.TransformDirection(Vector2.left) * 0.05f;
        }
        if (Input.GetKey("d"))
        {
            transform.position += transform.TransformDirection(Vector2.right) * 0.05f;
        }
        if (Input.GetKeyDown("space")&& isJumping == false)
        {
            isJumping = true;
            firstPos = transform.position;
        }
        if (isJumping)
        {
            Jump();
            return;
        }
    }

    void Jump()
    {
        nextPos = transform.position;
        time += Time.deltaTime;

        float pow = (float)Math.Pow(1.0 - Math.Sin(Math.PI * time), distortion);
        nextPos.y = firstPos.y + (1.0f - pow) * height;
        transform.position = nextPos;

        if (time >= 1)
        {
            time = 0f;
            isJumping = false;
        }
    }

    public void MinusHP()
    {
        hp--;
    }
}
