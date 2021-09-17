using System;
using System.Collections.Generic;
using System.Text;

namespace FakeAxeAndDummy.Interfaces
{
    public interface IWeapon
    {
        public int AttackPoints { get; }
        public int DurabilityPoints { get; }
        public void Attack(IAttackable target);
    }
}
