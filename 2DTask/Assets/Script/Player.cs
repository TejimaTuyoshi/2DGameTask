using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]GameObject obj;
    [SerializeField] float _x = 0f;
    [SerializeField] float _y = 0f;
    public int _Hp = 100;
    bool isJumping = false;
    float t = 0f; //�o�ߎ��� ( 0.0 -> 1.0 )
    Vector3 nextPos; //���ɐݒ肳�����W
    Vector3 firstPos; //����J�n�������W
    Vector3 targetPos; //�ڕW�ʒu
    float height = 1f; // �W�����v�̍���
    float distortion = 1f; // �Ȑ��̂䂪��
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _x = transform.position.x;
        _y = transform.position.y;
        if (Input.GetKeyDown("z"))
        {   
            Instantiate(obj, new Vector3(_x, _y,0), Quaternion.identity);
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
        t += Time.deltaTime;

        float pow = (float)Math.Pow(1.0 - Math.Sin(Math.PI * t), distortion);
        nextPos.y = firstPos.y + (1.0f - pow) * height;
        transform.position = nextPos;

        if (t >= 1)
        {
            t = 0f;
            isJumping = false;
        }
    }
}
