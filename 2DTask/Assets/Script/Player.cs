using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] float x = 0f;
    [SerializeField] float y = 0f;
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
        x = transform.position.x;
        y = transform.position.y;
        if (Input.GetKeyDown("z"))
        {
            Instantiate(obj, new Vector3(x, y, 0), Quaternion.identity);
        }
        if (Input.GetKeyDown("a"))
        {
            transform.position += transform.TransformDirection(Vector2.left) * 1f;
        }
        if (Input.GetKeyDown("d"))
        {
            transform.position += transform.TransformDirection(Vector2.right) * 1f;
        }
        if (Input.GetKeyDown("space"))
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
