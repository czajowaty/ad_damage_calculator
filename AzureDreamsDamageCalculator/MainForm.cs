using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AzureDreamsDamageCalculator
{
    public partial class MainForm : Form
    {
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
        public static readonly SortedDictionary<string, Genus> GenusNames = new SortedDictionary<string, Genus>()
        {
            { Genus.Fire.ToString(), Genus.Fire },
            { Genus.Water.ToString(), Genus.Water },
            { Genus.Wind.ToString(), Genus.Wind }
        };

        private Unit koh = new Unit();
        private Familiar familiar = new Familiar();
        private MonsterControl[] monsterControls = new MonsterControl[0];

        public MainForm()
        {
            InitializeComponent();
            CreateMonsterControls();
            FillComboBox(kohWeaponComboBox, KohWeaponsNames.Keys);
            FillComboBox(kohShieldComboBox, KohShieldsNames.Keys);
            FillComboBox(familiarGenusComboBox, GenusNames.Keys);
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
            koh.unitStatistics.attack = (uint)kohAttackNumericUpDown.Value;
            koh.unitStatistics.defense = (uint)kohDefenseNumericUpDown.Value;
            UpdateMonsterControls();
        }
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
        { SetFamiliarStatistics(); }
        private void SetFamiliarStatistics()
        {
            familiar.unitStatistics.attack = (uint)familiarAttackNumericUpDown.Value;
            familiar.unitStatistics.defense = (uint)familiarDefenseNumericUpDown.Value;
            familiar.unitStatistics.genus = GenusNames[familiarGenusComboBox.SelectedItem.ToString()];
            familiar.spellLevel = (uint)familiarSpellLevelNumericUpDown.Value;
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
                System.Console.WriteLine("Padding: " + monsterControls[0].Padding.ToString());
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
            Monster[] monstersOnSelectedFloor = MonstersOnSelectedFloor();
            for (int i = 0; i < monstersOnSelectedFloor.Length; ++i)
            { monsterControls[i].Fill(koh, familiar, monstersOnSelectedFloor[i]); }
        }
        private void kohAttackNumericUpDown_ValueChanged(object sender, System.EventArgs e)
        { SetKohStatistics(); }
        private void kohDefenseNumericUpDown_ValueChanged(object sender, System.EventArgs e)
        { SetKohStatistics(); }
        private void kohWeaponComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        { SetKohWeapon(); }
        private void kohWeaponQualityNumericUpDown_ValueChanged(object sender, System.EventArgs e)
        { SetKohWeaponQuality(); }
        private void kohShieldComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        { SetKohShield(); }
        private void kohShieldQualityNumericUpDown_ValueChanged(object sender, System.EventArgs e)
        { SetKohShieldQuality(); }
        private void familiarAttackNumericUpDown_ValueChanged(object sender, System.EventArgs e)
        { SetFamiliarStatistics();  }
        private void familiarDefenseNumericUpDown_ValueChanged(object sender, System.EventArgs e)
        { SetFamiliarStatistics(); }
        private void familiarGenusComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        { SetFamiliarStatistics(); }
        private void familiarSpellLevelNumericUpDown_ValueChanged(object sender, System.EventArgs e)
        { SetFamiliarStatistics(); }
        private void floorNumericUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            monsterControlsFlowLayoutPanel.SuspendLayout();
            CreateMonsterControls();
            UpdateMonsterControls();
            monsterControlsFlowLayoutPanel.ResumeLayout();
        }
        private void kohFrogCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            koh.isFrog = kohFrogCheckBox.Checked;
            UpdateMonsterControls();
        }
        private void familiarFrogCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            familiar.isFrog = familiarFrogCheckBox.Checked;
            UpdateMonsterControls();
        }
    }
}
