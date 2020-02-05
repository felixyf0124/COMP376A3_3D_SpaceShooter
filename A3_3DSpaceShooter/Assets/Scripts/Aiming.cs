using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour {

    public float angle;

    public Vector3 mousePos;

    public Camera camera;

    private bool CursorAiming;





    private void Start()
    {
        CursorAiming = false;
    }



    // Update is called once per frame
    void Update () {
        if (CursorAiming)
        {
            Cursor.visible = false;
            mousePos = camera.ScreenToViewportPoint(Input.mousePosition);
            Vector3 direction = new Vector3(mousePos.x - 0.5f, mousePos.y - 0.5f, 1.0f);
            float angleV = -Mathf.Atan2(direction.y, direction.z) * Mathf.Rad2Deg;
            float angleH = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(transform.rotation.x + angleV * angle, transform.rotation.y + angleH * angle, transform.rotation.z);
        }

        if(Input.GetKeyDown(KeyCode.Period))
        {
            CursorAiming = !CursorAiming;
        }
    }
}
