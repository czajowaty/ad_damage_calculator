using System;
using System.Collections.Generic;

namespace AzureDreamsDamageCalculator
{
    public class DamageCalculator
    {
        public static uint DirectAttackDamage(Unit attacker, Unit defender, byte damageRoll, int highGround, bool isCriticalHit)
        { return SwordMixtureDamage(attacker, defender, damageRoll, highGround, isCriticalHit, Spell.NO_SPELL); }
        public static uint MixtureAttackDamage(Unit attacker, Unit defender, byte damageRoll, int highGround, bool isCriticalHit, Spell spell)
        {
            if (spell.IsSwordTypeMixtureMagic())
            { return SwordMixtureDamage(attacker, defender, damageRoll, highGround, isCriticalHit, spell); }
            else if (spell.IsDamagingMixtureMagic())
            { return NonSwordMixtureDamage(spell, defender); }
            else
            { throw new ArgumentException(string.Format("Unsupported mixture type '{0}'!", spell.MixtureMagicType)); }
        }
        public static uint SpellAttackDamage(Spell spell, Unit defender)
        { return SpellAttackDamage(spell, spell.DirectRawDamage, defender); }
        private static uint SwordMixtureDamage(Unit attacker, Unit defender, byte damageRoll, int highGround, bool isCriticalHit, Spell spell)
        {
            uint baseDamage = CalculateBaseDamage(attacker, damageRoll, spell);
            uint baseDefense = CalculateBaseDefense(defender, ignoreShield: attacker.Weapon.IgnoresShield);
            int combatAdvantage = CalculateNonSpellCombatAdvantage(attacker, defender, spell, highGround);
            int combatAdvantageDamage = (int)Math.Floor(baseDamage * combatAdvantage / 8.0f);
            int damage = (int)Math.Floor((baseDamage + combatAdvantageDamage - baseDefense) / 2.0f);
            float criticalHitMultiplier = CalculateCriticalHitMultiplier(isCriticalHit);
            return (uint)Math.Max(damage * criticalHitMultiplier, 1);
        }
        private static uint CalculateBaseDamage(Unit attacker, byte damageRoll, Spell spell)
        {
            uint unitDamage = 2 * attacker.Stats.Attack + damageRoll;
            uint weaponFactorDamage = 2 * attacker.Weapon.WeaponDamage();
            float spellMultiplier = CalculateSpellMultiplier(attacker.Weapon, spell);
            uint spellFactorDamage = (uint)Math.Floor(
                (unitDamage + 2 * attacker.Weapon.WandDamage()) * Math.Floor(spellMultiplier * spell.Level) / (spell.Level + 1));
            return unitDamage + weaponFactorDamage + spellFactorDamage;
        }
        private static float CalculateSpellMultiplier(Weapon weaponStatistics, Spell spell)
        {
            float spellMultiplier = 1.0f;
            if (weaponStatistics.IsWand)
            { spellMultiplier += 0.5f; }
            if (weaponStatistics.Genus != Genus.None && weaponStatistics.Genus == spell.Genus)
            { spellMultiplier += 0.5f; }
            return spellMultiplier;
        }
        private static uint CalculateBaseDefense(Unit defender, bool ignoreShield)
        {
            uint frogPenalty = defender.IsFrog ? 2u : 1u;
            uint shieldDefense = ignoreShield ? 0 : defender.Shield.ShieldDefense();
            return (uint)Math.Max(Math.Floor((defender.Stats.Defense + shieldDefense) / (float)frogPenalty), 1);
        }
        private static int CalculateNonSpellCombatAdvantage(Unit attacker, Unit defender, Spell spell, int highGround)
        {
            Genus[] attackerElements = FindAttackerElements(attacker, spell);
            Genus defenderElement = FindDefenderElement(defender);
            int elementalAdvantages = (int)CalculateElementalAdvantages(attackerElements, defenderElement);
            int elementalDisadvantages = (int)CalculateElementalDisadvantages(attackerElements, defenderElement);
            return elementalAdvantages - 2 * elementalDisadvantages + highGround;
        }
        private static Genus[] FindAttackerElements(Unit attacker, Spell spell)
        {
            HashSet<Genus> elements = new HashSet<Genus> { attacker.Stats.Genus, attacker.Weapon.Genus, spell.Genus };
            elements.Remove(Genus.None);
            Genus[] attackerElements = new Genus[elements.Count];
            elements.CopyTo(attackerElements);
            return attackerElements;
        }
        private static Genus FindDefenderElement(Unit defender)
        {
            if (defender.Stats.Genus != Genus.None)
            { return defender.Stats.Genus; }
            else
            { return defender.Shield.Genus; }
        }
        private static uint CalculateElementalAdvantages(Genus[] attackerElements, Genus defenderElement)
        {
            uint elementalAdvantages = 0;
            foreach (Genus attackerElement in attackerElements)
            {
                if (HasElementalAdvantage(attackerElement, defenderElement))
                { ++elementalAdvantages; }
            }
            return elementalAdvantages;
        }
        private static bool HasElementalAdvantage(Genus attackerElement, Genus defenderElement)
        {
            return attackerElement == Genus.Fire && defenderElement == Genus.Wind ||
                attackerElement == Genus.Wind && defenderElement == Genus.Water ||
                attackerElement == Genus.Water && defenderElement == Genus.Fire;
        }
        private static uint CalculateElementalDisadvantages(Genus[] attackerElements, Genus defenderElement)
        {
            uint elementalAdvantages = 0;
            foreach (Genus attackerElement in attackerElements)
            {
                if (HasElementalDisadvantage(attackerElement, defenderElement))
                { ++elementalAdvantages; }
            }
            return elementalAdvantages;
        }
        private static bool HasElementalDisadvantage(Genus attackerElement, Genus defenderElement)
        {
            return attackerElement == Genus.Fire && defenderElement == Genus.Water ||
                attackerElement == Genus.Wind && defenderElement == Genus.Fire ||
                attackerElement == Genus.Water && defenderElement == Genus.Wind;
        }
        private static float CalculateCriticalHitMultiplier(bool isCriticalHit)
        { return isCriticalHit ? 1.5f : 1.0f; }
        private static uint NonSwordMixtureDamage(Spell spell, Unit defender)
        { return SpellAttackDamage(spell, spell.MixtureRawDamage, defender); }
        private static uint SpellAttackDamage(Spell spell, uint spellRawDamage, Unit defender)
        {
            uint baseDamage = (spellRawDamage + spell.Level) * 2;
            uint baseDefense = CalculateBaseDefense(defender, ignoreShield: false);
            int combatAdvantage = CalculateSpellCombatAdvantage(spell, defender);
            int combatDamage = (int)(baseDamage * combatAdvantage);
            if (combatAdvantage < 0)
            { combatDamage = (int)Math.Floor((combatDamage + 3) / 4.0f); }
            return (uint)Math.Max(Math.Floor((baseDamage + combatDamage - baseDefense) / 2.0f), 1u);
        }
        private static int CalculateSpellCombatAdvantage(Spell spell, Unit defender)
        {
            Genus[] attackerElement = { spell.Genus };
            Genus defenderElement = FindDefenderElement(defender);
            int elementalAdvantages = (int)CalculateElementalAdvantages(attackerElement, defenderElement);
            int elementalDisadvantages = (int)CalculateElementalDisadvantages(attackerElement, defenderElement);
            return elementalAdvantages - elementalDisadvantages;
        }
    }
}
