using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace weaponMod
{
    internal abstract class ModificationWeapon : IFire
    {
        private Weapon _weapon;

        protected abstract Weapon AddModification(Weapon weapon);
        protected abstract void RemModification();

        public void ApplyModification(Weapon weapon)
        {
            _weapon = AddModification(weapon);
        }
        public void RemoveModification()
        {
            RemModification();
        }

        public void Fire()
        {
            _weapon.Fire();
        }
    }
}


