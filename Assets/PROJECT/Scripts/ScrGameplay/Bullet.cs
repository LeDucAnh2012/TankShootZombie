using UnityEngine;

namespace GunShootZombie.Gameplay
{
    public abstract class Bullet : MonoBehaviour
    {
        public float speed = 1f;

        private bool isMove = false;
        private Vector3 angle = Vector3.zero;
        // abstract method
        public abstract void DestroyBullet(bool isDestroy, float timeDelayDestroy);
        public abstract void DestroyBullet(bool isDestroy, Vector3 positionDestroy);

        // virtual method
        public virtual void Move(bool _isMove, float _speed)
        {
            this.isMove = _isMove;
            this.speed = _speed;

            Debug.Log("Move in abstract class Bullet");
        }
        // normal method
        public void Destroy()
        {
            Destroy(this.gameObject);
            Debug.Log("Destroy Bullet abstract class Bullet");
        }
        //-------------------------------------------------------------------------------------------
        private void Update()
        {
            Move();
            CheckPositionBulletToDestroy();
        }
        private void Move()
        {
            // move the bullet when it is spawned
            if (!isMove) return;
            this.transform.Translate(0, Time.deltaTime * speed, 0);
        }
        private void CheckPositionBulletToDestroy()
        {
            float posX = this.transform.position.x;
            float posY = this.transform.position.y;

            float sizeCam = Camera.main.orthographicSize;
            if (posX > sizeCam * 2 || posX < sizeCam * -2 || posY > sizeCam + 1 || posY < sizeCam * -1 - 1)
                Destroy();
        }
    }
}
