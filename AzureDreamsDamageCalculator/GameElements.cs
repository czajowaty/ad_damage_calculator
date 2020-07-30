namespace AzureDreamsDamageCalculator
{
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
