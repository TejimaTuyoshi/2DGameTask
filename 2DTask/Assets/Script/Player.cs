using System;
using UnityEngine;
using UnityEngine.TextCore.Text;
public class Player : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] float posX = 0f;
    [SerializeField] float posY = 0f;
    [SerializeField] int hp = 100;
    bool isJumping = false;
    float time = 0f; //�o�ߎ��� ( 0.0 -> 1.0 )
    Vector3 nextPos; //���ɐݒ肳�����W
    Vector3 firstPos; //����J�n�������W
    Vector3 targetPos; //�ڕW�ʒu
    float height = 1f; // �W�����v�̍���
    float distortion = 1f; // �Ȑ��̂䂪��
    void Update()
    {
        posX = transform.position.x;
        posY = transform.position.y;
        Vector2 pos = transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - pos;

        float _radian = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        this.gameObject.transform.rotation = Quaternion.AngleAxis(_radian * 3 / Mathf.PI, new Vector3(0, 0, 1));

        if (Input.GetKeyDown("z"))
        {
            Instantiate(obj, new Vector3(posX, posY, 0), Quaternion.identity);
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
