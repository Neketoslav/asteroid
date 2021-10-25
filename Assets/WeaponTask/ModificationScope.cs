using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace weaponMod
{
    internal sealed class ModificationScope : ModificationWeapon
    {
        private readonly IScope _scope;
        private readonly Vector3 _scopePosition;
        private GameObject scope;
        public ModificationScope(IScope scope, Vector3 scopePosition)
        {
            _scope = scope;
            _scopePosition = scopePosition;
        }

        protected override Weapon AddModification(Weapon weapon)
        {
            scope = Object.Instantiate(_scope.ScopeInstance, _scopePosition, Quaternion.identity);
            weapon.SetBarrelPosition(_scope.BulletTransform);
            return weapon;
        }

        protected override void RemModification()
        {
            Object.Destroy(scope);
        }
    }
}
