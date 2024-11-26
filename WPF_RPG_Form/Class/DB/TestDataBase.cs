using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_RPG_Form;

namespace P_Lista_3_formularz.Class.DB
{
        internal class TestDatabase : IDataBase
        {
            static bool isInitializedLoadAllHeroes = false;
            // Statyczna baza danych w pamięci
            private static List<Heroe> heroes = new List<Heroe>();
            private static List<Heroe> removedHeroes = new List<Heroe>();
            private static int nextId = 1;

            public void LoadAllHeroes()
            {
            if (!isInitializedLoadAllHeroes)
            {
                heroes.Add(new Heroe(nextId++, "Warrior", "Tank", 150, 50, "Shield Bash", "Taunt", "Sword", 10));
                heroes.Add(new Heroe(nextId++, "Mage", "DPS", 80, 200, "Fireball", "Teleport", "Staff", 12));
                heroes.Add(new Heroe(nextId++, "Rogue", "Assassin", 100, 75, "Backstab", "Vanish", "Dagger", 11));
                isInitializedLoadAllHeroes = true;
            }

            // Kopiowanie listy bohaterów do statycznej listy w klasie Heroe
            Heroe.ListoOfHeroes = new List<Heroe>(heroes);
        }

            public void UpdateHeroe(int id, string name, string type, int hp, int mana, string skill, string skill2, string weapon, int lvl)
            {
                var hero = heroes.FirstOrDefault(h => h.id == id);
                if (hero != null)
                {
                    hero.name = name;
                    hero.type = type;
                    hero.hp = hp;
                    hero.mana = mana;
                    hero.skill = skill;
                    hero.skill2 = skill2;
                    hero.weapon = weapon;
                    hero.lvl = lvl;
                }
            }

            public void DeleteHeroe(int id)
            {
                var hero = heroes.FirstOrDefault(h => h.id == id);
                if (hero != null)
                {
                    heroes.Remove(hero);
                }
            }

            public void AddHeroe(string name, string type, int hp, int mana, string skill, string skill2, string weapon, int lvl)
            {
                var newHero = new Heroe(nextId++, name, type, hp, mana, skill, skill2, weapon, lvl);
                heroes.Add(newHero);
            }

            public void LoadRemovedHeroes()
            {
                Heroe.ListoOfRemovedHeroes = new List<Heroe>(removedHeroes);
            }

            public void AddDeletedHeroe(string name, string type, int hp, int mana, string skill, string skill2, string weapon, int lvl)
            {
                var removedHero = new Heroe(nextId++, name, type, hp, mana, skill, skill2, weapon, lvl);
                removedHeroes.Add(removedHero);
            }

            public void MoveFromRemovedToHeroe(int id)
            {
                var hero = removedHeroes.FirstOrDefault(h => h.id == id);
                if (hero != null)
                {
                    removedHeroes.Remove(hero);
                    heroes.Add(hero);
                }
            }

            public void DeleteRemovedHeroe(int id)
            {
                var hero = removedHeroes.FirstOrDefault(h => h.id == id);
                if (hero != null)
                {
                    removedHeroes.Remove(hero);
                }
            }
        }
    }
    
