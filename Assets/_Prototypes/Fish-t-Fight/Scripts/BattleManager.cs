using System.Collections;
using TMPro;
using UnityEngine;

namespace FishFight
{
    public class BattleManager : MonoBehaviour
    {
        public int _inputTime;
        public static PlayerBrain blueDuck;
        public static PlayerBrain pinkDuck;
        public TMP_Text TimerUI;
        public TMP_Text BattleStateUI;

        private void Start()
        {
            StartCoroutine(StartBattle());
        }

        public IEnumerator StartBattle()
        {
            while (blueDuck.HP > 0 && pinkDuck.HP > 0)
            {
                blueDuck.ToggleInputs(true);
                pinkDuck.ToggleInputs(true);
                yield return SkillSelection();
                Fight(blueDuck, pinkDuck);
                Fight(pinkDuck, blueDuck);
                yield return new WaitForSeconds(1);
            }

            if (blueDuck.HP > pinkDuck.HP)
            {
                BattleStateUI.text = "BLUE WINS!";
                pinkDuck.Animator.SetTrigger("Die");
            }
            else if(blueDuck.HP < pinkDuck.HP)
            {
                BattleStateUI.text = "PINK WINS!";
                blueDuck.Animator.SetTrigger("Die");
            }
            else
            {
                BattleStateUI.text = "YOU ALL SUCKS! IT'S A DRAW!";
                pinkDuck.Animator.SetTrigger("Die");
                blueDuck.Animator.SetTrigger("Die");
            }
            yield return null;
        }

        public IEnumerator SkillSelection()
        {
            BattleStateUI.text = "SELECT A MOVE!";
            int timer = _inputTime;
            blueDuck.ResetActions();
            pinkDuck.ResetActions();
            while (timer >= 0)
            {
                TimerUI.text = $"{timer}";
                timer--;
                yield return new WaitForSeconds(1);
            }

            yield return null;
        }

        public void Fight(PlayerBrain duck, PlayerBrain otherDuck)
        {
            BattleStateUI.text = "FIGHT!";
            if (duck.isAttacking)
            {
                duck.Attack(duck, otherDuck);
            }
            else if (duck.isDefending)
            {
                duck.Defend();
            }
            else if (duck.isHealing)
            {
                duck.Heal();
            }
        }
    }
}