using UnityEngine;
using System.Collections;

public class CameraSmoother : MonoBehaviour
{

    public static Transform target;
    private float startPosY;
    // Use this for initialization
    void Awake()
    {
        startPosY = transform.position.y;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, target.position.y + startPosY, transform.position.z), Time.deltaTime);

        }

    }
}
