namespace PR1_Metodos_Batalla
{
    static public class Batalla
    {
        /* Constants de text */
        const string Msg_Attack = "El/la heroi/ina {0} ataca al {1} amb un valor de {2} de dany.\n\r";
        const string Msg_Defense = "El/la heroi/ina {0} es defensa i rep la mitat del dany.\n\r";
        const string Msg_Dead = "{0} ha mort.\n\r";
        const string Msg_Turn = "Torn de {0}.\n\rIndica que vols fer:\n\r[1] Atacar.\n\r[2] Protegir-se.\n\r[3] Habilitat Especial. {1}";
        const string Hability_Archer = "Noqueja el Monstre durant 2 torns (no pot atacar)\n\r";
        const string Hability_Warrior = "Augmenta la defensa al 100% durant 2 torns\n\r";
        const string Hability_Mage = "Dispara una bola de foc que fa 3 cops el seu atac.\n\r";
        const string Hability_Druid = "Cura 500 de vida a tots els herois.\n\r";
        const string Msg_Skipturn = "Has superat el numero de intents per triar una opcio correcta. Passa el torn.\n\r";
        const string Monster = "Monstre";
        const string Msg_Cooldown = "Habilitat en cooldown. Torns restants {0}\n\r";
        const string Msg_Turn_Monster = "El monstre ataca a tots els herois amb {0} de dany.\n\r";
        const string Msg_Out = "El/la heroi/ina {0} està mort i no pot atacar.\n\r";
        const string Msg_Health = "La vida del/la heroi/ina {0} és de {1}.";
        const string Msg_No_Health = "El/la heroi/ina {0} està mort/a.\n\r";
        const string Msg_Monster_Health = "La vida del monstre és de {0}.\n\r";
        const string Msg_Monster_KnockOut = "El monstre està noquejat i no pot atacar.\n\r";
        const string Msg_Used_hability = "{0} ha utilitzat la seva habilitat especial.\n\r";
        const string Msg_All_Healed = "Tots els herois han estat curats.\n\r";
        const string Msg_Wait = "Prem una tecla per continuar...";

        /* Funcions */

        /* Funcio que comprova si un valor esta fora dels limits */
        public static bool IsNotLimits(int value, int min, int max)
        {
            return value < min || value > max;
        }

        /* Funcio per començar la batalla */
        public static bool BatallaStart(string Archer_Name, string Warrior_Name, string Mage_Name, string Druid_Name, int Archer_Health, int Archer_Defense, int Archer_Attack, int Warrior_Health, int Warrior_Defense, int Warrior_Attack, int Mage_Health, int Mage_Defense, int Mage_Attack, int Druid_Health, int Druid_Defense, int Druid_Attack, int Monster_Health, int Monster_Defense, int Monster_Attack)
        {
            bool Archer_Defensed = false;
            bool Warrior_Defensed = false;
            bool Mage_Defensed = false;
            bool Druid_Defensed = false;

            bool Archer_Hability = false;
            bool Warrior_Hability = false;
            bool Mage_Hability = false;
            bool Druid_Hability = false;

            bool Archer_Alive = true;
            bool Warrior_Alive = true;
            bool Mage_Alive = true;
            bool Druid_Alive = true;

            int Archer_Cooldown = 0;
            int Warrior_Cooldown = 0;
            int Mage_Cooldown = 0;
            int Druid_Cooldown = 0;
            int Archer_Hability_Ticks = 0;
            int Warrior_Hability_Ticks = 0;

            Console.Clear();

            return Batalla_Turn(
                ref Archer_Defensed, ref Warrior_Defensed, ref Mage_Defensed, ref Druid_Defensed,
                ref Archer_Hability, ref Warrior_Hability, ref Mage_Hability, ref Druid_Hability,
                ref Archer_Alive, ref Warrior_Alive, ref Mage_Alive, ref Druid_Alive,
                ref Archer_Cooldown, ref Warrior_Cooldown, ref Mage_Cooldown, ref Druid_Cooldown,
                ref Archer_Name, ref Warrior_Name, ref Mage_Name, ref Druid_Name,
                ref Archer_Health, ref Archer_Defense, ref Archer_Attack,
                ref Warrior_Health, ref Warrior_Defense, ref Warrior_Attack,
                ref Mage_Health, ref Mage_Defense, ref Mage_Attack,
                ref Druid_Health, ref Druid_Defense, ref Druid_Attack,
                ref Monster_Health, ref Monster_Defense, ref Monster_Attack, ref Archer_Hability_Ticks, ref Warrior_Hability_Ticks);
        }

