using FakeAxeAndDummy.Interfaces;
using System;

namespace FakeAxeAndDummy.Tests.Fakes
{
    class IWeaponFake : IWeapon
    {
        public int AttackPoints => 10;

        public int DurabilityPoints => 10;

        public void Attack(IAttackable target)
        {
            
        }
    }
}
