using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace weaponMod
{
    internal sealed class Example : MonoBehaviour
    {
        private bool mufflerBool = false;
        private bool ScopeBool= false;
        private IFire _fire;
        private Weapon weapon;

        [Header("Start Gun")]
        [SerializeField] private Rigidbody _bullet;
        [SerializeField] private Transform _barrelPosition;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;

        [Header("Muffler Gun")]
        [SerializeField] private AudioClip _audioClipMuffler;
        [SerializeField] private float _volumeFireOnMuffler;
        [SerializeField] private Transform _barrelPositionMuffler;
        [SerializeField] private GameObject _muffler;

        [Header("Scope Gun")]
        [SerializeField] private Transform _barrelPositionScope;
        [SerializeField] private GameObject _scope;

        ModificationWeapon modificationWeaponMuffler;
        ModificationWeapon modificationWeaponScope;

        private void Start()
        {
            IAmmunition ammunition = new Bullet(_bullet, 3.0f);
            var weapon = new Weapon(ammunition, _barrelPosition, 999.0f, _audioSource, _audioClip);
            _fire = weapon;
        }
        private void SetMuffler()
        {
            mufflerBool = true;
            var muffler = new Muffler(_audioClipMuffler, _volumeFireOnMuffler, _barrelPositionMuffler, _muffler);
            modificationWeaponMuffler = new ModificationMuffler(_audioSource, muffler, _barrelPosition.position);
            modificationWeaponMuffler.ApplyModification(weapon);
            _fire = modificationWeaponMuffler;
        }

        private void SetScope()
        {
            ScopeBool = true;
            var scope = new Scope(_scope, _barrelPositionScope);
            modificationWeaponScope = new ModificationScope(scope, _barrelPositionScope.position);
            modificationWeaponScope.ApplyModification(weapon);
            _fire = modificationWeaponScope;
        }
        private void DelMuffler()
        {
            mufflerBool = false;
            modificationWeaponMuffler.RemoveModification();
        }

        private void DelScope()
        {
            ScopeBool = false;
            modificationWeaponScope.RemoveModification();
        }


        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                _fire.Fire();

            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (ScopeBool == false)
                    SetScope();
                else
                    DelScope();
            }


            if (Input.GetKeyDown(KeyCode.X))
            {
                if (mufflerBool == false)
                    SetMuffler();
                else
                    DelMuffler();

            }


        }
    }
}
