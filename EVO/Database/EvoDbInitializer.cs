using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GameCore;
using Xname.EVO.Migrations;
using Log = PluginAPI.Core.Log;

namespace Xname.EVO.Database;

internal class EvoDbInitializer : MigrateDatabaseToLatestVersion<EvoDbContext, Configuration>
{
    protected void Seed(EvoDbContext context)
    {
        var rarities = new List<Rarity>();
        var ranks = new List<Rank>();
        var achievements = new List<Achievement>();

        rarities.Add(new Rarity
        {
            Color = "nickel",
            Name = "Common"
        });
        rarities.Add(new Rarity
        {
            Color = "nickel",
            Name = "Uncommon"
        });
        rarities.Add(new Rarity
        {
            Color = "orange",
            Name = "Rare"
        });
        rarities.Add(new Rarity
        {
            Color = "carmine",
            Name = "Legendary"
        });
        rarities.Add(new Rarity
        {
            Color = "crimson",
            Name = "Secret"
        });

        ranks.Add(new Rank
        {
            Name = "Lab Technician",
            Rarity = rarities[0]
        });
        ranks.Add(new Rank
        {
            Name = "Project Director",
            Rarity = rarities[0]
        });
        ranks.Add(new Rank
        {
            Name = "Junior Researcher",
            Rarity = rarities[1]
        });
        ranks.Add(new Rank
        {
            Name = "Contaminated",
            Rarity = rarities[0]
        });
        ranks.Add(new Rank
        {
            Name = "Employee of the Month",
            Rarity = rarities[2]
        });
        ranks.Add(new Rank
        {
            Name = "Foundation Astronaut",
            Rarity = rarities[0]
        });
        ranks.Add(new Rank
        {
            Name = "Veteran",
            Rarity = rarities[1]
        });
        ranks.Add(new Rank
        {
            Name = "Breach Technician",
            Rarity = rarities[2]
        });
        ranks.Add(new Rank
        {
            Name = "Death's Designer",
            Rarity = rarities[2]
        });
        ranks.Add(new Rank
        {
            Name = "MTF-Nu-7 'Hammer Down'",
            Rarity = rarities[2]
        });
        ranks.Add(new Rank
        {
            Name = "O5-1",
            Rarity = rarities[3]
        });
        ranks.Add(new Rank
        {
            Name = "Master of Disaster",
            Rarity = rarities[0]
        });
        ranks.Add(new Rank
        {
            Name = "Nuclear Engineer",
            Rarity = rarities[0]
        });
        ranks.Add(new Rank
        {
            Name = "Freedom Runner",
            Rarity = rarities[1]
        });
        ranks.Add(new Rank
        {
            Name = "Terrorist",
            Rarity = rarities[0]
        });
        ranks.Add(new Rank
        {
            Name = "Recruit",
            Rarity = rarities[0]
        });
        ranks.Add(new Rank
        {
            Name = "Steady Hand",
            Rarity = rarities[1]
        });
        ranks.Add(new Rank
        {
            Name = "Special Force",
            Rarity = rarities[2]
        });
        ranks.Add(new Rank
        {
            Name = "GOC Agent",
            Rarity = rarities[2]
        });
        ranks.Add(new Rank
        {
            Name = "Civilian Casualty",
            Rarity = rarities[1]
        });
        ranks.Add(new Rank
        {
            Name = "Chaotic Soldier",
            Rarity = rarities[1]
        });
        ranks.Add(new Rank
        {
            Name = "Fugative",
            Rarity = rarities[2]
        });
        ranks.Add(new Rank
        {
            Name = "Delta Commander",
            Rarity = rarities[3]
        });
        ranks.Add(new Rank
        {
            Name = "Reality Bender",
            Rarity = rarities[0]
        });
        ranks.Add(new Rank
        {
            Name = "Plague Doctor",
            Rarity = rarities[0]
        });
        ranks.Add(new Rank
        {
            Name = "Windows Enjoyer",
            Rarity = rarities[0]
        });
        ranks.Add(new Rank
        {
            Name = "Necromancy Overlord",
            Rarity = rarities[1]
        });
        ranks.Add(new Rank
        {
            Name = "Peanut",
            Rarity = rarities[0]
        });
        ranks.Add(new Rank
        {
            Name = "Old Man",
            Rarity = rarities[0]
        });
        ranks.Add(new Rank
        {
            Name = "Brainless Humanoid",
            Rarity = rarities[0]
        });
        ranks.Add(new Rank
        {
            Name = "The Gatekeeper",
            Rarity = rarities[1]
        });
        ranks.Add(new Rank
        {
            Name = "Saboteur",
            Rarity = rarities[0]
        });
        ranks.Add(new Rank
        {
            Name = "The Escapee",
            Rarity = rarities[1]
        });
        ranks.Add(new Rank
        {
            Name = "Decommissioned",
            Rarity = rarities[1]
        });
        ranks.Add(new Rank
        {
            Name = "Judgement Day",
            Rarity = rarities[2]
        });
        ranks.Add(new Rank
        {
            Name = "Mad Scientist",
            Rarity = rarities[0]
        });
        ranks.Add(new Rank
        {
            Name = "Incident Omega",
            Rarity = rarities[2]
        });
        ranks.Add(new Rank
        {
            Name = "The Scarlet King",
            Rarity = rarities[3]
        });
        ranks.Add(new Rank
        {
            Name = "Revenge Seeker",
            Rarity = rarities[0]
        });
        ranks.Add(new Rank
        {
            Name = "Good Patient",
            Rarity = rarities[0]
        });
        ranks.Add(new Rank
        {
            Name = "Ascended",
            Rarity = rarities[0]
        });
        ranks.Add(new Rank
        {
            Name = "Police Officer",
            Rarity = rarities[1]
        });
        ranks.Add(new Rank
        {
            Name = "Celebrity",
            Rarity = rarities[0]
        });
        ranks.Add(new Rank
        {
            Name = "Electrician",
            Rarity = rarities[1]
        });
        ranks.Add(new Rank
        {
            Name = "Border Guard",
            Rarity = rarities[0]
        });
        ranks.Add(new Rank
        {
            Name = "Pro Player",
            Rarity = rarities[2]
        });
        ranks.Add(new Rank
        {
            Name = "SCP-MISTAKEN",
            Rarity = rarities[1]
        });
        ranks.Add(new Rank
        {
            Name = "Hoarder",
            Rarity = rarities[1]
        });
        ranks.Add(new Rank
        {
            Name = "Type Green",
            Rarity = rarities[1]
        });
        ranks.Add(new Rank
        {
            Name = "Council of Liars",
            Rarity = rarities[2]
        });
        ranks.Add(new Rank
        {
            Name = "Four-Leafed Clover",
            Rarity = rarities[2]
        });
        ranks.Add(new Rank
        {
            Name = "A New World",
            Rarity = rarities[3]
        });
        ranks.Add(new Rank
        {
            Name = "Doctor Darling",
            Rarity = rarities[3]
        });
        ranks.Add(new Rank
        {
            Name = "Fritz Williams 'The Administrator'",
            Rarity = rarities[4]
        });

        achievements.Add(new Achievement
        {
            Name = "SCP-914 Testing",
            Description = "Użyj SCP-914 250 razy",
            Requirement = "Used914 > 249",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[0]
        });
        achievements.Add(new Achievement
        {
            Name = "SCIENCE!",
            Description = "Zagraj jako naukowiec 50 rund",
            Requirement = "PlayedClass6 > 49",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[1]
        });
        achievements.Add(new Achievement
        {
            Name = "Noble Scientist",
            Description = "Użyj SCP-500, SCP-268, SCP-207 lub jakiegokolwiek SCP-330 100 razy łącznie",
            Requirement = "(Used500 + Used268 + Used207 + Used330) > 99",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[2]
        });
        achievements.Add(new Achievement
        {
            Name = "5, 4, 3, 2, 1",
            Description = "Zgiń od dekontaminacji 20 razy",
            Requirement = "KIlledByDecontamination > 19",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[3]
        });
        achievements.Add(new Achievement
        {
            Name = "Experiment Alpha",
            Description = "Użyj MicroHID 30 razy",
            Requirement = "UsedMicrohid > 29",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[35]
        });
        achievements.Add(new Achievement
        {
            Name = "Professional Foundation Employee",
            Description = "Zabij 50 podmiotów SCP (wyłączając SCP-049-2)",
            Requirement =
                "(KilledClass0 + KilledClass3 + KilledClass5 + KilledClass7 + KilledClass9 + KilledClass16) > 49",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[4]
        });
        achievements.Add(new Achievement
        {
            Name = "AAAAAAAAAAAAAAA",
            Description = "Zgiń od upadku 50 razy",
            Requirement = " KilledByFalldown > 49",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[5]
        });
        achievements.Add(new Achievement
        {
            Name = "Yessir!",
            Description = "Poprowadź jednostkę MTF jako kapitan 60 razy",
            Requirement = "PlayedClass12 > 59",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[6]
        });
        achievements.Add(new Achievement
        {
            Name = "Site-02 Maintenance Department",
            Description = "Aktywuj wszystkie generatory w jednej rundzie",
            Requirement = "GeneratorActivated > 2",
            Flags = (AchievementFlag)3,
            InOneRound = false,
            Rank = ranks[7]
        });
        achievements.Add(new Achievement
        {
            Name = "Groundhog Day",
            Description = "Zgiń od dekontaminacji LCZ, upadku, SCP-207, i od eksplozji głowicy alfa w jednej rundzie",
            Requirement =
                "KilledByDecontamination > 0 &&  KilledByFalldown > 0 && KilledBySCP207 > 0 && KilledByNuke > 0",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[8]
        });
        achievements.Add(new Achievement
        {
            Name = "Command, target is secure",
            Description = "Zadaj 100000 obrażeń podmiotom SCP",
            Requirement = "DamageDoneToSCPS > 99999",
            Flags = (AchievementFlag)7,
            InOneRound = false,
            Rank = ranks[9]
        });
        achievements.Add(new Achievement
        {
            Name = "We are cold, not cruel",
            Description = "Odblokuj wszystkie Osiągnięcia Fundacji",
            Requirement = "true",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[10]
        });
        achievements.Add(new Achievement
        {
            Name = "The Red Button",
            Description = "Uruchom głowicę alfa 75 razy",
            Requirement = "WarheadStart > 74",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[11]
        });
        achievements.Add(new Achievement
        {
            Name = "What the f*** are you guys doing?",
            Description = "Anuluj proces detonacji głowicy alfa 75 razy",
            Requirement = "WarheadStop > 74",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[12]
        });
        achievements.Add(new Achievement
        {
            Name = "RUN!",
            Description = "Ucieknij 75 razy",
            Requirement = "Escaped > 74",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[13]
        });
        achievements.Add(new Achievement
        {
            Name = "Convicted ",
            Description = "Zagraj jako klasa D 150 razy",
            Requirement = "PlayedClass1 > 149",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[14]
        });
        achievements.Add(new Achievement
        {
            Name = "Chaos, CHAOS!",
            Description = "Odrodź się jako agent Rebelii Chaosu 50 razy",
            Requirement = "(PlayedClass8 + PlayedClass18 + PlayedClass19 + PlayedClass20) > 49",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[15]
        });
        achievements.Add(new Achievement
        {
            Name = "Lethal Rifleman",
            Description = "Traf 500 strzałów w głowę",
            Requirement = "Headshots > 499",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[16]
        });
        achievements.Add(new Achievement
        {
            Name = "Destroy Destroy Destroy",
            Description = "abij 3 podmioty SCP (poza 049-2) w jednej rundzie",
            Requirement =
                "(KilledClass0 + KilledClass3 + KilledClass5 + KilledClass7 + KilledClass9 + KilledClass16) > 2",
            Flags = (AchievementFlag)3,
            InOneRound = false,
            Rank = ranks[18]
        });
        achievements.Add(new Achievement
        {
            Name = "Feel the PAIN!",
            Description = "Otrzymaj 75000 punktów obrażeń",
            Requirement = "DamageTaken > 74999",
            Flags = (AchievementFlag)3,
            InOneRound = false,
            Rank = ranks[19]
        });
        achievements.Add(new Achievement
        {
            Name = "Chaotic Da Vinci",
            Description = "Odródź się jako każdy agent Rebelii Chaosu 15 razy",
            Requirement = "PlayedClass8 > 14 && PlayedClass18 > 14 && PlayedClass19 > 14 && PlayedClass20 > 14",
            Flags = (AchievementFlag)7,
            InOneRound = false,
            Rank = ranks[20]
        });
        achievements.Add(new Achievement
        {
            Name = "War Criminal",
            Description = "Zabij 10 osób w jednej rundzie jako człowiek",
            Requirement =
                "(KilledClass1 + KilledClass4 + KilledClass6 + KilledClass8 + KilledClass11 + KilledClass12 + KilledClass13 + KilledClass15 + KilledClass18 + KilledClass19 + KilledClass20) > 9",
            Flags = (AchievementFlag)7,
            InOneRound = false,
            Rank = ranks[21]
        });
        achievements.Add(new Achievement
        {
            Name = "Traitor from Alpha-1",
            Description = "-",
            Requirement = "true",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[22]
        });
        achievements.Add(new Achievement
        {
            Name = "Serpent's Hand Friends",
            Description = "Odródź się jako podmiot SCP (oprócz 049-2) 50 razy",
            Requirement =
                "(PlayedClass0 + PlayedClass3 + PlayedClass5 + PlayedClass7 + PlayedClass9 + PlayedClass16) > 49",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[23]
        });
        achievements.Add(new Achievement
        {
            Name = "I am the Cure",
            Description = "Wskrześ 100 graczy jako SCP-049",
            Requirement = "SCP049Revived > 99",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[24]
        });
        achievements.Add(new Achievement
        {
            Name = "Linux Bad",
            Description = "Zdobądź 2500 doświadczenia łącznie jako SCP-079",
            Requirement = "SCP079ExpierienceCollected > 2499",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[25]
        });
        achievements.Add(new Achievement
        {
            Name = "Snap ",
            Description = "Skręć 250 karków jako SCP-173",
            Requirement = "SCP173NecksSnapped > 249",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[27]
        });
        achievements.Add(new Achievement
        {
            Name = "Yoink ",
            Description = "Złap 200 osób jako SCP-106",
            Requirement = "SCP106Captured > 199",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[28]
        });
        achievements.Add(new Achievement
        {
            Name = "Daddy, where are you?",
            Description = "Odródź się jako SCP-049-2 50 razy",
            Requirement = "PlayedClass10 > 49",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[29]
        });
        achievements.Add(new Achievement
        {
            Name = "Got'em!",
            Description = "Zabij 25 osób jako SCP-079",
            Requirement = "SCP079Kills > 24",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[30]
        });
        achievements.Add(new Achievement
        {
            Name = "Night Shift",
            Description = "Jako SCP-079 wyłącz światła na 10 minut łącznie",
            Requirement = "SCP079Blackouts > 39",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[31]
        });
        achievements.Add(new Achievement
        {
            Name = "Doc, where the F*** ARE WE?",
            Description = "Ucieknij z wymiaru łuzowego 50 razy",
            Requirement = "PocketEscapes > 49",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[32]
        });
        achievements.Add(new Achievement
        {
            Name = "The Box Metaphor",
            Description = "Zagraj jako każdy podmiot SCP 10 razy",
            Requirement =
                "PlayedClass0 > 9 && PlayedClass3 > 9 && PlayedClass5 > 9 && PlayedClass10 > 9 && PlayedClass7 > 9 && PlayedClass9 > 9 && PlayedClass16 > 9",
            Flags = (AchievementFlag)3,
            InOneRound = false,
            Rank = ranks[33]
        });
        achievements.Add(new Achievement
        {
            Name = "Skynet ",
            Description = "Asystuj przy zabiciu 20 osób w jednej rundzie jako SCP-079",
            Requirement = " SCP079Assists > 19",
            Flags = (AchievementFlag)7,
            InOneRound = false,
            Rank = ranks[34]
        });
        achievements.Add(new Achievement
        {
            Name = "XK-Class Event",
            Description = "Odblokuj wszystkie Osiągnięcia Anomalii",
            Requirement = "true",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[37]
        });
        achievements.Add(new Achievement
        {
            Name = "Mass Murderer",
            Description = "Zabij 1000 graczy",
            Requirement = "(KilledClass0 + KilledClass1 + KilledClass2 + KilledClass3 + KilledClass4 + KilledClass5 + KilledClass6 + KilledClass7 + KilledClass8 + KilledClass9 + KilledClass10 + KilledClass11 + KilledClass12 + KilledClass13 + KilledClass15 + KilledClass16 + KilledClass17 + KilledClass18 + KilledClass19 + KilledClass20) > 999",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[38]
        });
        achievements.Add(new Achievement
        {
            Name = "Med Bay",
            Description = "Użyj leków, apteczek oraz adrenalin łącznie 300 razy",
            Requirement = "(UsedMedkits + UsedAdrenaline + UsedPainkillers) > 299",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[39]
        });
        achievements.Add(new Achievement
        {
            Name = "Director of Heaven",
            Description = "Zgiń 750 razy",
            Requirement = "Deaths > 749",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[40]
        });
        achievements.Add(new Achievement
        {
            Name = "SHOW ME YOUR HANDS!",
            Description = "Skuj łącznie 250 osób",
            Requirement = "TimesCuffed > 249",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[41]
        });
        achievements.Add(new Achievement
        {
            Name = "Hello? Anyone there?",
            Description = "Użyj Interkomu 100 razy",
            Requirement = "UsedIntercom > 99",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[42]
        });
        achievements.Add(new Achievement
        {
            Name = "Cables. Lots of cables",
            Description = "Uruchom 200 generatorów",
            Requirement = "GeneratorActivated > 199",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[43]
        });
        achievements.Add(new Achievement
        {
            Name = "Papers, please",
            Description = "Otwórz 7500 drzwi",
            Requirement = "DoorsOpened > 7499",
            Flags = (AchievementFlag)3,
            InOneRound = false,
            Rank = ranks[44]
        });
        achievements.Add(new Achievement
        {
            Name = "Mistaken Traveller",
            Description = "Zagraj 1000 rund",
            Requirement = "RoundsPlayed > 999",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[45]
        });
        achievements.Add(new Achievement
        {
            Name = "Time flies, huh?",
            Description = "Zagraj 300 godzin łącznie na serwerze",
            Requirement =
                "(TimePlayedClass0 + TimePlayedClass1 + TimePlayedClass2 + TimePlayedClass3 + TimePlayedClass4 + TimePlayedClass5 + TimePlayedClass6 + TimePlayedClass7 + TimePlayedClass8 + TimePlayedClass9 + TimePlayedClass10 + TimePlayedClass11 + TimePlayedClass12 + TimePlayedClass13 + TimePlayedClass15 + TimePlayedClass16 + TimePlayedClass17 + TimePlayedClass18 + TimePlayedClass19 + TimePlayedClass20) > 1080000",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[46]
        });
        achievements.Add(new Achievement
        {
            Name = "What's this?",
            Description = " Podnieś łącznie 5000 przedmiotów",
            Requirement = "ItemsPickedUp > 4999",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[47]
        });
        achievements.Add(new Achievement
        {
            Name = "Omnipotent Entity",
            Description = "Odródź się jako każda klasa w grze (poza Poradnikiem i obserwatorem) 30 razy",
            Requirement = "PlayedClass0 > 29 && PlayedClass1 > 29 && PlayedClass3 > 29 && PlayedClass4 > 29 && PlayedClass5 > 29 && PlayedClass6 > 29 && PlayedClass7 > 29 && PlayedClass8 > 29 && PlayedClass9 > 29 && PlayedClass10 > 29 && PlayedClass11 > 29 && PlayedClass12 > 29 && PlayedClass13 > 29 && PlayedClass15 > 29 && PlayedClass16 > 29 && PlayedClass18 > 29 && PlayedClass19 > 29",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[48]
        });
        achievements.Add(new Achievement
        {
            Name = "The Caesar Incident",
            Description = "Zgiń od głowicy alfa 20 razy",
            Requirement = "KIlledByNuke > 19",
            Flags = (AchievementFlag)7,
            InOneRound = false,
            Rank = ranks[49]
        });
        achievements.Add(new Achievement
        {
            Name = "Lucky Boi",
            Description =
                "Przetrwaj rundę bez umierania (nie licząc gry jako SCP), runda musi trwać conajmniej 20 minut",
            Requirement = "true",
            Flags = (AchievementFlag)7,
            InOneRound = false,
            Rank = ranks[50]
        });
        achievements.Add(new Achievement
        {
            Name = "Broken Masquerade",
            Description = "Zdobądź wszystkie widoczne osiągnięcia",
            Requirement = "true",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[51]
        });
        achievements.Add(new Achievement
        {
            Name = "Bureau of Control",
            Description = "Zdobądź wszystkie ukryte osiągnięcia",
            Requirement = "true",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[52]
        });
        achievements.Add(new Achievement
        {
            Name = "The End",
            Description = "Zdobądź wszystkie (włączając sekretne) osiągnięcia",
            Requirement = "true",
            Flags = (AchievementFlag)1,
            InOneRound = false,
            Rank = ranks[53]
        });
        /*
         * Id;Name;Color;Rarity_Id
1;Lab Technician;\N;1
2;Project Director;\N;1
3;Junior Researcher;\N;2
4;Contaminated;\N;1
5;Employee of the Month;\N;3
6;Foundation Astronaut;\N;1
7;Veteran;\N;2
8;Breach Technician;\N;3
9;Death's Designer;\N;3
10;MTF-Nu-7 "Hammer Down";\N;3
11;O5-1;\N;4
12;Master of Disaster;\N;1
13;Nuclear Engineer;\N;1
14;Freedom Runner;\N;2
15;Terrorist;\N;1
16;Recruit;\N;1
17;Steady Hand;\N;2
18;Special Force;\N;3
19;GOC Agent;\N;3
20;Civilian Casualty;\N;2
21;Chaotic Soldier;\N;2
22;Fugative;\N;3
23;Delta Commander;\N;4
24;Reality Bender;\N;1
25;Plague Doctor;\N;1
26;Windows Enjoyer;\N;1
27;Necromancy Overlord;\N;2
28;Peanut;\N;1
29;Old Man;\N;1
30;Brainless Humanoid;\N;1
31;The Gatekeeper;\N;2
32;Saboteur;\N;1
33;The Escapee;\N;2
34;Decommissioned;\N;2
35;Judgement Day;\N;3
36;Mad Scientist;\N;1
37;Incident Omega;\N;3
38;The Scarlet King;\N;4
39;Revenge Seeker;\N;1
40;Good Patient;\N;1
41;Ascended;\N;1
42;Police Officer;\N;2
43;Celebrity;\N;1
44;Electrician;\N;2
45;Border Guard;\N;1
46;Pro Player;\N;3
47;SCP-MISTAKEN;\N;2
48;Hoarder;\N;2
49;Type Green;\N;2
50;Council of Liars;\N;3
51;Four-Leafed Clover;\N;3
52;A New World;\N;4
53;Doctor Darling;\N;4
54;Fritz Williams "The Administrator";\N;5

         */
/*
 *
 * Id;Name;Description;Requirement;Flags;Rank_Id;InOneRound
1;SCP-914 Testing;Użyj SCP-914 250 razy;Used914 > 249;1;1;0
2;SCIENCE!;Zagraj jako naukowiec 50 rund;PlayedClass6 > 49;1;2;0
3;Noble Scientist;Użyj SCP-500, SCP-268, SCP-207 lub jakiegokolwiek SCP-330 100 razy łącznie;(Used500 + Used268 + Used207 + Used330) > 99;1;3;0
4;5, 4, 3, 2, 1;Zgiń od dekontaminacji 20 razy;KIlledByDecontamination > 19;1;4;0
5;Experiment Alpha;Użyj MicroHID 30 razy;UsedMicrohid > 29;1;36;0
6;Professional Foundation Employee;Zabij 50 podmiotów SCP (wyłączając SCP-049-2);(KilledClass0 + KilledClass3 + KilledClass5 + KilledClass7 + KilledClass9 + KilledClass16) > 49;1;5;0
7;AAAAAAAAAAAAAAA;Zgiń od upadku 50 razy; KilledByFalldown > 49;1;6;0
8;Yessir!;Poprowadź jednostkę MTF jako kapitan 60 razy;PlayedClass12 > 59;1;7;0
9;Site-02 Maintenance Department;Aktywuj wszystkie generatory w jednej rundzie;GeneratorActivated > 2;3;8;1
10;Groundhog Day;Zgiń od dekontaminacji LCZ, upadku, SCP-207, i od eksplozji głowicy alfa w jednej rundzie;KilledByDecontamination > 0 &&  KilledByFalldown > 0 && KilledBySCP207 > 0 && KilledByNuke > 0;1;9;1
11;Command, target is secure;Zadaj 100000 obrażeń podmiotom SCP;DamageDoneToSCPS > 99999;7;10;0
12;We are cold, not cruel;Odblokuj wszystkie Osiągnięcia Fundacji;true;1;11;0
13;The Red Button;Uruchom głowicę alfa 75 razy;WarheadStart > 74;1;12;0
14;What the f*** are you guys doing?;Anuluj proces detonacji głowicy alfa 75 razy;WarheadStop > 74;1;13;0
15;RUN!;Ucieknij 75 razy;Escaped > 74;1;14;0
16;Convicted ;Zagraj jako klasa D 150 razy;PlayedClass1 > 149;1;15;0
17;Chaos, CHAOS!;Odrodź się jako agent Rebelii Chaosu 50 razy;(PlayedClass8 + PlayedClass18 + PlayedClass19 + PlayedClass20) > 49;1;16;0
18;Lethal Rifleman;Traf 500 strzałów w głowę;Headshots > 499;1;17;0
19;Destroy Destroy Destroy;abij 3 podmioty SCP (poza 049-2) w jednej rundzie;(KilledClass0 + KilledClass3 + KilledClass5 + KilledClass7 + KilledClass9 + KilledClass16) > 2;3;19;1
20;Feel the PAIN!;Otrzymaj 75000 punktów obrażeń;DamageTaken > 74999;3;20;0
21;Chaotic Da Vinci;Odródź się jako każdy agent Rebelii Chaosu 15 razy;PlayedClass8 > 14 && PlayedClass18 > 14 && PlayedClass19 > 14 && PlayedClass20 > 14;7;21;0
22;War Criminal;Zabij 10 osób w jednej rundzie jako człowiek;(KilledClass1 + KilledClass4 + KilledClass6 + KilledClass8 + KilledClass11 + KilledClass12 + KilledClass13 + KilledClass15 + KilledClass18 + KilledClass19 + KilledClass20) > 9;7;22;1
23;Traitor from Alpha-1;-;true;1;23;0
24;Serpent’s Hand Friends;Odródź się jako podmiot SCP (oprócz 049-2) 50 razy;(PlayedClass0 + PlayedClass3 + PlayedClass5 + PlayedClass7 + PlayedClass9 + PlayedClass16) > 49;1;24;0
25;I am the Cure;Wskrześ 100 graczy jako SCP-049;SCP049Revived > 99;1;25;0
26;Linux Bad;Zdobądź 2500 doświadczenia łącznie jako SCP-079;SCP079ExpierienceCollected > 2499;1;26;0
27;Snap ;Skręć 250 karków jako SCP-173;SCP173NecksSnapped > 249;1;28;0
28;Yoink ;Złap 200 osób jako SCP-106;SCP106Captured > 199;1;29;0
29;Daddy, where are you?;Odródź się jako SCP-049-2 50 razy;PlayedClass10 > 49;1;30;0
30;Got’em!;Zabij 25 osób jako SCP-079;SCP079Kills > 24;1;31;0
31;Night Shift;Jako SCP-079 wyłącz światła na 10 minut łącznie;SCP079Blackouts > 39;1;32;0
32;Doc, where the F*** ARE WE?;Ucieknij z wymiaru łuzowego 50 razy;PocketEscapes > 49;1;33;0
33;The Box Metaphor;Zagraj jako każdy podmiot SCP 10 razy;PlayedClass0 > 9 && PlayedClass3 > 9 && PlayedClass5 > 9 && PlayedClass10 > 9 && PlayedClass7 > 9 && PlayedClass9 > 9 && PlayedClass16 > 9;3;34;0
34;Skynet ;Asystuj przy zabiciu 20 osób w jednej rundzie jako SCP-079; SCP079Assists > 19;7;35;1
35;XK-Class Event;Odblokuj wszystkie Osiągnięcia Anomalii;true;1;38;0
36;Mass Murderer;Zabij 1000 graczy;(KilledClass0 + KilledClass1 + KilledClass2 + KilledClass3 + KilledClass4 + KilledClass5 + KilledClass6 + KilledClass7 + KilledClass8 + KilledClass9 + KilledClass10 + KilledClass11 + KilledClass12 + KilledClass13 + KilledClass15 + KilledClass16 + KilledClass17 + KilledClass18 + KilledClass19 + KilledClass20) > 999;1;39;0
37;Med Bay;Użyj leków, apteczek oraz adrenalin łącznie 300 razy;(UsedMedkits + UsedAdrenaline + UsedPainkillers) > 299;1;40;0
38;Director of Heaven;Zgiń 750 razy;Deaths > 749;1;41;0
39;SHOW ME YOUR HANDS!;Skuj łącznie 250 osób;TimesCuffed > 249;1;42;0
40;Hello? Anyone there?;Użyj Interkomu 100 razy;UsedIntercom > 99;1;43;0
41;Cables. Lots of cables;Uruchom 200 generatorów;GeneratorActivated > 199;1;44;0
42;Papers, please;Otwórz 7500 drzwi;DoorsOpened > 7499;3;45;0
43;Mistaken Traveller;Zagraj 1000 rund;RoundsPlayed > 999;1;46;0
44;Time flies, huh?;Zagraj 300 godzin łącznie na serwerze;(TimePlayedClass0 + TimePlayedClass1 + TimePlayedClass2 + TimePlayedClass3 + TimePlayedClass4 + TimePlayedClass5 + TimePlayedClass6 + TimePlayedClass7 + TimePlayedClass8 + TimePlayedClass9 + TimePlayedClass10 + TimePlayedClass11 + TimePlayedClass12 + TimePlayedClass13 + TimePlayedClass15 + TimePlayedClass16 + TimePlayedClass17 + TimePlayedClass18 + TimePlayedClass19 + TimePlayedClass20) > 1080000;1;47;0
45;What’s this?; Podnieś łącznie 5000 przedmiotów;ItemsPickedUp > 4999;1;48;0
46;Omnipotent Entity;Odródź się jako każda klasa w grze (poza Poradnikiem i obserwatorem) 30 razy;PlayedClass0 > 29 && PlayedClass1 > 29 && PlayedClass3 > 29 && PlayedClass4 > 29 && PlayedClass5 > 29 && PlayedClass6 > 29 && PlayedClass7 > 29 && PlayedClass8 > 29 && PlayedClass9 > 29 && PlayedClass10 > 29 && PlayedClass11 > 29 && PlayedClass12 > 29 && PlayedClass13 > 29 && PlayedClass15 > 29 && PlayedClass16 > 29 && PlayedClass18 > 29 && PlayedClass19 > 29;1;49;0
47;The Caesar Incident;Zgiń od głowicy alfa 20 razy;KIlledByNuke > 19;7;50;0
48;Lucky Boi;Przetrwaj rundę bez umierania (nie licząc gry jako SCP), runda musi trwać conajmniej 20 minut;true;7;51;1
49;Broken Masquerade;Zdobądź wszystkie widoczne osiągnięcia;true;1;52;0
50;Bureau of Control;Zdobądź wszystkie ukryte osiągnięcia;true;1;53;0
51;The End;Zdobądź wszystkie (włączając sekretne) osiągnięcia;true;1;54;0

 */

//TODO: dodać seed dla całego tego gówna
        context.Rarities.AddRange(rarities);
        context.Ranks.AddRange(ranks);
        context.Achievements.AddRange(achievements);
        context.SaveChanges();
    }

    public override void InitializeDatabase(EvoDbContext context)
    {
        context.Database.ExecuteSqlCommand("SET NAMES 'utf8mb4';SET CHARACTER SET utf8mb4;");
        base.InitializeDatabase(context);
        Log.Info(context.Ranks.Count().ToString());
        Log.Info(context.Ranks.Any().ToString());
        if(context.Ranks.Any())
            return;
        Seed(context);
    }
}