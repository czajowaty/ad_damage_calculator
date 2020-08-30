namespace AzureDreamsDamageCalculator
{
    public struct UnitsTraits
    {
        public static readonly UnitTraits Koh = new UnitTraits()
        {
            Name = "Koh",
            BaseHp = 0x10,
            HpGrowth = 0x16,
            BaseMp = 0x64,
            MpGrowth = 0x00,
            BaseAttack = 0x05,
            AttackGrowth = 0x0D,
            BaseDefense = 0x04,
            DefenseGrowth = 0x0E,
            BaseAgility = 0x04,
            AgilityGrowth = 0x08,
            BaseLuck = 0x20,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x10,
            ExpGivenGrowth = 0x10,
            NativeGenus = Genus.None,
            NativeSpell = SpellTraits.EMPTY,
            Liftable = false,
            Pushable = false,
        };
        public static readonly UnitTraits Hikewne = new UnitTraits()
        {
            Name = "Hikewne",
            BaseHp = 0x0F,
            HpGrowth = 0x11,
            BaseMp = 0x78,
            MpGrowth = 0x04,
            BaseAttack = 0x07,
            AttackGrowth = 0x14,
            BaseDefense = 0x07,
            DefenseGrowth = 0x13,
            BaseAgility = 0x08,
            AgilityGrowth = 0x12,
            BaseLuck = 0x64,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x03,
            ExpGivenGrowth = 0x1E,
            NativeGenus = Genus.None,
            NativeSpell = SpellTraits.EMPTY,
            Liftable = false,
            Pushable = false,
            Portrait = Properties.Resources.hikewne
        };
        public static readonly UnitTraits Kewne = new UnitTraits()
        {
            Name = "Kewne",
            BaseHp = 0x0C,
            HpGrowth = 0x12,
            BaseMp = 0x64,
            MpGrowth = 0x00,
            BaseAttack = 0x06,
            AttackGrowth = 0x14,
            BaseDefense = 0x06,
            DefenseGrowth = 0x0E,
            BaseAgility = 0x05,
            AgilityGrowth = 0x14,
            BaseLuck = 0x50,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x03,
            ExpGivenGrowth = 0x10,
            NativeGenus = Genus.Fire,
            NativeSpell = SpellsTraits.Brid,
            Liftable = true,
            Pushable = true,
            Portrait = Properties.Resources.kewne
        };
        public static readonly UnitTraits Dragon = new UnitTraits()
        {
            Name = "Dragon",
            BaseHp = 0x0F,
            HpGrowth = 0x12,
            BaseMp = 0x46,
            MpGrowth = 0x00,
            BaseAttack = 0x09,
            AttackGrowth = 0x11,
            BaseDefense = 0x08,
            DefenseGrowth = 0x13,
            BaseAgility = 0x04,
            AgilityGrowth = 0x14,
            BaseLuck = 0x4B,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x03,
            ExpGivenGrowth = 0x16,
            NativeGenus = Genus.Fire,
            NativeSpell = SpellsTraits.Breath,
            IsEvolved = true,
            Liftable = false,
            Pushable = false,
            Portrait = Properties.Resources.dragon
        };
        public static readonly UnitTraits Kid = new UnitTraits()
        {
            Name = "Kid",
            BaseHp = 0x0C,
            HpGrowth = 0x12,
            BaseMp = 0x3C,
            MpGrowth = 0x08,
            BaseAttack = 0x07,
            AttackGrowth = 0x14,
            BaseDefense = 0x05,
            DefenseGrowth = 0x13,
            BaseAgility = 0x05,
            AgilityGrowth = 0x14,
            BaseLuck = 0x4B,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x02,
            ExpGivenGrowth = 0x13,
            NativeGenus = Genus.Fire,
            NativeSpell = SpellsTraits.Breath,
            Liftable = true,
            Pushable = true,
            Portrait = Properties.Resources.kid
        };
        public static readonly UnitTraits Ifrit = new UnitTraits()
        {
            Name = "Ifrit",
            BaseHp = 0x09,
            HpGrowth = 0x13,
            BaseMp = 0x5A,
            MpGrowth = 0x00,
            BaseAttack = 0x06,
            AttackGrowth = 0x15,
            BaseDefense = 0x06,
            DefenseGrowth = 0x12,
            BaseAgility = 0x06,
            AgilityGrowth = 0x0E,
            BaseLuck = 0x46,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x03,
            ExpGivenGrowth = 0x15,
            NativeGenus = Genus.Fire,
            NativeSpell = SpellsTraits.Sled,
            IsEvolved = true,
            Liftable = false,
            Pushable = false,
            Portrait = Properties.Resources.ifrit
        };
        public static readonly UnitTraits Flame = new UnitTraits()
        {
            Name = "Flame",
            BaseHp = 0x09,
            HpGrowth = 0x12,
            BaseMp = 0x50,
            MpGrowth = 0x00,
            BaseAttack = 0x05,
            AttackGrowth = 0x19,
            BaseDefense = 0x05,
            DefenseGrowth = 0x11,
            BaseAgility = 0x06,
            AgilityGrowth = 0x14,
            BaseLuck = 0x50,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x02,
            ExpGivenGrowth = 0x0F,
            NativeGenus = Genus.Fire,
            NativeSpell = SpellsTraits.Sled,
            Liftable = false,
            Pushable = true,
            Portrait = Properties.Resources.flame
        };
        public static readonly UnitTraits Grineut = new UnitTraits()
        {
            Name = "Grineut",
            BaseHp = 0x0A,
            HpGrowth = 0x14,
            BaseMp = 0x50,
            MpGrowth = 0x00,
            BaseAttack = 0x06,
            AttackGrowth = 0x13,
            BaseDefense = 0x06,
            DefenseGrowth = 0x12,
            BaseAgility = 0x06,
            AgilityGrowth = 0x15,
            BaseLuck = 0x46,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x03,
            ExpGivenGrowth = 0x12,
            NativeGenus = Genus.Fire,
            NativeSpell = SpellsTraits.Rise,
            IsEvolved = true,
            Liftable = false,
            Pushable = false,
            Portrait = Properties.Resources.grineut
        };
        public static readonly UnitTraits Griffon = new UnitTraits()
        {
            Name = "Griffon",
            BaseHp = 0x09,
            HpGrowth = 0x14,
            BaseMp = 0x50,
            MpGrowth = 0x00,
            BaseAttack = 0x06,
            AttackGrowth = 0x13,
            BaseDefense = 0x05,
            DefenseGrowth = 0x12,
            BaseAgility = 0x05,
            AgilityGrowth = 0x19,
            BaseLuck = 0x50,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x02,
            ExpGivenGrowth = 0x10,
            NativeGenus = Genus.Fire,
            NativeSpell = SpellsTraits.Rise,
            Liftable = true,
            Pushable = true,
            Portrait = Properties.Resources.griffon
        };
        public static readonly UnitTraits Saber = new UnitTraits()
        {
            Name = "Saber",
            BaseHp = 0x0A,
            HpGrowth = 0x14,
            BaseMp = 0x5A,
            MpGrowth = 0x00,
            BaseAttack = 0x05,
            AttackGrowth = 0x17,
            BaseDefense = 0x05,
            DefenseGrowth = 0x13,
            BaseAgility = 0x05,
            AgilityGrowth = 0x16,
            BaseLuck = 0x46,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x03,
            ExpGivenGrowth = 0x11,
            NativeGenus = Genus.Water,
            NativeSpell = SpellTraits.EMPTY,
            IsEvolved = true,
            Liftable = false,
            Pushable = false,
            Portrait = Properties.Resources.saber
        };
        public static readonly UnitTraits Snowman = new UnitTraits()
        {
            Name = "Snowman",
            BaseHp = 0x0A,
            HpGrowth = 0x14,
            BaseMp = 0x5A,
            MpGrowth = 0x00,
            BaseAttack = 0x05,
            AttackGrowth = 0x16,
            BaseDefense = 0x05,
            DefenseGrowth = 0x11,
            BaseAgility = 0x04,
            AgilityGrowth = 0x16,
            BaseLuck = 0x4B,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x02,
            ExpGivenGrowth = 0x0F,
            NativeGenus = Genus.Water,
            NativeSpell = SpellTraits.EMPTY,
            Liftable = false,
            Pushable = true,
            Portrait = Properties.Resources.snowman
        };
        public static readonly UnitTraits Ashra = new UnitTraits()
        {
            Name = "Ashra",
            BaseHp = 0x09,
            HpGrowth = 0x11,
            BaseMp = 0x50,
            MpGrowth = 0x00,
            BaseAttack = 0x06,
            AttackGrowth = 0x14,
            BaseDefense = 0x05,
            DefenseGrowth = 0x16,
            BaseAgility = 0x05,
            AgilityGrowth = 0x15,
            BaseLuck = 0x46,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x03,
            ExpGivenGrowth = 0x0F,
            NativeGenus = Genus.Water,
            NativeSpell = SpellTraits.EMPTY,
            IsEvolved = true,
            Liftable = false,
            Pushable = false,
            Portrait = Properties.Resources.ashra
        };
        public static readonly UnitTraits Arachne = new UnitTraits()
        {
            Name = "Arachne",
            BaseHp = 0x09,
            HpGrowth = 0x10,
            BaseMp = 0x46,
            MpGrowth = 0x00,
            BaseAttack = 0x06,
            AttackGrowth = 0x12,
            BaseDefense = 0x05,
            DefenseGrowth = 0x14,
            BaseAgility = 0x05,
            AgilityGrowth = 0x14,
            BaseLuck = 0x46,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x02,
            ExpGivenGrowth = 0x0E,
            NativeGenus = Genus.Water,
            NativeSpell = SpellTraits.EMPTY,
            Liftable = true,
            Pushable = true,
            Portrait = Properties.Resources.arachne
        };
        public static readonly UnitTraits Battnel = new UnitTraits()
        {
            Name = "Battnel",
            BaseHp = 0x0A,
            HpGrowth = 0x13,
            BaseMp = 0x46,
            MpGrowth = 0x00,
            BaseAttack = 0x07,
            AttackGrowth = 0x14,
            BaseDefense = 0x06,
            DefenseGrowth = 0x14,
            BaseAgility = 0x05,
            AgilityGrowth = 0x11,
            BaseLuck = 0x46,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x03,
            ExpGivenGrowth = 0x12,
            NativeGenus = Genus.Water,
            NativeSpell = SpellTraits.EMPTY,
            IsEvolved = true,
            Liftable = false,
            Pushable = false,
            Portrait = Properties.Resources.battnel
        };
        public static readonly UnitTraits Nyuel = new UnitTraits()
        {
            Name = "Nyuel",
            BaseHp = 0x0A,
            HpGrowth = 0x0F,
            BaseMp = 0x50,
            MpGrowth = 0x00,
            BaseAttack = 0x04,
            AttackGrowth = 0x13,
            BaseDefense = 0x05,
            DefenseGrowth = 0x13,
            BaseAgility = 0x08,
            AgilityGrowth = 0x13,
            BaseLuck = 0x50,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x02,
            ExpGivenGrowth = 0x0E,
            NativeGenus = Genus.Water,
            NativeSpell = SpellTraits.EMPTY,
            Liftable = false,
            Pushable = true,
            Portrait = Properties.Resources.nyuel
        };
        public static readonly UnitTraits Death = new UnitTraits()
        {
            Name = "Death",
            BaseHp = 0x08,
            HpGrowth = 0x13,
            BaseMp = 0x50,
            MpGrowth = 0x00,
            BaseAttack = 0x06,
            AttackGrowth = 0x12,
            BaseDefense = 0x05,
            DefenseGrowth = 0x12,
            BaseAgility = 0x06,
            AgilityGrowth = 0x12,
            BaseLuck = 0x46,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x03,
            ExpGivenGrowth = 0x10,
            NativeGenus = Genus.Wind,
            SpecialTraits = SpecialTraits.DoubleSpellGrowth,
            NativeSpell = SpellsTraits.Down,
            IsEvolved = true,
            Liftable = false,
            Pushable = true,
            Portrait = Properties.Resources.death
        };
        public static readonly UnitTraits Clown = new UnitTraits()
        {
            Name = "Clown",
            BaseHp = 0x08,
            HpGrowth = 0x12,
            BaseMp = 0x50,
            MpGrowth = 0x00,
            BaseAttack = 0x06,
            AttackGrowth = 0x11,
            BaseDefense = 0x05,
            DefenseGrowth = 0x12,
            BaseAgility = 0x06,
            AgilityGrowth = 0x12,
            BaseLuck = 0x46,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x02,
            ExpGivenGrowth = 0x12,
            NativeGenus = Genus.Wind,
            SpecialTraits = SpecialTraits.DoubleSpellGrowth,
            NativeSpell = SpellsTraits.Down,
            Liftable = true,
            Pushable = true,
            Portrait = Properties.Resources.clown
        };
        public static readonly UnitTraits Univern = new UnitTraits()
        {
            Name = "Univern",
            BaseHp = 0x0A,
            HpGrowth = 0x16,
            BaseMp = 0x50,
            MpGrowth = 0x00,
            BaseAttack = 0x06,
            AttackGrowth = 0x12,
            BaseDefense = 0x06,
            DefenseGrowth = 0x0F,
            BaseAgility = 0x07,
            AgilityGrowth = 0x12,
            BaseLuck = 0x46,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x03,
            ExpGivenGrowth = 0x14,
            NativeGenus = Genus.Wind,
            NativeSpell = SpellTraits.EMPTY,
            IsEvolved = true,
            Liftable = false,
            Pushable = false,
            Portrait = Properties.Resources.univern
        };
        public static readonly UnitTraits Unicorn = new UnitTraits()
        {
            Name = "Unicorn",
            BaseHp = 0x09,
            HpGrowth = 0x14,
            BaseMp = 0x50,
            MpGrowth = 0x00,
            BaseAttack = 0x05,
            AttackGrowth = 0x11,
            BaseDefense = 0x05,
            DefenseGrowth = 0x12,
            BaseAgility = 0x07,
            AgilityGrowth = 0x0F,
            BaseLuck = 0x46,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x02,
            ExpGivenGrowth = 0x0E,
            NativeGenus = Genus.Wind,
            NativeSpell = SpellTraits.EMPTY,
            Liftable = true,
            Pushable = true,
            Portrait = Properties.Resources.unicorn
        };
        public static readonly UnitTraits Metal = new UnitTraits()
        {
            Name = "Metal",
            BaseHp = 0x0A,
            HpGrowth = 0x11,
            BaseMp = 0x50,
            MpGrowth = 0x00,
            BaseAttack = 0x06,
            AttackGrowth = 0x11,
            BaseDefense = 0x08,
            DefenseGrowth = 0x13,
            BaseAgility = 0x04,
            AgilityGrowth = 0x16,
            BaseLuck = 0x46,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x03,
            ExpGivenGrowth = 0x12,
            NativeGenus = Genus.Wind,
            NativeSpell = SpellTraits.EMPTY,
            IsEvolved = true,
            Liftable = false,
            Pushable = false,
            Portrait = Properties.Resources.metal
        };
        public static readonly UnitTraits Block = new UnitTraits()
        {
            Name = "Block",
            BaseHp = 0x0A,
            HpGrowth = 0x10,
            BaseMp = 0x50,
            MpGrowth = 0x00,
            BaseAttack = 0x06,
            AttackGrowth = 0x10,
            BaseDefense = 0x08,
            DefenseGrowth = 0x12,
            BaseAgility = 0x03,
            AgilityGrowth = 0x16,
            BaseLuck = 0x46,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x02,
            ExpGivenGrowth = 0x10,
            NativeGenus = Genus.Wind,
            NativeSpell = SpellTraits.EMPTY,
            Liftable = false,
            Pushable = false,
            Portrait = Properties.Resources.block
        };
        public static readonly UnitTraits Pulunpa = new UnitTraits()
        {
            Name = "Pulunpa",
            BaseHp = 0x08,
            HpGrowth = 0x13,
            BaseMp = 0x28,
            MpGrowth = 0x00,
            BaseAttack = 0x04,
            AttackGrowth = 0x12,
            BaseDefense = 0x04,
            DefenseGrowth = 0x13,
            BaseAgility = 0x04,
            AgilityGrowth = 0x14,
            BaseLuck = 0x32,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x01,
            ExpGivenGrowth = 0x0B,
            NativeGenus = Genus.Water,
            NativeSpell = SpellTraits.EMPTY,
            Liftable = true,
            Pushable = true,
            Portrait = Properties.Resources.pulunpa
        };
        public static readonly UnitTraits Troll = new UnitTraits()
        {
            Name = "Troll",
            BaseHp = 0x06,
            HpGrowth = 0x12,
            BaseMp = 0x3C,
            MpGrowth = 0x00,
            BaseAttack = 0x04,
            AttackGrowth = 0x12,
            BaseDefense = 0x05,
            DefenseGrowth = 0x12,
            BaseAgility = 0x05,
            AgilityGrowth = 0x12,
            BaseLuck = 0x3C,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x04,
            ExpGivenGrowth = 0x0F,
            NativeGenus = Genus.Fire,
            NativeSpell = SpellTraits.EMPTY,
            Liftable = true,
            Pushable = true,
            Portrait = Properties.Resources.troll
        };
        public static readonly UnitTraits Noise = new UnitTraits()
        {
            Name = "Noise",
            BaseHp = 0x09,
            HpGrowth = 0x0F,
            BaseMp = 0x46,
            MpGrowth = 0x00,
            BaseAttack = 0x06,
            AttackGrowth = 0x13,
            BaseDefense = 0x05,
            DefenseGrowth = 0x14,
            BaseAgility = 0x05,
            AgilityGrowth = 0x10,
            BaseLuck = 0x41,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x03,
            ExpGivenGrowth = 0x0C,
            NativeGenus = Genus.Wind,
            NativeSpell = SpellTraits.EMPTY,
            Liftable = false,
            Pushable = true,
            Portrait = Properties.Resources.noise
        };
        public static readonly UnitTraits UBoat = new UnitTraits()
        {
            Name = "UBoat",
            BaseHp = 0x09,
            HpGrowth = 0x11,
            BaseMp = 0x50,
            MpGrowth = 0x00,
            BaseAttack = 0x06,
            AttackGrowth = 0x12,
            BaseDefense = 0x05,
            DefenseGrowth = 0x14,
            BaseAgility = 0x05,
            AgilityGrowth = 0x16,
            BaseLuck = 0x3C,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x02,
            ExpGivenGrowth = 0x0F,
            NativeGenus = Genus.Water,
            NativeSpell = SpellTraits.EMPTY,
            Liftable = true,
            Pushable = true,
            Portrait = Properties.Resources.uboat
        };
        public static readonly UnitTraits Balloon = new UnitTraits()
        {
            Name = "Balloon",
            BaseHp = 0x08,
            HpGrowth = 0x14,
            BaseMp = 0x46,
            MpGrowth = 0x00,
            BaseAttack = 0x06,
            AttackGrowth = 0x11,
            BaseDefense = 0x05,
            DefenseGrowth = 0x13,
            BaseAgility = 0x06,
            AgilityGrowth = 0x10,
            BaseLuck = 0x50,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x02,
            ExpGivenGrowth = 0x0C,
            NativeGenus = Genus.Fire,
            NativeSpell = SpellTraits.EMPTY,
            Liftable = false,
            Pushable = true,
            Portrait = Properties.Resources.balloon
        };
        public static readonly UnitTraits Dreamin = new UnitTraits()
        {
            Name = "Dreamin",
            BaseHp = 0x08,
            HpGrowth = 0x13,
            BaseMp = 0x46,
            MpGrowth = 0x00,
            BaseAttack = 0x03,
            AttackGrowth = 0x13,
            BaseDefense = 0x05,
            DefenseGrowth = 0x13,
            BaseAgility = 0x04,
            AgilityGrowth = 0x13,
            BaseLuck = 0x3C,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x02,
            ExpGivenGrowth = 0x0A,
            NativeGenus = Genus.Wind,
            NativeSpell = SpellTraits.EMPTY,
            Liftable = true,
            Pushable = true,
            Portrait = Properties.Resources.dreamin
        };
        public static readonly UnitTraits Blume = new UnitTraits()
        {
            Name = "Blume",
            BaseHp = 0x09,
            HpGrowth = 0x17,
            BaseMp = 0x50,
            MpGrowth = 0x00,
            BaseAttack = 0x05,
            AttackGrowth = 0x14,
            BaseDefense = 0x04,
            DefenseGrowth = 0x16,
            BaseAgility = 0x05,
            AgilityGrowth = 0x13,
            BaseLuck = 0x46,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x02,
            ExpGivenGrowth = 0x0D,
            NativeGenus = Genus.Water,
            NativeSpell = SpellTraits.EMPTY,
            Liftable = false,
            Pushable = true,
            Portrait = Properties.Resources.blume
        };
        public static readonly UnitTraits Volcano = new UnitTraits()
        {
            Name = "Volcano",
            BaseHp = 0x09,
            HpGrowth = 0x15,
            BaseMp = 0x50,
            MpGrowth = 0x00,
            BaseAttack = 0x04,
            AttackGrowth = 0x1B,
            BaseDefense = 0x05,
            DefenseGrowth = 0x10,
            BaseAgility = 0x05,
            AgilityGrowth = 0x13,
            BaseLuck = 0x46,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x02,
            ExpGivenGrowth = 0x0C,
            NativeGenus = Genus.Fire,
            NativeSpell = SpellTraits.EMPTY,
            Liftable = true,
            Pushable = true,
            Portrait = Properties.Resources.volcano
        };
        public static readonly UnitTraits Cyclone = new UnitTraits()
        {
            Name = "Cyclone",
            BaseHp = 0x09,
            HpGrowth = 0x14,
            BaseMp = 0x50,
            MpGrowth = 0x00,
            BaseAttack = 0x05,
            AttackGrowth = 0x17,
            BaseDefense = 0x05,
            DefenseGrowth = 0x11,
            BaseAgility = 0x05,
            AgilityGrowth = 0x14,
            BaseLuck = 0x3C,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x02,
            ExpGivenGrowth = 0x11,
            NativeGenus = Genus.Wind,
            NativeSpell = SpellTraits.EMPTY,
            Liftable = false,
            Pushable = true,
            Portrait = Properties.Resources.cyclone
        };
        public static readonly UnitTraits Manoeva = new UnitTraits()
        {
            Name = "Manoeva",
            BaseHp = 0x0A,
            HpGrowth = 0x12,
            BaseMp = 0x46,
            MpGrowth = 0x00,
            BaseAttack = 0x05,
            AttackGrowth = 0x15,
            BaseDefense = 0x06,
            DefenseGrowth = 0x11,
            BaseAgility = 0x05,
            AgilityGrowth = 0x11,
            BaseLuck = 0x3C,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x02,
            ExpGivenGrowth = 0x0F,
            NativeGenus = Genus.Water,
            NativeSpell = SpellTraits.EMPTY,
            Liftable = false,
            Pushable = false,
            Portrait = Properties.Resources.manoeva
        };
        public static readonly UnitTraits Barong = new UnitTraits()
        {
            Name = "Barong",
            BaseHp = 0x06,
            HpGrowth = 0x1C,
            BaseMp = 0x3C,
            MpGrowth = 0x00,
            BaseAttack = 0x05,
            AttackGrowth = 0x10,
            BaseDefense = 0x04,
            DefenseGrowth = 0x0C,
            BaseAgility = 0x05,
            AgilityGrowth = 0x0E,
            BaseLuck = 0x5A,
            LuckGrowth = 0x02,
            BaseExpGiven = 0x04,
            ExpGivenGrowth = 0x0D,
            NativeGenus = Genus.Fire,
            NativeSpell = SpellTraits.EMPTY,
            Liftable = true,
            Pushable = true,
            Portrait = Properties.Resources.barong
        };
        public static readonly UnitTraits Picket = new UnitTraits()
        {
            Name = "Picket",
            BaseHp = 0x08,
            HpGrowth = 0x14,
            BaseMp = 0x41,
            MpGrowth = 0x00,
            BaseAttack = 0x03,
            AttackGrowth = 0x08,
            BaseDefense = 0x04,
            DefenseGrowth = 0x0E,
            BaseAgility = 0x08,
            AgilityGrowth = 0x0F,
            BaseLuck = 0x55,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x02,
            ExpGivenGrowth = 0x0E,
            NativeGenus = Genus.Wind,
            NativeSpell = SpellTraits.EMPTY,
            Liftable = true,
            Pushable = true,
            Portrait = Properties.Resources.picket
        };
        public static readonly UnitTraits Kraken = new UnitTraits()
        {
            Name = "Kraken",
            BaseHp = 0x08,
            HpGrowth = 0x16,
            BaseMp = 0x46,
            MpGrowth = 0x00,
            BaseAttack = 0x06,
            AttackGrowth = 0x13,
            BaseDefense = 0x06,
            DefenseGrowth = 0x12,
            BaseAgility = 0x05,
            AgilityGrowth = 0x10,
            BaseLuck = 0x50,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x01,
            ExpGivenGrowth = 0x10,
            NativeGenus = Genus.Water,
            NativeSpell = SpellTraits.EMPTY,
            Liftable = false,
            Pushable = false,
            Portrait = Properties.Resources.kraken
        };
        public static readonly UnitTraits Weadog = new UnitTraits()
        {
            Name = "Weadog",
            BaseHp = 0x09,
            HpGrowth = 0x14,
            BaseMp = 0x50,
            MpGrowth = 0x00,
            BaseAttack = 0x06,
            AttackGrowth = 0x12,
            BaseDefense = 0x05,
            DefenseGrowth = 0x13,
            BaseAgility = 0x05,
            AgilityGrowth = 0x13,
            BaseLuck = 0x46,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x01,
            ExpGivenGrowth = 0x0E,
            NativeGenus = Genus.Fire,
            NativeSpell = SpellTraits.EMPTY,
            Liftable = false,
            Pushable = false,
            Portrait = Properties.Resources.weadog
        };
        public static readonly UnitTraits Stealth = new UnitTraits()
        {
            Name = "Stealth",
            BaseHp = 0x08,
            HpGrowth = 0x13,
            BaseMp = 0x50,
            MpGrowth = 0x00,
            BaseAttack = 0x04,
            AttackGrowth = 0x14,
            BaseDefense = 0x05,
            DefenseGrowth = 0x14,
            BaseAgility = 0x04,
            AgilityGrowth = 0x13,
            BaseLuck = 0x3C,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x03,
            ExpGivenGrowth = 0x0C,
            NativeGenus = Genus.Wind,
            NativeSpell = SpellTraits.EMPTY,
            Liftable = true,
            Pushable = true,
            Portrait = Properties.Resources.stealth
        };
        public static readonly UnitTraits Viper = new UnitTraits()
        {
            Name = "Viper",
            BaseHp = 0x09,
            HpGrowth = 0x13,
            BaseMp = 0x50,
            MpGrowth = 0x00,
            BaseAttack = 0x06,
            AttackGrowth = 0x13,
            BaseDefense = 0x05,
            DefenseGrowth = 0x12,
            BaseAgility = 0x06,
            AgilityGrowth = 0x12,
            BaseLuck = 0x46,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x03,
            ExpGivenGrowth = 0x0F,
            NativeGenus = Genus.Water,
            NativeSpell = SpellTraits.EMPTY,
            Liftable = true,
            Pushable = true,
            Portrait = Properties.Resources.viper
        };
        public static readonly UnitTraits Naplass = new UnitTraits()
        {
            Name = "Naplass",
            BaseHp = 0x0B,
            HpGrowth = 0x14,
            BaseMp = 0x50,
            MpGrowth = 0x00,
            BaseAttack = 0x06,
            AttackGrowth = 0x12,
            BaseDefense = 0x06,
            DefenseGrowth = 0x13,
            BaseAgility = 0x05,
            AgilityGrowth = 0x10,
            BaseLuck = 0x3C,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x03,
            ExpGivenGrowth = 0x0E,
            NativeGenus = Genus.Fire,
            SpecialTraits = SpecialTraits.DoubleHP,
            NativeSpell = SpellTraits.EMPTY,
            Liftable = false,
            Pushable = true,
            Portrait = Properties.Resources.naplass
        };
        public static readonly UnitTraits Zu = new UnitTraits()
        {
            Name = "Zu",
            BaseHp = 0x0A,
            HpGrowth = 0x13,
            BaseMp = 0x50,
            MpGrowth = 0x00,
            BaseAttack = 0x06,
            AttackGrowth = 0x11,
            BaseDefense = 0x05,
            DefenseGrowth = 0x11,
            BaseAgility = 0x07,
            AgilityGrowth = 0x0F,
            BaseLuck = 0x50,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x02,
            ExpGivenGrowth = 0x0C,
            NativeGenus = Genus.Wind,
            NativeSpell = SpellTraits.EMPTY,
            Liftable = true,
            Pushable = true,
            Portrait = Properties.Resources.zu
        };
        public static readonly UnitTraits Mandara = new UnitTraits()
        {
            Name = "Mandara",
            BaseHp = 0x0B,
            HpGrowth = 0x0E,
            BaseMp = 0x55,
            MpGrowth = 0x00,
            BaseAttack = 0x06,
            AttackGrowth = 0x12,
            BaseDefense = 0x06,
            DefenseGrowth = 0x0F,
            BaseAgility = 0x05,
            AgilityGrowth = 0x11,
            BaseLuck = 0x50,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x03,
            ExpGivenGrowth = 0x10,
            NativeGenus = Genus.Water,
            NativeSpell = SpellTraits.EMPTY,
            Liftable = false,
            Pushable = true,
            Portrait = Properties.Resources.mandara
        };
        public static readonly UnitTraits Killer = new UnitTraits()
        {
            Name = "Killer",
            BaseHp = 0x0A,
            HpGrowth = 0x13,
            BaseMp = 0x3C,
            MpGrowth = 0x00,
            BaseAttack = 0x08,
            AttackGrowth = 0x12,
            BaseDefense = 0x05,
            DefenseGrowth = 0x13,
            BaseAgility = 0x05,
            AgilityGrowth = 0x13,
            BaseLuck = 0x50,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x03,
            ExpGivenGrowth = 0x12,
            NativeGenus = Genus.Fire,
            NativeSpell = SpellTraits.EMPTY,
            Liftable = false,
            Pushable = false,
            Portrait = Properties.Resources.killer
        };
        public static readonly UnitTraits Garuda = new UnitTraits()
        {
            Name = "Garuda",
            BaseHp = 0x0A,
            HpGrowth = 0x10,
            BaseMp = 0x50,
            MpGrowth = 0x00,
            BaseAttack = 0x05,
            AttackGrowth = 0x13,
            BaseDefense = 0x05,
            DefenseGrowth = 0x15,
            BaseAgility = 0x06,
            AgilityGrowth = 0x12,
            BaseLuck = 0x3C,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x02,
            ExpGivenGrowth = 0x0E,
            NativeGenus = Genus.Wind,
            NativeSpell = SpellTraits.EMPTY,
            Liftable = true,
            Pushable = true,
            Portrait = Properties.Resources.garuda
        };
        public static readonly UnitTraits Glacier = new UnitTraits()
        {
            Name = "Glacier",
            BaseHp = 0x0A,
            HpGrowth = 0x14,
            BaseMp = 0x50,
            MpGrowth = 0x00,
            BaseAttack = 0x05,
            AttackGrowth = 0x12,
            BaseDefense = 0x06,
            DefenseGrowth = 0x13,
            BaseAgility = 0x05,
            AgilityGrowth = 0x11,
            BaseLuck = 0x55,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x02,
            ExpGivenGrowth = 0x0F,
            NativeGenus = Genus.Water,
            NativeSpell = SpellTraits.EMPTY,
            Liftable = false,
            Pushable = false,
            Portrait = Properties.Resources.glacier
        };
        public static readonly UnitTraits Tyrant = new UnitTraits()
        {
            Name = "Tyrant",
            BaseHp = 0x0A,
            HpGrowth = 0x12,
            BaseMp = 0x46,
            MpGrowth = 0x00,
            BaseAttack = 0x06,
            AttackGrowth = 0x11,
            BaseDefense = 0x06,
            DefenseGrowth = 0x12,
            BaseAgility = 0x05,
            AgilityGrowth = 0x10,
            BaseLuck = 0x41,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x03,
            ExpGivenGrowth = 0x0E,
            NativeGenus = Genus.Fire,
            NativeSpell = SpellTraits.EMPTY,
            Liftable = true,
            Pushable = true,
            Portrait = Properties.Resources.tyrant
        };
        public static readonly UnitTraits Golem = new UnitTraits()
        {
            Name = "Golem",
            BaseHp = 0x0E,
            HpGrowth = 0x0F,
            BaseMp = 0x46,
            MpGrowth = 0x00,
            BaseAttack = 0x07,
            AttackGrowth = 0x13,
            BaseDefense = 0x0A,
            DefenseGrowth = 0x10,
            BaseAgility = 0x04,
            AgilityGrowth = 0x14,
            BaseLuck = 0x46,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x03,
            ExpGivenGrowth = 0x11,
            NativeGenus = Genus.Wind,
            NativeSpell = SpellTraits.EMPTY,
            Liftable = false,
            Pushable = false,
            Portrait = Properties.Resources.golem
        };
        public static readonly UnitTraits Maximum = new UnitTraits()
        {
            Name = "Maximum",
            BaseHp = 0x10,
            HpGrowth = 0x10,
            BaseMp = 0x50,
            MpGrowth = 0x00,
            BaseAttack = 0x08,
            AttackGrowth = 0x13,
            BaseDefense = 0x09,
            DefenseGrowth = 0x0F,
            BaseAgility = 0x04,
            AgilityGrowth = 0x14,
            BaseLuck = 0x50,
            LuckGrowth = 0x00,
            BaseExpGiven = 0x04,
            ExpGivenGrowth = 0x15,
            NativeGenus = Genus.Fire,
            NativeSpell = SpellTraits.EMPTY,
            Liftable = false,
            Pushable = false,
            Portrait = Properties.Resources.maximum
        };
    }

    public struct SpellsTraits
    {
        public static readonly SpellTraits Breath = new SpellTraits(
            name: "Breath", 
            genus: Genus.Fire, 
            rawDamage: 16, 
            mixtureMagicType: SpellMixtureMagicType.Sword, 
            directMagicType: SpellDirectMagicType.Damage);
        public static readonly SpellTraits Sled = new SpellTraits(
            name: "Sled",
            genus: Genus.Fire,
            rawDamage: 8,
            mixtureMagicType: SpellMixtureMagicType.Sword,
            directMagicType: SpellDirectMagicType.Damage);
        public static readonly SpellTraits Brid = new SpellTraits(
            name: "Brid",
            genus: Genus.Fire,
            rawDamage: 10, 
            mixtureMagicType: SpellMixtureMagicType.Sword,
            directMagicType: SpellDirectMagicType.Damage);
        public static readonly SpellTraits Rise = new SpellTraits(
            name: "Rise",
            rawDamage: 19,
            genus: Genus.Fire,
            mixtureMagicType: SpellMixtureMagicType.Sword,
            directMagicType: SpellDirectMagicType.Damage);
        /*
        public static readonly SpellTraits Grave = new SpellTraits(
            name: "Grave", 
            rawDamage: 24, 
            genus: Genus.Wind,
            mixtureMagicType);
        */
        public static readonly SpellTraits Down = new SpellTraits(
            name: "Down", 
            rawDamage: 10, 
            genus: Genus.Wind,
            mixtureMagicType: SpellMixtureMagicType.Wave,
            directMagicType: SpellDirectMagicType.None);
        public static readonly SpellTraits FireBall = Breath.Copy("Fire ball");
        public static readonly SpellTraits BlazeBall = Sled.Copy("Blaze ball");
        public static readonly SpellTraits FlameBall = Brid.Copy("Flame ball");
        public static readonly SpellTraits PillarBall = Rise.Copy("Pillar ball");
        public static readonly SpellTraits AcidRainBall = new SpellTraits(
            name: "Acid rain ball", 
            rawDamage: 32, 
            genus: Genus.Water,
            mixtureMagicType: SpellMixtureMagicType.None,
            directMagicType: SpellDirectMagicType.Damage);
        public static readonly SpellTraits PoisonBall = new SpellTraits(
            name: "Poison ball",
            rawDamage: 0,
            genus: Genus.None,
            mixtureMagicType: SpellMixtureMagicType.None,
            directMagicType: SpellDirectMagicType.Status);
        public static readonly SpellTraits WaterBall = new SpellTraits(
            name: "Water ball",
            rawDamage: 0,
            genus: Genus.None,
            mixtureMagicType: SpellMixtureMagicType.None,
            directMagicType: SpellDirectMagicType.Status);
        public static readonly SpellTraits RepelBall = new SpellTraits(
            name: "Repel ball",
            rawDamage: 0,
            genus: Genus.None,
            mixtureMagicType: SpellMixtureMagicType.None,
            directMagicType: SpellDirectMagicType.Status);
        public static readonly SpellTraits IceRockBall = new SpellTraits(
            name: "Ice Rock ball",
            rawDamage: 0,
            genus: Genus.None,
            mixtureMagicType: SpellMixtureMagicType.None,
            directMagicType: SpellDirectMagicType.None);
        public static readonly SpellTraits RecoveryBall = new SpellTraits(
            name: "Recovery ball",
            rawDamage: 0,
            genus: Genus.Water,
            mixtureMagicType: SpellMixtureMagicType.None,
            directMagicType: SpellDirectMagicType.Status);
        public static readonly SpellTraits BindingBall = new SpellTraits(
            name: "Binding ball",
            rawDamage: 0,
            genus: Genus.None,
            mixtureMagicType: SpellMixtureMagicType.None,
            directMagicType: SpellDirectMagicType.Status);
        public static readonly SpellTraits SleepBall = new SpellTraits(
            name: "Sleep ball",
            rawDamage: 0,
            genus: Genus.None,
            mixtureMagicType: SpellMixtureMagicType.None,
            directMagicType: SpellDirectMagicType.Status);
        public static readonly SpellTraits BlinderBall = new SpellTraits(
            name: "Blinder ball",
            rawDamage: 0,
            genus: Genus.None,
            mixtureMagicType: SpellMixtureMagicType.None,
            directMagicType: SpellDirectMagicType.Status);
        public static readonly SpellTraits WeakBall = new SpellTraits(
            name: "Weak ball",
            rawDamage: 0,
            genus: Genus.Wind,
            mixtureMagicType: SpellMixtureMagicType.None,
            directMagicType: SpellDirectMagicType.Status);
    }

    public struct Monsters
    {
        public static readonly Monster NoiseLv1 = new MonsterCreator(UnitsTraits.Noise, level: 1);
        public static readonly Monster PulunpaLv1 = new MonsterCreator(UnitsTraits.Pulunpa, level: 1);
        public static readonly Monster TrollHammerLv2 = new MonsterCreator(UnitsTraits.Troll, level: 2)
            .GiveWeapon(new ConstantDamageWeapon(name: "Hammer", damage: 2));
        public static readonly Monster FlameLv3 = new MonsterCreator(UnitsTraits.Flame, level: 3);
        public static readonly Monster CycloneLv4 = new MonsterCreator(UnitsTraits.Cyclone, level: 4);
        public static readonly Monster BalloonLv5 = new MonsterCreator(UnitsTraits.Balloon, level: 5);
        public static readonly Monster ManoevaLv5 = new MonsterCreator(UnitsTraits.Manoeva, level: 5);
        public static readonly Monster BlumeLv6 = new MonsterCreator(UnitsTraits.Blume, level: 6);
        public static readonly Monster UBoatLv7 = new MonsterCreator(UnitsTraits.UBoat, level: 7);
        public static readonly Monster ClownLv8 = new MonsterCreator(UnitsTraits.Clown, level: 8);
        public static readonly Monster DreaminLv9 = new MonsterCreator(UnitsTraits.Dreamin, level: 9);
        public static readonly Monster TrollBowLv10 = new MonsterCreator(UnitsTraits.Troll, level: 10)
            .GiveWeapon(new ConstantDamageWeapon(name: "Bow", damage: 1));
        public static readonly Monster VolcanoLv11 = new MonsterCreator(UnitsTraits.Volcano, level: 11);
        public static readonly Monster GriffonLv12 = new MonsterCreator(UnitsTraits.Griffon, level: 12);
        public static readonly Monster KrakenLv13 = new MonsterCreator(UnitsTraits.Kraken, level: 13);
        public static readonly Monster NyuelLv14 = new MonsterCreator(UnitsTraits.Nyuel, level: 14);
        public static readonly Monster GarudaLv16 = new MonsterCreator(UnitsTraits.Garuda, level: 16);
        public static readonly Monster TrollSwordLv15 = new MonsterCreator(UnitsTraits.Troll, level: 15)
            .GiveWeapon(new ConstantDamageWeapon(name: "Sword", damage: 8, ignoresShield: true));
        public static readonly Monster BarongLv20 = new MonsterCreator(UnitsTraits.Barong, level: 20);
        public static readonly Monster ManoevaLv15 = new MonsterCreator(UnitsTraits.Manoeva, level: 15);
        public static readonly Monster PicketLv17 = new MonsterCreator(UnitsTraits.Picket, level: 17);
        public static readonly Monster ArachneLv18 = new MonsterCreator(UnitsTraits.Arachne, level: 18);
        public static readonly Monster WeadogLv19 = new MonsterCreator(UnitsTraits.Weadog, level: 19);
        public static readonly Monster UnicornLv20 = new MonsterCreator(UnitsTraits.Unicorn, level: 20);
        public static readonly Monster ViperLv21 = new MonsterCreator(UnitsTraits.Viper, level: 21);
        public static readonly Monster PulunpaCollarJackLv16 = new MonsterCreator(UnitsTraits.Pulunpa, level: 16);
        public static readonly Monster BlockLv22 = new MonsterCreator(UnitsTraits.Block, level: 22);
        public static readonly Monster StealthLv23 = new MonsterCreator(UnitsTraits.Stealth, level: 23);
        public static readonly Monster ZuLv24 = new MonsterCreator(UnitsTraits.Zu, level: 24);
        public static readonly Monster MandaraLv26 = new MonsterCreator(UnitsTraits.Mandara, level: 26);
        public static readonly Monster SnowmanLv25 = new MonsterCreator(UnitsTraits.Snowman, level: 25);
        public static readonly Monster ManoevaLv25 = new MonsterCreator(UnitsTraits.Manoeva, level: 25);
        public static readonly Monster NaplassLv27 = new MonsterCreator(UnitsTraits.Naplass, level: 27);
        public static readonly Monster KillerLv28 = new MonsterCreator(UnitsTraits.Killer, level: 28)
            .GiveWeapon(new ConstantDamageWeapon(name: "", damage: 8));
        public static readonly Monster TyrantLv29 = new MonsterCreator(UnitsTraits.Tyrant, level: 29);
        public static readonly Monster DragonLv29 = new MonsterCreator(UnitsTraits.Dragon, level: 29);
        public static readonly Monster GlacierLv30 = new MonsterCreator(UnitsTraits.Glacier, level: 30);
        public static readonly Monster GolemLv30 = new MonsterCreator(UnitsTraits.Golem, level: 30)
            .GiveWeapon(new ConstantDamageWeapon(name: "", damage: 4));
        public static readonly Monster MaximumLv30 = new MonsterCreator(UnitsTraits.Maximum, level: 30);

        public static readonly Monster[][] PerFloor = {
            // 1
            new Monster[] { NoiseLv1, PulunpaLv1, TrollHammerLv2 },
            // 2
            new Monster[] { NoiseLv1, PulunpaLv1, TrollHammerLv2, FlameLv3 },
            // 3
            new Monster[] { PulunpaLv1, TrollHammerLv2, FlameLv3, CycloneLv4 },
            // 4
            new Monster[] { TrollHammerLv2, FlameLv3, CycloneLv4, BalloonLv5 },
            // 5
            new Monster[] { FlameLv3, CycloneLv4, BalloonLv5, ManoevaLv5 },
            // 6
            new Monster[] { CycloneLv4, BalloonLv5, ManoevaLv5, BlumeLv6 },
            // 7
            new Monster[] { BalloonLv5, ManoevaLv5, BlumeLv6, UBoatLv7 },
            // 8
            new Monster[] { ManoevaLv5, BlumeLv6, UBoatLv7, ClownLv8 },
            // 9
            new Monster[] { BlumeLv6, UBoatLv7, ClownLv8, DreaminLv9 },
            // 10
            new Monster[] { ClownLv8, DreaminLv9, TrollBowLv10, VolcanoLv11 },
            // 11
            new Monster[] { DreaminLv9, TrollBowLv10, VolcanoLv11, GriffonLv12 },
            // 12
            new Monster[] { DreaminLv9, VolcanoLv11, GriffonLv12, KrakenLv13 },
            // 13
            new Monster[] { VolcanoLv11, GriffonLv12, KrakenLv13, NyuelLv14 },
            // 14
            new Monster[] { KrakenLv13, NyuelLv14, GarudaLv16, TrollSwordLv15 },
            // 15
            new Monster[] { KrakenLv13, NyuelLv14, GarudaLv16, TrollSwordLv15 },
            // 16
            new Monster[] { GarudaLv16, TrollSwordLv15, ManoevaLv15, BarongLv20 },
            // 17
            new Monster[] { GarudaLv16, TrollSwordLv15, ManoevaLv15, TrollHammerLv2, TrollBowLv10, PicketLv17 },
            // 18
            new Monster[] { ManoevaLv15, ArachneLv18, PicketLv17 },
            // 19
            new Monster[] { ManoevaLv15, ArachneLv18, PicketLv17, WeadogLv19 },
            // 20
            new Monster[] { ArachneLv18, WeadogLv19, UnicornLv20, ViperLv21 },
            // 21
            new Monster[] { WeadogLv19, UnicornLv20, ViperLv21, PulunpaLv1, PulunpaCollarJackLv16 },
            // 22
            new Monster[] { UnicornLv20, ViperLv21, PulunpaLv1, PulunpaCollarJackLv16, BlockLv22 },
            // 23
            new Monster[] { UnicornLv20, ViperLv21, BlockLv22, StealthLv23 },
            // 24
            new Monster[] { ViperLv21, BlockLv22, StealthLv23, ZuLv24 },
            // 25
            new Monster[] { BlockLv22, StealthLv23, ZuLv24, PicketLv17 },
            // 26
            new Monster[] { ZuLv24, MandaraLv26, SnowmanLv25, BarongLv20 },
            // 27
            new Monster[] { ZuLv24, MandaraLv26, SnowmanLv25, ManoevaLv25 },
            // 28
            new Monster[] { MandaraLv26, SnowmanLv25, ManoevaLv25, NaplassLv27 },
            // 29
            new Monster[] { SnowmanLv25, ManoevaLv25, NaplassLv27, KillerLv28 },
            // 30
            new Monster[] { ManoevaLv25, NaplassLv27, KillerLv28, TyrantLv29 },
            // 31
            new Monster[] { NaplassLv27, KillerLv28, TyrantLv29, DragonLv29 },
            // 32
            new Monster[] { KillerLv28, TyrantLv29, DragonLv29, GlacierLv30 },
            // 33
            new Monster[] { TyrantLv29, DragonLv29, GlacierLv30, GolemLv30 },
            // 34
            new Monster[] { TyrantLv29, DragonLv29, GlacierLv30, GolemLv30 },
            // 35
            new Monster[] { DragonLv29, GlacierLv30, GolemLv30, MaximumLv30 },
            // 36
            new Monster[] { GlacierLv30, GolemLv30, MaximumLv30, BarongLv20 },
            // 37
            new Monster[] { GlacierLv30, GolemLv30, MaximumLv30, DragonLv29 },
            // 38
            new Monster[] { GlacierLv30, GolemLv30, MaximumLv30, DragonLv29 },
            // 39
            new Monster[] { GlacierLv30, GolemLv30, MaximumLv30, DragonLv29 }
        };

    }

    public struct Eggs
    {
        public static readonly Egg[] Floor1_5 =
        {
                new Egg(UnitsTraits.Noise.Name, 0.1875f),
                new Egg(UnitsTraits.Flame.Name, 0.1563f),
                new Egg(UnitsTraits.Pulunpa.Name, 0.1563f),
                new Egg(UnitsTraits.Balloon.Name, 0.125f),
                new Egg(UnitsTraits.Troll.Name, 0.125f),
                new Egg(UnitsTraits.Blume.Name, 0.0938f),
                new Egg(UnitsTraits.Cyclone.Name, 0.0938f),
                new Egg(UnitsTraits.Manoeva.Name, 0.0625f)
            };
        public static readonly Egg[] Floor6_10 =
        {
                new Egg(UnitsTraits.Blume.Name, 0.1875f),
                new Egg(UnitsTraits.Balloon.Name, 0.1563f),
                new Egg(UnitsTraits.Cyclone.Name, 0.1563f),
                new Egg(UnitsTraits.Manoeva.Name, 0.125f),
                new Egg(UnitsTraits.Clown.Name, 0.0938f),
                new Egg(UnitsTraits.Dreamin.Name, 0.0938f),
                new Egg(UnitsTraits.UBoat.Name, 0.0938f),
                new Egg(UnitsTraits.Volcano.Name, 0.0938f)
            };
        public static readonly Egg[] Floor11_15 =
        {
                new Egg(UnitsTraits.Clown.Name, 0.1563f),
                new Egg(UnitsTraits.Dreamin.Name, 0.1563f),
                new Egg(UnitsTraits.UBoat.Name, 0.1563f),
                new Egg(UnitsTraits.Volcano.Name, 0.1563f),
                new Egg(UnitsTraits.Garuda.Name, 0.0938f),
                new Egg(UnitsTraits.Griffon.Name, 0.0938f),
                new Egg(UnitsTraits.Kraken.Name, 0.0938f),
                new Egg(UnitsTraits.Nyuel.Name, 0.0938f)
            };
        public static readonly Egg[] Floor16_20 =
        {
                new Egg(UnitsTraits.Garuda.Name, 0.1563f),
                new Egg(UnitsTraits.Griffon.Name, 0.1563f),
                new Egg(UnitsTraits.Kraken.Name, 0.1563f),
                new Egg(UnitsTraits.Nyuel.Name, 0.1563f),
                new Egg(UnitsTraits.Arachne.Name, 0.0938f),
                new Egg(UnitsTraits.Picket.Name, 0.0938f),
                new Egg(UnitsTraits.Weadog.Name, 0.0938f),
                new Egg(UnitsTraits.Troll.Name, 0.0625f),
                new Egg(UnitsTraits.Barong.Name, 0.0313f)
            };
        public static readonly Egg[] Floor21_25 =
        {
                new Egg(UnitsTraits.Arachne.Name, 0.1563f),
                new Egg(UnitsTraits.Picket.Name, 0.1563f),
                new Egg(UnitsTraits.Weadog.Name, 0.1563f),
                new Egg(UnitsTraits.Block.Name, 0.0938f),
                new Egg(UnitsTraits.Stealth.Name, 0.0938f),
                new Egg(UnitsTraits.Unicorn.Name, 0.0938f),
                new Egg(UnitsTraits.Viper.Name, 0.0938f),
                new Egg(UnitsTraits.Manoeva.Name, 0.0625f),
                new Egg(UnitsTraits.Troll.Name, 0.0625f),
                new Egg(UnitsTraits.Barong.Name, 0.0313f)
            };
        public static readonly Egg[] Floor26_30 =
        {
                new Egg(UnitsTraits.Block.Name, 0.1563f),
                new Egg(UnitsTraits.Stealth.Name, 0.1563f),
                new Egg(UnitsTraits.Unicorn.Name, 0.1563f),
                new Egg(UnitsTraits.Viper.Name, 0.1563f),
                new Egg(UnitsTraits.Mandara.Name, 0.0938f),
                new Egg(UnitsTraits.Naplass.Name, 0.0938f),
                new Egg(UnitsTraits.Snowman.Name, 0.0938f),
                new Egg(UnitsTraits.Zu.Name, 0.0938f)
            };
        public static readonly Egg[] Floor31_35 =
        {
                new Egg(UnitsTraits.Mandara.Name, 0.1563f),
                new Egg(UnitsTraits.Naplass.Name, 0.1563f),
                new Egg(UnitsTraits.Snowman.Name, 0.1563f),
                new Egg(UnitsTraits.Zu.Name, 0.1563f),
                new Egg(UnitsTraits.Glacier.Name, 0.0938f),
                new Egg(UnitsTraits.Kid.Name, 0.0938f),
                new Egg(UnitsTraits.Killer.Name, 0.0938f),
                new Egg(UnitsTraits.Tyrant.Name, 0.0938f)
            };
        public static readonly Egg[] Floor36_39 =
        {
                new Egg(UnitsTraits.Killer.Name, 0.2188f),
                new Egg(UnitsTraits.Glacier.Name, 0.1875f),
                new Egg(UnitsTraits.Tyrant.Name, 0.1875f),
                new Egg(UnitsTraits.Golem.Name, 0.1563f),
                new Egg(UnitsTraits.Kid.Name, 0.1563f),
                new Egg(UnitsTraits.Maximum.Name, 0.0938f)
            };
    }

    struct Swords
    {
        public static readonly Sword Gold = new Sword(name: "Gold sword", baseAttack: 1);
        public static readonly Sword Copper = new Sword(name: "Copper sword", baseAttack: 2);
        public static readonly Sword Iron = new Sword(name: "Iron sword", baseAttack: 3);
        public static readonly Sword Steel = new Sword(name: "Steel sword", baseAttack: 4);
        public static readonly Sword Vital = new Sword(name: "Vital sword", baseAttack: 5);
        public static readonly Sword Holy = new Sword(name: "Holy sword", baseAttack: 7);
        public static readonly Sword Seraphim = new Sword(name: "Seraphim sword", baseAttack: 8);
        public static readonly Sword Dark = new Sword(name: "Dark sword", baseAttack: 10);
        public static readonly Sword Blizzard = new Sword(name: "Blizzard sword", baseAttack: 5, genus: Genus.Water);
        public static readonly Sword Fire = new Sword(name: "Fire sword", baseAttack: 5, genus: Genus.Fire);
        public static readonly Sword Gulfwind = new Sword(name: "Gulfwind sword", baseAttack: 5, genus: Genus.Wind);
    }

    struct Wands
    {
        public static readonly Wand Wooden = new Wand(name: "Wooden wand");
        public static readonly Wand Scarlet = new Wand(name: "Scarlet wand", genus: Genus.Fire);
        public static readonly Wand Gulf = new Wand(name: "Gulf wand", genus: Genus.Wind);
        public static readonly Wand Stream = new Wand(name: "Stream wand", genus: Genus.Water);
        public static readonly Wand Money = new Wand(name: "Money wand");
        public static readonly Wand Paralyze = new Wand(name: "Paralyze wand");
        public static readonly Wand Life = new Wand(name: "Life wand");
        public static readonly Wand Trained = new Wand(name: "Trained wand");
    }

    struct Shields
    {
        public static readonly Shield Leather = new Shield(name: "Leather", baseDefense: 1);
        public static readonly Shield Wood = new Shield(name: "Wood", baseDefense: 2);
        public static readonly Shield Mirror = new Shield(name: "Mirror", baseDefense: 3);
        public static readonly Shield Copper = new Shield(name: "Copper", baseDefense: 4);
        public static readonly Shield Iron = new Shield(name: "Iron", baseDefense: 5);
        public static readonly Shield Steel = new Shield(name: "Steel", baseDefense: 6);
        public static readonly Shield Scorch = new Shield(name: "Scorch", baseDefense: 5, genus: Genus.Fire);
        public static readonly Shield Ice = new Shield(name: "Ice", baseDefense: 5, genus: Genus.Water);
        public static readonly Shield Earth = new Shield(name: "Earth", baseDefense: 5, genus: Genus.Wind);
        public static readonly Shield Live = new Shield(name: "Live", baseDefense: 5);
        public static readonly Shield Diamond = new Shield(name: "Diamond", baseDefense: 7);
    }
}
