using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AzureDreamsDamageCalculator
{
    public partial class MainForm : Form
    {
        public static readonly string VERSION = "0.2";
        public static readonly SortedDictionary<string, Weapon> KohWeaponsNames = CreateNamedDictionary(
            new[]
            {
                Weapon.NO_WEAPON,
                Swords.Gold,
                Swords.Copper,
                Swords.Iron,
                Swords.Steel,
                Swords.Vital,
                Swords.Holy,
                Swords.Seraphim,
                Swords.Dark,
                Swords.Blizzard,
                Swords.Fire,
                Swords.Gulfwind,
                Wands.Wooden,
                Wands.Scarlet,
                Wands.Gulf,
                Wands.Stream,
                Wands.Money,
                Wands.Paralyze,
                Wands.Life,
                Wands.Trained
            });
        public static readonly SortedDictionary<string, Shield> KohShieldsNames = CreateNamedDictionary(
            new[]
            {
                Shield.NO_SHIELD,
                Shields.Leather,
                Shields.Wood,
                Shields.Mirror,
                Shields.Copper,
                Shields.Iron,
                Shields.Steel,
                Shields.Scorch,
                Shields.Ice,
                Shields.Earth,
                Shields.Live,
                Shields.Diamond
            });
        public static readonly SortedDictionary<string, UnitTraits> FamiliarsTraits = CreateNamedDictionary(
            new[]
            {
                UnitsTraits.Kewne,
                UnitsTraits.Dragon ,
                UnitsTraits.Kid,
                UnitsTraits.Ifrit,
                UnitsTraits.Flame,
                UnitsTraits.Grineut,
                UnitsTraits.Griffon,
                UnitsTraits.Saber,
                UnitsTraits.Snowman,
                UnitsTraits.Ashra,
                UnitsTraits.Arachne,
                UnitsTraits.Battnel,
                UnitsTraits.Nyuel,
                UnitsTraits.Death,
                UnitsTraits.Clown,
                UnitsTraits.Univern,
                UnitsTraits.Unicorn,
                UnitsTraits.Metal,
                UnitsTraits.Block,
                UnitsTraits.Pulunpa,
                UnitsTraits.Troll,
                UnitsTraits.Noise,
                UnitsTraits.UBoat,
                UnitsTraits.Balloon,
                UnitsTraits.Dreamin,
                UnitsTraits.Blume,
                UnitsTraits.Volcano,
                UnitsTraits.Cyclone,
                UnitsTraits.Manoeva,
                UnitsTraits.Barong,
                UnitsTraits.Picket,
                UnitsTraits.Kraken,
                UnitsTraits.Weadog,
                UnitsTraits.Stealth,
                UnitsTraits.Viper,
                UnitsTraits.Naplass,
                UnitsTraits.Zu,
                UnitsTraits.Mandara,
                UnitsTraits.Killer,
                UnitsTraits.Garuda,
                UnitsTraits.Glacier,
                UnitsTraits.Tyrant,
                UnitsTraits.Golem,
                UnitsTraits.Maximum
            });
        public static readonly SortedDictionary<string, SpellTraits> KohSpells = CreateNamedDictionary(
            new []{ SpellsTraits.FireBall, SpellsTraits.BlazeBall, SpellsTraits.FlameBall, SpellsTraits.PillarBall, SpellsTraits.AcidRainBall });
        public static readonly SortedDictionary<string, SpellTraits> FamiliarSpells = CreateNamedDictionary(
            new[] { SpellTraits.EMPTY, SpellsTraits.Breath, SpellsTraits.Sled, SpellsTraits.Brid, SpellsTraits.Rise, SpellsTraits.Grave });
        public static readonly SortedDictionary<string, Genus> GenusNames = new SortedDictionary<string, Genus>()
        {
            { Genus.Fire.ToString(), Genus.Fire },
            { Genus.Water.ToString(), Genus.Water },
            { Genus.Wind.ToString(), Genus.Wind }
        };
        public static readonly SortedDictionary<string, SpecialTraits> FamiliarSpecialTraits = new SortedDictionary<string, SpecialTraits>()
        {
            { "", SpecialTraits.None },
            { "Double ATK", SpecialTraits.DoubleAttack },
            { "Double DEF", SpecialTraits.DoubleDefense },
            { "Double spell growth", SpecialTraits.DoubleSpellGrowth }
        };
        private static SortedDictionary<string, T> CreateNamedDictionary<T>(T[] namedEntities) where T : Named
        {
            SortedDictionary<string, T> namedDictionary = new SortedDictionary<string, T>();
            foreach (T namedEntity in namedEntities)
            { namedDictionary[namedEntity.Name] = namedEntity; }
            return namedDictionary;
        }

        private Unit koh = new Unit(UnitsTraits.Koh);
        private Unit familiar;
        private MonsterControl[] monsterControls = new MonsterControl[0];

        public MainForm()
        {
            InitializeComponent();
            Text += " " + VERSION;
            CreateMonsterControls();
            FillComboBox(kohWeaponComboBox, KohWeaponsNames.Keys);
            FillComboBox(kohShieldComboBox, KohShieldsNames.Keys);
            FillComboBox(kohSpellComboBox, KohSpells.Keys);
            FillComboBox(familiarTypeComboBox, FamiliarsTraits.Keys);
            FillComboBox(familiarGenusComboBox, GenusNames.Keys);
            FillComboBox(familiarSpellComboBox, FamiliarSpells.Keys);
            FillComboBox(familiarSpecialTraitComboBox, FamiliarSpecialTraits.Keys);
            ResetUI();
            AddUIDelegatesHandlers();
            UpdateMonsterControls();
        }
        private void ResetUI()
        {
            kohLevelNumericUpDown.Value = 1;
            kohFrogCheckBox.Checked = false;
            kohAttackModifierNumericUpDown.Value = 0;
            kohDefenseModifierNumericUpDown.Value = 0;
            kohWeaponComboBox.SelectedItem = Swords.Copper.Name;
            kohWeaponQualityNumericUpDown.Value = 0;
            kohShieldComboBox.SelectedItem = Shields.Wood.Name;
            kohShieldQualityNumericUpDown.Value = 0;
            kohSpellComboBox.SelectedItem = SpellsTraits.FlameBall.Name;
            familiarSpecialTraitComboBox.SelectedIndex = 0;
            familiarTypeComboBox.SelectedItem = UnitsTraits.Kewne.Name;
            familiarFrogCheckBox.Checked = false;
            familiarLevelNumericUpDown.Value = 1;
            familiarSpellLevelModifierNumericUpDown.Value = 0;
            familiarSpellComboBox.SelectedItem = UnitsTraits.Kewne.NativeSpell.Name;
            familiarAttackModifierNumericUpDown.Value = 0;
            familiarDefenseModifierNumericUpDown.Value = 0;
            UpdateKoh();
            UpdateFamiliar();
        }
        private void AddUIDelegatesHandlers()
        {
            this.kohLevelNumericUpDown.ValueChanged += new System.EventHandler(this.kohLevelNumericUpDown_ValueChanged);
            this.kohFrogCheckBox.CheckedChanged += new System.EventHandler(this.kohFrogCheckBox_CheckedChanged);
            this.kohAttackModifierNumericUpDown.ValueChanged += new System.EventHandler(this.kohAttackModifierNumericUpDown_ValueChanged);
            this.kohDefenseModifierNumericUpDown.ValueChanged += new System.EventHandler(this.kohDefenseModifierNumericUpDown_ValueChanged);
            this.kohShieldQualityNumericUpDown.ValueChanged += new System.EventHandler(this.kohShieldQualityNumericUpDown_ValueChanged);
            this.kohShieldComboBox.SelectedIndexChanged += new System.EventHandler(this.kohShieldComboBox_SelectedIndexChanged);
            this.kohWeaponComboBox.SelectedIndexChanged += new System.EventHandler(this.kohWeaponComboBox_SelectedIndexChanged);
            this.kohWeaponQualityNumericUpDown.ValueChanged += new System.EventHandler(this.kohWeaponQualityNumericUpDown_ValueChanged);
            this.kohSpellComboBox.SelectedIndexChanged += new System.EventHandler(this.kohSpellComboBox_SelectedIndexChanged);
            this.familiarTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.familiarTypeComboBox_SelectedIndexChanged);
            this.familiarGenusComboBox.SelectedIndexChanged += new System.EventHandler(this.familiarGenusComboBox_SelectedIndexChanged);
            this.familiarFrogCheckBox.CheckedChanged += new System.EventHandler(this.familiarFrogCheckBox_CheckedChanged);
            this.familiarLevelNumericUpDown.ValueChanged += new System.EventHandler(this.familiarLevelNumericUpDown_ValueChanged);
            this.familiarSpellLevelModifierNumericUpDown.ValueChanged += new System.EventHandler(this.familiarSpellLevelModifierNumericUpDown_ValueChanged);
            this.familiarSpellComboBox.SelectedIndexChanged += new System.EventHandler(this.familiarSpellComboBox_SelectedIndexChanged);
            this.familiarSpecialTraitComboBox.SelectedIndexChanged += new System.EventHandler(this.familiarTraitComboBox_SelectedIndexChanged);
            this.familiarAttackModifierNumericUpDown.ValueChanged += new System.EventHandler(this.familiarAttackModifierNumericUpDown_ValueChanged);
            this.familiarDefenseModifierNumericUpDown.ValueChanged += new System.EventHandler(this.familiarDefenseModifierNumericUpDown_ValueChanged);
        }
        private void FillComboBox(ComboBox comboBox, IEnumerable<string> items)
        {
            comboBox.Items.AddRange(items.ToArray<string>());
            comboBox.SelectedIndex = 0;
        }
        private void UpdateKoh()
        {
            SetKohFrogStatus();
            CalculateKohStatistics();
            SetKohWeapon();
            SetKohShield();
            SetKohSpell();
        }
        private void SetKohFrogStatus()
        { koh.IsFrog = kohFrogCheckBox.Checked; }
        private void CalculateKohStatistics()
        {
            koh.Level = (uint)kohLevelNumericUpDown.Value;
            CalculateUnitBaseStats(koh);
            ModifyKohStats();
            SetKohSpellLevel();
        }
        private void ModifyKohStats()
        {
            koh.Stats.AttackModifier = (int)kohAttackModifierNumericUpDown.Value;
            kohAttackTextBox.Text = koh.Stats.Attack.ToString();
            koh.Stats.DefenseModifier = (int)kohDefenseModifierNumericUpDown.Value;
            kohDefenseTextBox.Text = koh.Stats.Defense.ToString();
        }
        private void SetKohWeapon()
        {
            string weaponName = kohWeaponComboBox.SelectedItem.ToString();
            koh.Weapon = KohWeaponsNames[weaponName];
            SetKohWeaponQuality();
        }
        private void SetKohWeaponQuality()
        { koh.Weapon.Quality = (int)kohWeaponQualityNumericUpDown.Value; }
        private void SetKohShield()
        {
            string shieldName = kohShieldComboBox.SelectedItem.ToString();
            koh.Shield = KohShieldsNames[shieldName];
            SetKohShieldQuality();
        }
        private void SetKohShieldQuality()
        { koh.Shield.Quality = (int)kohShieldQualityNumericUpDown.Value; }
        private void SetKohSpell()
        {
            string kohSpellName = kohSpellComboBox.SelectedItem.ToString();
            koh.Spell = new Spell(KohSpells[kohSpellName]);
            SetKohSpellLevel();
        }
        private void SetKohSpellLevel()
        { koh.Spell.BaseLevel = koh.Level * 4; }
        private void UpdateFamiliar()
        { SetFamiliarType(); }
        private void SetFamiliarType()
        {
            string familiarType = familiarTypeComboBox.SelectedItem.ToString();
            CreateFamiliar(FamiliarsTraits[familiarType]);
            familiarGenusComboBox.SelectedItem = familiar.Stats.Genus.ToString();
            familiarSpellComboBox.SelectedItem = familiar.Spell.Name;
        }
        private void CreateFamiliar(UnitTraits traits)
        {
            familiar = new Unit(traits, traits.NativeSpell);
            familiar.Stats.Genus = traits.NativeGenus;
            SetFamiliarFrogStatus();
            SetFamiliarLevel(initialize: true);
            ModifyFamiliarSpellLevel();
            CalculateFamiliarStats();
        }
        private void SetFamiliarGenus()
        {
            Genus genus = GenusNames[familiarGenusComboBox.SelectedItem.ToString()];
            familiar.Stats.Genus = genus;
            familiar.Spell.Genus = genus;
            familiarSpellLockedCheckBox.Checked = !familiar.IsNativeGenus;
        }
        private void SetFamiliarFrogStatus()
        { familiar.IsFrog = kohFrogCheckBox.Checked; }
        private void SetFamiliarLevel(bool initialize = false)
        {
            uint newLevel = (uint)familiarLevelNumericUpDown.Value;
            int levelDifference = initialize ? 0 : (int)(newLevel - familiar.Level);
            familiar.Level = newLevel;
            familiar.Spell.BaseLevel = familiar.Level;
            if (familiarSpellLockedCheckBox.Checked)
            {
                int spellLevelModifier = (int)familiarSpellLevelModifierNumericUpDown.Value;
                familiarSpellLevelModifierNumericUpDown.Value = spellLevelModifier - levelDifference;
            }
            else if (familiar.HasDoubleSpellGrowth())
            {
                int spellLevelModifier = (int)familiarSpellLevelModifierNumericUpDown.Value;
                familiarSpellLevelModifierNumericUpDown.Value = spellLevelModifier + levelDifference;
            }
            ModifyFamiliarSpellLevel();
            CalculateFamiliarStats();
            ModifyFamiliarStats();
        }
        private void SetFamiliarSpell()
        {
            string spellTraits = familiarSpellComboBox.SelectedItem.ToString();
            familiar.Spell = new Spell(FamiliarSpells[spellTraits], familiar.Level);
            ModifyFamiliarSpellLevel();
        }
        private void ModifyFamiliarSpellLevel()
        {
            familiar.Spell.LevelModifier = (int)familiarSpellLevelModifierNumericUpDown.Value;
            familiarSpellLevelTextBox.Text = familiar.Spell.Level.ToString();
        }
        private void CalculateFamiliarStats()
        {
            CalculateUnitBaseStats(familiar);
            ModifyFamiliarStats();
        }
        private void ModifyFamiliarStats()
        {
            familiar.Stats.AttackModifier = (int)familiarAttackModifierNumericUpDown.Value;
            familiarAttackTextBox.Text = familiar.Stats.Attack.ToString();
            familiar.Stats.DefenseModifier = (int)familiarDefenseModifierNumericUpDown.Value;
            familiarDefenseTextBox.Text = familiar.Stats.Defense.ToString();
        }
        private void CalculateUnitBaseStats(Unit unit)
        {
            unit.Stats.BaseAttack = StatsCalculator.Attack(unit.Traits, unit.Level, unit.HasDoubleAttack());
            unit.Stats.BaseDefense = StatsCalculator.Defense(unit.Traits, unit.Level, unit.HasDoubleDefense());
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
            Monster[] monstersOnSelectedFloor = MonstersOnSelectedFloor();
            for (int i = 0; i < monstersOnSelectedFloor.Length; ++i)
            { monsterControls[i].Fill(koh, familiar, monstersOnSelectedFloor[i]); }
        }
        private void kohLevelNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            CalculateKohStatistics();
            UpdateMonsterControls();
        }
        private void kohFrogCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetKohFrogStatus();
            UpdateMonsterControls();
        }
        private void kohAttackModifierNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ModifyKohStats();
            UpdateMonsterControls();
        }
        private void kohDefenseModifierNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ModifyKohStats();
            UpdateMonsterControls();
        }
        private void kohWeaponComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            SetKohWeapon();
            UpdateMonsterControls();
        }
        private void kohWeaponQualityNumericUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            SetKohWeaponQuality();
            UpdateMonsterControls();
        }
        private void kohShieldComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            SetKohShield();
            UpdateMonsterControls();
        }
        private void kohShieldQualityNumericUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            SetKohShieldQuality();
            UpdateMonsterControls();
        }
        private void kohSpellComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetKohSpell();
            UpdateMonsterControls();
        }
        private void familiarTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFamiliarType();
            UpdateMonsterControls();
        }
        private void familiarGenusComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            SetFamiliarGenus();
            UpdateMonsterControls();
        }
        private void familiarFrogCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetFamiliarFrogStatus();
            UpdateMonsterControls();
        }
        private void familiarLevelNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetFamiliarLevel();
            UpdateMonsterControls();
        }
        private void familiarSpellLevelModifierNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ModifyFamiliarSpellLevel();
            UpdateMonsterControls();
        }
        private void familiarTraitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SpecialTraits oldSpecialTraits = familiar.SpecialTraits;
            string specialTraits = familiarSpecialTraitComboBox.SelectedItem.ToString();
            familiar.SpecialTraits = FamiliarSpecialTraits[specialTraits];
            OnFamiliarSpecialTraitChanged(oldSpecialTraits);
            OnFamiliarSpecialTraitChanged(familiar.SpecialTraits);
        }
        private void OnFamiliarSpecialTraitChanged(SpecialTraits specialTraits)
        {
            switch (specialTraits)
            {
                case SpecialTraits.DoubleAttack:
                case SpecialTraits.DoubleDefense:
                    CalculateFamiliarStats();
                    break;
                case SpecialTraits.DoubleSpellGrowth:
                    familiarDoubleSpellGrowthTraitChanged();
                    break;
            }
        }

        private void familiarDoubleSpellGrowthTraitChanged()
        {
            uint level = (uint)familiarLevelNumericUpDown.Value;
            int spellLevelModifier = (int)familiarSpellLevelModifierNumericUpDown.Value;
            if (familiar.HasDoubleSpellGrowth())
            { familiarSpellLevelModifierNumericUpDown.Value = spellLevelModifier + level; }
            else
            { familiarSpellLevelModifierNumericUpDown.Value = spellLevelModifier - level; }
        }
        private void familiarSpellComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFamiliarSpell();
            UpdateMonsterControls();
        }
        private void familiarAttackModifierNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ModifyFamiliarStats();
            UpdateMonsterControls();
        }
        private void familiarDefenseModifierNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ModifyFamiliarStats();
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
            kohLevelNumericUpDown.Value += 1;
            familiarLevelNumericUpDown.Value += 1;
            UpdateMonsterControls();
        }
        private void resetButton_Click(object sender, EventArgs e)
        { ResetUI(); }
    }
}
