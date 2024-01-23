# Herois VS Monstre V.2
---
## Mètodes del programa (Clase Batalla)

> 1. IsNotLimits
```csharp
public static bool IsNotLimits(int value, int min, int max)
```

> 2. RandomAttacker
```csharp
public static int[] RandomAttacker()
```

> 3. Attack
```csharp
public static void Attack(string Name, ref int H_Attack, ref int H_Defense, ref int M_Health, ref int M_Defense, ref bool H_Defensed, ref int Cooldown, ref bool Hability, string Hability_Name)
```

> 4. Monster_Turn
```csharp
public static void Monster_Turn(ref int Monster_Attack, ref int Archer_Health, ref int Warrior_Health, ref int Mage_Health, ref int Druid_Health)
```

> 5. Display_Health
```csharp
public static void Display_Health(int Archer_Health, int Warrior_Health, int Mage_Health, int Druid_Health, int Monster_Health, string Archer_Name, string Warrior_Name, string Mage_Name, string Druid_Name)
```

> 6. Sort_Desc
```csharp
public static int[] Sort_Desc(int[] array)
```

> 7. BatallaStart
```csharp
public static bool BatallaStart(string Archer_Name, string Warrior_Name, string Mage_Name, string Druid_Name, int Archer_Health, int Archer_Defense, int Archer_Attack, int Warrior_Health, int Warrior_Defense, int Warrior_Attack, int Mage_Health, int Mage_Defense, int Mage_Attack, int Druid_Health, int Druid_Defense, int Druid_Attack, int Monster_Health, int Monster_Defense, int Monster_Attack)
```

> 8. BatallaTurn
```csharp
public static bool Batalla_Turn(
ref bool Archer_Defensed, ref bool Warrior_Defensed, ref bool Mage_Defensed, ref bool Druid_Defensed, ref bool Archer_Hability, ref bool Warrior_Hability, ref bool Mage_Hability, ref bool Druid_Hability, ref bool Archer_Alive, ref bool Warrior_Alive, ref bool Mage_Alive, ref bool Druid_Alive, ref int Archer_Cooldown, ref int Warrior_Cooldown, ref int Mage_Cooldown, ref int Druid_Cooldown, ref string Archer_Name, ref string Warrior_Name, ref string Mage_Name, ref string Druid_Name, ref int Archer_Health, ref int Archer_Defense, ref int Archer_Attack, ref int Warrior_Health, ref int Warrior_Defense, ref int Warrior_Attack, ref int Mage_Health, ref int Mage_Defense, ref int Mage_Attack, ref int Druid_Health, ref int Druid_Defense, ref int Druid_Attack, ref int Monster_Health, ref int Monster_Defense, ref int Monster_Attack, ref int Archer_Hability_Ticks, ref int Warrior_Hability_Ticks)
```

---
---

## Clases d'equivalència
---
> IsNotLimits

| Classe d'Equivalència | Descripció                                  | Valors Representatius                   |
|------------------------|---------------------------------------------|----------------------------------------|
| Classe Vàlida           | `min <= value <= max`                       | `value = min`, `value = (min + max) / 2`, `value = max` |
| Classe No Vàlida (abaix)| `value < min`                               | `value = min - 1`, `value = min - 100` |
| Classe No Vàlida (amunt)| `value > max`                               | `value = max + 1`, `value = max + 100` |

---

| N# | value | min | max | Resultat Esperat                    |
|----|-------|-----|-----|--------------------------------------|
| 1  | 5     | 1   | 10  | Fals                         |
| 2  | 15    | 1   | 10  | Cert                        |
| 3  | -5    | 0   | 10  | Cert                         |
| 4  | 5     | 5   | 10  | Fals                      |
| 5  | 10    | 1   | 10  | Fals                        |

---

> RandomAttacker()

| Classe d'Equivalència | Descripció                                         | Valors Representatius                           |
|------------------------|----------------------------------------------------|--------------------------------------------------|
| Classe Vàlida           | S'espera una seqüència única de nombres de 1 a 4.  | `order = [1, 2, 3, 4]`, `order = [4, 3, 2, 1]`   |
| Classe No Vàlida        | Cap valor repetit a la seqüència.                  | `order = [1, 2, 2, 4]`, `order = [3, 3, 1, 2]`   |

---

| N# | Resultat Esperat                                      |
|----|--------------------------------------------------------|
| 1  | Array de 4 elements amb valors únics de 1 a 4 desordenats         |

--

> Attack()

