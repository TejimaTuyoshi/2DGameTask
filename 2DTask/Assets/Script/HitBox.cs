using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    // “_‚Ìî•ñ
    float point_pos_x = 120.0f;
    float point_pos_y = 50.0f;

    // ‹éŒ`‚Ìî•ñ
    float rect_pos_x = 100.0f;
    float rect_pos_y = 30.0f;
    float rect_width = 80.0f;
    float rect_height = 40.0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        point_pos_x = transform.position.x;
        point_pos_y = transform.position.y;
    }
}

