using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace AzureDreamsDamageCalculator
{
    public partial class MainForm : Form
    {
        public static readonly string VERSION = "0.3.3";
        public static readonly SortedDictionary<string, Weapon> KohWeaponsNames = Helpers.CreateNamedDictionary(
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
                Wands.Seal,
                Wands.Life,
                Wands.Trained
            });
        public static readonly SortedDictionary<string, Shield> KohShieldsNames = Helpers.CreateNamedDictionary(
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
        public static readonly SortedDictionary<string, UnitTraits> FamiliarsTraits = Helpers.CreateNamedDictionary(
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
        public static readonly SortedDictionary<string, SpellTraits> FamiliarSpells = Helpers.CreateNamedDictionary(
            new[] { SpellTraits.EMPTY, SpellsTraits.Breath, SpellsTraits.Sled, SpellsTraits.Brid, SpellsTraits.Rise, SpellsTraits.Down });
        public static readonly SortedDictionary<string, Genus> GenusNames = new SortedDictionary<string, Genus>()
        {
            { Genus.Fire.ToString(), Genus.Fire },
            { Genus.Water.ToString(), Genus.Water },
            { Genus.Wind.ToString(), Genus.Wind }
        };
        public static readonly SortedDictionary<string, Talent> FamiliarTalents = Helpers.CreateNamedDictionary(
            new[] { Talents.HpIncreased, Talents.StrengthIncreased, Talents.Hard, Talents.MagicAttackIncreased });

        private Unit koh = new Unit(UnitsTraits.Koh);
        private BindingList<BallSpell> kohSpellsList = new BindingList<BallSpell>();
        private BallSpell kohSpell = BallSpell.NO_BALL_SPELL;
        private Familiar familiar;
        private MonsterControl[] monsterControls = new MonsterControl[0];

        public MainForm()
        {
            InitializeComponent();
            kohSpellComboBox.DataSource = kohSpellsList;
            Text += " " + VERSION;
            CreateMonsterControls();
            FillComboBox(kohWeaponComboBox, KohWeaponsNames.Keys);
            FillComboBox(kohShieldComboBox, KohShieldsNames.Keys);
            FillComboBox(familiarTypeComboBox, FamiliarsTraits.Keys);
            FillComboBox(familiarGenusComboBox, GenusNames.Keys);
            FillComboBox(familiarSpell1ComboBox, FamiliarSpells.Keys);
            FillComboBox(familiarSpell2ComboBox, FamiliarSpells.Keys);
            FillListBox(familiarTalentsListBox, FamiliarTalents.Keys);
            ResetUI();
            OnKohSpellChanged();
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
            kohSpellsList.Clear();
            kohSpellsList.Add(new BallSpell(SpellsTraits.FireBall, minCharges: 5, maxCharges: 5));
            familiarTalentsListBox.ClearSelected();
            familiarTypeComboBox.SelectedItem = UnitsTraits.Kewne.Name;
            familiarFrogCheckBox.Checked = false;
            familiarLevelNumericUpDown.Value = 1;
            familiarSpell1ComboBox.SelectedItem = UnitsTraits.Kewne.NativeSpell.Name;
            familiarSpell1LevelNumericUpDown.Value = 1;
            familiarSpell2ComboBox.SelectedItem = 
            familiarAttackModifierNumericUpDown.Value = 0;
            familiarDefenseModifierNumericUpDown.Value = 0;
            floorNumericUpDown.Value = 1;
            UpdateKoh();
            UpdateFamiliar();
            UpdateEggs();
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
            this.familiarSpell1ComboBox.SelectedIndexChanged += new System.EventHandler(this.familiarSpell1ComboBox_SelectedIndexChanged);
            this.familiarSpell1LevelNumericUpDown.ValueChanged += new System.EventHandler(this.familiarSpell1LevelNumericUpDown_ValueChanged);
            this.familiarSpell2ComboBox.SelectedIndexChanged += new System.EventHandler(this.familiarSpell2ComboBox_SelectedIndexChanged);
            this.familiarSpell2LevelNumericUpDown.ValueChanged += new System.EventHandler(this.familiarSpell2LevelNumericUpDown_ValueChanged);
            this.familiarTalentsListBox.SelectedIndexChanged += new System.EventHandler(this.familiarTalentsListBox_SelectedIndexChanged);
            this.familiarAttackModifierNumericUpDown.ValueChanged += new System.EventHandler(this.familiarAttackModifierNumericUpDown_ValueChanged);
            this.familiarDefenseModifierNumericUpDown.ValueChanged += new System.EventHandler(this.familiarDefenseModifierNumericUpDown_ValueChanged);
        }
        private void FillComboBox(ComboBox comboBox, IEnumerable<string> items)
        {
            comboBox.Items.AddRange(items.ToArray<string>());
            comboBox.SelectedIndex = 0;
        }
        private void FillListBox(ListBox listBox, IEnumerable<string> items)
        { listBox.Items.AddRange(items.ToArray<string>()); }
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
            bool isSpellSelected = kohSpellComboBox.SelectedIndex != -1;
            if (isSpellSelected)
            { kohSpell = (BallSpell)kohSpellComboBox.SelectedItem; }
            else
            { kohSpell = BallSpell.NO_BALL_SPELL; }
            SetKohSpellLevel();
            removeKohSpellButton.Enabled = isSpellSelected;
            removeChargeButton.Enabled = isSpellSelected;
            addChargeButton.Enabled = isSpellSelected;
            identifyKohSpellButton.Enabled = isSpellSelected && !kohSpell.IsIdentified();
        }
        private void SetKohSpellLevel()
        {
            if (kohSpell.IsDamagingDirectSpellType())
            { kohSpell.Level = Math.Min(Spell.MAX_SPELL_LEVEL, koh.Level * 4); }
        }
        private void UpdateFamiliar()
        { SetFamiliarType(); }
        private void SetFamiliarType()
        {
            string familiarType = familiarTypeComboBox.SelectedItem.ToString();
            CreateFamiliar(FamiliarsTraits[familiarType]);
            familiarGenusComboBox.SelectedItem = familiar.Stats.Genus.ToString();
            familiarTalentsListBox.ClearSelected();
            for (int index = 0; index < familiarTalentsListBox.Items.Count; ++index)
            {
                Talent talent = FamiliarTalents[familiarTalentsListBox.Items[index].ToString()];
                if (familiar.Traits.Talents.Has(talent))
                { familiarTalentsListBox.SetSelected(index, true); }
            }
            familiarSpell1ComboBox.SelectedItem = familiar.Spell.Name;
            familiarSpell2ComboBox.SelectedItem = "";
            familiarSpell2LockedCheckBox.Checked = true;
        }
        private void CreateFamiliar(UnitTraits traits)
        {
            familiar = new Familiar(traits);
            SetFamiliarFrogStatus();
            SetFamiliarLevel(initialize: true);
            CalculateFamiliarStats();
        }
        private void SetFamiliarGenus()
        {
            Genus genus = GenusNames[familiarGenusComboBox.SelectedItem.ToString()];
            familiar.Genus = genus;
            familiarSpell1LockedCheckBox.Checked = !familiar.Spell.HasNativeGenus();
            familiarSpell2LockedCheckBox.Checked = !familiar.Spell2.HasNativeGenus();
        }
        private void SetFamiliarFrogStatus()
        { familiar.IsFrog = kohFrogCheckBox.Checked; }
        private void SetFamiliarLevel(bool initialize = false)
        {
            uint newLevel = (uint)familiarLevelNumericUpDown.Value;
            int levelDifference = initialize ? 0 : (int)(newLevel - familiar.Level);
            familiar.Level = newLevel;
            UpdateFamiliarSpell1Level(levelDifference);
            UpdateFamiliarSpell2Level(levelDifference);
            CalculateFamiliarStats();
            ModifyFamiliarStats();
        }
        private void SetFamiliarSpell1()
        {
            familiar.Spell = CreateFamiliarSpell(familiarSpell1ComboBox, familiarSpell1LevelNumericUpDown);
            familiarSpell1LockedCheckBox.Checked = !familiar.Spell.HasNativeGenus();
        }
        private void UpdateFamiliarSpell1Level(int levelDifference)
        { UpdateFamiliarSpellLevel(levelDifference, familiarSpell1LevelNumericUpDown, familiarSpell1LockedCheckBox); }
        private void SetFamiliarSpell2()
        {
            familiar.Spell2 = CreateFamiliarSpell(familiarSpell2ComboBox, familiarSpell2LevelNumericUpDown);
            familiarSpell2LockedCheckBox.Checked = !familiar.Spell2.HasNativeGenus();
        }
        private void UpdateFamiliarSpell2Level(int levelDifference)
        { UpdateFamiliarSpellLevel(levelDifference, familiarSpell2LevelNumericUpDown, familiarSpell2LockedCheckBox); }
        private Spell CreateFamiliarSpell(ComboBox spellComboBox, NumericUpDown spellLevelNumericUpDown)
        {
            string spellTraits = spellComboBox.SelectedItem.ToString();
            Spell spell = new Spell(FamiliarSpells[spellTraits], (uint)spellLevelNumericUpDown.Value);
            spell.Genus = familiar.Genus;
            return spell;
        }
        private void UpdateFamiliarSpellLevel(int levelDifference, NumericUpDown spellLevelNumericUpDown, CheckBox spellLockedCheckBox)
        {
            if (spellLockedCheckBox.Checked)
            { return; }
            int spellLevel = (int)spellLevelNumericUpDown.Value;
            spellLevel += levelDifference;
            if (familiar.Talents.Has(Talents.MagicAttackIncreased))
            { spellLevel += levelDifference; }
            SetFamiliarSpellLevelNumericUpDown(spellLevel, spellLevelNumericUpDown);
        }
        private void SetFamiliarSpellLevelNumericUpDown(int spellLevel, NumericUpDown spellLevelNumericUpDown)
        {
            if (spellLevel < spellLevelNumericUpDown.Minimum)
            { spellLevel = (int)spellLevelNumericUpDown.Minimum; }
            else if (spellLevel > spellLevelNumericUpDown.Maximum)
            { spellLevel = (int)spellLevelNumericUpDown.Maximum; }
            spellLevelNumericUpDown.Value = spellLevel;
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
            unit.Stats.BaseAttack = StatsCalculator.Attack(unit.Traits, unit.Level, unit.Talents.Has(Talents.StrengthIncreased));
            unit.Stats.BaseDefense = StatsCalculator.Defense(unit.Traits, unit.Level, unit.Talents.Has(Talents.Hard));
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
        private void UpdateMonsterControls(bool useNativeMonsterGenus = false)
        {
            Monster[] monstersOnSelectedFloor = MonstersOnSelectedFloor();
            for (int i = 0; i < monstersOnSelectedFloor.Length; ++i)
            { monsterControls[i].Fill(koh, familiar, monstersOnSelectedFloor[i], kohSpell, useNativeMonsterGenus); }
        }
        private void kohLevelNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            CalculateKohStatistics();
            SetKohSpellLevel();
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
        { OnKohSpellChanged(); }
        private void OnKohSpellChanged()
        {
            SetKohSpell();
            UpdateMonsterControls();
        }
        private void addKohSpellButton_Click(object sender, EventArgs e)
        {
            AddSpellDialog addSpellDialog = new AddSpellDialog();
            SetDialogPosition(addSpellDialog);
            if (addSpellDialog.ShowDialog(this) == DialogResult.OK)
            {
                kohSpellsList.Add(addSpellDialog.Spell);
                if (!kohSpell.IsDamagingDirectSpellType())
                { OnKohSpellChanged(); }
            }
        }
        private void removeKohSpellButton_Click(object sender, EventArgs e)
        {
            int previousSelectedIndex = kohSpellComboBox.SelectedIndex;
            kohSpellsList.RemoveAt(previousSelectedIndex);
            if (previousSelectedIndex != kohSpellComboBox.SelectedIndex)
            { OnKohSpellChanged(); }
        }
        private void removeChargeButton_Click(object sender, EventArgs e)
        {
            kohSpell.RemoveCharge();
            RefreshKohSpellComboBox();
        }
        private void addChargeButton_Click(object sender, EventArgs e)
        {
            kohSpell.AddCharge();
            RefreshKohSpellComboBox();
        }
        private void RefreshKohSpellComboBox()
        { kohSpellsList.ResetItem(kohSpellComboBox.SelectedIndex); }
        private void identifyKohSpellButton_Click(object sender, EventArgs e)
        {
            IdentifySpellDialog identifySpellDialog = new IdentifySpellDialog();
            identifySpellDialog.Charges = kohSpell.MinCharges;
            SetDialogPosition(identifySpellDialog);
            if (identifySpellDialog.ShowDialog() == DialogResult.OK)
            {
                kohSpell.Identify(identifySpellDialog.Charges);
                RefreshKohSpellComboBox();
            } 
        }
        private void SetDialogPosition(Form dialogWindow)
        {
            Size halfSize = dialogWindow.Size;
            halfSize.Width /= 2;
            halfSize.Height /= 2;
            dialogWindow.Location = Cursor.Position - halfSize;
        }
        private void UpdateEggs()
        {
            eggsFlowLayoutPanel.Controls.Clear();
            foreach (Egg egg in EggsOnCurrentFloor())
            {
                Label label = new Label();
                label.AutoSize = true;
                label.BackColor = Color.White;
                label.Font = new Font(label.Font.FontFamily, emSize: 14);
                label.Margin = new Padding(5);
                label.Text = string.Format("{0}: {1:F2}%", egg.Name, egg.Probability * 100);
                label.TextAlign = ContentAlignment.MiddleCenter;
                eggsFlowLayoutPanel.Controls.Add(label);
            }
        }
        private Egg[] EggsOnCurrentFloor()
        {
            uint floor = (uint)floorNumericUpDown.Value;
            if (floor <= 5)
            { return Eggs.Floor1_5; }
            else if (floor <= 10)
            { return Eggs.Floor6_10; }
            else if (floor <= 15)
            { return Eggs.Floor11_15; }
            else if (floor <= 20)
            { return Eggs.Floor16_20; }
            else if (floor <= 25)
            { return Eggs.Floor21_25; }
            else if (floor <= 30)
            { return Eggs.Floor26_30; }
            else if (floor <= 35)
            { return Eggs.Floor31_35; }
            else
            { return Eggs.Floor36_39; }
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
        private void familiarTalentsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Talents newTalents = new Talents();
            foreach (object talentName in familiarTalentsListBox.SelectedItems)
            {
                Talent talent = FamiliarTalents[talentName.ToString()];
                newTalents.Add(talent);
            }
            bool hadMagicAttackIncreasedTalent = familiar.Talents.Has(Talents.MagicAttackIncreased);
            familiar.Talents = newTalents;
            CalculateFamiliarStats();
            if (hadMagicAttackIncreasedTalent != newTalents.Has(Talents.MagicAttackIncreased))
            { FamiliarMagicAttackIncreasedTalentChanged(); }
        }
        private void FamiliarMagicAttackIncreasedTalentChanged()
        {
            uint spell1Level = familiar.Spell.Level;
            uint spell2Level = familiar.Spell2.Level;
            if (familiar.Talents.Has(Talents.MagicAttackIncreased))
            {
                spell1Level *= 2;
                spell2Level *= 2;
            }
            else
            {
                spell1Level /= 2;
                spell2Level /= 2;
            }
            SetFamiliarSpellLevelNumericUpDown((int)spell1Level, familiarSpell1LevelNumericUpDown);
            SetFamiliarSpellLevelNumericUpDown((int)spell2Level, familiarSpell2LevelNumericUpDown);
        }
        private void familiarLevelNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetFamiliarLevel();
            UpdateMonsterControls();
        }
        private void familiarFrogCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetFamiliarFrogStatus();
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
        private void familiarSpell1ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFamiliarSpell1();
            UpdateMonsterControls();
        }
        private void familiarSpell1LevelNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            familiar.Spell.Level = (uint)familiarSpell1LevelNumericUpDown.Value;
            UpdateMonsterControls();
        }
        private void familiarSpell1LockedCheckBox_CheckedChanged(object sender, EventArgs e)
        { familiarSpell1LevelNumericUpDown.Enabled = !familiarSpell1LockedCheckBox.Checked; }
        private void familiarSpell2ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFamiliarSpell2();
            UpdateMonsterControls();
        }
        private void familiarSpell2LevelNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            familiar.Spell2.Level = (uint)familiarSpell2LevelNumericUpDown.Value;
            UpdateMonsterControls();
        }
        private void familiarSpell2LockedCheckBox_CheckedChanged(object sender, EventArgs e)
        { familiarSpell2LevelNumericUpDown.Enabled = !familiarSpell2LockedCheckBox.Checked; }
        private void floorNumericUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            monsterControlsFlowLayoutPanel.SuspendLayout();
            CreateMonsterControls();
            UpdateMonsterControls(useNativeMonsterGenus: true);
            monsterControlsFlowLayoutPanel.ResumeLayout();
            eggsFlowLayoutPanel.SuspendLayout();
            UpdateEggs();
            eggsFlowLayoutPanel.ResumeLayout();
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
