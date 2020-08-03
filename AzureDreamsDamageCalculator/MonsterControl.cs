using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AzureDreamsDamageCalculator
{
    public partial class MonsterControl : UserControl
    {
        static readonly byte[] DAMAGE_ROLLS = { 0, 1, 2 };
        static readonly int[] GROUND_MODIFIERS = { 0, 1, -1 };
        static readonly bool[] CRITICAL_HIT_OPTIONS = { false, true };
        static readonly CalculateDamageRecipe[] CALCULATE_DAMAGE_RECIPES = {
            KohNormalAttackDamage,
            MixtureAttackDamage,
            FamiliarAttackDamage,
            VsKohAttackDamage,
            VsFamiliarAttackDamage
        };
        static readonly Dictionary<Genus, Bitmap> GenusImageMapping = new Dictionary<Genus, Bitmap>()
        {
            { Genus.Fire, Properties.Resources.genus_fire },
            { Genus.Water, Properties.Resources.genus_water },
            { Genus.Wind, Properties.Resources.genus_wind },
        };
        static readonly uint INVALID_DAMAGE = 0xFFFFFFFF;

        private delegate uint CalculateDamageRecipe(
            Unit koh,
            Unit familiar, 
            Monster monster, 
            Descriptor descriptor);
        private class Descriptor
        {
            public DataGridViewCell cell;
            public byte damageRoll;
            public int groundModifier;
            public bool criticalHit;
            public CalculateDamageRecipe calculateDamageRecipe;
        }

        private List<Descriptor> descriptors = new List<Descriptor>();

        public MonsterControl()
        {
            InitializeComponent();
            CreateDamageTextBoxes();
        }
        private void CreateDamageTextBoxes()
        {
            this.SuspendLayout();
            int row = 0;
            int index = 0;
            foreach (CalculateDamageRecipe calculateDamageRecipe in CALCULATE_DAMAGE_RECIPES)
            {
                foreach (bool criticalHit in CRITICAL_HIT_OPTIONS)
                {
                    damageGridView.Rows.Add();
                    int column = 0;
                    foreach (int groundModifier in GROUND_MODIFIERS)
                    {
                        foreach (byte damageRoll in DAMAGE_ROLLS)
                        {
                            Descriptor descriptor = new Descriptor();
                            descriptor.cell = damageGridView[column, row];
                            descriptor.cell.Style.BackColor = DamageLabelColor(calculateDamageRecipe, criticalHit, groundModifier, damageRoll);
                            descriptor.damageRoll = damageRoll;
                            descriptor.groundModifier = groundModifier;
                            descriptor.criticalHit = criticalHit;
                            descriptor.calculateDamageRecipe = calculateDamageRecipe;
                            descriptors.Add(descriptor);
                            ++column;
                            ++index;
                        }
                    }
                    ++row;
                }
            }
            int rowHeight = damageGridView.Height / damageGridView.RowCount;
            for (int i = 0; i < damageGridView.RowCount; ++i)
            { damageGridView.Rows[i].Height = rowHeight; }
            damageGridView.SelectionChanged += DamageGridView_SelectionChanged;
            this.ResumeLayout();
        }
        private Color DamageLabelColor(CalculateDamageRecipe calculateDamageRecipe, bool criticalHit, int groundModifier, byte damageRoll)
        {
            if (criticalHit || damageRoll != 1)
            { return Color.White; }
            if (groundModifier == 0)
            { return Color.DeepSkyBlue; }
            else
            {
                bool isMonsterAttack = calculateDamageRecipe == VsKohAttackDamage || calculateDamageRecipe == VsFamiliarAttackDamage;
                if (groundModifier == 1)
                { return isMonsterAttack ? Color.Red : Color.LawnGreen; }
                else
                { return isMonsterAttack ? Color.LawnGreen : Color.Red; }
            }
        }
        private void DamageGridView_SelectionChanged(object sender, EventArgs e)
        { damageGridView.ClearSelection(); }
        public void Fill(Unit koh, Unit familiar, Monster monster)
        {
            mainGroupBox.Text = monster.Traits.Name;
            portraitPictureBox.Image = monster.Traits.Portrait;
            genusPictureBox.Image = GenusImageMapping[monster.Stats.Genus];
            levelTextBox.Text = monster.Level.ToString();
            hpTextBox.Text = monster.HP.ToString();
            mpTextBox.Text = monster.MP.ToString();
            attackTextBox.Text = monster.Stats.Attack.ToString();
            defenseTextBox.Text = monster.Stats.Defense.ToString();
            weaponTextBox.Text = monster.Weapon.Name;
            liftableCheckBox.Checked = monster.Traits.Liftable;
            pushableCheckBox.Checked = monster.Traits.Pushable;
            foreach (Descriptor descriptor in descriptors)
            {
                uint damage = descriptor.calculateDamageRecipe(koh, familiar, monster, descriptor);
                descriptor.cell.Value = DamageToString(damage);
            }
            kohSpellDamageLabel.Text = DamageToString(SpellAttackDamage(koh, monster));
            familiarSpellDamageLabel.Text = DamageToString(SpellAttackDamage(familiar, monster));
            monsterSpellDamageLabel.Text = DamageToString(SpellAttackDamage(monster, koh));
        }
        private string DamageToString(uint damage)
        { return damage != INVALID_DAMAGE ? damage.ToString() : ""; }
        private static uint SpellAttackDamage(Unit attacker, Unit defender)
        {
            if (attacker.HasSpell())
            { return DamageCalculator.spellAttackDamage(attacker, defender); }
            else
            { return INVALID_DAMAGE; }
        }
        private static uint KohNormalAttackDamage(Unit koh, Unit familiar, Monster monster, Descriptor descriptor)
        { return NonSpellAttackDamage(koh, monster, descriptor); }
        private static uint MixtureAttackDamage(Unit koh, Unit familiar, Monster monster, Descriptor descriptor)
        {
            if (familiar.HasSpell())
            {
                return DamageCalculator.mixtureAttackDamage(
                    koh,
                    monster,
                    descriptor.damageRoll,
                    descriptor.groundModifier,
                    descriptor.criticalHit,
                    familiar.Spell);
            }
            else
            { return INVALID_DAMAGE; }
        }
        private static uint FamiliarAttackDamage(Unit koh, Unit familiar, Monster monster, Descriptor descriptor)
        { return NonSpellAttackDamage(familiar, monster, descriptor); }
        private static uint VsKohAttackDamage(Unit koh, Unit familiar, Monster monster, Descriptor descriptor)
        { return NonSpellAttackDamage(monster, koh, descriptor); }
        private static uint VsFamiliarAttackDamage(Unit koh, Unit familiar, Monster monster, Descriptor descriptor)
        { return NonSpellAttackDamage(monster, familiar, descriptor); }
        private static uint NonSpellAttackDamage(Unit attacker, Unit defender, Descriptor descriptor)
        {
            return DamageCalculator.standardAttackDamage(
                attacker, 
                defender, 
                descriptor.damageRoll, 
                descriptor.groundModifier, 
                descriptor.criticalHit);
        }
    }
}