        /* Funcio que fa un torn de batalla */
        public static bool Batalla_Turn(
            ref bool Archer_Defensed, ref bool Warrior_Defensed, ref bool Mage_Defensed, ref bool Druid_Defensed,
            ref bool Archer_Hability, ref bool Warrior_Hability, ref bool Mage_Hability, ref bool Druid_Hability,
            ref bool Archer_Alive, ref bool Warrior_Alive, ref bool Mage_Alive, ref bool Druid_Alive,
            ref int Archer_Cooldown, ref int Warrior_Cooldown, ref int Mage_Cooldown, ref int Druid_Cooldown,
            ref string Archer_Name, ref string Warrior_Name, ref string Mage_Name, ref string Druid_Name,
            ref int Archer_Health, ref int Archer_Defense, ref int Archer_Attack,
            ref int Warrior_Health, ref int Warrior_Defense, ref int Warrior_Attack,
            ref int Mage_Health, ref int Mage_Defense, ref int Mage_Attack,
            ref int Druid_Health, ref int Druid_Defense, ref int Druid_Attack,
            ref int Monster_Health, ref int Monster_Defense, ref int Monster_Attack, ref int Archer_Hability_Ticks, ref int Warrior_Hability_Ticks)
        {
            int[] order = RandomAttacker();

            /* Bucle d'atac */
            for (int i = 0; i < 4; i++)
            {
                switch (order[i])
                {
                    case 1:
                        if (Archer_Health > 0)
                        {
                            Attack(Archer_Name, ref Archer_Attack, ref Archer_Defense, ref Monster_Health, ref Monster_Defense, ref Archer_Defensed, ref Archer_Cooldown, ref Archer_Hability, Hability_Archer);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(Msg_Out, Archer_Name);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        if (Archer_Hability)
                        {
                            Archer_Hability = false;
                            Archer_Hability_Ticks = 2;
                        }
                        break;
                    case 2:
                        if (Warrior_Health > 0)
                        {
                            Attack(Warrior_Name, ref Warrior_Attack, ref Warrior_Defense, ref Monster_Health, ref Monster_Defense, ref Warrior_Defensed, ref Warrior_Cooldown, ref Warrior_Hability, Hability_Warrior);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(Msg_Out, Warrior_Name);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        if (Warrior_Hability)
                        {
                            Warrior_Hability = false;
                            Warrior_Defense *= 2;
                            Archer_Hability_Ticks = 2;
                        }
                        break;
                    case 3:
                        if (Mage_Health > 0)
                        {
                            Attack(Mage_Name, ref Mage_Attack, ref Mage_Defense, ref Monster_Health, ref Monster_Defense, ref Mage_Defensed, ref Mage_Cooldown, ref Mage_Hability, Hability_Mage);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(Msg_Out, Mage_Name);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        if (Mage_Hability)
                        {
                            Mage_Hability = false;
                            Monster_Health -= Mage_Attack * 3;
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine(Msg_Attack, Mage_Name, Monster, Mage_Attack * 3);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        break;
                    case 4:
                        if (Druid_Health > 0)
                        {
                            Attack(Druid_Name, ref Druid_Attack, ref Druid_Defense, ref Monster_Health, ref Monster_Defense, ref Druid_Defensed, ref Druid_Cooldown, ref Druid_Hability, Hability_Druid);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(Msg_Out, Druid_Name);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        if (Druid_Hability)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(Msg_All_Healed);
                            if (Archer_Health > 0) Archer_Health += 500;
                            if (Warrior_Health > 0) Warrior_Health += 500;
                            if (Mage_Health > 0) Mage_Health += 500;
                            if (Druid_Health > 0) Druid_Health += 500;
                            Display_Health(Archer_Health, Warrior_Health, Mage_Health, Druid_Health, Monster_Health, Archer_Name, Warrior_Name, Mage_Name, Druid_Name);
                            Druid_Hability = false;
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        break;
                    default:
                        break;
                }

                if (Monster_Health <= 0)
                {
                    Console.WriteLine(Msg_Dead, Monster);
                    return true;
                }

            }
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(Msg_Wait);
            Console.ReadKey();


            Console.Clear();

            /* Torn del monstre */
            if (Archer_Hability_Ticks == 0) Monster_Turn(ref Monster_Attack, ref Archer_Health, ref Warrior_Health, ref Mage_Health, ref Druid_Health,
                ref Archer_Defense, ref Warrior_Defense, ref Mage_Defense, ref Druid_Defense, ref Archer_Defensed, ref Warrior_Defensed, ref Mage_Defensed, ref Druid_Defensed);
            else
            {
                Console.WriteLine(Msg_Monster_KnockOut); 
                Archer_Hability_Ticks--;
            }
            if (Warrior_Hability_Ticks == 0) Warrior_Defense /= 2;
            else
            {
                Warrior_Hability_Ticks--;
            }

            /* Comprovacio de si hi ha algun heroi mort */
            if (Archer_Health < 0 && Archer_Alive)
            {
                Console.WriteLine(Msg_Dead, Archer_Name);
                Archer_Alive = false;
            }
            if (Warrior_Health < 0 && Warrior_Alive)
            {
                Console.WriteLine(Msg_Dead, Warrior_Name);
                Warrior_Alive = false;
            }
            if (Mage_Health < 0 && Mage_Alive)
            {
                Console.WriteLine(Msg_Dead, Mage_Name);
                Mage_Alive = false;
            }
            if (Druid_Health < 0 && Druid_Alive)
            {
                Console.WriteLine(Msg_Dead, Druid_Name);
                Druid_Alive = false;
            }

            if (Archer_Health < 0 && Warrior_Health < 0 && Mage_Health < 0 && Druid_Health < 0)
            {
                return false;
            }
            
            /* Mostrar vida dels herois */
            Display_Health(Archer_Health, Warrior_Health, Mage_Health, Druid_Health, Monster_Health, Archer_Name, Warrior_Name, Mage_Name, Druid_Name);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Msg_Monster_Health, Monster_Health);
            Console.ForegroundColor = ConsoleColor.Cyan;

            /* Comprovacio de cooldowns */
            if(Archer_Cooldown>0) Archer_Cooldown--;
            if(Warrior_Cooldown>0) Warrior_Cooldown--;
            if(Mage_Cooldown>0) Mage_Cooldown--;
            if(Druid_Cooldown>0) Druid_Cooldown--;


            /* Iniciar un nou torn de batalla */
            Batalla_Turn(
                ref Archer_Defensed, ref Warrior_Defensed, ref Mage_Defensed, ref Druid_Defensed,
                ref Archer_Hability, ref Warrior_Hability, ref Mage_Hability, ref Druid_Hability,
                ref Archer_Alive, ref Warrior_Alive, ref Mage_Alive, ref Druid_Alive,
                ref Archer_Cooldown, ref Warrior_Cooldown, ref Mage_Cooldown, ref Druid_Cooldown,
                ref Archer_Name, ref Warrior_Name, ref Mage_Name, ref Druid_Name,
                ref Archer_Health, ref Archer_Defense, ref Archer_Attack,
                ref Warrior_Health, ref Warrior_Defense, ref Warrior_Attack,
                ref Mage_Health, ref Mage_Defense, ref Mage_Attack,
                ref Druid_Health, ref Druid_Defense, ref Druid_Attack,
                ref Monster_Health, ref Monster_Defense, ref Monster_Attack, ref Archer_Hability_Ticks, ref Warrior_Hability_Ticks);

            return true;
        }

        /* Funcio que retorna un array amb els herois en ordre aleatori */
        public static int[] RandomAttacker()
        {
            Random random = new Random();

            int[] order = new int[4];

            for (int i = 0; i < 4; i++)
            {
                int value = random.Next(1, 5);

                while (order.Contains(value))
                {
                    value = random.Next(1, 5);
                }

                order[i] = value;
            }

            return order;
        }
        
         /* Funcio que fa un torn del monstre */
        public static void Monster_Turn(ref int Monster_Attack, ref int Archer_Health, ref int Warrior_Health, ref int Mage_Health, ref int Druid_Health, ref int Archer_Defense,
            ref int Warrior_Defense, ref int Mage_Defense, ref int Druid_Defense, ref bool Archer_Defensed, ref bool Warrior_Defensed, ref bool Mage_Defensed, ref bool Druid_Defensed)
        {
            Console.WriteLine(Msg_Turn_Monster, Monster_Attack);

            /* Atac del monstre */
            Archer_Health -= Monster_Attack - (Monster_Attack * Archer_Defense / 100);
            Warrior_Health -= Monster_Attack - (Monster_Attack * Warrior_Defense / 100);
            Mage_Health -= Monster_Attack - (Monster_Attack * Mage_Defense / 100);
            Druid_Health -= Monster_Attack - (Monster_Attack * Druid_Defense / 100);

            if (Archer_Defensed)
            {
                Archer_Defense /= 2;
                Archer_Defensed = false;
            }
            if (Warrior_Defensed)
            {
                Warrior_Defense /= 2;
                Warrior_Defensed = false;
            }
            if (Mage_Defensed)
            {
                Mage_Defense /= 2;
                Mage_Defensed = false;
            }
            if (Druid_Defensed)
            {
                Druid_Defense /= 2;
                Druid_Defensed = false;
            }
        }

}
