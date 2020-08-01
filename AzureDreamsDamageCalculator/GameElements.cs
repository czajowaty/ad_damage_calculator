namespace AzureDreamsDamageCalculator
{
    public struct UnitsTraits
    {
        public static readonly UnitTraits Koh = new UnitTraits()
        {
            baseHp = 0x10,
            hpGrowth = 0x16,
            baseMp = 0x64,
            mpGrowth = 0x00,
            baseAttack = 0x05,
            attackGrowth = 0x0D,
            baseDefense = 0x04,
            defenseGrowth = 0x0E,
            baseAgility = 0x04,
            agilityGrowth = 0x08,
            baseLuck = 0x20,
            luckGrowth = 0x00,
            baseExpGiven = 0x10,
            expGivenGrowth = 0x10,
            nativeGenus = Genus.None,
            liftable = false,
            pushable = false
        };
        public static readonly UnitTraits Hikewne = new UnitTraits()
        {
            baseHp = 0x0F,
            hpGrowth = 0x11,
            baseMp = 0x78,
            mpGrowth = 0x04,
            baseAttack = 0x07,
            attackGrowth = 0x14,
            baseDefense = 0x07,
            defenseGrowth = 0x13,
            baseAgility = 0x08,
            agilityGrowth = 0x12,
            baseLuck = 0x64,
            luckGrowth = 0x00,
            baseExpGiven = 0x03,
            expGivenGrowth = 0x1E,
            nativeGenus = Genus.None,
            liftable = false,
            pushable = false
        };
        public static readonly UnitTraits Kewne = new UnitTraits()
        {
            baseHp = 0x0C,
            hpGrowth = 0x12,
            baseMp = 0x64,
            mpGrowth = 0x00,
            baseAttack = 0x06,
            attackGrowth = 0x14,
            baseDefense = 0x06,
            defenseGrowth = 0x0E,
            baseAgility = 0x05,
            agilityGrowth = 0x14,
            baseLuck = 0x50,
            luckGrowth = 0x00,
            baseExpGiven = 0x03,
            expGivenGrowth = 0x10,
            nativeGenus = Genus.Fire,
            liftable = true,
            pushable = true
        };
        public static readonly UnitTraits Dragon = new UnitTraits()
        {
            baseHp = 0x0F,
            hpGrowth = 0x12,
            baseMp = 0x46,
            mpGrowth = 0x00,
            baseAttack = 0x09,
            attackGrowth = 0x11,
            baseDefense = 0x08,
            defenseGrowth = 0x13,
            baseAgility = 0x04,
            agilityGrowth = 0x14,
            baseLuck = 0x4B,
            luckGrowth = 0x00,
            baseExpGiven = 0x03,
            expGivenGrowth = 0x16,
            nativeGenus = Genus.Fire,
            liftable = false,
            pushable = false
        };
        public static readonly UnitTraits Kid = new UnitTraits()
        {
            baseHp = 0x0C,
            hpGrowth = 0x12,
            baseMp = 0x3C,
            mpGrowth = 0x08,
            baseAttack = 0x07,
            attackGrowth = 0x14,
            baseDefense = 0x05,
            defenseGrowth = 0x13,
            baseAgility = 0x05,
            agilityGrowth = 0x14,
            baseLuck = 0x4B,
            luckGrowth = 0x00,
            baseExpGiven = 0x02,
            expGivenGrowth = 0x13,
            nativeGenus = Genus.Fire,
            liftable = true,
            pushable = true
        };
        public static readonly UnitTraits Ifrit = new UnitTraits()
        {
            baseHp = 0x09,
            hpGrowth = 0x13,
            baseMp = 0x5A,
            mpGrowth = 0x00,
            baseAttack = 0x06,
            attackGrowth = 0x15,
            baseDefense = 0x06,
            defenseGrowth = 0x12,
            baseAgility = 0x06,
            agilityGrowth = 0x0E,
            baseLuck = 0x46,
            luckGrowth = 0x00,
            baseExpGiven = 0x03,
            expGivenGrowth = 0x15,
            nativeGenus = Genus.Fire,
            liftable = false,
            pushable = false
        };
        public static readonly UnitTraits Flame = new UnitTraits()
        {
            baseHp = 0x09,
            hpGrowth = 0x12,
            baseMp = 0x50,
            mpGrowth = 0x00,
            baseAttack = 0x05,
            attackGrowth = 0x19,
            baseDefense = 0x05,
            defenseGrowth = 0x11,
            baseAgility = 0x06,
            agilityGrowth = 0x14,
            baseLuck = 0x50,
            luckGrowth = 0x00,
            baseExpGiven = 0x02,
            expGivenGrowth = 0x0F,
            nativeGenus = Genus.Fire,
            liftable = false,
            pushable = true
        };
        public static readonly UnitTraits Grineut = new UnitTraits()
        {
            baseHp = 0x0A,
            hpGrowth = 0x14,
            baseMp = 0x50,
            mpGrowth = 0x00,
            baseAttack = 0x06,
            attackGrowth = 0x13,
            baseDefense = 0x06,
            defenseGrowth = 0x12,
            baseAgility = 0x06,
            agilityGrowth = 0x15,
            baseLuck = 0x46,
            luckGrowth = 0x00,
            baseExpGiven = 0x03,
            expGivenGrowth = 0x12,
            nativeGenus = Genus.Fire,
            liftable = false,
            pushable = false
        };
        public static readonly UnitTraits Griffon = new UnitTraits()
        {
            baseHp = 0x09,
            hpGrowth = 0x14,
            baseMp = 0x50,
            mpGrowth = 0x00,
            baseAttack = 0x06,
            attackGrowth = 0x13,
            baseDefense = 0x05,
            defenseGrowth = 0x12,
            baseAgility = 0x05,
            agilityGrowth = 0x19,
            baseLuck = 0x50,
            luckGrowth = 0x00,
            baseExpGiven = 0x02,
            expGivenGrowth = 0x10,
            nativeGenus = Genus.Fire,
            liftable = true,
            pushable = true
        };
        public static readonly UnitTraits Saber = new UnitTraits()
        {
            baseHp = 0x0A,
            hpGrowth = 0x14,
            baseMp = 0x5A,
            mpGrowth = 0x00,
            baseAttack = 0x05,
            attackGrowth = 0x17,
            baseDefense = 0x05,
            defenseGrowth = 0x13,
            baseAgility = 0x05,
            agilityGrowth = 0x16,
            baseLuck = 0x46,
            luckGrowth = 0x00,
            baseExpGiven = 0x03,
            expGivenGrowth = 0x11,
            nativeGenus = Genus.Water,
            liftable = false,
            pushable = false
        };
        public static readonly UnitTraits Snowman = new UnitTraits()
        {
            baseHp = 0x0A,
            hpGrowth = 0x14,
            baseMp = 0x5A,
            mpGrowth = 0x00,
            baseAttack = 0x05,
            attackGrowth = 0x16,
            baseDefense = 0x05,
            defenseGrowth = 0x11,
            baseAgility = 0x04,
            agilityGrowth = 0x16,
            baseLuck = 0x4B,
            luckGrowth = 0x00,
            baseExpGiven = 0x02,
            expGivenGrowth = 0x0F,
            nativeGenus = Genus.Water,
            liftable = false,
            pushable = true
        };
        public static readonly UnitTraits Ashra = new UnitTraits()
        {
            baseHp = 0x09,
            hpGrowth = 0x11,
            baseMp = 0x50,
            mpGrowth = 0x00,
            baseAttack = 0x06,
            attackGrowth = 0x14,
            baseDefense = 0x05,
            defenseGrowth = 0x16,
            baseAgility = 0x05,
            agilityGrowth = 0x15,
            baseLuck = 0x46,
            luckGrowth = 0x00,
            baseExpGiven = 0x03,
            expGivenGrowth = 0x0F,
            nativeGenus = Genus.Water,
            liftable = false,
            pushable = false
        };
        public static readonly UnitTraits Arachne = new UnitTraits()
        {
            baseHp = 0x09,
            hpGrowth = 0x10,
            baseMp = 0x46,
            mpGrowth = 0x00,
            baseAttack = 0x06,
            attackGrowth = 0x12,
            baseDefense = 0x05,
            defenseGrowth = 0x14,
            baseAgility = 0x05,
            agilityGrowth = 0x14,
            baseLuck = 0x46,
            luckGrowth = 0x00,
            baseExpGiven = 0x02,
            expGivenGrowth = 0x0E,
            nativeGenus = Genus.Water,
            liftable = true,
            pushable = true
        };
        public static readonly UnitTraits Battnel = new UnitTraits()
        {
            baseHp = 0x0A,
            hpGrowth = 0x13,
            baseMp = 0x46,
            mpGrowth = 0x00,
            baseAttack = 0x07,
            attackGrowth = 0x14,
            baseDefense = 0x06,
            defenseGrowth = 0x14,
            baseAgility = 0x05,
            agilityGrowth = 0x11,
            baseLuck = 0x46,
            luckGrowth = 0x00,
            baseExpGiven = 0x03,
            expGivenGrowth = 0x12,
            nativeGenus = Genus.Water,
            liftable = false,
            pushable = false
        };
        public static readonly UnitTraits Nyuel = new UnitTraits()
        {
            baseHp = 0x0A,
            hpGrowth = 0x0F,
            baseMp = 0x50,
            mpGrowth = 0x00,
            baseAttack = 0x04,
            attackGrowth = 0x13,
            baseDefense = 0x05,
            defenseGrowth = 0x13,
            baseAgility = 0x08,
            agilityGrowth = 0x13,
            baseLuck = 0x50,
            luckGrowth = 0x00,
            baseExpGiven = 0x02,
            expGivenGrowth = 0x0E,
            nativeGenus = Genus.Water,
            liftable = false,
            pushable = true
        };
        public static readonly UnitTraits Death = new UnitTraits()
        {
            baseHp = 0x08,
            hpGrowth = 0x13,
            baseMp = 0x50,
            mpGrowth = 0x00,
            baseAttack = 0x06,
            attackGrowth = 0x12,
            baseDefense = 0x05,
            defenseGrowth = 0x12,
            baseAgility = 0x06,
            agilityGrowth = 0x12,
            baseLuck = 0x46,
            luckGrowth = 0x00,
            baseExpGiven = 0x03,
            expGivenGrowth = 0x10,
            nativeGenus = Genus.Wind,
            liftable = false,
            pushable = true
        };
        public static readonly UnitTraits Clown = new UnitTraits()
        {
            baseHp = 0x08,
            hpGrowth = 0x12,
            baseMp = 0x50,
            mpGrowth = 0x00,
            baseAttack = 0x06,
            attackGrowth = 0x11,
            baseDefense = 0x05,
            defenseGrowth = 0x12,
            baseAgility = 0x06,
            agilityGrowth = 0x12,
            baseLuck = 0x46,
            luckGrowth = 0x00,
            baseExpGiven = 0x02,
            expGivenGrowth = 0x12,
            nativeGenus = Genus.Wind,
            liftable = true,
            pushable = true
        };
        public static readonly UnitTraits Univern = new UnitTraits()
        {
            baseHp = 0x0A,
            hpGrowth = 0x16,
            baseMp = 0x50,
            mpGrowth = 0x00,
            baseAttack = 0x06,
            attackGrowth = 0x12,
            baseDefense = 0x06,
            defenseGrowth = 0x0F,
            baseAgility = 0x07,
            agilityGrowth = 0x12,
            baseLuck = 0x46,
            luckGrowth = 0x00,
            baseExpGiven = 0x03,
            expGivenGrowth = 0x14,
            nativeGenus = Genus.Wind,
            liftable = false,
            pushable = false
        };
        public static readonly UnitTraits Unicorn = new UnitTraits()
        {
            baseHp = 0x09,
            hpGrowth = 0x14,
            baseMp = 0x50,
            mpGrowth = 0x00,
            baseAttack = 0x05,
            attackGrowth = 0x11,
            baseDefense = 0x05,
            defenseGrowth = 0x12,
            baseAgility = 0x07,
            agilityGrowth = 0x0F,
            baseLuck = 0x46,
            luckGrowth = 0x00,
            baseExpGiven = 0x02,
            expGivenGrowth = 0x0E,
            nativeGenus = Genus.Wind,
            liftable = true,
            pushable = true
        };
        public static readonly UnitTraits Metal = new UnitTraits()
        {
            baseHp = 0x0A,
            hpGrowth = 0x11,
            baseMp = 0x50,
            mpGrowth = 0x00,
            baseAttack = 0x06,
            attackGrowth = 0x11,
            baseDefense = 0x08,
            defenseGrowth = 0x13,
            baseAgility = 0x04,
            agilityGrowth = 0x16,
            baseLuck = 0x46,
            luckGrowth = 0x00,
            baseExpGiven = 0x03,
            expGivenGrowth = 0x12,
            nativeGenus = Genus.Wind,
            liftable = false,
            pushable = false
        };
        public static readonly UnitTraits Block = new UnitTraits()
        {
            baseHp = 0x0A,
            hpGrowth = 0x10,
            baseMp = 0x50,
            mpGrowth = 0x00,
            baseAttack = 0x06,
            attackGrowth = 0x10,
            baseDefense = 0x08,
            defenseGrowth = 0x12,
            baseAgility = 0x03,
            agilityGrowth = 0x16,
            baseLuck = 0x46,
            luckGrowth = 0x00,
            baseExpGiven = 0x02,
            expGivenGrowth = 0x10,
            nativeGenus = Genus.Wind,
            liftable = false,
            pushable = false
        };
        public static readonly UnitTraits Pulunpa = new UnitTraits()
        {
            baseHp = 0x08,
            hpGrowth = 0x13,
            baseMp = 0x28,
            mpGrowth = 0x00,
            baseAttack = 0x04,
            attackGrowth = 0x12,
            baseDefense = 0x04,
            defenseGrowth = 0x13,
            baseAgility = 0x04,
            agilityGrowth = 0x14,
            baseLuck = 0x32,
            luckGrowth = 0x00,
            baseExpGiven = 0x01,
            expGivenGrowth = 0x0B,
            nativeGenus = Genus.Water,
            liftable = true,
            pushable = true
        };
        public static readonly UnitTraits Troll = new UnitTraits()
        {
            baseHp = 0x06,
            hpGrowth = 0x12,
            baseMp = 0x3C,
            mpGrowth = 0x00,
            baseAttack = 0x04,
            attackGrowth = 0x12,
            baseDefense = 0x05,
            defenseGrowth = 0x12,
            baseAgility = 0x05,
            agilityGrowth = 0x12,
            baseLuck = 0x3C,
            luckGrowth = 0x00,
            baseExpGiven = 0x04,
            expGivenGrowth = 0x0F,
            nativeGenus = Genus.Fire,
            liftable = true,
            pushable = true
        };
        public static readonly UnitTraits Noise = new UnitTraits()
        {
            baseHp = 0x09,
            hpGrowth = 0x0F,
            baseMp = 0x46,
            mpGrowth = 0x00,
            baseAttack = 0x06,
            attackGrowth = 0x13,
            baseDefense = 0x05,
            defenseGrowth = 0x14,
            baseAgility = 0x05,
            agilityGrowth = 0x10,
            baseLuck = 0x41,
            luckGrowth = 0x00,
            baseExpGiven = 0x03,
            expGivenGrowth = 0x0C,
            nativeGenus = Genus.Wind,
            liftable = false,
            pushable = true
        };
        public static readonly UnitTraits UBoat = new UnitTraits()
        {
            baseHp = 0x09,
            hpGrowth = 0x11,
            baseMp = 0x50,
            mpGrowth = 0x00,
            baseAttack = 0x06,
            attackGrowth = 0x12,
            baseDefense = 0x05,
            defenseGrowth = 0x14,
            baseAgility = 0x05,
            agilityGrowth = 0x16,
            baseLuck = 0x3C,
            luckGrowth = 0x00,
            baseExpGiven = 0x02,
            expGivenGrowth = 0x0F,
            nativeGenus = Genus.Water,
            liftable = true,
            pushable = true
        };
        public static readonly UnitTraits Baloon = new UnitTraits()
        {
            baseHp = 0x08,
            hpGrowth = 0x14,
            baseMp = 0x46,
            mpGrowth = 0x00,
            baseAttack = 0x06,
            attackGrowth = 0x11,
            baseDefense = 0x05,
            defenseGrowth = 0x13,
            baseAgility = 0x06,
            agilityGrowth = 0x10,
            baseLuck = 0x50,
            luckGrowth = 0x00,
            baseExpGiven = 0x02,
            expGivenGrowth = 0x0C,
            nativeGenus = Genus.Fire,
            liftable = false,
            pushable = true
        };
        public static readonly UnitTraits Dreamin = new UnitTraits()
        {
            baseHp = 0x08,
            hpGrowth = 0x13,
            baseMp = 0x46,
            mpGrowth = 0x00,
            baseAttack = 0x03,
            attackGrowth = 0x13,
            baseDefense = 0x05,
            defenseGrowth = 0x13,
            baseAgility = 0x04,
            agilityGrowth = 0x13,
            baseLuck = 0x3C,
            luckGrowth = 0x00,
            baseExpGiven = 0x02,
            expGivenGrowth = 0x0A,
            nativeGenus = Genus.Wind,
            liftable = true,
            pushable = true
        };
        public static readonly UnitTraits Blume = new UnitTraits()
        {
            baseHp = 0x09,
            hpGrowth = 0x17,
            baseMp = 0x50,
            mpGrowth = 0x00,
            baseAttack = 0x05,
            attackGrowth = 0x14,
            baseDefense = 0x04,
            defenseGrowth = 0x16,
            baseAgility = 0x05,
            agilityGrowth = 0x13,
            baseLuck = 0x46,
            luckGrowth = 0x00,
            baseExpGiven = 0x02,
            expGivenGrowth = 0x0D,
            nativeGenus = Genus.Water,
            liftable = false,
            pushable = true
        };
        public static readonly UnitTraits Volcano = new UnitTraits()
        {
            baseHp = 0x09,
            hpGrowth = 0x15,
            baseMp = 0x50,
            mpGrowth = 0x00,
            baseAttack = 0x04,
            attackGrowth = 0x1B,
            baseDefense = 0x05,
            defenseGrowth = 0x10,
            baseAgility = 0x05,
            agilityGrowth = 0x13,
            baseLuck = 0x46,
            luckGrowth = 0x00,
            baseExpGiven = 0x02,
            expGivenGrowth = 0x0C,
            nativeGenus = Genus.Fire,
            liftable = true,
            pushable = true
        };
        public static readonly UnitTraits Cyclone = new UnitTraits()
        {
            baseHp = 0x09,
            hpGrowth = 0x14,
            baseMp = 0x50,
            mpGrowth = 0x00,
            baseAttack = 0x05,
            attackGrowth = 0x17,
            baseDefense = 0x05,
            defenseGrowth = 0x11,
            baseAgility = 0x05,
            agilityGrowth = 0x14,
            baseLuck = 0x3C,
            luckGrowth = 0x00,
            baseExpGiven = 0x02,
            expGivenGrowth = 0x11,
            nativeGenus = Genus.Wind,
            liftable = false,
            pushable = true
        };
        public static readonly UnitTraits Manoeva = new UnitTraits()
        {
            baseHp = 0x0A,
            hpGrowth = 0x12,
            baseMp = 0x46,
            mpGrowth = 0x00,
            baseAttack = 0x05,
            attackGrowth = 0x15,
            baseDefense = 0x06,
            defenseGrowth = 0x11,
            baseAgility = 0x05,
            agilityGrowth = 0x11,
            baseLuck = 0x3C,
            luckGrowth = 0x00,
            baseExpGiven = 0x02,
            expGivenGrowth = 0x0F,
            nativeGenus = Genus.Water,
            liftable = false,
            pushable = false
        };
        public static readonly UnitTraits Barong = new UnitTraits()
        {
            baseHp = 0x06,
            hpGrowth = 0x1C,
            baseMp = 0x3C,
            mpGrowth = 0x00,
            baseAttack = 0x05,
            attackGrowth = 0x10,
            baseDefense = 0x04,
            defenseGrowth = 0x0C,
            baseAgility = 0x05,
            agilityGrowth = 0x0E,
            baseLuck = 0x5A,
            luckGrowth = 0x02,
            baseExpGiven = 0x04,
            expGivenGrowth = 0x0D,
            nativeGenus = Genus.Fire,
            liftable = true,
            pushable = true
        };
        public static readonly UnitTraits Picket = new UnitTraits()
        {
            baseHp = 0x08,
            hpGrowth = 0x14,
            baseMp = 0x41,
            mpGrowth = 0x00,
            baseAttack = 0x03,
            attackGrowth = 0x08,
            baseDefense = 0x04,
            defenseGrowth = 0x0E,
            baseAgility = 0x08,
            agilityGrowth = 0x0F,
            baseLuck = 0x55,
            luckGrowth = 0x00,
            baseExpGiven = 0x02,
            expGivenGrowth = 0x0E,
            nativeGenus = Genus.Wind,
            liftable = true,
            pushable = true
        };
        public static readonly UnitTraits Kraken = new UnitTraits()
        {
            baseHp = 0x08,
            hpGrowth = 0x16,
            baseMp = 0x46,
            mpGrowth = 0x00,
            baseAttack = 0x06,
            attackGrowth = 0x13,
            baseDefense = 0x06,
            defenseGrowth = 0x12,
            baseAgility = 0x05,
            agilityGrowth = 0x10,
            baseLuck = 0x50,
            luckGrowth = 0x00,
            baseExpGiven = 0x01,
            expGivenGrowth = 0x10,
            nativeGenus = Genus.Water,
            liftable = false,
            pushable = false
        };
        public static readonly UnitTraits Weadog = new UnitTraits()
        {
            baseHp = 0x09,
            hpGrowth = 0x14,
            baseMp = 0x50,
            mpGrowth = 0x00,
            baseAttack = 0x06,
            attackGrowth = 0x12,
            baseDefense = 0x05,
            defenseGrowth = 0x13,
            baseAgility = 0x05,
            agilityGrowth = 0x13,
            baseLuck = 0x46,
            luckGrowth = 0x00,
            baseExpGiven = 0x01,
            expGivenGrowth = 0x0E,
            nativeGenus = Genus.Fire,
            liftable = false,
            pushable = false
        };
        public static readonly UnitTraits Stealth = new UnitTraits()
        {
            baseHp = 0x08,
            hpGrowth = 0x13,
            baseMp = 0x50,
            mpGrowth = 0x00,
            baseAttack = 0x04,
            attackGrowth = 0x14,
            baseDefense = 0x05,
            defenseGrowth = 0x14,
            baseAgility = 0x04,
            agilityGrowth = 0x13,
            baseLuck = 0x3C,
            luckGrowth = 0x00,
            baseExpGiven = 0x03,
            expGivenGrowth = 0x0C,
            nativeGenus = Genus.Wind,
            liftable = true,
            pushable = true
        };
        public static readonly UnitTraits Viper = new UnitTraits()
        {
            baseHp = 0x09,
            hpGrowth = 0x13,
            baseMp = 0x50,
            mpGrowth = 0x00,
            baseAttack = 0x06,
            attackGrowth = 0x13,
            baseDefense = 0x05,
            defenseGrowth = 0x12,
            baseAgility = 0x06,
            agilityGrowth = 0x12,
            baseLuck = 0x46,
            luckGrowth = 0x00,
            baseExpGiven = 0x03,
            expGivenGrowth = 0x0F,
            nativeGenus = Genus.Water,
            liftable = true,
            pushable = true
        };
        public static readonly UnitTraits Naplass = new UnitTraits()
        {
            baseHp = 0x0B,
            hpGrowth = 0x14,
            baseMp = 0x50,
            mpGrowth = 0x00,
            baseAttack = 0x06,
            attackGrowth = 0x12,
            baseDefense = 0x06,
            defenseGrowth = 0x13,
            baseAgility = 0x05,
            agilityGrowth = 0x10,
            baseLuck = 0x3C,
            luckGrowth = 0x00,
            baseExpGiven = 0x03,
            expGivenGrowth = 0x0E,
            nativeGenus = Genus.Fire,
            liftable = false,
            pushable = true
        };
        public static readonly UnitTraits Zu = new UnitTraits()
        {
            baseHp = 0x0A,
            hpGrowth = 0x13,
            baseMp = 0x50,
            mpGrowth = 0x00,
            baseAttack = 0x06,
            attackGrowth = 0x11,
            baseDefense = 0x05,
            defenseGrowth = 0x11,
            baseAgility = 0x07,
            agilityGrowth = 0x0F,
            baseLuck = 0x50,
            luckGrowth = 0x00,
            baseExpGiven = 0x02,
            expGivenGrowth = 0x0C,
            nativeGenus = Genus.Wind,
            liftable = true,
            pushable = true
        };
        public static readonly UnitTraits Mandara = new UnitTraits()
        {
            baseHp = 0x0B,
            hpGrowth = 0x0E,
            baseMp = 0x55,
            mpGrowth = 0x00,
            baseAttack = 0x06,
            attackGrowth = 0x12,
            baseDefense = 0x06,
            defenseGrowth = 0x0F,
            baseAgility = 0x05,
            agilityGrowth = 0x11,
            baseLuck = 0x50,
            luckGrowth = 0x00,
            baseExpGiven = 0x03,
            expGivenGrowth = 0x10,
            nativeGenus = Genus.Water,
            liftable = false,
            pushable = true
        };
        public static readonly UnitTraits Killer = new UnitTraits()
        {
            baseHp = 0x0A,
            hpGrowth = 0x13,
            baseMp = 0x3C,
            mpGrowth = 0x00,
            baseAttack = 0x08,
            attackGrowth = 0x12,
            baseDefense = 0x05,
            defenseGrowth = 0x13,
            baseAgility = 0x05,
            agilityGrowth = 0x13,
            baseLuck = 0x50,
            luckGrowth = 0x00,
            baseExpGiven = 0x03,
            expGivenGrowth = 0x12,
            nativeGenus = Genus.Fire,
            liftable = false,
            pushable = false
        };
        public static readonly UnitTraits Garuda = new UnitTraits()
        {
            baseHp = 0x0A,
            hpGrowth = 0x10,
            baseMp = 0x50,
            mpGrowth = 0x00,
            baseAttack = 0x05,
            attackGrowth = 0x13,
            baseDefense = 0x05,
            defenseGrowth = 0x15,
            baseAgility = 0x06,
            agilityGrowth = 0x12,
            baseLuck = 0x3C,
            luckGrowth = 0x00,
            baseExpGiven = 0x02,
            expGivenGrowth = 0x0E,
            nativeGenus = Genus.Wind,
            liftable = true,
            pushable = true
        };
        public static readonly UnitTraits Glacier = new UnitTraits()
        {
            baseHp = 0x0A,
            hpGrowth = 0x14,
            baseMp = 0x50,
            mpGrowth = 0x00,
            baseAttack = 0x05,
            attackGrowth = 0x12,
            baseDefense = 0x06,
            defenseGrowth = 0x13,
            baseAgility = 0x05,
            agilityGrowth = 0x11,
            baseLuck = 0x55,
            luckGrowth = 0x00,
            baseExpGiven = 0x02,
            expGivenGrowth = 0x0F,
            nativeGenus = Genus.Water,
            liftable = false,
            pushable = false
        };
        public static readonly UnitTraits Tyrant = new UnitTraits()
        {
            baseHp = 0x0A,
            hpGrowth = 0x12,
            baseMp = 0x46,
            mpGrowth = 0x00,
            baseAttack = 0x06,
            attackGrowth = 0x11,
            baseDefense = 0x06,
            defenseGrowth = 0x12,
            baseAgility = 0x05,
            agilityGrowth = 0x10,
            baseLuck = 0x41,
            luckGrowth = 0x00,
            baseExpGiven = 0x03,
            expGivenGrowth = 0x0E,
            nativeGenus = Genus.Fire,
            liftable = true,
            pushable = true
        };
        public static readonly UnitTraits Golem = new UnitTraits()
        {
            baseHp = 0x0E,
            hpGrowth = 0x0F,
            baseMp = 0x46,
            mpGrowth = 0x00,
            baseAttack = 0x07,
            attackGrowth = 0x13,
            baseDefense = 0x0A,
            defenseGrowth = 0x10,
            baseAgility = 0x04,
            agilityGrowth = 0x14,
            baseLuck = 0x46,
            luckGrowth = 0x00,
            baseExpGiven = 0x03,
            expGivenGrowth = 0x11,
            nativeGenus = Genus.Wind,
            liftable = false,
            pushable = false
        };
        public static readonly UnitTraits Maximum = new UnitTraits()
        {
            baseHp = 0x10,
            hpGrowth = 0x10,
            baseMp = 0x50,
            mpGrowth = 0x00,
            baseAttack = 0x08,
            attackGrowth = 0x13,
            baseDefense = 0x09,
            defenseGrowth = 0x0F,
            baseAgility = 0x04,
            agilityGrowth = 0x14,
            baseLuck = 0x50,
            luckGrowth = 0x00,
            baseExpGiven = 0x04,
            expGivenGrowth = 0x15,
            nativeGenus = Genus.Fire,
            liftable = false,
            pushable = false
        };
    }
    struct Monsters
    {
        public static readonly Monster Noise = new Monster(
            "Noise",
            new UnitStatistics(attack: 6, defense: 5, genus: Genus.Wind),
            hp: 9, mp: 70, image: Properties.Resources.noise);
        public static readonly Monster Pulunpa = new Monster(
            "Pulunpa", 
            new UnitStatistics(attack: 4, defense: 4, genus: Genus.Water),
            hp: 8, mp: 40, image: Properties.Resources.pulunpa);
        public static readonly Monster TrollHammer = new Monster(
            "Troll, Hammer", 
            new UnitStatistics(attack: 5, defense: 6, genus: Genus.Fire),
            hp: 13, mp: 60, image: Properties.Resources.troll,
            weapon: new ConstantDamageWeapon(2));
        public static readonly Monster Flame = new Monster(
            "Flame",
            new UnitStatistics(attack: 8, defense: 7, genus: Genus.Fire),
            hp: 20, mp: 80, image: Properties.Resources.flame);
        public static readonly Monster Cyclone = new Monster(
            "Cyclone", 
            new UnitStatistics(attack: 10, defense: 8, genus: Genus.Wind),
            hp: 25, mp: 80, image: Properties.Resources.cyclone);
        public static readonly Monster Balloon = new Monster(
            "Balloon", 
            new UnitStatistics(attack: 12, defense: 10, genus: Genus.Fire),
            hp: 28, mp: 70, image: Properties.Resources.balloon);
        public static readonly Monster ManoevaLv5 = new Monster(
            "Manoeva",
            new UnitStatistics(attack: 11, defense: 12, genus: Genus.Water),
            hp: 27, mp: 70, image: Properties.Resources.manoeva);
        public static readonly Monster Blume = new Monster(
            "Blume",
            new UnitStatistics(attack: 12, defense: 10, genus: Genus.Water),
            hp: 37, mp: 80, image: Properties.Resources.blume);
        public static readonly Monster UBoat = new Monster(
            "U-Boat",
            new UnitStatistics(attack: 16, defense: 14, genus: Genus.Water),
            hp: 30, mp: 80, image: Properties.Resources.uboat);
        public static readonly Monster Clown = new Monster(
            "Clown",
            new UnitStatistics(attack: 17, defense: 14, genus: Genus.Wind),
            hp: 32, mp: 80, image: Properties.Resources.clown);
        public static readonly Monster Dreamin = new Monster(
            "Dreamin",
            new UnitStatistics(attack: 10, defense: 16, genus: Genus.Wind),
            hp: 37, mp: 70, image: Properties.Resources.dreamin);
        public static readonly Monster TrollBow = new Monster(
            "Troll, Bow",
            new UnitStatistics(attack: 14, defense: 17, genus: Genus.Fire),
            hp: 36, mp: 60, image: Properties.Resources.troll,
            weapon: new ConstantDamageWeapon(1));
        public static readonly Monster Volcano = new Monster(
            "Volcano",
            new UnitStatistics(attack: 20, defense: 17, genus: Genus.Fire),
            hp: 48, mp: 80, image: Properties.Resources.volcano);
        public static readonly Monster Griffon = new Monster(
            "Griffon",
            new UnitStatistics(attack: 25, defense: 20, genus: Genus.Fire),
            hp: 48, mp: 80, image: Properties.Resources.griffon);
        public static readonly Monster Kraken = new Monster(
            "Kraken",
            new UnitStatistics(attack: 27, defense: 26, genus: Genus.Water),
            hp: 55, mp: 70, image: Properties.Resources.kraken);
        public static readonly Monster Nyuel = new Monster(
            "Nyuel",
            new UnitStatistics(attack: 19, defense: 24, genus: Genus.Water),
            hp: 40, mp: 80, image: Properties.Resources.nyuel);
        public static readonly Monster Garuda = new Monster(
            "Garuda",
            new UnitStatistics(attack: 27, defense: 29, genus: Genus.Wind),
            hp: 46, mp: 80, image: Properties.Resources.garuda);
        public static readonly Monster TrollSword = new Monster(
            "Troll, Sword",
            new UnitStatistics(attack: 19, defense: 24, genus: Genus.Fire),
            hp: 46, mp: 60, image: Properties.Resources.troll);
        public static readonly Monster Barong = new Monster(
            "Barong",
            new UnitStatistics(attack: 28, defense: 18, genus: Genus.Fire),
            hp: 95, mp: 60, image: Properties.Resources.barong);
        public static readonly Monster ManoevaLv15 = new Monster(
            "Manoeva",
            new UnitStatistics(attack: 27, defense: 28, genus: Genus.Water),
            hp: 50, mp: 70, image: Properties.Resources.manoeva);
        public static readonly Monster Picket = new Monster(
            "Picket",
            new UnitStatistics(attack: 9, defense: 18, genus: Genus.Wind),
            hp: 59, mp: 65, image: Properties.Resources.picket);
        public static readonly Monster Arachne = new Monster(
            "Arachne",
            new UnitStatistics(attack: 68, defense: 31, genus: Genus.Water),
            hp: 49, mp: 70, image: Properties.Resources.arachne);
        public static readonly Monster Weadog = new Monster(
            "Weadog",
            new UnitStatistics(attack: 36, defense: 31, genus: Genus.Fire),
            hp: 64, mp: 80, image: Properties.Resources.weadog);
        public static readonly Monster Unicorn = new Monster(
            "Unicorn",
            new UnitStatistics(attack: 30, defense: 31, genus: Genus.Wind),
            hp: 66, mp: 80, image: Properties.Resources.unicorn);
        public static readonly Monster Viper = new Monster(
            "Viper",
            new UnitStatistics(attack: 41, defense: 33, genus: Genus.Water),
            hp: 64, mp: 80, image: Properties.Resources.viper);
        public static readonly Monster PulunpaCollarJack = new Monster(
            "Pulunpa, Collar-Jack",
            new UnitStatistics(attack: 20, defense: 21, genus: Genus.Water),
            hp: 53, mp: 40, image: Properties.Resources.pulunpa);
        public static readonly Monster Block = new Monster(
            "Block",
            new UnitStatistics(attack: 37, defense: 110, genus: Genus.Wind),
            hp: 56, mp: 80, image: Properties.Resources.block);
        public static readonly Monster Stealth = new Monster(
            "Stealth",
            new UnitStatistics(attack: 31, defense: 39, genus: Genus.Wind),
            hp: 68, mp: 80, image: Properties.Resources.stealth);
        public static readonly Monster Zu = new Monster(
            "Zu",
            new UnitStatistics(attack: 42, defense: 35, genus: Genus.Wind),
            hp: 72, mp: 80, image: Properties.Resources.zu);
        public static readonly Monster Mandara = new Monster(
            "Mandara",
            new UnitStatistics(attack: 48, defense: 41, genus: Genus.Water),
            hp: 55, mp: 85, image: Properties.Resources.mandara);
        public static readonly Monster Snowman = new Monster(
            "Snowman",
            new UnitStatistics(attack: 46, defense: 36, genus: Genus.Water),
            hp: 78, mp: 90, image: Properties.Resources.snowman);
        public static readonly Monster ManoevaLv25 = new Monster(
            "Manoeva",
            new UnitStatistics(attack: 44, defense: 44, genus: Genus.Water),
            hp: 70, mp: 70, image: Properties.Resources.manoeva);
        public static readonly Monster Naplass = new Monster(
            "Naplass",
            new UnitStatistics(attack: 49, defense: 52, genus: Genus.Fire),
            hp: 166, mp: 80, image: Properties.Resources.naplass);
        public static readonly Monster Killer = new Monster(
            "Killer",
            new UnitStatistics(attack: 68, defense: 45, genus: Genus.Fire),
            hp: 80, mp: 60, image: Properties.Resources.killer);
        public static readonly Monster Tyrant = new Monster(
            "Tyrant",
            new UnitStatistics(attack: 50, defense: 53, genus: Genus.Fire),
            hp: 76, mp: 70, image: Properties.Resources.tyrant);
        public static readonly Monster Dragon = new Monster(
            "Dragon",
            new UnitStatistics(attack: 69, defense: 54, genus: Genus.Fire),
            hp: 81, mp: 60, image: Properties.Resources.dragon);
        public static readonly Monster Glacier = new Monster(
            "Glacier",
            new UnitStatistics(attack: 45, defense: 57, genus: Genus.Water),
            hp: 88, mp: 80, image: Properties.Resources.glacier);
        public static readonly Monster Golem = new Monster(
            "Golem",
            new UnitStatistics(attack: 67, defense: 82, genus: Genus.Wind),
            hp: 68, mp: 70, image: Properties.Resources.golem);
        public static readonly Monster Maximum = new Monster(
            "Maximum",
            new UnitStatistics(attack: 76, defense: 70, genus: Genus.Fire),
            hp: 75, mp: 80, image: Properties.Resources.maximum);

        public static readonly Monster[][] PerFloor = {
            // 1
            new Monster[] { Noise, Pulunpa, TrollHammer },
            // 2
            new Monster[] { Noise, Pulunpa, TrollHammer, Flame },
            // 3
            new Monster[] { Pulunpa, TrollHammer, Flame, Cyclone },
            // 4
            new Monster[] { TrollHammer, Flame, Cyclone, Balloon },
            // 5
            new Monster[] { Flame, Cyclone, Balloon, ManoevaLv5 },
            // 6
            new Monster[] { Cyclone, Balloon, ManoevaLv5, Blume },
            // 7
            new Monster[] { Balloon, ManoevaLv5, Blume, UBoat },
            // 8
            new Monster[] { ManoevaLv5, Blume, UBoat, Clown },
            // 9
            new Monster[] { Blume, UBoat, Clown, Dreamin },
            // 10
            new Monster[] { Clown, Dreamin, TrollBow, Volcano },
            // 11
            new Monster[] { Dreamin, TrollBow, Volcano, Griffon },
            // 12
            new Monster[] { Dreamin, Volcano, Griffon, Kraken },
            // 13
            new Monster[] { Volcano, Griffon, Kraken, Nyuel },
            // 14
            new Monster[] { Kraken, Nyuel, Garuda, TrollSword },
            // 15
            new Monster[] { Kraken, Nyuel, Garuda, TrollSword },
            // 16
            new Monster[] { Garuda, TrollSword, ManoevaLv15, Barong },
            // 17
            new Monster[] { Garuda, TrollSword, ManoevaLv15, TrollHammer, TrollBow },
            // 18
            new Monster[] { ManoevaLv15, Arachne, Picket },
            // 19
            new Monster[] { ManoevaLv15, Arachne, Picket, Weadog },
            // 20
            new Monster[] { Arachne, Weadog, Unicorn, Viper },
            // 21
            new Monster[] { Weadog, Unicorn, Viper, Pulunpa, PulunpaCollarJack },
            // 22
            new Monster[] { Unicorn, Viper, Pulunpa, PulunpaCollarJack, Block },
            // 23
            new Monster[] { Unicorn, Viper, Block, Stealth },
            // 24
            new Monster[] { Viper, Block, Stealth, Zu },
            // 25
            new Monster[] { Block, Stealth, Zu, Picket },
            // 26
            new Monster[] { Zu, Mandara, Snowman, Barong },
            // 27
            new Monster[] { Zu, Mandara, Snowman, ManoevaLv25 },
            // 28
            new Monster[] { Mandara, Snowman, ManoevaLv25, Naplass },
            // 29
            new Monster[] { Snowman, ManoevaLv25, Naplass, Killer },
            // 30
            new Monster[] { ManoevaLv25, Naplass, Killer, Tyrant },
            // 31
            new Monster[] { Naplass, Killer, Tyrant, Dragon },
            // 32
            new Monster[] { Killer, Tyrant, Dragon, Glacier },
            // 33
            new Monster[] { Tyrant, Dragon, Glacier, Golem },
            // 34
            new Monster[] { Tyrant, Dragon, Glacier, Golem },
            // 35
            new Monster[] { Dragon, Glacier, Golem, Maximum },
            // 36
            new Monster[] { Glacier, Golem, Maximum, Barong },
            // 37
            new Monster[] { Glacier, Golem, Maximum, Dragon },
            // 38
            new Monster[] { Glacier, Golem, Maximum, Dragon },
            // 39
            new Monster[] { Glacier, Golem, Maximum, Dragon }
        };
    }

    struct Swords
    {
        public static readonly Sword Gold = new Sword(attack: 1);
        public static readonly Sword Copper = new Sword(attack: 2);
        public static readonly Sword Iron = new Sword(attack: 3);
        public static readonly Sword Steel = new Sword(attack: 4);
        public static readonly Sword Vital = new Sword(attack: 5);
        public static readonly Sword Holy = new Sword(attack: 7);
        public static readonly Sword Seraphim = new Sword(attack: 8);
        public static readonly Sword Dark = new Sword(attack: 10);
        public static readonly Sword Blizzard = new Sword(attack: 5, genus: Genus.Water);
        public static readonly Sword Fire = new Sword(attack: 5, genus: Genus.Fire);
        public static readonly Sword Gulfwind = new Sword(attack: 5, genus: Genus.Wind);
    }

    struct Wands
    {
        public static readonly Wand Wooden = new Wand();
        public static readonly Wand Scarlet = new Wand(Genus.Fire);
        public static readonly Wand Gulf = new Wand(Genus.Wind);
        public static readonly Wand Stream = new Wand(Genus.Water);
        public static readonly Wand Money = new Wand();
        public static readonly Wand Paralyze = new Wand();
        public static readonly Wand Life = new Wand();
        public static readonly Wand Trained = new Wand();
    }

    struct Shields
    {
        public static readonly Shield Leather = new Shield(defense: 1);
        public static readonly Shield Wood = new Shield(defense: 2);
        public static readonly Shield Mirror = new Shield(defense: 3);
        public static readonly Shield Copper = new Shield(defense: 4);
        public static readonly Shield Iron = new Shield(defense: 5);
        public static readonly Shield Steel = new Shield(defense: 6);
        public static readonly Shield Scorch = new Shield(defense: 5, genus: Genus.Fire);
        public static readonly Shield Ice = new Shield(defense: 5, genus: Genus.Water);
        public static readonly Shield Earth = new Shield(defense: 5, genus: Genus.Wind);
        public static readonly Shield Live = new Shield(defense: 5);
        public static readonly Shield Diamond = new Shield(defense: 7);
    }
}
