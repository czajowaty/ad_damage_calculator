using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AzureDreamsDamageCalculator
{
    public partial class MainForm : Form
    {
        public static readonly string VERSION = "0.1.1";
        public static readonly SortedDictionary<string, Weapon> KohWeaponsNames = new SortedDictionary<string, Weapon>()
        {
            { "", Unit.NO_WEAPON },
            { "GoldSword", Swords.Gold },
            { "CopperSword", Swords.Copper },
            { "IronSword", Swords.Iron },
            { "SteelSword", Swords.Steel },
            { "VitalSword", Swords.Vital },
            { "HolySword", Swords.Holy },
            { "SeraphimSword", Swords.Seraphim },
            { "DarkSword", Swords.Dark },
            { "BlizzardSword", Swords.Blizzard },
            { "FireSword", Swords.Fire },
            { "GulfwindSword", Swords.Gulfwind },
            { "WoodenWand", Wands.Wooden },
            { "ScarletWand", Wands.Scarlet },
            { "GulfWand", Wands.Gulf },
            { "StreamWand", Wands.Stream },
            { "MoneyWand", Wands.Money },
            { "ParalyzeWand", Wands.Paralyze },
            { "LifeWand", Wands.Life },
            { "TrainedWand", Wands.Trained }
        };
        public static readonly SortedDictionary<string, Shield> KohShieldsNames = new SortedDictionary<string, Shield>()
        {
            { "", Unit.NO_SHIELD },
            { "Leather", Shields.Leather },
            { "Wood", Shields.Wood },
            { "Mirror", Shields.Mirror },
            { "Copper", Shields.Copper },
            { "Iron", Shields.Iron },
            { "Steel", Shields.Steel },
            { "Scorch", Shields.Scorch },
            { "Ice", Shields.Ice },
            { "Earth", Shields.Earth },
            { "Live", Shields.Live },
            { "Diamond", Shields.Diamond }
        };
        public static readonly SortedDictionary<string, UnitTraits> FamiliarsTraits = new SortedDictionary<string, UnitTraits>()
        {
            { "Kewne", UnitsTraits.Kewne },
            //{ "Dragon", UnitsTraits.Dragon },
            { "Kid", UnitsTraits.Kid },
            //{ "Ifrit", UnitsTraits.Ifrit },
            { "Flame", UnitsTraits.Flame },
            //{ "Grineut", UnitsTraits.Grineut },
            { "Griffon", UnitsTraits.Griffon },
            //{ "Saber", UnitsTraits.Saber },
            { "Snowman", UnitsTraits.Snowman },
            //{ "Ashra", UnitsTraits.Ashra },
            { "Arachne", UnitsTraits.Arachne },
            //{ "Battnel", UnitsTraits.Battnel },
            { "Nyuel", UnitsTraits.Nyuel },
            //{ "Death", UnitsTraits.Death },
            { "Clown", UnitsTraits.Clown },
            //{ "Univern", UnitsTraits.Univern },
            { "Unicorn", UnitsTraits.Unicorn },
            //{ "Metal", UnitsTraits.Metal },
            { "Block", UnitsTraits.Block },
            { "Pulunpa", UnitsTraits.Pulunpa },
            { "Troll", UnitsTraits.Troll },
            { "Noise", UnitsTraits.Noise },
            { "U-Boat", UnitsTraits.UBoat },
            { "Baloon", UnitsTraits.Baloon },
            { "Dreamin", UnitsTraits.Dreamin },
            { "Blume", UnitsTraits.Blume },
            { "Volcano", UnitsTraits.Volcano },
            { "Cyclone", UnitsTraits.Cyclone },
            { "Manoeva", UnitsTraits.Manoeva },
            { "Barong", UnitsTraits.Barong },
            { "Picket", UnitsTraits.Picket },
            { "Kraken", UnitsTraits.Kraken },
            { "Weadog", UnitsTraits.Weadog },
            { "Stealth", UnitsTraits.Stealth },
            { "Viper", UnitsTraits.Viper },
            { "Naplass", UnitsTraits.Naplass },
            { "Zu", UnitsTraits.Zu },
            { "Mandara", UnitsTraits.Mandara },
            { "Killer", UnitsTraits.Killer },
            { "Garuda", UnitsTraits.Garuda },
            { "Glacier", UnitsTraits.Glacier },
            { "Tyrant", UnitsTraits.Tyrant },
            { "Golem", UnitsTraits.Golem },
            { "Maximum", UnitsTraits.Maximum }
        };
        public static readonly SortedDictionary<string, Genus> GenusNames = new SortedDictionary<string, Genus>()
        {
            { Genus.Fire.ToString(), Genus.Fire },
            { Genus.Water.ToString(), Genus.Water },
            { Genus.Wind.ToString(), Genus.Wind }
        };

        private Unit koh = new Unit();
        private Familiar familiar = new Familiar();
        private UnitTraits familiarTraits = new UnitTraits();
        private MonsterControl[] monsterControls = new MonsterControl[0];
        private bool updateMonstersControlBlocked = false;

        public MainForm()
        {
            InitializeComponent();
            Text += " " + VERSION;
            CreateMonsterControls();
            FillComboBox(kohWeaponComboBox, KohWeaponsNames.Keys);
            FillComboBox(kohShieldComboBox, KohShieldsNames.Keys);
            FillComboBox(familiarGenusComboBox, GenusNames.Keys);
            FillComboBox(familiarTypeComboBox, FamiliarsTraits.Keys);
            familiarTypeComboBox.SelectedItem = "Kewne";
            UpdateKoh();
            UpdateFamiliar();
        }

        private void FillComboBox(ComboBox comboBox, IEnumerable<string> items)
        {
            comboBox.Items.AddRange(items.ToArray<string>());
            comboBox.SelectedIndex = 0;
        }
        private void UpdateKoh()
        {
            SetKohStatistics();
            SetKohWeapon();
            SetKohShield();
        }
        private void SetKohStatistics()
        {
            UnitStatistics unitStatistics = UnitsTraits.Koh.calculateUnitStatistics((uint)kohLevelNumericUpDown.Value);
            unitStatistics.attack = ModifiedStat(unitStatistics.attack, (int)kohAttackModifierNumericUpDown.Value);
            unitStatistics.defense = ModifiedStat(unitStatistics.defense, (int)kohDefenseModifierNumericUpDown.Value);
            koh.unitStatistics = unitStatistics;
            kohAttackTextBox.Text = unitStatistics.attack.ToString();
            kohDefenseTextBox.Text = unitStatistics.defense.ToString();
            UpdateMonsterControls();
        }
        private uint ModifiedStat(uint stat, int modifier)
        { return (uint)Math.Max(stat + modifier, 1u); }
        private void SetKohWeapon()
        {
            string weaponName = kohWeaponComboBox.SelectedItem.ToString();
            koh.weapon = KohWeaponsNames[weaponName];
            SetKohWeaponQuality();
        }
        private void SetKohWeaponQuality()
        {
            koh.weapon.SetQuality((int)kohWeaponQualityNumericUpDown.Value);
            UpdateMonsterControls();
        }
        private void SetKohShield()
        {
            string shieldName = kohShieldComboBox.SelectedItem.ToString();
            koh.shield = KohShieldsNames[shieldName];
            SetKohShieldQuality();
        }
        private void SetKohShieldQuality()
        {
            koh.shield.quality = (int)kohShieldQualityNumericUpDown.Value;
            UpdateMonsterControls();
        }
        private void UpdateFamiliar()
        { SetFamiliarType(); }
        private void SetFamiliarType()
        {
            string familiarType = familiarTypeComboBox.SelectedItem.ToString();
            familiarTraits = FamiliarsTraits[familiarType];
            familiarGenusComboBox.SelectedItem = familiarTraits.nativeGenus.ToString();
            SetFamiliarStatistics();
        }
        private void SetFamiliarStatistics()
        {
            uint familiarLevel = (uint)familiarLevelNumericUpDown.Value;
            UnitStatistics unitStatistics = familiarTraits.calculateUnitStatistics(familiarLevel);
            unitStatistics.attack = ModifiedStat(unitStatistics.attack, (int)familiarAttackModifierNumericUpDown.Value);
            unitStatistics.defense = ModifiedStat(unitStatistics.defense, (int)familiarDefenseModifierNumericUpDown.Value);
            unitStatistics.genus = GenusNames[familiarGenusComboBox.SelectedItem.ToString()];
            familiar.spellLevel = ModifiedStat(familiarLevel, (int)familiarSpellLevelModifierNumericUpDown.Value);
            familiar.unitStatistics = unitStatistics;
            familiarAttackTextBox.Text = unitStatistics.attack.ToString();
            familiarDefenseTextBox.Text = unitStatistics.defense.ToString();
            familiarSpellLevelTextBox.Text = familiar.spellLevel.ToString();
            UpdateMonsterControls();
        }
        private void CreateMonsterControls()
        {
            int newMonstersNumber = MonstersOnSelectedFloor().Length;
            if (newMonstersNumber > monsterControls.Length)
            {
                int prevMonsterControlsLength = monsterControls.Length;
                Array.Resize(ref monsterControls, newMonstersNumber);
                for (int i = prevMonsterControlsLength; i < monsterControls.Length; ++i)
                { monsterControls[i] = new MonsterControl(); }
            }
            int prevMonstersNumber = monsterControlsFlowLayoutPanel.Controls.Count;
            if (newMonstersNumber > prevMonstersNumber)
            {
                for (int i = prevMonstersNumber; i < newMonstersNumber; ++i)
                { monsterControlsFlowLayoutPanel.Controls.Add(monsterControls[i]); }
            }
            else if (newMonstersNumber < prevMonstersNumber)
            {
                while (monsterControlsFlowLayoutPanel.Controls.Count > newMonstersNumber)
                { monsterControlsFlowLayoutPanel.Controls.RemoveAt(monsterControlsFlowLayoutPanel.Controls.Count - 1); }
            }
        }
        private Monster[] MonstersOnSelectedFloor()
        {
            uint floor = (uint)floorNumericUpDown.Value - 1;
            return Monsters.PerFloor[floor];
        }
        private void UpdateMonsterControls()
        {
            if (updateMonstersControlBlocked)
            { return; }
            Monster[] monstersOnSelectedFloor = MonstersOnSelectedFloor();
            for (int i = 0; i < monstersOnSelectedFloor.Length; ++i)
            { monsterControls[i].Fill(koh, familiar, monstersOnSelectedFloor[i]); }
        }
        private void kohLevelNumericUpDown_ValueChanged(object sender, EventArgs e)
        { SetKohStatistics(); }
        private void kohFrogCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            koh.isFrog = kohFrogCheckBox.Checked;
            UpdateMonsterControls();
        }
        private void kohAttackModifierNumericUpDown_ValueChanged(object sender, EventArgs e)
        { SetKohStatistics(); }
        private void kohDefenseModifierNumericUpDown_ValueChanged(object sender, EventArgs e)
        { SetKohStatistics(); }
        private void kohWeaponComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        { SetKohWeapon(); }
        private void kohWeaponQualityNumericUpDown_ValueChanged(object sender, System.EventArgs e)
        { SetKohWeaponQuality(); }
        private void kohShieldComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        { SetKohShield(); }
        private void kohShieldQualityNumericUpDown_ValueChanged(object sender, System.EventArgs e)
        { SetKohShieldQuality(); }
        private void familiarTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        { SetFamiliarType(); }
        private void familiarGenusComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        { SetFamiliarStatistics(); }
        private void familiarAttackModifierNumericUpDown_ValueChanged(object sender, EventArgs e)
        { SetFamiliarStatistics(); }
        private void familiarDefenseModifierNumericUpDown_ValueChanged(object sender, EventArgs e)
        { SetFamiliarStatistics(); }
        private void familiarLevelNumericUpDown_ValueChanged(object sender, EventArgs e)
        { SetFamiliarStatistics(); }
        private void familiarSpellLevelModifierNumericUpDown_ValueChanged(object sender, EventArgs e)
        { SetFamiliarStatistics(); }
        private void familiarFrogCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            familiar.isFrog = familiarFrogCheckBox.Checked;
            UpdateMonsterControls();
        }
        private void floorNumericUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            monsterControlsFlowLayoutPanel.SuspendLayout();
            CreateMonsterControls();
            UpdateMonsterControls();
            monsterControlsFlowLayoutPanel.ResumeLayout();
        }
        private void levelUpKohFamiliarButton_Click(object sender, EventArgs e)
        {
            updateMonstersControlBlocked = true;
            kohLevelNumericUpDown.Value += 1;
            familiarLevelNumericUpDown.Value += 1;
            updateMonstersControlBlocked = false;
            UpdateMonsterControls();
        }
    }
}
