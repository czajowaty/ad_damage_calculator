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
            public Label damageLabel;
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
            int index = 0;
            foreach (CalculateDamageRecipe calculateDamageRecipe in CALCULATE_DAMAGE_RECIPES)
            {
                foreach (bool criticalHit in CRITICAL_HIT_OPTIONS)
                {
                    int column = DAMAGE_TEXT_BOXES_START_COLUMN;
                    foreach (int groundModifier in GROUND_MODIFIERS)
                    {
                        foreach (byte damageRoll in DAMAGE_ROLLS)
                        {
                            Label label = new Label();
                            this.mainLayout.Controls.Add(label, column, row);
                            label.BackColor = DamageLabelColor(calculateDamageRecipe, criticalHit, groundModifier, damageRoll);
                            label.Dock = DockStyle.Fill;
                            label.Font = new Font(label.Font.FontFamily, 10.0f);
                            label.Margin = new Padding(0);
                            label.Text = column.ToString() + ":" + row.ToString();
                            label.TextAlign = ContentAlignment.MiddleCenter;
                            Descriptor descriptor = new Descriptor();
                            descriptor.damageRoll = damageRoll;
                            descriptor.groundModifier = groundModifier;
                            descriptor.criticalHit = criticalHit;
                            descriptor.damageLabel = label;
                            descriptor.calculateDamageRecipe = calculateDamageRecipe;
                            descriptors.Add(descriptor);
                            ++column;
                            ++index;
                        }
                    }
                    ++row;
                }
            }
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
                descriptor.damageLabel.Text = damage.ToString();
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
