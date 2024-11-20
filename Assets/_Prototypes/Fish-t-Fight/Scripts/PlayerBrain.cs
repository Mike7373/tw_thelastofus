using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace FishFight
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerBrain : MonoBehaviour
    {
        [Header("Stats")] 
        public string name;
        public int maxHealth = 100;
        public int damage;
        public int healingPower;

        [Header("UI References")] 
        public Slider currentHealth;
        
        [Header("[DEBUG] Moves")] 
        public bool isAttacking;
        public bool isDefending;
        public bool isHealing;

        public int HP => _hp;
        public Animator Animator => _animator;
        
        private int _hp;
        private Animator _animator;
        private InputActionAsset _inputs;

        private void Awake()
        {
            if (name == "Blue")
            {
                BattleManager.blueDuck = this;
            }
            else
            {
                BattleManager.pinkDuck = this;
            }
            _animator = GetComponent<Animator>();
            _inputs = GetComponent<PlayerInput>().actions;
            _hp = maxHealth;
        }

        private void Start()
        {
            currentHealth.maxValue = maxHealth;
            currentHealth.value = maxHealth;
        }

        private void OnAttack()
        {
            Debug.Log($"[{name}]OnAttack");
            isAttacking = true;
            ToggleInputs(false);
        }

        private void OnDefend()
        {
            Debug.Log($"[{name}]OnDefend");
            isDefending = true;
            ToggleInputs(false);
        }

        private void OnHeal()
        {
            Debug.Log($"[{name}]OnHeal");
            isHealing = true;
            ToggleInputs(false);
        }

        public void Attack(PlayerBrain attacker, PlayerBrain defender)
        {
            if (attacker == this)
            {
                if (!defender.isDefending)
                {
                    defender._hp -= damage;
                    defender.currentHealth.value = defender._hp;
                }
            }
            Debug.Log($"[{name}]ATTACK");
            _animator.SetTrigger("Attack");
        }

        public void Defend()
        {
            Debug.Log($"[{name}]DEFEND");
            _animator.SetTrigger("Defend");
        }

        public void Heal()
        {
            _hp = (_hp + healingPower < maxHealth) ? _hp + healingPower : maxHealth;
            currentHealth.value = _hp;
            Debug.Log($"[{name}]Healing");
            _animator.SetTrigger("Heal");
        }
        
        public void ToggleInputs(bool toggle)
        {
            if (toggle)
            {
                _inputs.Enable();
                return;
            }
            _inputs.Disable();
        }

        public void ResetActions()
        {
            isAttacking = false;
            isDefending = false;
            isHealing = false;
        }
    }
}