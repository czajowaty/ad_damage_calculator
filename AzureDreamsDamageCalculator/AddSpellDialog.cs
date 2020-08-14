using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AzureDreamsDamageCalculator
{
    public partial class AddSpellDialog : Form
    {
        public static readonly SortedDictionary<string, SpellTraits> Spells = Helpers.CreateNamedDictionary(
            new[] { SpellsTraits.FireBall, SpellsTraits.BlazeBall, SpellsTraits.FlameBall, SpellsTraits.PillarBall, SpellsTraits.AcidRainBall });

        public AddSpellDialog()
        {
            InitializeComponent();
            Spell = null;
            spellComboBox.Items.AddRange(Spells.Keys.ToArray<string>());
            spellComboBox.SelectedIndex = 0;
            this.Shown += (sender, e) => okButton.Focus();
        }
        public BallSpell Spell
        { get; private set; }
        private void okButton_Click(object sender, EventArgs e)
        {
            Spell = new BallSpell(SelectedSpellTraits(), (uint)minChargesNumericUpDown.Value, (uint)maxChargesNumericUpDown.Value);
            DialogResult = DialogResult.OK;
            this.Close();
        }
        private void spellComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string spellName = spellComboBox.SelectedItem.ToString();
            if (spellName == SpellsTraits.AcidRainBall.Name)
            {
                minChargesNumericUpDown.Value = 1;
                maxChargesNumericUpDown.Value = 1;
            }
            else
            {
                minChargesNumericUpDown.Value = BallSpell.DEFAULT_MIN_CHARGES;
                maxChargesNumericUpDown.Value = BallSpell.DEFAULT_MAX_CHARGES;
            }
        }
        private SpellTraits SelectedSpellTraits()
        { return Spells[spellComboBox.SelectedItem.ToString()]; }
    }
}
