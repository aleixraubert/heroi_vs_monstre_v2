using System;
using PR1_Metodos_Batalla;

namespace PR1
{
    public class Program
    {
        public static void Main()
        {  
             /* Constants de missatges */
            const string Msg_Welcome = " _   _                _   _   _ _____  ___  ___                _              _   _  _____ \r\n| | | |              (_) | | | /  ___| |  \\/  |               | |            | | | |/ __  \\\r\n| |_| | ___ _ __ ___  _  | | | \\ `--.  | .  . | ___  _ __  ___| |_ _ __ ___  | | | |`' / /'\r\n|  _  |/ _ \\ '__/ _ \\| | | | | |`--. \\ | |\\/| |/ _ \\| '_ \\/ __| __| '__/ _ \\ | | | |  / /  \r\n| | | |  __/ | | (_) | | \\ \\_/ /\\__/ / | |  | | (_) | | | \\__ \\ |_| | |  __/ \\ \\_/ /./ /___\r\n\\_| |_/\\___|_|  \\___/|_|  \\___/\\____/  \\_|  |_/\\___/|_| |_|___/\\__|_|  \\___|  \\___(_)_____/\r\n                                                                                           \r\n                                                                                           ";
            const string Msg_Start = "\"1. Iniciar una nova batalla\"\r\n\"0. Sortir\"\r\n";
            const string Msg_Difficult = "Selecciona una dificultat\r\n\"1. Fàcil\"\r\n\"2. Difícil\"\r\n\"3. Personalitzat\"\r\n\"4. Random\"\r\n";
            const string Msg_Final = "Gràcies per jugar! Fins aviat!";
            const string Msg_Trys_Out = "Has superat el nombre de intents per triar una opció vàlida.";
            const string Msg_Option_Wrong = "Opció incorrecta. Torna a intentar-ho.";
            const string Msg_Dificult_Easy = "Has triat la dificultat fàcil. Els atributs dels personatges són els més alts i els del monstre els més baixos.";
            const string Msg_Dificult_Hard = "Has triat la dificultat difícil. Els atributs dels personatges són els més baixos i els del monstre els més alts.";
            const string Msg_Dificult_Personalized = "Has triat la dificultat personalitzada. Pots triar els atributs dels personatges i del monstre.";
            const string Msg_Dificult_Random = "Has triat la dificultat random. Els atributs dels personatges i del monstre són aleatoris.";
            const string Msg_Names = "Introdueix els noms dels personatges separats per comes (,).";
            const string Msg_Archer = "Arquera ({0})";
            const string Msg_Archer_Health = "Vida [1500-2000]: ";
            const string Msg_Archer_Attack = "Atac [200-300]: ";
            const string Msg_Archer_Defense = "Defensa [25-35]: ";
            const string Msg_Warrior = "Bàrbar ({0})";
            const string Msg_Warrior_Health = "Vida [3000-3750]: ";
            const string Msg_Warrior_Attack = "Atac [150-250]: ";
            const string Msg_Warrior_Defense = "Defensa [35-45]: ";
            const string Msg_Mage = "Maga ({0})";
            const string Msg_Mage_Health = "Vida [1100-1500]: ";
            const string Msg_Mage_Attack = "Atac [300-400]: ";
            const string Msg_Mage_Defense = "Defensa [20-35]: ";
            const string Msg_Druid = "Druida ({0})";
            const string Msg_Druid_Health = "Vida [2000-2500]: ";
            const string Msg_Druid_Attack = "Atac [70-120]: ";
            const string Msg_Druid_Defense = "Defensa [25-40]: ";
            const string Msg_Monster = "Monstre";
            const string Msg_Monster_Health = "Vida [7000-10000]: ";
            const string Msg_Monster_Attack = "Atac [300-400]: ";
            const string Msg_Monster_Defense = "Defensa [20-30]: ";
            const string Msg_No_Limits = "El valor no està dins dels límits. Torna a intentar-ho.";
            const string Msg_Trys_Out_Character = "Has superat el nombre màxim d'intents. S'ha assignat el valor més baix del rang.";
            const string Msg_Trys_Out_Monster = "Has superat el nombre màxim d'intents. S'ha assignat el valor més alt del rang.";
            const string Msg_Start_Battle = "Comença la batalla!\r\n";
            const string Msg_Win = "Has guanyat la batalla! El monstre ha mort!";
            const string Msg_Lose = "Has perdut la batalla. Tots els herois han mort...";
            const string Msg_Continue = "Prem qualsevol tecla per continuar...";

            /*Constants de personatges*/
            const int Min_Archer_Health = 1500, Max_Archer_Health = 2000, Min_Archer_Attack = 200, Max_Archer_Attack = 300, Min_Archer_Defense = 25, Max_Archer_Defense = 35;
            const int Min_Warrior_Health = 3000, Max_Warrior_Health = 3750, Min_Warrior_Attack = 150, Max_Warrior_Attack = 250, Min_Warrior_Defense = 35, Max_Warrior_Defense = 45;
            const int Min_Mage_Health = 1100, Max_Mage_Health = 1500, Min_Mage_Attack = 300, Max_Mage_Attack = 400, Min_Mage_Defense = 20, Max_Mage_Defense = 35;
            const int Min_Druid_Health = 2000, Max_Druid_Health = 2500, Min_Druid_Attack = 70, Max_Druid_Attack = 120, Min_Druid_Defense = 25, Max_Druid_Defense = 40;
            const int Min_Monster_Health = 7000, Max_Monster_Health = 10000, Min_Monster_Attack = 300, Max_Monster_Attack = 400, Min_Monster_Defense = 20, Max_Monster_Defense = 30;

            /* Constants */
            const int Zero = 0;

            /*Variables*/
            string Archer_Name = "Arquera", Warrior_Name = "Bàrbar", Mage_Name = "Maga", Druid_Name = "Druida", Name_List = "";


            bool gamerStarted = true, dificultChoosen = false;

            int Archer_Health = 0, Archer_Attack = 0, Archer_Defense = 0;
            int Warrior_Health = 0, Warrior_Attack = 0, Warrior_Defense = 0;
            int Mage_Health = 0, Mage_Attack = 0, Mage_Defense = 0;
            int Druid_Health = 0, Druid_Attack = 0, Druid_Defense = 0;
            int Monster_Health = 0, Monster_Attack = 0, Monster_Defense = 0;

            char option;

            /* Inici del programa */
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(Msg_Welcome);

            int trys = 2;

            Console.WriteLine(Msg_Start);

            option = Convert.ToChar(Console.ReadLine());

            Console.Clear();
            
            /* Bucle principal de joc*/
            while (gamerStarted)
            {
                /* Switch per triar una opció jugar/sortir*/
                switch (option)
                {
                    case '1':
                        trys = 2;
                        Console.WriteLine(Msg_Difficult);

                        option = Convert.ToChar(Console.ReadLine());

                        Console.Clear();

                        /* Switch per triar una dificultat*/
                        while (!dificultChoosen)
                        {
                            switch (option)
                            {
                                case '1':

                                    /* Dificultat fàcil */
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine(Msg_Dificult_Easy);

                                    Archer_Health = Max_Archer_Health;
                                    Archer_Attack = Max_Archer_Attack;
                                    Archer_Defense = Max_Archer_Defense;

                                    Warrior_Health = Max_Warrior_Health;
                                    Warrior_Attack = Max_Warrior_Attack;
                                    Warrior_Defense = Max_Warrior_Defense;

                                    Mage_Health = Max_Mage_Health;
                                    Mage_Attack = Max_Mage_Attack;
                                    Mage_Defense = Max_Mage_Defense;

                                    Druid_Health = Max_Druid_Health;
                                    Druid_Attack = Max_Druid_Attack;
                                    Druid_Defense = Max_Druid_Defense;

                                    Monster_Health = Min_Monster_Health;
                                    Monster_Attack = Min_Monster_Attack;
                                    Monster_Defense = Min_Monster_Defense;

                                    Console.WriteLine(Msg_Names);

                                    Name_List = Console.ReadLine();

                                    dificultChoosen = true;
                                    break;
                                case '2':

                                    /* Dificultat difícil */
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(Msg_Dificult_Hard);

                                    Archer_Health = Min_Archer_Health;
                                    Archer_Attack = Min_Archer_Attack;
                                    Archer_Defense = Min_Archer_Defense;

                                    Warrior_Health = Min_Warrior_Health;
                                    Warrior_Attack = Min_Warrior_Attack;
                                    Warrior_Defense = Min_Warrior_Defense;

                                    Mage_Health = Min_Mage_Health;
                                    Mage_Attack = Min_Mage_Attack;
                                    Mage_Defense = Min_Mage_Defense;

                                    Druid_Health = Min_Druid_Health;
                                    Druid_Attack = Min_Druid_Attack;
                                    Druid_Defense = Min_Druid_Defense;

                                    Monster_Health = Max_Monster_Health;
                                    Monster_Attack = Max_Monster_Attack;
                                    Monster_Defense = Max_Monster_Defense;

                                    Console.WriteLine(Msg_Names);

                                    Name_List = Console.ReadLine();

                                    dificultChoosen = true;
                                    break;
                                case '3':
                                    
                                    /* Creació de personatges personalitzats */
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine(Msg_Dificult_Personalized);

                                    Console.WriteLine(Msg_Names);

                                    Name_List = Console.ReadLine();

                                    string[] name = Name_List.Split(',');

                                    Archer_Name = name[0];
                                    Warrior_Name = name[1];
                                    Mage_Name = name[2];
                                    Druid_Name = name[3];

                                    Console.Clear();
                                    Console.WriteLine(Msg_Archer, Archer_Name);
                                    Console.WriteLine(Msg_Archer_Health);
                                    Archer_Health = Convert.ToInt32(Console.ReadLine());
                                    while (Batalla.IsNotLimits(Archer_Health, Min_Archer_Health, Max_Archer_Health) && trys > Zero)
                                    {
                                        Console.WriteLine(Msg_No_Limits);
                                        Archer_Health = Convert.ToInt32(Console.ReadLine());
                                        trys--;
                                    }

                                    if (trys <= Zero)
                                    {
                                        Console.WriteLine(Msg_Trys_Out_Character);
                                        Archer_Health = Min_Archer_Health;
                                    }

                                    trys = 2;

                                    Console.WriteLine(Msg_Archer_Attack);
                                    Archer_Attack = Convert.ToInt32(Console.ReadLine());
                                    while (Batalla.IsNotLimits(Archer_Attack, Min_Archer_Attack, Max_Archer_Attack) && trys > Zero)
                                    {
                                        Console.WriteLine(Msg_No_Limits);
                                        Archer_Attack = Convert.ToInt32(Console.ReadLine());
                                        trys--;
                                    }

                                    if (trys <= Zero)
                                    {
                                        Console.WriteLine(Msg_Trys_Out_Character);
                                        Archer_Attack = Min_Archer_Attack;
                                    }

                                    trys = 2;

                                    Console.WriteLine(Msg_Archer_Defense);
                                    Archer_Defense = Convert.ToInt32(Console.ReadLine());
                                    while (Batalla.IsNotLimits(Archer_Defense, Min_Archer_Defense, Max_Archer_Defense) && trys > Zero)
                                    {
                                        Console.WriteLine(Msg_No_Limits);
                                        Archer_Defense = Convert.ToInt32(Console.ReadLine());
                                        trys--;
                                    }

                                    if (trys <= Zero)
                                    {
                                        Console.WriteLine(Msg_Trys_Out_Character);
                                        Archer_Defense = Min_Archer_Defense;
                                    }

                                    trys = 2;

                                    Console.Clear();
                                    Console.WriteLine(Msg_Warrior, Warrior_Name);
                                    Console.WriteLine(Msg_Warrior_Health);
                                    Warrior_Health = Convert.ToInt32(Console.ReadLine());
                                    while (Batalla.IsNotLimits(Warrior_Health, Min_Warrior_Health, Max_Warrior_Health) && trys > Zero)
                                    {
                                        Console.WriteLine(Msg_No_Limits);
                                        Warrior_Health = Convert.ToInt32(Console.ReadLine());
                                        trys--;
                                    }

                                    if (trys <= Zero)
                                    {
                                        Console.WriteLine(Msg_Trys_Out_Character);
                                        Warrior_Health = Min_Warrior_Health;
                                    }

                                    trys = 2;

                                    Console.WriteLine(Msg_Warrior_Attack);
                                    Warrior_Attack = Convert.ToInt32(Console.ReadLine());
                                    while (Batalla.IsNotLimits(Warrior_Attack, Min_Warrior_Attack, Max_Warrior_Attack) && trys > Zero)
                                    {
                                        Console.WriteLine(Msg_No_Limits);
                                        Warrior_Attack = Convert.ToInt32(Console.ReadLine());
                                        trys--;
                                    }

                                    if (trys <= Zero)
                                    {
                                        Console.WriteLine(Msg_Trys_Out_Character);
                                        Warrior_Attack = Min_Warrior_Attack;
                                    }

                                    trys = 2;

                                    Console.WriteLine(Msg_Warrior_Defense);
                                    Warrior_Defense = Convert.ToInt32(Console.ReadLine());
                                    while (Batalla.IsNotLimits(Warrior_Defense, Min_Warrior_Defense, Max_Warrior_Defense) && trys > Zero)
                                    {
                                        Console.WriteLine(Msg_No_Limits);
                                        Warrior_Defense = Convert.ToInt32(Console.ReadLine());
                                        trys--;
                                    }

                                    if (trys <= Zero)
                                    {
                                        Console.WriteLine(Msg_Trys_Out_Character);
                                        Warrior_Defense = Min_Warrior_Defense;
                                    }

                                    trys = 2;

                                    Console.Clear();
                                    Console.WriteLine(Msg_Mage, Mage_Name);
                                    Console.WriteLine(Msg_Mage_Health);
                                    Mage_Health = Convert.ToInt32(Console.ReadLine());
                                    while (Batalla.IsNotLimits(Mage_Health, Min_Mage_Health, Max_Mage_Health) && trys > Zero)
                                    {
                                        Console.WriteLine(Msg_No_Limits);
                                        Mage_Health = Convert.ToInt32(Console.ReadLine());
                                        trys--;
                                    }

                                    if (trys <= Zero)
                                    {
                                        Console.WriteLine(Msg_Trys_Out_Character);
                                        Mage_Health = Min_Mage_Health;
                                    }

                                    trys = 2;

                                    Console.WriteLine(Msg_Mage_Attack);
                                    Mage_Attack = Convert.ToInt32(Console.ReadLine());
                                    while (Batalla.IsNotLimits(Mage_Attack, Min_Mage_Attack, Max_Mage_Attack) && trys > Zero)
                                    {
                                        Console.WriteLine(Msg_No_Limits);
                                        Mage_Attack = Convert.ToInt32(Console.ReadLine());
                                        trys--;
                                    }

                                    if (trys <= Zero)
                                    {
                                        Console.WriteLine(Msg_Trys_Out_Character);
                                        Mage_Attack = Min_Mage_Attack;
                                    }

                                    trys = 2;

                                    Console.WriteLine(Msg_Mage_Defense);
                                    Mage_Defense = Convert.ToInt32(Console.ReadLine());
                                    while (Batalla.IsNotLimits(Mage_Defense, Min_Mage_Defense, Max_Mage_Defense) && trys > Zero)
                                    {
                                        Console.WriteLine(Msg_No_Limits);
                                        Mage_Defense = Convert.ToInt32(Console.ReadLine());
                                        trys--;
                                    }

                                    if (trys <= Zero)
                                    {
                                        Console.WriteLine(Msg_Trys_Out_Character);
                                        Mage_Defense = Min_Mage_Defense;
                                    }

                                    trys = 2;

                                    Console.Clear();
                                    Console.WriteLine(Msg_Druid, Druid_Name);
                                    Console.WriteLine(Msg_Druid_Health);
                                    Druid_Health = Convert.ToInt32(Console.ReadLine());
                                    while (Batalla.IsNotLimits(Druid_Health, Min_Druid_Health, Max_Druid_Health) && trys > Zero)
                                    {
                                        Console.WriteLine(Msg_No_Limits);
                                        Druid_Health = Convert.ToInt32(Console.ReadLine());
                                        trys--;
                                    }

                                    if (trys <= Zero)
                                    {
                                        Console.WriteLine(Msg_Trys_Out_Character);
                                        Druid_Health = Min_Druid_Health;
                                    }

                                    trys = 2;

                                    Console.WriteLine(Msg_Druid_Attack);
                                    Druid_Attack = Convert.ToInt32(Console.ReadLine());
                                    while (Batalla.IsNotLimits(Druid_Attack, Min_Druid_Attack, Max_Druid_Attack) && trys > Zero)
                                    {
                                        Console.WriteLine(Msg_No_Limits);
                                        Druid_Attack = Convert.ToInt32(Console.ReadLine());
                                        trys--;
                                    }

                                    if (trys <= Zero)
                                    {
                                        Console.WriteLine(Msg_Trys_Out_Character);
                                        Druid_Attack = Min_Druid_Attack;
                                    }

                                    trys = 2;

                                    Console.WriteLine(Msg_Druid_Defense);
                                    Druid_Defense = Convert.ToInt32(Console.ReadLine());
                                    while (Batalla.IsNotLimits(Druid_Defense, Min_Druid_Defense, Max_Druid_Defense) && trys > Zero)
                                    {
                                        Console.WriteLine(Msg_No_Limits);
                                        Druid_Defense = Convert.ToInt32(Console.ReadLine());
                                        trys--;
                                    }

                                    if (trys <= Zero)
                                    {
                                        Console.WriteLine(Msg_Trys_Out_Character);
                                        Druid_Defense = Min_Druid_Defense;
                                    }

                                    trys = 2;

                                    Console.Clear();
                                    Console.WriteLine(Msg_Monster);
                                    Console.WriteLine(Msg_Monster_Health);
                                    Monster_Health = Convert.ToInt32(Console.ReadLine());
                                    while (Batalla.IsNotLimits(Monster_Health, Min_Monster_Health, Max_Monster_Health) && trys > Zero)
                                    {
                                        Console.WriteLine(Msg_No_Limits);
                                        Monster_Health = Convert.ToInt32(Console.ReadLine());
                                        trys--;
                                    }

                                    if (trys <= Zero)
                                    {
                                        Console.WriteLine(Msg_Trys_Out_Monster);
                                        Monster_Health = Max_Monster_Health;
                                    }

                                    trys = 2;

                                    Console.WriteLine(Msg_Monster_Attack);
                                    Monster_Attack = Convert.ToInt32(Console.ReadLine());
                                    while (Batalla.IsNotLimits(Monster_Attack, Min_Monster_Attack, Max_Monster_Attack) && trys > Zero)
                                    {
                                        Console.WriteLine(Msg_No_Limits);
                                        Monster_Attack = Convert.ToInt32(Console.ReadLine());
                                        trys--;
                                    }

                                    if (trys <= Zero)
                                    {
                                        Console.WriteLine(Msg_Trys_Out_Monster);
                                        Monster_Attack = Max_Monster_Attack;
                                    }

                                    trys = 2;

                                    Console.WriteLine(Msg_Monster_Defense);
                                    Monster_Defense = Convert.ToInt32(Console.ReadLine());
                                    while (Batalla.IsNotLimits(Monster_Defense, Min_Monster_Defense, Max_Monster_Defense) && trys > Zero)
                                    {
                                        Console.WriteLine(Msg_No_Limits);
                                        Monster_Defense = Convert.ToInt32(Console.ReadLine());
                                        trys--;
                                    }

                                    if (trys <= Zero)
                                    {
                                        Console.WriteLine(Msg_Trys_Out_Monster);
                                        Monster_Defense = Max_Monster_Defense;
                                    }
                                    dificultChoosen = true;
                                    break;
                                case '4':

                                    /* Dificultat random */
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine(Msg_Dificult_Random);

                                    Random random = new Random();

                                    Archer_Health = random.Next(Min_Archer_Health, Max_Archer_Health);
                                    Archer_Attack = random.Next(Min_Archer_Attack, Max_Archer_Attack);
                                    Archer_Defense = random.Next(Min_Archer_Defense, Max_Archer_Defense);

                                    Warrior_Health = random.Next(Min_Warrior_Health, Max_Warrior_Health);
                                    Warrior_Attack = random.Next(Min_Warrior_Attack, Max_Warrior_Attack);
                                    Warrior_Defense = random.Next(Min_Warrior_Defense, Max_Warrior_Defense);

                                    Mage_Health = random.Next(Min_Mage_Health, Max_Mage_Health);
                                    Mage_Attack = random.Next(Min_Mage_Attack, Max_Mage_Attack);
                                    Mage_Defense = random.Next(Min_Mage_Defense, Max_Mage_Defense);

                                    Druid_Health = random.Next(Min_Druid_Health, Max_Druid_Health);
                                    Druid_Attack = random.Next(Min_Druid_Attack, Max_Druid_Attack);
                                    Druid_Defense = random.Next(Min_Druid_Defense, Max_Druid_Defense);

                                    Monster_Health = random.Next(Min_Monster_Health, Max_Monster_Health);
                                    Monster_Attack = random.Next(Min_Monster_Attack, Max_Monster_Attack);
                                    Monster_Defense = random.Next(Min_Monster_Defense, Max_Monster_Defense);

                                    Console.WriteLine(Msg_Names);

                                    Name_List = Console.ReadLine();

                                    dificultChoosen = true;
                                    break;
                                default:
                                    Console.WriteLine(Msg_Option_Wrong);
                                    trys--;
                                    option = Convert.ToChar(Console.ReadLine());
                                    if (trys <= Zero)
                                    {
                                        Console.WriteLine(Msg_Trys_Out);
                                        option = '1';
                                    }
                                    break;
                            }
        }
    }
}
