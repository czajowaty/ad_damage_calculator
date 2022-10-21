using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AzureDreamsDamageCalculator
{
    public partial class MonsterControl : UserControl
    {
        static readonly byte[] DAMAGE_ROLLS = { 0, 1, 2 };
        static readonly int[] GROUND_MODIFIERS = { 0, 1, -1 };
        static readonly bool[] CRITICAL_HIT_OPTIONS = { false, true };
        static readonly CalculateDamageRecipe[] CALCULATE_DAMAGE_RECIPES = {
            KohAttackDamage,
            Mixture1AttackDamage,
            Mixture2AttackDamage,
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
            Familiar familiar, 
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
        private class GenusDescriptor
        {
            public Genus Genus
            { get; set; }
            public PictureBox PictureBox
            { get; set; }
            public Bitmap ActiveImage
            { get; set; }
            public Bitmap InactiveImage
            { get; set; }
        }

        private List<Descriptor> descriptors = new List<Descriptor>();
        private GenusDescriptor fireGenusDescriptor;
        private GenusDescriptor waterGenusDescriptor;
        private GenusDescriptor windGenusDescriptor;
        private GenusDescriptor activeGenusDescriptor;
        private Unit koh;
        private Familiar familiar;
        private Monster monster;
        private Spell kohSpell;
        private event EventHandler AboutToBeClosed;

        public MonsterControl()
        {
            InitializeComponent();
            PrepareGenusDescriptors();
            CreateDamageTextBoxes();
            closeButton.Visible = false;
            closeButton.Click += CloseButton_Click;
        }
        public void MakeClosable(EventHandler closeEventHandler)
        {
            closeButton.Visible = true;
            AboutToBeClosed += closeEventHandler;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            AboutToBeClosed(this, EventArgs.Empty);
            Dispose();
        }

        private void PrepareGenusDescriptors()
        {
            fireGenusDescriptor = new GenusDescriptor()
            {
                Genus = Genus.Fire,
                PictureBox = fireGenusPictureBox,
                ActiveImage = Properties.Resources.genus_fire,
                InactiveImage = Properties.Resources.genus_fire_gray
            };
            waterGenusDescriptor = new GenusDescriptor()
            {
                Genus = Genus.Water,
                PictureBox = waterGenusPictureBox,
                ActiveImage = Properties.Resources.genus_water,
                InactiveImage = Properties.Resources.genus_water_gray
            };
            windGenusDescriptor = new GenusDescriptor()
            {
                Genus = Genus.Wind,
                PictureBox = windGenusPictureBox,
                ActiveImage = Properties.Resources.genus_wind,
                InactiveImage = Properties.Resources.genus_wind_gray
            };
            activeGenusDescriptor = fireGenusDescriptor;
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
        public void Fill(Unit koh, Familiar familiar, Monster monster, Spell kohSpell, bool useNativeGenus)
        {
            Genus genus = (useNativeGenus | this.monster == null) ? monster.Genus : this.monster.Genus;
            this.monster = monster.Copy();
            this.monster.Genus = genus;
            Fill(koh, familiar, kohSpell);
        }
        public void Fill(Unit koh, Familiar familiar, Spell kohSpell)
        {
            this.koh = koh;
            this.familiar = familiar;
            this.kohSpell = kohSpell;
            Fill();
        }
        private void Fill()
        {
            mainGroupBox.Text = monster.Traits.Name;
            portraitPictureBox.Image = monster.Traits.Portrait;
            SetActiveGenus(monster.Stats.Genus);
            levelTextBox.Text = monster.Level.ToString();
            hpTextBox.Text = monster.HP.ToString();
            mpTextBox.Text = monster.MP.ToString();
            attackTextBox.Text = monster.Stats.Attack.ToString();
            defenseTextBox.Text = monster.Stats.Defense.ToString();
            uint exp = monster.Stats.Exp;
            if (koh.Level < monster.Level)
            { exp *= 2; }
            expTextBox.Text = exp.ToString();
            weaponTextBox.Text = monster.Weapon.Name;
            uint weaponDamage = monster.Weapon.WeaponDamage();
            if (weaponDamage > 0)
            { weaponAtkTextBox.Text = weaponDamage.ToString(); }
            else
            { weaponAtkTextBox.Text = ""; }
            liftableCheckBox.Checked = monster.Traits.Liftable;
            pushableCheckBox.Checked = monster.Traits.Pushable;
            foreach (Descriptor descriptor in descriptors)
            {
                uint damage = descriptor.calculateDamageRecipe(koh, familiar, monster, descriptor);
                descriptor.cell.Value = DamageToString(damage);
            }
            kohSpellDamageLabel.Text = DamageToString(SpellAttackDamage(koh, monster, kohSpell));
            familiarSpell1DamageLabel.Text = DamageToString(SpellAttackDamage(familiar, monster, familiar.Spell));
            familiarSpell2DamageLabel.Text = DamageToString(SpellAttackDamage(familiar, monster, familiar.Spell2));
            monsterVsKohSpellDamageLabel.Text = DamageToString(SpellAttackDamage(monster, koh, monster.Spell));
            monsterVsFamiliarSpellDamageLabel.Text = DamageToString(SpellAttackDamage(monster, familiar, monster.Spell));
        }
        private void SetActiveGenus(Genus genus)
        {
            activeGenusDescriptor.PictureBox.BackColor = Color.Yellow;
            activeGenusDescriptor.PictureBox.Image = activeGenusDescriptor.InactiveImage;
            switch (genus)
            {
                case Genus.Fire:
                    activeGenusDescriptor = fireGenusDescriptor;
                    break;
                case Genus.Water:
                    activeGenusDescriptor = waterGenusDescriptor;
                    break;
                case Genus.Wind:
                    activeGenusDescriptor = windGenusDescriptor;
                    break;
            }
            activeGenusDescriptor.PictureBox.BackColor = Color.White;
            activeGenusDescriptor.PictureBox.Image = activeGenusDescriptor.ActiveImage;
        }
        private string DamageToString(uint damage)
        { return damage != INVALID_DAMAGE ? damage.ToString() : ""; }
        private static uint SpellAttackDamage(Unit attacker, Unit defender, Spell spell)
        {
            if (spell.IsDamagingDirectSpellType())
            { return DamageCalculator.SpellAttackDamage(spell, defender); }
            else
            { return INVALID_DAMAGE; }
        }
        private static uint KohAttackDamage(Unit koh, Familiar familiar, Monster monster, Descriptor descriptor)
        { return DirectAttackDamage(koh, monster, descriptor); }
        private static uint Mixture1AttackDamage(Unit koh, Familiar familiar, Monster monster, Descriptor descriptor)
        { return MixtureAttackDamage(koh, familiar.Spell, monster, descriptor); }
        private static uint Mixture2AttackDamage(Unit koh, Familiar familiar, Monster monster, Descriptor descriptor)
        { return MixtureAttackDamage(koh, familiar.Spell2, monster, descriptor); }
        private static uint MixtureAttackDamage(Unit koh, Spell familiarSpell, Monster monster, Descriptor descriptor)
        {
            if (familiarSpell.IsDamagingMixtureMagic())
            { return DamageCalculator.MixtureAttackDamage(koh, monster, descriptor.damageRoll, descriptor.groundModifier, descriptor.criticalHit, familiarSpell); }
            else
            { return INVALID_DAMAGE; }
        }
        private static uint FamiliarAttackDamage(Unit koh, Familiar familiar, Monster monster, Descriptor descriptor)
        { return DirectAttackDamage(familiar, monster, descriptor); }
        private static uint VsKohAttackDamage(Unit koh, Familiar familiar, Monster monster, Descriptor descriptor)
        { return DirectAttackDamage(monster, koh, descriptor); }
        private static uint VsFamiliarAttackDamage(Unit koh, Familiar familiar, Monster monster, Descriptor descriptor)
        { return DirectAttackDamage(monster, familiar, descriptor); }
        private static uint DirectAttackDamage(Unit attacker, Unit defender, Descriptor descriptor)
        {
            return DamageCalculator.DirectAttackDamage(
                attacker, 
                defender, 
                descriptor.damageRoll, 
                descriptor.groundModifier, 
                descriptor.criticalHit);
        }
        private void fireGenusPictureBox_Click(object sender, EventArgs e)
        {
            monster.Genus = Genus.Fire;
            Fill();
        }
        private void waterGenusPictureBox_Click(object sender, EventArgs e)
        {
            monster.Genus = Genus.Water;
            Fill();
        }
        private void windGenusPictureBox_Click(object sender, EventArgs e)
        {
            monster.Genus = Genus.Wind;
            Fill();
        }
    }
}
