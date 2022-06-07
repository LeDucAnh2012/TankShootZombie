using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GunShootZombie.Gameplay
{
    public class GunController : MonoBehaviour
    {
        public float velocityBullet = 2;
        public bool isRotate = false;

        [SerializeField] private GameObject objTank;
        [SerializeField] private VariableJoystick variableJoystick;

        public void FixedUpdate()
        {
            Rotate();
        }
        private void Rotate()
        {
            Vector3 direction = Vector3.right * variableJoystick.Vertical + Vector3.forward * variableJoystick.Horizontal;
            RotateTank(direction, true);
        }
        private void RotateTank(Vector3 direction, bool isRotate)
        {
            if (!isRotate) return;

            this.isRotate = isRotate;

            Vector3 relative = variableJoystick.transform.InverseTransformPoint(direction);

            float angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;
            objTank.transform.localEulerAngles = new Vector3(0, 0, angle - 90);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
                InstantiateBullet();
        }
        [SerializeField] private BulletPlayer bulletPlayer;
        public void InstantiateBullet()
        {
            Quaternion euler = objTank.transform.localRotation;
            BulletPlayer _b = Instantiate(bulletPlayer, this.transform.position, euler);
            _b.Move(true, velocityBullet);
        }
    }
}
