using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    [SerializeField] float _x = 0f;
    [SerializeField] float _y = 0f;
    [SerializeField] float _playerX = 0f;
    [SerializeField] float _playerY = 0f;
    [SerializeField] float m_x = 0f;
    [SerializeField] float m_y = 0f;
    [SerializeField] Transform m_transform;
    [SerializeField] Player _player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _x = transform.position.x;
        _y = transform.position.y;
        _playerX = _player.transform.position.x;
        _playerY = _player.transform.position.y;
        m_x = _playerX - _x;
        m_y = _playerY - _y;
        if (m_x < 0)
        {
            m_x *= -1;
        }
        if (m_y < 0)
        {
            m_y *= -1;
        }
    }
}
