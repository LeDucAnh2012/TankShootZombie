using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    private Vector3 direction;
    private bool isRotate;

    [SerializeField] private GameObject objTank;
    public VariableJoystick variableJoystick;

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.right * variableJoystick.Vertical + Vector3.forward * variableJoystick.Horizontal;
        //objTank.transform.localEulerAngles = direction;
        //Debug.Log("direction = " + direction);

        Vector3 relative = variableJoystick.transform.InverseTransformPoint(direction);
        float angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;
        objTank.transform.localEulerAngles = new Vector3(0, 0, angle - 90);
    }
    private void Rotate()
    {
        if (!isRotate) return;

        if (objTank == null) return;

        objTank.transform.localEulerAngles = this.direction;
    }
    public void RotateTank(Vector3 direction, bool isRotate)
    {
        this.direction = direction;
        this.isRotate = isRotate;
    }
}
