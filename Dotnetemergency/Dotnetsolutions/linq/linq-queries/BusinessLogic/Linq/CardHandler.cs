using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

/*
plz install:
dotnet add package Newtonsoft.Json
*/
namespace BusinessLogic.Linq
{
     class CardHandler{

         private const string path = @"mtg.json";
         private JObject json = null;


         public CardHandler(){
            this.json = this.readCards();
         }

        private JObject readCards(){
            return  JObject.Parse(File.ReadAllText(path));
        }

        
        /*
        ==> Caves of Koilos
        */
        public void CardWithNumber(int number){
            var cards = json["cards"]
            .Where(card => ((string)card["number"]) == (number.ToString()))
            .Select(card => ((string)card["name"]));

            foreach(var card in cards){
                Console.WriteLine($"==> {card}");
            }

        }

        /*
        ==> 100
        */
        public void CountCards(){
            var cards = json["cards"];
            int count = cards.Count();
            Console.WriteLine($"==> {count}");
        }

        /*
        ==> Abundance
        ==> Academy Researchers
        ==> Adarkar Wastes
        ==> Afflict
        ==> Aggressive Urge
        ==> Agonizing Memories
        ==> Air Elemental
        ==> Air Elemental
        ==> Ambassador Laquatus
        ==> Anaba Bodyguard
        ==> Anaba Bodyguard
        ==> Ancestor's Chosen
        ==> Ancestor's Chosen
        ==> Angel of Mercy
        ==> Angel of Mercy
        ==> Angel's Feather
        ==> Angelic Blessing
        ==> Angelic Blessing
        ==> Angelic Chorus
        ==> Angelic Wall
        ==> Angelic Wall
        ==> Arcane Teachings
        ==> Arcane Teachings
        ==> Arcanis the Omnipotent
        ==> Ascendant Evincar
        ==> Ascendant Evincar
        ==> Assassinate
        ==> Aura Graft
        ==> Aura of Silence
        ==> Avatar of Might
        ==> Avatar of Might
        ==> Aven Cloudchaser
        ==> Aven Cloudchaser
        ==> Aven Fisher
        ==> Aven Fisher
        ==> Aven Windreader
        ==> Aven Windreader
        */
        public void CardsStartingWith(string text){
            var cards = json["cards"]
            .Where(card => ((string)card["name"]).StartsWith(text))
            .Select(card => ((string)card["name"]));

            foreach(var card in cards){
                Console.WriteLine($"==> {card}");
            }
        }
        /*
            ==> Abundance
            ==> Academy Researchers
            ==> Adarkar Wastes
            ==> Afflict
            ==> Aggressive Urge
            ==> Agonizing Memories
            ==> Air Elemental
            ==> Ambassador Laquatus
            ==> Anaba Bodyguard
            ==> Ancestor's Chosen
            ==> Angel of Mercy
            ==> Angel's Feather
            ==> Angelic Blessing
            ==> Angelic Chorus
            ==> Angelic Wall
            ==> Arcane Teachings
            ==> Arcanis the Omnipotent
            ==> Ascendant Evincar
            ==> Assassinate
            ==> Aura Graft
            ==> Aura of Silence
            ==> Avatar of Might
            ==> Aven Cloudchaser
            ==> Aven Fisher
            ==> Aven Windreader
        */
        public void CardsStartingWithUnique(string text){
            var cards = json["cards"]
            .Select(card => ((string)card["name"]))
            .Where(card => card.StartsWith(text))
            .Distinct();
            

            foreach(var card in cards){
                Console.WriteLine($"==> {card}");
            }
        }

        
        /*
        ==> { Name = Ancestor's Chosen, ManaCost = {5}{W}{W}, CMC = 7 }
        ==> { Name = Ancestor's Chosen, ManaCost = {5}{W}{W}, CMC = 7 }
        ==> { Name = Avatar of Might, ManaCost = {6}{G}{G}, CMC = 8 }
        ==> { Name = Avatar of Might, ManaCost = {6}{G}{G}, CMC = 8 }
        ==> { Name = Bloodfire Colossus, ManaCost = {6}{R}{R}, CMC = 8 }
        ==> { Name = Colossus of Sardia, ManaCost = {9}, CMC = 9 }
        ==> { Name = Colossus of Sardia, ManaCost = {9}, CMC = 9 }
        ==> { Name = Denizen of the Deep, ManaCost = {6}{U}{U}, CMC = 8 }
        */
        public void CovertedManaCostGreaterThen6(){
            var cards = json["cards"]
            .Select(card => new {
                Name = (string)card["name"],
                ManaCost = (string)card["manaCost"],
                CMC = (string)card["cmc"]          })
            .Where(card => (Int32.Parse(card.CMC)) > 6);

            foreach(var card in cards){
                Console.WriteLine($"==> {card}");
            }
        }

