using UnityEngine;
using UnityEngine.UI;

public class PuppetDoll : MonoBehaviour
{
    [Header("Params")] [SerializeField] [Range(0, 100)]
    private int _damage = 25; 
    [Header("References")]
    [SerializeField] private Animator _animator;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Animator _enemy;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !_animator.GetCurrentAnimatorStateInfo(0).IsName("Hit") && _healthBar.value > 0)
        {
            _animator.SetTrigger("Hit");
            _healthBar.value -= _damage;
            if (_healthBar.value <= 0)
            {
                _healthBar.value = 0;
                _enemy.SetTrigger("Die");
            }
        }
    }
}