| Classe d'Equivalència | Descripció                                        | Valors Representatius                                                |
|------------------------|---------------------------------------------------|-----------------------------------------------------------------------|
| Entrada Vàlida         | Opcions vàlides de 1 a 3 (Atacar, Defensar, Habilidad) | `option = 1`, `option = 2`, `option = 3`                             |
| Entrada No Vàlida      | Opcions fora de l'abast 1 a 3, s'han de demanar màxim 2 vegades | `option = 0`, `option = 4`, `option = 10`, `option = -1`           |
| Cas Atacar amb Fallada | Valor aleatori per fallada menor que 5%           | `aux = 3`, `aux = 2` (simulant fallada) (aux = Random(1,101))                              |
| Cas Atacar Crític      | Valor aleatori per atac crític menor que 10%      | `aux = 9`, `aux = 8` (simulant atac crític) (aux = Random(1,101))                         |
| Cas Atacar Normal      | Cap fallada ni crític, escollirà l'opció per defecte | `aux = 20`, `aux = 50` (simulant atac normal) (aux = Random(1,101))                     |
| Cas Defensar            | Opció de defensar, duplica la defensa i activa la bandera de defensar | `option = 2`                                                        |
| Cas Habilidad           | Opció d'habilitat amb cooldown a 0, activa la bandera d'habilitat i estableix el cooldown a 5 | `option = 3`, `Cooldown = 0`                                       |
| Cas Habilidad Cooldown  | Opció d'habilitat amb cooldown no a 0, mostra el missatge de cooldown | `option = 3`, `Cooldown = 2`                                       |

---

| N# | option | aux | Cooldown | Resultat Esperat                        |
|----|--------|-----|----------|----------------------------------------|
| 1  | 1      | -   | -        | Atac realitzat amb èxit                 |
| 2  | 0      | -   | -        | Nova entrada requerida (1 intent)      |
| 3  | 4      | -   | -        | Nova entrada requerida (2 intents)     |
| 4  | -      | 3   | -        | Missatge d'atac fallit                 |
| 5  | -      | 9   | -        | Missatge d'atac crític                 |
| 6  | -      | 20  | -        | Atac normal realitzat                   |
| 7  | 2      | -   | -        | Defensa realitzada amb èxit             |
| 8  | 3      | -   | 0        | Habilidad activada amb cooldown 0      |
| 9  | 3      | -   | 2        | Missatge de cooldown mostrat           |

> Monster_Turn

| Classe d'Equivalència | Descripció                                                                                   | Valors Representatius                                                |
|------------------------|----------------------------------------------------------------------------------------------|-----------------------------------------------------------------------|
| Atac Monster       | Monstre ataca tots els personatges amb les seves estadístiques i efectes de defensa aplicats  | `Monster_Attack = 20`, `Archer_Health = 80`, `Warrior_Health = 90`, `Mage_Health = 70`, `Druid_Health = 100` |

---

| N# | Monster_Attack | Resultat Esperat |
|----|------------------|-------------------------------------------------|
| 1  | 300             | Atac del monstre amb 300 de dany |
| 2  | 315             | Atac del monstre amb 315 de dany |

---

> Display_Health()
> 
| Classe d'Equivalència | Descripció                                                                                    | Valors Representatius                                   |
|------------------------|-----------------------------------------------------------------------------------------------|----------------------------------------------------------|
| Cas Salut Positiva     | Personatge amb salut positiva (> 0)                                                         | `Archer_Health = 80`, `Warrior_Health = 90`, `Mage_Health = 70`, `Druid_Health = 100`                              |
| Cas Salut Zero         | Personatge amb salut zero                                                                   | `Archer_Health = 0`, `Warrior_Health = 10`, `Mage_Health = 0`, `Druid_Health = 0`                                   |

---

| N# | Archer_Health | Warrior_Health | Mage_Health | Druid_Health | Resultat Esperat                           |
|----|---------------|-----------------|-------------|--------------|--------------------------------------------|
| 1  | 80            | 90              | 70          | 100          | Mostra la vida de tots els herois|
| 2  | 0             | 10              | 0           | 0            | Mostra la vida només del Bàrbar         |
| 3  | 0             | 0               | 0           | 0            | N/A |

---

> Sort_Desc()
> 
| Classe d'Equivalència | Descripció                                                                                           | Valors Representatius                              |
|------------------------|------------------------------------------------------------------------------------------------------|-----------------------------------------------------|
| Cas Array Vàlid        | L'array té valors vàlids i ha de ser ordenat de forma descendent                                     | `array = [10, 8, 5, 3, 1]`                          |
| Cas Array No Vàlid     | L'array no té valors vàlids o no ha de ser ordenat                                                  | `array = []`, `array = [3, 2, 5, 2, 1]`, `array = [-3, 2, -5, 1, 0]`                           |

---

| N# | array                    | Resultat Esperat               |
|----|--------------------------|--------------------------------|
| 1  | [3, 5, 8, 10]         | [10, 8, 5, 3] |
| 2  | []                       | []|
| 3  | [3, 2, 5, 2]          | [5, 3, 2, 2] |
| 4  | [10, 8, 0, 1]         | [10, 8, 1, 0] |
| 5  | [-3, -5, 1, 0]        | [1, 0, -3, -5] |

---
