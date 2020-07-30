using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzureDreamsDamageCalculator
{
    public partial class MonsterControl : UserControl
    {
        private static DamageCalculator calculator = new DamageCalculator();

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
        const int DAMAGE_TEXT_BOXES_START_COLUMN = 2;
        const int DAMAGE_TEXT_BOXES_START_ROW = 4;

        private delegate uint CalculateDamageRecipe(
            Unit koh,
            Familiar familiar, 
            Monster monster, 
            Descriptor descriptor);
        private class Descriptor
        {
            public byte damageRoll;
            public int groundModifier;
            public bool criticalHit;
            public TextBox damageTextBox;
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
            int row = DAMAGE_TEXT_BOXES_START_ROW;
            foreach (CalculateDamageRecipe calculateDamageRecipe in CALCULATE_DAMAGE_RECIPES)
            {
                foreach (bool criticalHit in CRITICAL_HIT_OPTIONS)
                {
                    int column = DAMAGE_TEXT_BOXES_START_COLUMN;
                    foreach (int groundModifier in GROUND_MODIFIERS)
                    {
                        foreach (byte damageRoll in DAMAGE_ROLLS)
                        {
                            TextBox textBox = new TextBox();
                            this.mainLayout.Controls.Add(textBox, column, row);
                            textBox.Dock = DockStyle.Fill;
                            textBox.ReadOnly = true;
                            textBox.Margin = new Padding(0);
                            textBox.Text = column.ToString() + ":" + row.ToString();
                            textBox.TextAlign = HorizontalAlignment.Center;
                            Descriptor descriptor = new Descriptor();
                            descriptor.damageRoll = damageRoll;
                            descriptor.groundModifier = groundModifier;
                            descriptor.criticalHit = criticalHit;
                            descriptor.damageTextBox = textBox;
                            descriptor.calculateDamageRecipe = calculateDamageRecipe;
                            descriptors.Add(descriptor);
                            ++column;
                        }
                    }
                    ++row;
                }
            }
            this.ResumeLayout();
        }
        public void Fill(Unit koh, Familiar familiar, Monster monster)
        {
            mainGroupBox.Text = monster.name;
            pictureBox.Image = monster.image;
            hpTextBox.Text = monster.hp.ToString();
            mpTextBox.Text = monster.mp.ToString();
            genusTextBox.Text = monster.unitStatistics.genus.ToString();
            foreach (Descriptor descriptor in descriptors)
            {
                uint damage = descriptor.calculateDamageRecipe(koh, familiar, monster, descriptor);
                descriptor.damageTextBox.Text = damage.ToString();
            }
        }
        private static uint KohNormalAttackDamage(Unit koh, Familiar familiar, Monster monster, Descriptor descriptor)
        { return NonSpellAttackDamage(koh, monster, descriptor); }
        private static uint MixtureAttackDamage(Unit koh, Familiar familiar, Monster monster, Descriptor descriptor)
        { return SpellAttackDamage(koh, monster, familiar.Spell(), descriptor); }
        private static uint FamiliarAttackDamage(Unit koh, Familiar familiar, Monster monster, Descriptor descriptor)
        { return NonSpellAttackDamage(familiar, monster, descriptor); }
        private static uint VsKohAttackDamage(Unit koh, Familiar familiar, Monster monster, Descriptor descriptor)
        { return NonSpellAttackDamage(monster, koh, descriptor); }
        private static uint VsFamiliarAttackDamage(Unit koh, Familiar familiar, Monster monster, Descriptor descriptor)
        { return NonSpellAttackDamage(monster, familiar, descriptor); }
        private static uint NonSpellAttackDamage(Unit attacker, Unit defender, Descriptor descriptor)
        {
            return calculator.nonSpellAttackDamage(
                attacker, 
                defender, 
                descriptor.damageRoll, 
                descriptor.groundModifier, 
                descriptor.criticalHit);
        }
        private static uint SpellAttackDamage(Unit attacker, Unit defender, Spell spell, Descriptor descriptor)
        {
            return calculator.spellAttackDamage(
                attacker,
                defender,
                descriptor.damageRoll,
                descriptor.groundModifier,
                descriptor.criticalHit,
                spell);
        }
    }
}
