using UnityEngine;

namespace GunShootZombie.Gameplay
{
    public class BulletEnemy : Bullet
    {
        public override void Move(bool _isMove, float _speed)
        {
            base.Move(_isMove, _speed);
        }
        public override void DestroyBullet(bool isDestroy, float timeDelayDestroy)
        {
            if (!isDestroy) return;

            Invoke(nameof(base.Destroy), timeDelayDestroy);
        }

        public override void DestroyBullet(bool isDestroy, Vector3 positionDestroy)
        {
            if (!isDestroy) return;

            if (this.transform.position == positionDestroy)
                base.Destroy();
        }
    }
}