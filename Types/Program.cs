using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types
{
    class Program
    {
        #region Variables
        public static int monsterrace = 1;
        public static int clotharmoramt = 0;
        public static int ironarmoramt = 0;
        public static int steelarmoramt = 0;
        public static int bronzearmoramt = 0;
        public static Boolean clotharmor = false;
        public static Boolean ironarmor = false;
        public static Boolean steelarmor = false;
        public static Boolean bronzearmor = false;
        public static int armorequip = 0;
        public static int ironswordamt = 0;
        public static int steelswordamt = 0;
        public static int bronzeswordamt = 0;
        public static Boolean ironequip = false;
        public static Boolean steelequip = false;
        public static Boolean bronzeequip = false;
        public static int equip =0;
        public static Boolean bronzesword= false;
        public static Boolean steelsword= false;
        public static Boolean ironsword= false;
        public static int maxmana;
        public static int magic = 0;
        public static int mana;
        public static int lightning;
        public static int ice;
        public static int fire;
        public static int lightningstat;
        public static int firestat;
        public static int icestat;
        public static int newexp;
        public static int playerdmg;
        public static int newlife;
        public static int dmg;
        public static int fullife;
        public static int initiallife;
        public static int truedefense;
        public static int enemylife;
        public static int enemytruedamage;
        public static int playertruedamage;
        public static int enemyhealth;
        public static int enemyattack;
        public static int enemyarmor;
        public static int skillpoints;
        public static int attack = 1;
        public static int defense = 1;
        public static int health = 1;
        public static int life = health * 20;
        public static int maxlife;
        public static int level = 1;
        public static int myLevel = 1;
        public static int currentexp = 0;
        public static int myexp = currentexp;
        public static int enemylvl;
        public static int enemyexp = 20 * enemylvl;
        public static int exptolevel = 50 * level;
        public static int damage;
        public static int armor;
        public static int healthp = 0;
        public static int gold = 0;
        public static int getgold;
        #endregion
        #region Enemy Spawning Check
        public static void check()
        {
            CalcEnemylvl();
            CalcEnemyStats();
           // Console.WriteLine("Enemy Level:{0}",enemylvl);
           // Console.WriteLine("Enemy Attack:{0}",enemyattack);
           // Console.WriteLine("Enemy Armor:{0}",enemyarmor);
           // Console.WriteLine("Enemy Health:{0}",enemyhealth);
           //string chk = Console.ReadLine();
           // switch (chk)
           // {
            //    default:
           //         check();
           //         break;
           // }
        }
        #endregion
        #region GameStart *Gold
public static void GameStart()
        {
            CalcStats();
            gold = 10000000;
            initiallife = life;
            maxlife = 20;
            healthp=1;
            skillpoints = 1;
            fullife = maxlife;
            Console.WriteLine("Welcome to a new dog eat dog world! Here you will attempt to survive as long as possible.");
            Console.WriteLine("Your journey awaits!");
            Menu();
        }
        #endregion
        #region Menu
        public static void Menu()
        {
            Console.WriteLine("<------Main Hub Menu------>");
            Console.WriteLine("Fight=F|Shop=S|Inventory=I|USE POTION=U|Stats=Q|Spend SkillPoints=P");
            string whattodo = Console.ReadLine();
            string whatto = whattodo.ToLower();
            switch (whatto)
            {
                case "u":
                    if (healthp >= 1)
                    {
                        healthp--;
                        life += 20;

                        if (life > maxlife)
                        {
                            life = maxlife;
                        }
                        fullife = life;
                        Console.WriteLine("You used one potion and healed by 20 points.");
                        Console.WriteLine("You have {0} potions remaining.", healthp);
                        Menu();
                    }
                    Console.WriteLine("You have no potions!");
                    Menu();
                    break;
                case "q":
                    CalcStats();
                    Console.WriteLine("<------Stats Display------>");
                    Console.WriteLine("EXP:{0}\nLIFEFORCE:{1}\nLEVEL:{2}\nEXP TO NEXT LEVEL:{3}\nDAMAGE ON HIT:{4}\nARMOR RATING:{5}\nSKILLPOINTS:{6}\nMAX LIFE:{7}\nMANA:{8}\nMAX MANA:{9}", myexp, life, myLevel, exptolevel, damage, armor, skillpoints,maxlife,mana,maxmana);
                    Menu();
                    break;
                case "p":
                    addpoints();
                    break;
                default:
                    Console.WriteLine("I'm not exactly sure what you ment. Let's try again.");
                    Menu();
                    break;
                case "i":
                    Inventory();
                    Menu();
                    break;
                case "s":
                    Shop();
                    break;
                case "f":
                    Battle();
                    break;
;            }
        }
        #endregion
        #region battleactive
        public static void battleactive()
        {
            Console.WriteLine("<------Active Battle Menu------>");
            if (life<= 0)
            {
                Dead();
            }
            Console.WriteLine("INVENTORY=I|ATTACK=A|DEFEND=D|USE POTION=P|USE SPELL=W|MONSTER STATS=M|YOUR STATS=Q|RUN AWAY=R\nMONSTER LIFE REMAINING:{0}", enemylife);
            string battleseq = Console.ReadLine();
            string doit = battleseq.ToLower();
            switch (doit)
            {
                default:
                    Console.WriteLine("I'm not sure what you mean.");
                    battleactive();
                    break;
                case "i":
                    Inventory();
                    battleactive();
                    break;
                case "p":
                    if (healthp >= 1)
                    {
                        healthp--;
                        life += 20;

                        if (life > maxlife)
                        {
                            life = maxlife;
                        }
                        fullife = life;
                        Console.WriteLine("You used one potion and healed by 20 points.");
                        Console.WriteLine("You have {0} potions remaining.", healthp);
                        battleactive();
                    }
                    Console.WriteLine("You have no potions!");
                    battleactive();
                    break;
                case "m":
                    Console.WriteLine("Monster Level:{0}\nMoster Attack:{1}\nMonster Armor{2}\nMonster Life:{3}",enemylvl,enemyattack,enemyarmor,enemylife);
                    battleactive();
                    break;
                case "q":
                    CalcStats();
                    Console.WriteLine("<------Stats Display------>");
                    Console.WriteLine("EXP:{0}\nLIFEFORCE:{1}\nLEVEL:{2}\nEXP TO NEXT LEVEL:{3}\nDAMAGE ON HIT:{4}\nARMOR RATING:{5}\nSKILLPOINTS:{6}\nMAX LIFE:{7}\nMANA:{7}\nMAX MANA:{9}", myexp, life, myLevel, exptolevel, damage, armor, skillpoints,maxlife,mana,maxmana);
                    battleactive();
                    break;
                case "d":
                    Console.WriteLine("You stay back and ready your weapon to defend yourself.");
                    Defend();
                    break;
                case "r":
                    var run = new Random().Next(1, 5);
                    if (run == 1)
                    {
                        Console.WriteLine("Your attempt to run has succeeded!");
                        Battle();
                    }
                        Console.WriteLine("Your path was blocked by the monster. The monster attacked you in your attempt to flee.");
                        CalcEnemyBattleDamage();
                        Console.WriteLine("LIFEFORCE:{0}", life);
                        battleactive();
                    break;
                case "a":
                    Console.WriteLine("You swing your weapon at the monster and trade blows with it.");
                    CalcPlayerBattleDamage();
                    CalcEnemyBattleDamage();
                    Console.WriteLine("The Monster dealt {0} damage to you.\nYou dealt {1} damage to the Monster.",dmg,playerdmg);
                    battleactive();
                    break;
                case "w":
                    if (magic >= 10)
                    { 
                        Console.WriteLine("LIGHTNING=L|FIRE=F|ICE=I|EXIT SPELLS=E");
                        string usemag = Console.ReadLine();
                        string usem = usemag.ToLower();
                    switch (usem)
                    {
                        case "l":
                                CalcEnemyBattleDamage();
                                Lightningdmg();
                          battleactive();
                            break;
                        case "f":
                                CalcEnemyBattleDamage();
                                Firedmg();
                            battleactive();
                            break;
                        case "i":
                                CalcEnemyBattleDamage();
                                Icedmg();
                            battleactive();
                            break;
                        case "e":
                            battleactive();
                            break;
                    }
                    }
                    if (magic >= 5 & magic <=9)
                    {
                        Console.WriteLine("FIRE=F|ICE=I|EXIT SPELLS=E");
                        string usemag = Console.ReadLine();
                        string usem = usemag.ToLower();
                        switch (usem)
                        {
                            case "f":
                                CalcEnemyBattleDamage();
                                Firedmg();
                                battleactive();
                                break;
                            case "i":
                                CalcEnemyBattleDamage();
                                Icedmg();
                                battleactive();
                                break;
                            case "e":
                                battleactive();
                                break;
                        }
                    }
                        if (magic >= 1 & magic <=4)
                    { 
                            Console.WriteLine("ICE=I|EXIT SPELLS=E");
                        string usemag = Console.ReadLine();
                        string usem = usemag.ToLower();
                        switch(usem)
                        {
                            case "i":
                                CalcEnemyBattleDamage();
                                Icedmg();
                                battleactive();
                                break;
                            case "e":
                                battleactive();
                                break;
                        }
                    }
                        Console.WriteLine("You have no spells.");
                        battleactive();
                    break;
            }

        }
        #endregion
        #region Battle
        public static void Battle()
        {
            monsterrace = 0;
            Console.WriteLine("<------Main Battle Menu------>");
            Console.WriteLine("SEARCH FOR ENEMY=S|GO TO HUB MENU=M|USE POTION=P|CHECK INVENTORY=I|CHECK STATS=Q");
            string todo = Console.ReadLine();
            string tod = todo.ToLower();
            switch (tod)
            {
                case "p":
                    if (healthp >= 1)
                    {
                        healthp--;
                        life += 20;

                        if (life > maxlife)
                        {
                            life = maxlife;
                        }
                        fullife = life;
                        Console.WriteLine("You used one potion and healed by 20 points.");
                        Console.WriteLine("You have {0} potions remaining.", healthp);
                        Battle();
                    }
                    Console.WriteLine("You have no potions!");
                    Battle();
                    break;
                case "s":
                    var cashvslife = new Random().Next(1, 2);
                    var cashflow = new Random().Next(1, 100);
                var encounter = new Random().Next(10);
            if (encounter == 1)
            {
                CalcEnemylvl();
                CalcEnemyStats();
                Console.WriteLine("You its a level {0} Albatross!", enemylvl);
                        monsterrace = 1;
                battleactive();
            }
                    if (encounter == 5)
                    {
                        CalcEnemylvl();
                        CalcEnemyStats();
                        Console.WriteLine("You its a level {0} Ent!", enemylvl);
                        monsterrace = 2;
                        battleactive();
                    }
                    if (encounter == 7)
                    {
                        CalcEnemylvl();
                        CalcEnemyStats();
                        Console.WriteLine("You its a level {0} Wolf!", enemylvl);
                        monsterrace = 3;
                        battleactive();
                    }
                    if (encounter == 2)
            {
                var item = new Random().Next(1, 50);
                        enemyexp = 0;
                        enemylvl = 0;
                        myexp += item;
                Console.WriteLine("You found an item! You have gained {0} EXP!!!", item);
                        Level();
                Battle();
            }
            if (encounter == 3)
            {
                        if (cashvslife == 1)
                        {
                            Console.WriteLine("You found a health potion!");
                            healthp++;
                            Battle();
                        }
                        if (cashvslife == 2)
                        {
                            Console.WriteLine("You found {0}GP!", cashflow);
                            gold += cashflow;
                        }
            }
                    else
                    {
                        Console.WriteLine("You turned up empty handed. But there has to be something around here.");
                        Battle();
                    }
                    break;
                default:
                    Console.WriteLine("I'm not sure what you mean.");
                    Battle();
                    break;
                case "m":
                    Menu();
                    break;
                case "i":
                    Inventory();
                    Battle();
                    break;
                case "q":
                    CalcStats();
                    Console.WriteLine("<------Stats Display------>");
                    Console.WriteLine("EXP:{0}\nLIFEFORCE:{1}\nLEVEL:{2}\nEXP TO NEXT LEVEL:{3}\nDAMAGE ON HIT:{4}\nARMOR RATING:{5}\nSKILLPOINTS:{6}\nMAX LIFE:{7}\nMANA:{8}\nMAX MANA:{9}", myexp, life, myLevel, exptolevel, damage, armor, skillpoints, maxlife, mana, maxmana);
                    Battle();
                    break;
            }


        }
        #endregion
        #region Shop
        public static void Shop()
        {
            Console.WriteLine("<------Lords Bits and Bobs Item Shop------>");
            Console.WriteLine("Sell Items=G|Weapons=W|Armor=A|Skillpoints/EXP/Potions=S|INN=R|Exit Shop=E");
            string shopping = Console.ReadLine();
            string shoppin = shopping.ToLower();
            switch (shoppin)
            {
                case "g":
                    Sell();
                    break;
                case "r":
                    Console.WriteLine("Would you like to spend 10GP to stay the night?(Y/N)");
                    string inn = Console.ReadLine();
                    string innn = inn.ToLower();
                    switch(innn)
                    {
                        default:
                            Console.WriteLine("I'm sorry I don't know how to respond to that.");
                            Shop();
                            break;
                        case "y":
                            if(gold>=10)
                            {
                                Console.WriteLine("Thank You! Have a good night!");
                                life = maxlife;
                                Shop();
                            }
                            Console.WriteLine("You dont have enough GP!");
                            Shop();
                            break;
                        case "n":
                            Console.WriteLine("Okay! Our beds are so comfortable that you feel refreshed when you wake up though.");
                            Shop();
                            break;
                    }
                    break;
                case "s":
                    Shopskill();
                        break;
                default:
                    Console.WriteLine("I'm not sure what you mean.");
                    Shop();
                    break;
                case "e":
                    Console.WriteLine("Goodbye! Hope to see you soon!");
                    Menu();
                    break;
                case "a":
                    Shoparmor();
                    break;
                case "w":
                    Shopweapons();
                    break;

            }
        }
        #endregion
        #region Shopskill
        public static void Shopskill()
        {
            Console.WriteLine("<------SkillPoints|EXP|Potions------>");
            Console.WriteLine("HEALTH POTIONS=P:Cost 50GP per Potion\nSKILLPOINTS=S:Cost 1,500GP per Point\nEXP=X:Cost 1,000GP per 100EXP\nEXIT MENU=E");
            string buyskill = Console.ReadLine();
            string buyskil = buyskill.ToLower();
            switch (buyskil)
            {
                default:
                    Console.WriteLine("I'm not sure what you mean.");
                    Shopskill();
                    break;
                case "e":
                    Shop();
                    break;
                case "x":
                    Console.WriteLine("Would you like to buy 100EXP for 1,000GP?(Max 1 at a time)Y/N");
                    string buyxp = Console.ReadLine();
                    string buyexp = buyxp.ToLower();
                    switch (buyexp)
                    {
                        case "y":
                            if (gold >= 1000)
                            {
                                Console.WriteLine("Bought 100EXP for 1,000GP. Thank You!");
                                myexp += 100;
                                gold -= 1000;
                                Level();
                                Shopskill();
                            }
                            else
                            {
                                Console.WriteLine("You don't have enough GP!");
                                Shopskill();
                            }
                            break;
                        case "n":
                            Console.WriteLine("You such a waste of time.....");
                            Shopskill();
                            break;
                        default:
                            Console.WriteLine("I'm not sure what you mean.");
                            Shopskill();
                            break;
                            
                    }
                    break;
                case "p":
                    Console.WriteLine("How many would you like to buy? (Max of 5 at a time)");
                    string potionsquan = Console.ReadLine();
                    string potionsquant = potionsquan.ToLower();
                    switch (potionsquant)
                    {
                        default:
                            Console.WriteLine("I'm not sure what you mean.");
                            Shopskill();
                            break;
                        case "0":
                            Console.WriteLine("Are you kidding me? C'MON!");
                            Shopskill();
                            break;
                        case "1":
                            Console.WriteLine("Okay that will be 50GP.\nDo you want to buy? Y/N");
                            string buy = Console.ReadLine();
                            string buyy = buy.ToLower();
                            switch (buyy)
                            {
                                case "y":
                                    if (gold >= 50)
                                    {
                                        gold = gold - 50;
                                        healthp++;
                                        Console.WriteLine("One health potion bought. Thank You!");
                                        Shopskill();
                                    }
                                    else
                                    {
                                        Console.WriteLine("You dont have enough Gold! o.O");
                                        Shopskill();
                                    }
                                    break;
                                case "n":
                                    Console.WriteLine("*Sigh* Then don't waste my time.");
                                    Shopskill();
                                    break;
                                default:
                                    Console.WriteLine("I'm not sure what you mean.");
                                    Shopskill();
                                    break;
                            }
                            break;
                        case "2":
                            Console.WriteLine("Okay that will be 100GP.\nDo you want to buy? Y/N");
                            string buy2 = Console.ReadLine();
                            string buyy2 = buy2.ToLower();
                            switch (buyy2)
                            {
                                case "y":
                                    if (gold >= 100)
                                    {
                                        gold = gold - 100;
                                        healthp += 2;
                                        Console.WriteLine("Two health potions bought. Thank You!");
                                        Shopskill();
                                    }
                                    else
                                    {
                                        Console.WriteLine("You dont have enough Gold! o.O");
                                        Shopskill();
                                    }
                                    break;
                                case "n":
                                    Console.WriteLine("*Sigh* Then don't waste my time.");
                                    Shopskill();
                                    break;
                                default:
                                    Console.WriteLine("I'm not sure what you mean.");
                                    Shopskill();
                                    break;
                            }
                            break;
                        case "3":
                            Console.WriteLine("Okay that will be 150GP.\nDo you want to buy? Y/N");
                            string buy3 = Console.ReadLine();
                            string buyy3 = buy3.ToLower();
                            switch (buyy3)
                            {
                                case "y":
                                    if (gold >= 150)
                                    {
                                        gold = gold - 150;
                                        healthp += 3;
                                        Console.WriteLine("Three health potions bought. Thank You!");
                                        Shopskill();
                                    }
                                    else
                                    {
                                        Console.WriteLine("You dont have enough Gold! o.O");
                                        Shopskill();
                                    }
                                    break;
                                case "n":
                                    Console.WriteLine("*Sigh* Then don't waste my time.");
                                    Shopskill();
                                    break;
                                default:
                                    Console.WriteLine("I'm not sure what you mean.");
                                    Shopskill();
                                    break;
                            }
                            break;
                        case "4":
                            Console.WriteLine("Okay that will be 200GP.\nDo you want to buy? Y/N");
                            string buy4 = Console.ReadLine();
                            string buyy4 = buy4.ToLower();
                            switch (buyy4)
                            {
                                case "y":
                                    if (gold >= 200)
                                    {
                                        gold = gold - 200;
                                        healthp += 4;
                                        Console.WriteLine("Four health potions bought. Thank You!");
                                        Shopskill();
                                    }
                                    else
                                    {
                                        Console.WriteLine("You dont have enough Gold! o.O");
                                        Shopskill();
                                    }
                                    break;
                                case "n":
                                    Console.WriteLine("*Sigh* Then don't waste my time.");
                                    Shopskill();
                                    break;
                                default:
                                    Console.WriteLine("I'm not sure what you mean.");
                                    Shopskill();
                                    break;
                            }
                            break;
                        case "5":
                            Console.WriteLine("Okay that will be 250GP.\nDo you want to buy? Y/N");
                            string buy5 = Console.ReadLine();
                            string buyy5 = buy5.ToLower();
                            switch (buyy5)
                            {
                                case "y":
                                    if (gold >= 250)
                                    {
                                        gold = gold - 250;
                                        healthp += 5;
                                        Console.WriteLine("Five health potions bought. Thank You!");
                                        Shopskill();
                                    }
                                    else
                                    {
                                        Console.WriteLine("You dont have enough Gold! o.O");
                                        Shopskill();
                                    }
                                    break;
                                case "n":
                                    Console.WriteLine("*Sigh* Then don't waste my time.");
                                    Shopskill();
                                    break;
                                default:
                                    Console.WriteLine("I'm not sure what you mean.");
                                    Shopskill();
                                    break;
                            }
                            break;
                    }
                    break;
                case "s":
                    Console.WriteLine("Would you like to buy a skillpoint? (Max 1 at a time) Y/N");
                    string skillbuy = Console.ReadLine();
                    string skilbuy = skillbuy.ToLower();
                    switch (skilbuy)
                    {
                        default:
                            Console.WriteLine("I'm not sure what you mean.");
                            Shopskill();
                            break;
                        case "y":
                            if (gold >= 1500)
                            {
                                skillpoints++;
                                gold = gold - 1500;
                                Console.WriteLine("You bought 1 SkillPoint for 1,500GP!Thank You!");
                                Shopskill();
                            }
                            else
                            {
                                Console.WriteLine("You dont have enough gold! Shame on you trying to cheat");
                                Shopskill();
                            }
                            break;
                        case "n":
                            Console.WriteLine("Awww C'MON buy a skillpoint. You know you need it...... Fine get outta here.");
                            Shopskill();
                            break;
                    }
                    break;
            }
            
        }
        #endregion
        #region Sell Items
        public static void Sell()
        {
            Console.WriteLine("<------Sell Items------>");
            Console.WriteLine("Sell Iron Sword for 5GP=I|Sell Steel Sword for 25GP=S|Sell Bronze Sword for 75GP=B|Sell Health Potion for 25GP=H|\nExit to Shop=E|Sell Armor=A");
            string checkk = Console.ReadLine();
            string check = checkk.ToLower();
            switch(check)
            {
                default:
                    Console.WriteLine("I'm not sure what you mean. Please try again.");
                    Sell();
                    break;
                case "i":
                    if (ironswordamt >= 1 & ironequip==false)
                    {
                        ironswordamt--;
                        gold += 5;
                        Console.WriteLine("You sold 1 Iron Sword for 5GP! You have {0} remaining.", ironswordamt);
                        Sell();
                    }
                    if ( ironswordamt >= 2 & ironequip == true)
                    {
                        ironswordamt--;
                        gold += 5;
                        Console.WriteLine("You sold 1 Iron Sword for 5GP! You have {0} remaining.", ironswordamt);
                        Sell();
                    }
                    else
                    {
                        Console.WriteLine("You don't have an Iron Sword to sell!");
                        Sell();
                    }
                    break;
                case "s":
                    if (steelswordamt >= 1 & steelequip == false)
                    {
                        steelswordamt--;
                        gold += 25;
                        Console.WriteLine("You sold 1 Steel Sword for 25GP! You have {0} remaining.", steelswordamt);
                        Sell();
                    }
                    if ( steelswordamt >= 2 & steelequip == true)
                    {
                        steelswordamt--;
                        gold += 25;
                        Console.WriteLine("You sold 1 Steel Sword for 25GP! You have {0} remaining.", steelswordamt);
                        Sell();
                    }
                    else
                    {
                        Console.WriteLine("You don't have a Steel Sword to sell!");
                        Sell();
                    }
                    break;
                case "b":
                    if (bronzeswordamt >= 1 & bronzeequip == false)
                    {
                        bronzeswordamt--;
                        gold += 75;
                        Console.WriteLine("You sold 1 Bronze Sword for 75GP! You have {0} remaining.", bronzeswordamt);
                        Sell();
                    }
                    if (bronzeswordamt >= 2 & bronzeequip == true)
                    {
                        bronzeswordamt--;
                        gold += 75;
                        Console.WriteLine("You sold 1 Bronze Sword for 75GP! You have {0} remaining.", bronzeswordamt);
                        Sell();
                    }
                    else
                    {
                        Console.WriteLine("You don't have a Bronze Sword to sell!");
                        Sell();
                    }
                    break;
                case "e":
                    Shop();
                    break;
                case "h":
                    if(healthp >= 1)
                    {
                        healthp--;
                        gold += 25;
                        Console.WriteLine("You sold 1 Health Potion for 25GP!");
                        Sell();
                    }
                    else
                    {
                        Console.WriteLine("You don't have a Health Potion to sell!");
                        Sell();
                    }
                    break;
                case "a":
                    SellArmor();
                    break;
            }
        }
        #endregion
        #region Sell Armor
        public static void SellArmor()
        {
            Console.WriteLine("<------Sell Armor------>");
            Console.WriteLine("Sell Cloth Armor=5GP=1|Sell Iron Armor=15GP=2|Sell Steel Armor=40GP=3|Sell Bronze Armor=75GP=4|Exit to Shop=E");
            string sell = Console.ReadLine();
            string sellwhat = sell.ToLower();
            switch(sellwhat)
            {
                default:
                    Console.WriteLine("I'm not sure what you mean. Please try again.");
                    SellArmor();
                    break;
                case "e":
                    Shop();
                    break;
                case "1":
                    Console.WriteLine("Would you like to sell 1 Cloth Armor for 5GP?(Y/N)");
                    string sellit = Console.ReadLine();
                    string sellcloth = sellit.ToLower();
                    switch (sellcloth)
                    {
                        case "y":
                            if (clotharmoramt >= 1 & clotharmor == false)
                            {
                                clotharmoramt--;
                                gold += 5;
                                Console.WriteLine("You sold 1 cloth armor for 5GP!");
                                SellArmor();
                            }
                            if (clotharmoramt >=2 & clotharmor == true)
                            {
                                clotharmoramt--;
                                gold += 5;
                                Console.WriteLine("You sold 1 cloth armor for 5GP!");
                                SellArmor();
                            }
                            else
                            {
                                Console.WriteLine("You don't have any cloth armor to sell!");
                                SellArmor();
                            }
                            break;
                        case "n":
                            Console.WriteLine("Stop wasting my time!!!");
                            SellArmor();
                            break;
                    }
                    break;
                case "2":
                    Console.WriteLine("Would you like to sell 1 Iron Armor for 15GP?(Y/N)");
                    string selliron = Console.ReadLine();
                    string seliron = selliron.ToLower();
                    switch (seliron)
                    {
                        case "y":
                            if (ironarmoramt >= 1 & ironarmor == false)
                            {
                                ironarmoramt--;
                                gold += 15;
                                Console.WriteLine("You sold 1 Iron Armor for 15GP!");
                                SellArmor();
                            }
                            if (ironarmoramt >= 2 & ironarmor == true)
                            {
                                ironarmoramt--;
                                gold += 15;
                                Console.WriteLine("You sold 1 Iron Armor for 15GP!");
                                SellArmor();
                            }
                            else
                            {
                                Console.WriteLine("You don't have any Iron Armor to sell!");
                                SellArmor();
                            }
                            break;
                        case "n":
                            Console.WriteLine("Stop wasting my time!!!");
                            SellArmor();
                            break;
                    }
                            break;
                        case "3":
                            Console.WriteLine("Would you like to sell 1 Steel Armor for 40GP?(Y/N)");
                            string sellsteel = Console.ReadLine();
                            string selsteel = sellsteel.ToLower();
                    switch (selsteel)
                    {
                        case "y":
                            if (steelarmoramt >= 1 & steelarmor == false)
                            {
                                steelarmoramt--;
                                gold += 40;
                                Console.WriteLine("You sold 1 Steel Armor for 40GP!");
                                SellArmor();
                            }
                            if (ironarmoramt >= 2 & ironarmor == true)
                            {
                                ironarmoramt--;
                                gold += 40;
                                Console.WriteLine("You sold 1 Steel Armor for 40GP!");
                                SellArmor();
                            }
                            else
                            {
                                Console.WriteLine("You don't have any Steel Armor to sell!");
                                SellArmor();
                            }
                            break;
                        case "n":
                            Console.WriteLine("Stop wasting my time!!!");
                            SellArmor();
                            break;
                    }
                                    break;
                                case "4":
                                    Console.WriteLine("Would you like to sell 1 Bronze Armor for 75GP?(Y/N)");
                                    string sellbronze = Console.ReadLine();
                                    string selbronze = sellbronze.ToLower();
                                    switch (selbronze)
                                    {
                                        case "y":
                                            if (bronzearmoramt >= 1 & bronzearmor == false)
                                            {
                                                bronzearmoramt--;
                                                gold += 75;
                                                Console.WriteLine("You sold 1 Bronze Armor for 75GP!");
                                                SellArmor();
                                            }
                                            if (bronzearmoramt >= 2 & bronzearmor == true)
                                            {
                                                bronzearmoramt--;
                                                gold += 75;
                                                Console.WriteLine("You sold 1 Bronze Armor for 75GP!");
                                                SellArmor();
                                            }
                                            else
                                            {
                                                Console.WriteLine("You don't have any Bronze Armor to sell!");
                                                SellArmor();
                                            }
                                            break;
                                        case "n":
                                            Console.WriteLine("Stop wasting my time!!!");
                                            SellArmor();
                                            break;
                                    }
                                    break;
            }
        }
        #endregion
        #region ShopArmor
        public static void Shoparmor()
        {
            Console.WriteLine("<------Armor Shop------>");
            Console.WriteLine("Cloth Armor=10GP=1|Iron Armor=25GP=2|Steel Armor=75GP=3|Bronze Armor=150GP=4|Exit Armor Shop=E");
            string amount = Console.ReadLine();
            string amoun = amount.ToLower();
            switch (amoun)
            {
                case "1":
                    Console.WriteLine("You want to buy Cloth Armor for 10GP?(Y/N)");
                    string oneyn = Console.ReadLine();
                    string onyn = oneyn.ToLower();
                    switch (onyn)
                    {
                        case "y":
                            if(gold>=10)
                            {
                                Console.WriteLine("You bought Cloth Armor for 10GP!Thank You!");
                                clotharmoramt++;
                                gold -= 10;
                                CalcStats();
                                Shoparmor();
                            }
                            else
                            {
                                Console.WriteLine("You don't have enough GP!");
                                Shoparmor();
                            }
                            break;
                        case "n":
                            Console.WriteLine("Seriously what is wrong with you!?!?!?!?");
                            Shoparmor();
                            break;
                    }
                    break;
                case "2":
                    Console.WriteLine("Do you want to buy Iron Armor for 25GP?(Y/N)");
                    string twoyn = Console.ReadLine();
                    string twyn = twoyn.ToLower();
                    switch (twyn)
                    {
                        case "y":
                            if (gold >= 25)
                            {
                                Console.WriteLine("You bought Iron Armor for 25GP!Thank You!");
                                ironarmoramt++;
                                gold -= 25;
                                CalcStats();
                                Shoparmor();
                            }
                            else
                            {
                                Console.WriteLine("You don't have enough GP!");
                                Shoparmor();
                            }
                            break;
                        case "n":
                            Console.WriteLine("Seriously what is wrong with you!?!?!?!?");
                            Shoparmor();
                            break;
                    }
                    break;
                case "3":
                    Console.WriteLine("You want to buy Steel Armor for 75GP?(Y/N)");
                    string threeyn = Console.ReadLine();
                    string threyn = threeyn.ToLower();
                    switch (threyn)
                    {
                        case "y":
                            if (gold >= 75)
                            {
                                Console.WriteLine("You bought Steel Armor for 75GP!Thank You!");
                                steelarmoramt++;
                                gold -= 75;
                                CalcStats();
                                Shoparmor();
                            }
                            else
                            {
                                Console.WriteLine("You don't have enough GP!");
                                Shoparmor();
                            }
                            break;
                        case "n":
                            Console.WriteLine("Seriously what is wrong with you!?!?!?!?");
                            Shoparmor();
                            break;
                    }
                    break;
                case "4":
                    Console.WriteLine("You want to buy Bronze Armor for 150GP?(Y/N)");
                    string fouryn = Console.ReadLine();
                    string fourryn = fouryn.ToLower();
                    switch (fourryn)
                    {
                        case "y":
                            if (gold >= 150)
                            {
                                Console.WriteLine("You bought Bronze Armor for 150GP!Thank You!");
                                bronzearmoramt++;
                                gold -= 150;
                                CalcStats();
                                Shoparmor();
                            }
                            else
                            {
                                Console.WriteLine("You don't have enough GP!");
                                Shoparmor();
                            }
                            break;
                        case "n":
                            Console.WriteLine("Seriously what is wrong with you!?!?!?!?");
                            Shoparmor();
                            break;
                    }
                    break;
                case "e":
                    Shop();
                    break;
                default:
                    Console.WriteLine("I'm not sure what you mean.");
                    Shoparmor();
                    break;
            }
        }
        #endregion
        #region Shopweapons
        public static void Shopweapons()
        {
            Console.WriteLine("<------Weapons Shop------>");
            Console.WriteLine("IRON SWORD = 10GP = 1|STEEL SWORD = 50GP = 2|BRONZE SWORD = 150GP = 3|EXIT = E");
            string buyarmor = Console.ReadLine();
            string buyarmo = buyarmor.ToLower();
            switch(buyarmo)
            {
                default:
                    Console.WriteLine("I'm not sure what you mean.");
                    Shopweapons();
                    break;
                case "e":
                    Shop();
                    break;
                case "1":
                    Console.WriteLine("BUY IRON SWORD FOR 10GP?(Y/N)");
                    string buyweapon = Console.ReadLine();
                    string buyweap = buyweapon.ToLower();
                    switch(buyweap)
                    {
                        case "y":
                            if (gold >= 10)
                            {
                                Console.WriteLine("You Bought an IRON SWORD for 10GP!Thank You!");
                                gold -= 10;
                                ironsword = true;
                                ironswordamt++;
                                CalcStats();
                                Shopweapons();
                            }
                            else
                            {
                                Console.WriteLine("You don't have enough GP!");
                                Shopweapons();
                            }
                            break;
                        case "n":
                            Console.WriteLine("Well then get out!");
                            Shopweapons();
                            break;
                    }
                    break;
                case "2":
                    Console.WriteLine("BUY STEEL SWORD FOR 50GP?(Y/N)");
                    string buyweapo = Console.ReadLine();
                    string buywea = buyweapo.ToLower();
                    switch (buywea)
                    {
                        case "y":
                            if (gold >= 50)
                            {
                                Console.WriteLine("You Bought a STEEL SWORD for 50GP!Thank You!");
                                gold -= 50;
                                steelsword = true;
                                steelswordamt++;
                                Shopweapons();
                            }
                            else
                            {
                                Console.WriteLine("You don't have enough GP!");
                                Shopweapons();
                            }
                            break;
                        case "n":
                            Console.WriteLine("Well then get out!");
                            Shopweapons();
                            break;
                    }
                    break;
                case "3":
                    Console.WriteLine("BUY BRONZE SWORD FOR 150GP?(Y/N)");
                    string buyweapons = Console.ReadLine();
                    string buyweaps = buyweapons.ToLower();
                    switch (buyweaps)
                    {
                        case "y":
                            if (gold >= 150)
                            {
                                Console.WriteLine("You Bought a BRONZE SWORD for 150GP!Thank You!");
                                gold -= 150;
                                bronzesword = true;
                                bronzeswordamt++;
                                Shopweapons();
                            }
                            else
                            {
                                Console.WriteLine("You don't have enough GP!");
                                Shopweapons();
                            }
                            break;
                        case "n":
                            Console.WriteLine("Well then get out!");
                            Shopweapons();
                            break;
                    }
                    break;
            }
        }
        #endregion
        #region Life,Damage,Armor,EXPTOLVL,EnemyEXP Calcs
        public static void CalcStats()
        {
            exptolevel = 50 * level;
            enemyexp = 15 * enemylvl;
            initiallife = health * 20;
            damage = 5 * attack + equip;
            armor = 2 * defense + armorequip;
        }
        #endregion
        #region Player Damage Calc
        public static void CalcPlayerBattleDamage()
        {
            CalcStats();
            playertruedamage = damage - enemyarmor;
            if (playertruedamage<=0)
            {
                Console.WriteLine("Your attack did nothing!");
            }
            newlife = enemylife;
            enemylife = enemylife - playertruedamage;
            playerdmg = newlife - enemylife;
            if (enemylife <= 0)
            {
                CalcGetGold();
                CalcHaveGold();
                Level();
                Console.WriteLine("You have slain the monster! You have earned {0}GP and gained {1}EXP!",getgold,enemyexp);
                getgold = 0;
                Battle();
            }
        }
        #endregion
        #region Enemy Damage Calc
        public static void CalcEnemyBattleDamage()
        {
            enemytruedamage = enemyattack - armor;
            if (enemytruedamage <= 0)
            {
                enemytruedamage = 0;
                life = life - enemytruedamage;
            }
            fullife = life;
            life = life - enemytruedamage;
            dmg = fullife - life;
            if (life<=0)
            {
                Dead();
            }
        }
        #endregion
        #region Defend
        public static void Defend()
        {
            truedefense = armor * 2;
            enemytruedamage = truedefense - enemyattack;
            if(enemytruedamage<=0)
            {
                enemytruedamage = 0;
                life = life - enemytruedamage;
            }
            life = life - enemytruedamage;
            fullife = life;
           dmg = fullife - life;
            if (dmg <= 0)
            {
                Console.WriteLine("You were able to successfully parry the monsters blow");
            }
            else
            {
                Console.WriteLine("The monster was still able to hit you but with alot less power.He was able to deal:{0} damage.", dmg);
            }
            Console.WriteLine("LIFEFORCE:{0}", life);
            CalcStats();
            if(life<=0)
            {
                Dead();
            }
            battleactive();
        }
        #endregion
        #region Dead
        public static void Dead()
        {
            Console.WriteLine("You have died.");
            Console.WriteLine("The Angels sing as you watch your life replay before your eyes.");
            tryagain();
        }
        #endregion
        #region Play Again
        public static void tryagain()
        {
            Console.WriteLine("Would you like to play again?(Y/N)");
            string again = Console.ReadLine();
            string agai = again.ToLower();
            switch (agai)
            {
                case "y":
                    Console.WriteLine("Returning you to the beginning.");
                    skillpoints = 3;
                    attack = 1;
                    defense = 1;
                    health = 1;
                    life = health * 20;
                    level = 1;
                    myLevel = 1;
                    currentexp = 0;
                    myexp = currentexp;
                    enemyexp = 20 * enemylvl;
                    exptolevel = 50 * level;
                    healthp = 0;
                    gold = 0;
                    GameStart();
                    break;
                case "n":
                    Console.WriteLine("Okay Goodbye!");
                    Console.WriteLine("Press Enter to Exit");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("I'm not sure what you ment.");
                    tryagain();
                    break;
            }
        }
        #endregion
        #region Getting Gold Calc
        public static void CalcGetGold()
        {
            if (level >= 5)
            {
                getgold = level * enemylvl;
            }
            else
            {
                getgold = level * enemylvl * 2;
            }
        }
        #endregion
        #region Adding Gold Calc
        public static void CalcHaveGold()
        {
            gold = gold + getgold;
        }
        #endregion
        #region Enemy Level Calc
        public static void CalcEnemylvl()
        {
            var ran = new Random().Next(-2, 3);
            if (level <= 3)
            {
                enemylvl = level;
            }
            else
            {
                enemylvl = level + ran;
            }
        }
        #endregion
        #region Health Potion Calcs
        public static void HealthPotion()
        {
            if (healthp > 0)
            {
                healthp--;
                life += 20;
                Console.WriteLine("The Health Potion has healed you 20 points.\nLIFEFORCE:{0}\nHEALTH POTIONS:{1}",life,healthp);
            }
            else
            {
                Console.WriteLine("You have no Health Potions!");
            }
        }
        #endregion
        #region Fire Magic Damage *Incomplete
        public static void Firedmg()
        {
            if (mana >= 10)
            {
                mana -= 10;
                if (monsterrace == 2)
                {
                    playertruedamage = 20;
                }
                if (monsterrace == 1)
                {
                    playertruedamage = 5;
                }
                else
                {
                    playertruedamage = 10;
                }
                newlife = enemylife;
                enemylife = enemylife - playertruedamage;
                playerdmg = newlife - enemylife;
                Console.WriteLine("You dealt {0} damage to the enemy\n The enemy dealt {1} damage to you.", playertruedamage, dmg);
                if (enemylife <= 0)
                {
                    CalcGetGold();
                    CalcHaveGold();
                    Level();
                    Console.WriteLine("You have slain the enemy! You have earned {0}GP and gained {1}EXP!", getgold, enemyexp);
                    getgold = 0;
                    Battle();
                }
            }
            else
            {
                Console.WriteLine("You don't have enough mana!");
                battleactive();
            }
        }
        #endregion
        #region Ice Magic Damage*Incomplete
        public static void Icedmg()
        {
            if (mana >= 5)
            {
                mana -= 5;
                if (monsterrace == 3)
                {
                    playertruedamage = 10;
                }
                if (monsterrace == 2)
                {
                    playertruedamage = 1;
                }
                else
                {
                    playertruedamage = 5;
                }
                newlife = enemylife;
                enemylife = enemylife - playertruedamage;
                playerdmg = newlife - enemylife;
                Console.WriteLine("You dealt {0} damage to the enemy\n The enemy dealt {1} damage to you.", playertruedamage, dmg);
                if (enemylife <= 0)
                {
                    CalcGetGold();
                    CalcHaveGold();
                    Level();
                    Console.WriteLine("You have slain the enemy! You have earned {0}GP and gained {1}EXP!", getgold, enemyexp);
                    getgold = 0;
                    Battle();
                }
            }
            else
            {
                Console.WriteLine("You don't have enough mana!");
                battleactive();
            }
        }
        #endregion
        #region Lightning Magic Damage
        public static void Lightningdmg()
        {
            if (mana >= 20)
            {
                mana -= 20;
                if (monsterrace == 1)
                {
                    playertruedamage = 40;
                }
                if (monsterrace == 3)
                {
                    playertruedamage = 10;
                }
                else
                {
                    playertruedamage = 20;
                }
                newlife = enemylife;
                enemylife = enemylife - playertruedamage;
                playerdmg = newlife - enemylife;
                Console.WriteLine("You dealt {0} damage to the enemy\n The enemy dealt {1} damage to you.", playertruedamage, dmg);
                if (enemylife <= 0)
                {
                    CalcGetGold();
                    CalcHaveGold();
                    Level();
                    Console.WriteLine("You have slain the enemy! You have earned {0}GP and gained {1}EXP!", getgold, enemyexp);
                    getgold = 0;
                    Battle();
                }
            }
            else
            {
                Console.WriteLine("You don't have enough mana!");
                battleactive();
            }
        }
        #endregion
        #region Magic Calc*Incomplete
        public static void CalcMana()
        {
            mana = magic * 10;
            maxmana = mana;
            if (mana>= maxmana)
            {
                mana = maxmana;
            }
        }
        #endregion
        #region Inventory
        public static void Inventory()
        {
            CalcStats();
            Console.WriteLine("<------Inventory------>");
            Console.WriteLine("Healt Potions:{0}\nGP:{1}", healthp, gold);
            if (ironswordamt >= 1)
            {
                Console.WriteLine("Press I to equip your Iron Sword. Iron Sword Count:{0}", ironswordamt);
            }
            if (steelswordamt >= 1)
            {
                Console.WriteLine("Press S to equip your Steel Sword. Steel Sword Count:{0}", steelswordamt);
            }
            if (bronzeswordamt >= 1)
            {
                Console.WriteLine("Press B to equip your Bronze Sword. Bronze Sword Count:{0}", bronzeswordamt);
            }
            if (clotharmoramt >= 1)
            {
                Console.WriteLine("Press C to equip your Cloth Armor. Cloth Armor Count:{0}", clotharmoramt);
            }
            if (ironarmoramt >= 1)
            {
                Console.WriteLine("Press A to equip your Iron Armor. Iron Armor Count:{0}", ironarmoramt);
            }
            if (steelarmoramt >= 1)
            {
                Console.WriteLine("Press P to equip your Steel Armor. Steel Armor Count:{0}", steelarmoramt);
            }
            if (bronzearmoramt >= 1)
            {
                Console.WriteLine("Press N to equip your Bronze Armor. Bronze Armor Count:{0}", bronzearmoramt);
            }
            if (bronzeequip ==true || steelequip == true || ironequip== true)
            {
                Console.WriteLine("Press U to unequip your current weapon.");
            }
            if (bronzearmor == true || steelarmor == true || ironarmor == true || clotharmor == true)
            {
                Console.WriteLine("Press Z to unequip your current armor.");
            }
            Console.WriteLine("Press E to exit your Inventory.");
            string whattodo = Console.ReadLine();
            string check = whattodo.ToLower();
            switch (check)
            {
                default:
                    Console.WriteLine("I'm not sure what you mean. Please try again.");
                    Inventory();
                    break;
                case "z":
                    Console.WriteLine("Your current armor has been unequiped.");
                    armorequip = 0;
                    clotharmor = false;
                    ironarmor = false;
                    steelarmor = false;
                    bronzearmor = false;
                    Inventory();
                    break;
                case "c":
                    if (clotharmoramt >= 1)
                    {
                        Console.WriteLine("You have donned your Cloth Armor!");
                        clotharmor = true;
                        ironarmor = false;
                        steelarmor = false;
                        bronzearmor = false;
                        armorequip = 5;
                        Inventory();
                    }
                    else
                    {
                        Console.WriteLine("I'm not sure what you mean. Please try again.");
                        Inventory();
                    }
                    break;
                case "a":
                    if (ironarmoramt >= 1)
                    {
                        Console.WriteLine("You have donned your Iron Armor.");
                        clotharmor = false;
                        ironarmor = true;
                        steelarmor = false;
                        bronzearmor = false;
                        armorequip = 10;
                        Inventory();
                    }
                    else
                    {
                        Console.WriteLine("I'm not sure what you mean. Please try again.");
                        Inventory();
                    }
                    break;
                case "p":
                    if (steelarmoramt >= 1)
                    {
                        Console.WriteLine("You have donned your Steel Armor.");
                        clotharmor = false;
                        ironarmor = false;
                        steelarmor = true;
                        bronzearmor = false;
                        armorequip = 15;
                        Inventory();
                    }
                    else
                    {
                        Console.WriteLine("I'm not sure what you mean. Please try again.");
                        Inventory();
                    }
                    break;
                case "n":
                    if (bronzearmoramt >= 1)
                    {
                        Console.WriteLine("You have donned your Bronze Armor");
                        clotharmor = false;
                        ironarmor = false;
                        steelarmor = false;
                        bronzearmor = true;
                        armorequip = 20;
                        Inventory();
                    }
                    else
                    {
                        Console.WriteLine("I'm not sure what you mean. Please try again.");
                        Inventory();
                    }
                    break;
                case "i":
                    if (ironswordamt >= 1)
                    {
                        Console.WriteLine("You have equiped your Iron Sword!");
                        ironequip = true;
                        steelequip = false;
                        bronzeequip = false;
                        equip = 10;
                        Inventory();
                    }
                    else
                    {
                        Console.WriteLine("I'm not sure what you mean. Please try again.");
                        Inventory();
                    }
                    break;
                case "s":
                    if (steelswordamt >= 1)
                    {
                        Console.WriteLine("You have equiped your Steel Sword!");
                        ironequip = false;
                        steelequip = true;
                        bronzeequip = false;
                        equip = 15;
                        Inventory();
                    }
                    else
                    {
                        Console.WriteLine("I'm not sure what you mean. Please try again.");
                        Inventory();
                    }
                    break;
                case "b":
                    if (bronzeswordamt >= 1)
                    {
                        Console.WriteLine("You have equiped your Bronze Sword!");
                        ironequip = false;
                        steelequip = false;
                        bronzeequip = true;
                        equip = 20;
                        Inventory();
                    }

                    else
                    {
                        Console.WriteLine("I'm not sure what you mean. Please try again.");
                        Inventory();
                    }
                    break;
                case "e":
                    Console.WriteLine("Exiting Inventory.");
                    break;
                case "u":
                    if (ironequip = true || steelequip == true || bronzeequip == true)
                    {
                        Console.WriteLine("You now have no weapon equiped.");
                        ironequip = false;
                        steelequip = false;
                        bronzeequip = false;
                        equip = 0;
                        Inventory();
                    }
                    else
                    {
                        Console.WriteLine("I'm not sure what you mean. Please try again.");
                        Inventory();
                    }
                    break;
            }
        }
        #endregion
        #region Enemy Stats Calc
        public static void CalcEnemyStats()
        {
            enemyattack = enemylvl*5;
            //Console.WriteLine("EnemyAttack:"+enemyattack);
            // Console.WriteLine("EnemyLevel:" + enemylvl);
             enemyarmor = enemylvl*2;
            enemyhealth = enemylvl * 20;
            enemylife = enemyhealth;
        }
        #endregion
        #region Stat Points Tree
        public static void addpoints()
        {
            if (skillpoints > 0)
            {
                Console.WriteLine("<------SkillPoint Spending Tree------>");
                Console.WriteLine("Attack=A|Defense=D|Health=H|Mana=M|Exit Point Spending=E");
                string response = Console.ReadLine();
                string resp=response.ToLower();
                switch (resp)
                {
                    case "a":
                        attack++;
                        skillpoints--;
                        CalcStats();
                        Console.WriteLine("One point was added to Attack. Your Attack stat is now: {0} | You have {1} skillpoints left.", attack, skillpoints);
                        addpoints();
                        break;
                    case "d":
                        defense++;
                        skillpoints--;
                        CalcStats();
                        Console.WriteLine("One point was added to Defense. Your Defense stat is now: {0} | You have {1} skillpoints left.", defense, skillpoints);
                        addpoints();
                        break;
                    case "h":
                        health++;
                        life += 20;
                        maxlife += 20;
                        skillpoints--;
                        CalcStats();
                        Console.WriteLine("One point was added to Health. Your Health stat is now: {0} | You have {1} skillpoints left.", health, skillpoints);
                        addpoints();
                        break;
                    default:
                        Console.WriteLine("I'm not sure which stat you ment. Perhaps we could try that again!");
                        addpoints();
                        break;
                    case "e":
                        Console.WriteLine("Yeah who needs skills when you have luck. Well back to the Menu.");
                        Menu();
                        break;
                    case "m":
                        magic++;
                        mana += 10;
                        maxmana += 10;
                        skillpoints--;
                        CalcMana();
                        Console.WriteLine("One point was added to Magic. Your Magic stat is now: {0} | You have {1} skillpoints left.", magic, skillpoints);
                        if (magic == 1)
                        {
                            Console.WriteLine("Congratulations with your increased skill comes increased power!");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("You have Learned the ICE Spell!");
                            Console.ResetColor();
                        }
                        if (magic == 5)
                        {
                            Console.WriteLine("Congratultions with your increased skill comes increased power!");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You have Learned the FIRE Spell!");
                            Console.ResetColor();
                        }
                        if (magic == 10)
                        {
                            Console.WriteLine("Congratulations with your increased skill comes increased power!");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("You have Learned the LIGHTENING Spell!");
                            Console.ResetColor();
                        }
                        addpoints();
                        break;
                }
            }
            else
            {
                Console.WriteLine("You don't have any skillpoints!");
                Menu();
            }
        }
        #endregion
        #region Level up calcs
        public static void Level()
        {
            currentexp = myexp + enemyexp;
            myexp = currentexp;
            if (myexp >= exptolevel)
            {
                level++; myexp = myexp - exptolevel;
                CalcStats();
                if (level >= 15)
                {
                    Console.WriteLine("Congratulations you have reach Level 15! That concludes your quest! Thank You for playing!");
                    Console.WriteLine("Would you like to play again?(Y/N)");
                    string again = Console.ReadLine();
                    string agai = again.ToLower();
                    switch (agai)
                    {
                        default:
                            Console.WriteLine("I'm not sure what you mean.");
                            Level();
                            break;
                        case "y":
                            Console.WriteLine("Okay returning you to the beginning!");
                            GameStart();
                            break;
                        case "n":
                            Console.WriteLine("Press any key to exit.");
                            Console.ReadKey();
                            Environment.Exit(0);
                            break;
                    }
                }
                if (level > myLevel)
                {
                    skillpoints += 3;
                    myLevel = level;
                    currentexp = myexp;
                    currentexp = 0;
                    Console.WriteLine("Congratulations you have leveled up! You are now a level {0}! You gained 3 skillpoints you now currently have {1} skillpoints!", level, skillpoints);
                }
                else
                {
                    currentexp = 0;
                }
            }
            else
            {
                currentexp = 0;
            }

        }
        #endregion
        #region Main string args
        static void Main(string[] args)
        {
            //gold += 15000;
            // myexp += 1000;
            // Level();
            //addpoints();
            //check();
             GameStart();
        }
    }
    #endregion
    #region Random Number Generator
    //public static class RandomGenerator
    // {
    //  private static Random random = new Random();
    // public static int GetRandomNumber(int maxValue)
    // {
    //    return random.Next(maxValue);
    //}
    // }
    #endregion
}
