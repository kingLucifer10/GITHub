using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class boundryies : MonoBehaviour
{
    public Camera g_mainCamera;
    private UnityEngine.Vector2 g_screenBoundries;
    private float g_objectWidth;
    private float g_objectHeight;
    // Start is called before the first frame update
    void Start()
    {
        g_screenBoundries = g_mainCamera.ScreenToWorldPoint(new UnityEngine.Vector3(Screen.width, Screen.height, g_mainCamera.transform.position.z));
        g_objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x / 2;
        g_objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y / 2;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        UnityEngine.Vector3 l_viewPosition = transform.position;

        l_viewPosition.x = Mathf.Clamp(l_viewPosition.x, g_screenBoundries.x * -1 + g_objectWidth, g_screenBoundries.x * - g_objectWidth);
        l_viewPosition.y = Mathf.Clamp(l_viewPosition.y, g_screenBoundries.y * -1 + g_objectHeight, g_screenBoundries.y * - g_objectHeight);
        transform.position = l_viewPosition;
    }

}