        /*
        ==> { Name = Ambassador Laquatus, ManaCost = {1}{U}{U}, Rarity = Rare, Type = Legendary Creature - Merfolk Wizard, Image = http://gatherer.wizards.com/Handlers/Image.ashx?multiverseid=129913&type=card }
        ==> { Name = Arcanis the Omnipotent, ManaCost = {3}{U}{U}{U}, Rarity = Rare, Type = Legendary Creature - Wizard, Image = http://gatherer.wizards.com/Handlers/Image.ashx?multiverseid=106426&type=card }
        ==> { Name = Ascendant Evincar, ManaCost = {4}{B}{B}, Rarity = Rare, Type = Legendary Creature - Vampire, Image = http://gatherer.wizards.com/Handlers/Image.ashx?multiverseid=106525&type=card }
        ==> { Name = Ascendant Evincar, ManaCost = {4}{B}{B}, Rarity = Rare, Type = Legendary Creature - Vampire, Image =  }
        ==> { Name = Avatar of Might, ManaCost = {6}{G}{G}, Rarity = Rare, Type = Creature - Avatar, Image = http://gatherer.wizards.com/Handlers/Image.ashx?multiverseid=135249&type=card }
        ==> { Name = Avatar of Might, ManaCost = {6}{G}{G}, Rarity = Rare, Type = Creature - Avatar, Image =  }
        ==> { Name = Birds of Paradise, ManaCost = {G}, Rarity = Rare, Type = Creature - Bird, Image = http://gatherer.wizards.com/Handlers/Image.ashx?multiverseid=129906&type=card }
        ==> { Name = Birds of Paradise, ManaCost = {G}, Rarity = Rare, Type = Creature - Bird, Image =  }
        ==> { Name = Bloodfire Colossus, ManaCost = {6}{R}{R}, Rarity = Rare, Type = Creature - Giant, Image = http://gatherer.wizards.com/Handlers/Image.ashx?multiverseid=129709&type=card }
        ==> { Name = Cephalid Constable, ManaCost = {1}{U}{U}, Rarity = Rare, Type = Creature - Cephalid Wizard, Image = http://gatherer.wizards.com/Handlers/Image.ashx?multiverseid=135261&type=card }
        ==> { Name = Cho-Manno, Revolutionary, ManaCost = {2}{W}{W}, Rarity = Rare, Type = Legendary Creature - Human Rebel, Image = http://gatherer.wizards.com/Handlers/Image.ashx?multiverseid=130554&type=card }
        ==> { Name = Clone, ManaCost = {3}{U}, Rarity = Rare, Type = Creature - Shapeshifter, Image = http://gatherer.wizards.com/Handlers/Image.ashx?multiverseid=129501&type=card }
        ==> { Name = Colossus of Sardia, ManaCost = {9}, Rarity = Rare, Type = Artifact Creature - Golem, Image = http://gatherer.wizards.com/Handlers/Image.ashx?multiverseid=135268&type=card }
        ==> { Name = Colossus of Sardia, ManaCost = {9}, Rarity = Rare, Type = Artifact Creature - Golem, Image =  }
        ==> { Name = Denizen of the Deep, ManaCost = {6}{U}{U}, Rarity = Rare, Type = Creature - Serpent, Image = http://gatherer.wizards.com/Handlers/Image.ashx?multiverseid=135250&type=card }
        */
        public void allCreatureCardsWithRarity(string rarity){
            
            var cards = json["cards"]
            .Select(card => new {
                Name = (string)card["name"],
                ManaCost = (string)card["manaCost"],
                Rarity = (string)card["rarity"],
                Type= (string)card["type"],
                Image= (string)card["imageUrl"]
            })
            .Where(c => ((string)c.Rarity).Contains(rarity))
            .Where(c => ((string)c.Type).Contains("Creature"));

           foreach(var card in cards){
                Console.WriteLine($"==> {card}");
            }
        }

