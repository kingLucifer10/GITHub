using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class joyStick : MonoBehaviour
{
    public Transform g_player;
    public float g_speed = 5.0f;

    private bool g_touchStart = false;
    private Vector2 g_pointA;
    private Vector2 g_pointB;

    public Transform g_innerCircle;
    public Transform g_outerCircle;

   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            g_pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

            g_innerCircle.transform.position = g_pointA * -1;
            g_outerCircle.transform.position = g_pointA * -1;
            g_innerCircle.GetComponent<SpriteRenderer>().enabled = true;
            g_outerCircle.GetComponent<SpriteRenderer>().enabled = true;

        }
        if (Input.GetMouseButton(0))
        {
            g_touchStart = true;
            g_pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            g_touchStart = false;
        }
    }
    private void FixedUpdate()
    {
        if (g_touchStart)
        {
            Vector2 l_offset = g_pointB - g_pointA;
            Vector2 l_direction = Vector2.ClampMagnitude(l_offset, 1.0f);
            f_moveCharacter(l_direction * 1);

            g_innerCircle.transform.position = new Vector2(g_pointA.x + l_direction.x, g_pointA.y + l_direction.y)*-1;
        }
        else
        {
            g_innerCircle.GetComponent<SpriteRenderer>().enabled = false;
            g_outerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    void f_moveCharacter(Vector2 l_direction)
    {
        g_player.Translate(l_direction * g_speed * Time.deltaTime); 
    }
}
