using System;
using System.Collections.Generic;
using System.Text;

namespace MyCoolGame
{
    public interface ISpell
    {
        public void Cast(BaseSpell spell, BaseCreature target, BaseCreature user)
        {

        }

        public void Cancel(BaseSpell spell)
        {

        }
    }

    public abstract class BaseSpell : IGetInfo
    {
        public int Level { get; set; } = 1;

        public int ManaCost { get; set; } = 1;

        public int StaminaCost { get; set; } = 1;

        public int Cooldown { get; set; } = 1;

        public int Range { get; set; } = 1;

        public int Area { get; set; } = 1;

        public int BaseDamage { get; set; }

        public bool IsReady { get; set; }
    }

    public enum SpellElement
    {
        Fire,
        Water,
        Ice,
        Iron,
        Lightning,
        Ether,
        Dark,
        Light,
        Phisical,
        Heal,
        Nothing
    }

    public enum DamageType
    {
        Stabbing,
        Slashing,
        Crushing,
        Magic
    }
}