        /*
        ==> Enchantment
        ==> Creature
        ==> Land
        ==> Instant
        ==> Sorcery
        ==> Artifact
        ==> Aura
        */
        public void allPosibleTypes(){
            var cards = json["cards"]
            .Select(
                (card) => {
                    string cardType = (string)card["type"];
                    if(cardType.Contains("Aura"))
                        return "Aura";
                    
                    return ((string)card["type"]).Contains("Creature") ? "Creature" : ((string)card["type"]);
                }
                )
            .Distinct();

            foreach(var card in cards){
                Console.WriteLine($"==> {card}");
            }

        }

        /*
        (card) => new {
                    English = ((string)card["name"]),
                    German = ((string)card["foreignNames"][0]["name"]),
                    Spanich = ((string)card["foreignNames"][0]["name"]),
                    French = ((string)card["foreignNames"][0]["name"]),
                    Italian = ((string)card["foreignNames"][0]["name"]),
                    Japanese = ((string)card["foreignNames"][0]["name"])
                }
        */

        /*
            ==> German: Ausgewählter der Ahnfrau
            ==> Spanish: Elegido de la Antepasada
            ==> French: Élu de l'Ancêtre
            ==> Italian: Prescelto dell'Antenata
            ==> Japanese: ????????
            ==> Portuguese (Brazil): Eleito da Ancestral
            ==> Russian: ????????? ???????????
            ==> Chinese Simplified: ?????
            ==> English: Ancestor's Chosen
            -----
            ==> German: Engel der Gnade
            ==> Spanish: Ángel de piedad
            ==> French: Ange de miséricorde
            ==> Italian: Angelo della Misericordia
            ==> Japanese: ?????
            ==> Portuguese (Brazil): Anjo de Misericórdia
            ==> Russian: ????? ??????????
            ==> Chinese Simplified: ????
            ==> English: Angel of Mercy
            -----
            ==> German: Himmlischer Segen
            ==> Spanish: Bendición angélica
            ==> French: Bénédiction angélique
            ==> Italian: Benedizione Angelica
            ==> Japanese: ?????
            ==> Portuguese (Brazil): Bênção Angelical
            ==> Russian: ????????????? ??????
            ==> Chinese Simplified: ?????
            ==> English: Angelic Blessing
            -----

            HINT: 
                - SKIP THE NUMBERS WITH A ★!!! (use int.TryParse)
                - you can use a Dictionary here
        */
        public void TranslationsOrderByNumberTop(int top){
            var cards = json["cards"]
            .OrderBy(card => {
                string input = ((string)card["number"]);
                int number = 0;
                bool isNumeric = int.TryParse(input, out number);
                if(isNumeric){
                    return number;
                }else{
                    return 9999999;
                }
                })
                .Select(
                (card) => {
                    Dictionary<string, string> ct = new Dictionary<string, string>();
                    foreach(var t in card["foreignNames"]){
                        ct.Add((string)t["language"], (string)t["name"]);
                    }
                    ct.Add("English", (string)card["name"]);
                    return ct;
                }
            )
            
            .Take(top);
            
            foreach(var card in cards)
            {
                foreach(var translation in card)
                {
                    Console.WriteLine($"==> {translation.Key}: {translation.Value}");
                }
                 Console.WriteLine("-----");
            }
            
        }
        /*
        ==> { Name = Abundance, Printings = [
        "10E",
        "C17",
        "DDR",
        "USG"
        ] }
        ==> { Name = Academy Researchers, Printings = [
        "10E",
        "USG"
        ] }
        ==> { Name = Angelic Chorus, Printings = [
        "10E",
        "BBD",
        "USG"
        ] }
        ==> { Name = Blanchwood Armor, Printings = [
        "10E",
        "7ED",
        "8ED",
        "9ED",
        "DPA",
        "M19",
        "MB1",
        "PS11",
        "USG"
        ] }
        ==> { Name = Blanchwood Armor, Printings = [
        "10E",
        "7ED",
        "8ED",
        "9ED",
        "DPA",
        "M19",
        "MB1",
        "PS11",
        "USG"
        ] }
        ==> { Name = Chimeric Staff, Printings = [
        "10E",
        "USG"
        ] }
        ==> { Name = Citanul Flute, Printings = [
        "10E",
        "USG"
        ] }

        // https://stackoverflow.com/questions/23343771/jarray-contains-issue

        */
        public void InPrintings(string printing){

            var cards = json["cards"]
            .Select(n => new {
                Name = (string) n["name"],
                Printings = n["printings"]
            })
            .Where(card => card.Printings.Where(m => ((string)m) == printing).Any())
            ;

            foreach(var card in cards){
                Console.WriteLine($"==> {card}");
            }
            
        }

    }
}
