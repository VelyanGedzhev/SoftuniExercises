using System;
using System.Collections.Generic;
using System.Text;

namespace FakeAxeAndDummy.Interfaces
{
    public interface IAttackable
    {
        public void TakeAttack(int attackPoints);
        public int GiveExperience();
        public bool IsDead();
    }
}
