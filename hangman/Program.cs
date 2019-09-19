using System;
//hier zeg ik dat ik collections gebruik waardoor arraylist werken
using System.Collections;
using System.Collections.Generic;
namespace hangman
{
    class Program
    {
        //Hier maak ik de arraylijsten.
        private static ArrayList letters = new ArrayList();
        private static ArrayList progress = new ArrayList();
        private static ArrayList words = new ArrayList();
        static List<string> wrongletters = new List<string>();
        

        //Alle variable ( static zodat ik ze overal in deze class kan gebruiken )
        private static int lives = 5;
        private static int CorrectenLetters = 0;
        private static int checker = 0;
        private static string TheWord;
        private static bool Lettergoed = false;
        private static void Main(string[] args)
        {
            
            CreateWords();

            Console.Clear();
            Console.WriteLine("Hey ik ben [System E]");
            Console.WriteLine("PRESS ENTER TO START");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("regels en uitleg");
            Console.WriteLine("1: type STOP om het spel te stoppen");
            Console.WriteLine("2: je hebt 5 levens");
            Console.WriteLine("3: type maar 1 letter per keer wanneer je het hele woord goed hebt win je!");
            Console.WriteLine("4: GEEN hoofdletters alleen kleine letters");

            Console.WriteLine("dit bericht verwijderd zichzelf in 10 seconde");
            System.Threading.Thread.Sleep(10000);
            Console.Clear();
            
            //Maakt een random getal tussen de 0 en de (hoeveelheid worden dat ik heb toegevoegd)
            var Random = new Random();
            var RandomNumber = Random.Next(0, words.Count);

            TheWord = words[RandomNumber].ToString();

            foreach (char c in TheWord)
        {
            var s = c.ToString();
            letters.Add(s);
            progress.Add("_");
        }
            
            while(lives != 0) {
                foreach (string c in progress) {
                    Console.Write(c);
                }
                Console.WriteLine("\nLives left:" + lives);
                Console.WriteLine("Type een letter");
                Console.Write("deze letters heb je al getyped: ");
                for(var i = 0; i != wrongletters.Count;) {
                    Console.Write( wrongletters[i]);
                    Console.Write(" - ");
                    i++;
                }
                var entered = Console.ReadLine();

                if (letters.Contains(entered)) {
                        
                    //Een loop die door alle letters van letters gaat
                    for(var i = 0; i < letters.Count; i++) {
                        if (letters[i].ToString() == entered) {
                            Lettergoed = true;
                            progress[i] = entered;
                        } else {

                        }
                    }
                }
                //Wammeer de speler STOP typed stopt het wel
                if (entered.ToString() == "STOP") {
                    Console.Clear();
                    Console.WriteLine("Het spel is gestopt");
                    System.Threading.Thread.Sleep(3000);
                    Console.Clear();
                    return;
                    
                } else if (entered.Length == 0) {
                    Console.WriteLine("geef een letter");
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();
                }
                else if (entered.Length != 1) {
                    Console.WriteLine("geef maar een letter op");
                    Console.Clear();
                }
                else if (wrongletters.Contains(entered.ToString())) {
                    Console.WriteLine("je hebt deze letter al is opgenoemd");
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();
                } else if (Lettergoed == false) {
            CorrectenLetters = 0;
            checker = 0;
            Lettergoed = false;
            wrongletters.Add(entered);
            Console.WriteLine("dit klopt niet");
            lives--;
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            } else if (Lettergoed == true){
                wrongletters.Add(entered);
                CorrectenLetters = 0;
                checker = 0;
                Lettergoed = false;
            Console.WriteLine("Het was goed");
                 System.Threading.Thread.Sleep(1000);
                 Console.Clear();
                }
            
      
        //gaat door elke letter in letters en kijkt of het gelijk is met die van progress
        //Als alles gelijk is heb je het word dus helemaal en word het spel geeindigd omdat je gewonnen hebt
            foreach (String s in letters) {
            if (progress[CorrectenLetters].ToString() == letters[CorrectenLetters].ToString()) {
                CorrectenLetters++;
                checker++;
            } else {
                checker++;
            }
        }
        if (CorrectenLetters == letters.Count) {
                CorrectenLetters = 0;
                checker = 0;
                    Console.Clear();
                    Console.WriteLine("Het hele woord is goed, goed gedaan. het woord was:\n" + TheWord);
                    System.Threading.Thread.Sleep(4000);
                    Console.Clear();
                    return; 
        }
        if (lives == 0) {
                Console.WriteLine("Je levens zijn op. Jammer dat je het niet gehaald hebt, het juiste woord was:\n" + TheWord);
                System.Threading.Thread.Sleep(4000);
                Console.Clear();
                return; 

                }
            }
        }            
        static void CreateWords() {
            words.Add("appel");
            words.Add("peer");
            words.Add("banaan");
            words.Add("spruiten");
            words.Add("random");
            words.Add("speer");
            words.Add("meneer");
            words.Add("pizza");
            words.Add("patat");
            words.Add("aardappel");
            words.Add("saus");
            words.Add("laptop");
            
        }
    }
}
