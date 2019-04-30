/*
 CIDM 2315 FINAL PROJECT
 GROUP MEMBERS:
 1.  Elizabeth Free
 2.
 3.
 4.

 DUE by 11:59 PM on WTCLASS on Tuesday, 5/7

*/

/*
    Errors encountere with solutions:

    1.
    2.
    3.
    4.

*/


using System;


namespace wumpus
{
    public class Wumpus
    {
        /* The Wumpus class has a constructor, methods, and private variables. */
                
        private string name;    // holds the name of the Wumpus
        private string size;    // holds the size of the Wumpus
        private int strength;   // holds the Wumpus' strength - the amount of attack damage dealt
        private int intellect;  // holds the Wumpus' intellect - the amount of special damage dealt
        private int health;     // holds the Wumpus' health
        private int mana;       // holds the Wumpus' mana - using special ability costs mana
        private int[] currentPosition = new int[2];                 // holds the current coordinates of the Wumpus' on Yob map
        private List<string> wumpusAbilities = new List<string>();  // a list of the Wumpus' abilities

        // ########### //
        //   TASK 1    //
        // ########### //

        /* 
            Create the Wumpus constructor. 
            The constructor takes two parameters, one for the name and one for the size of the Wumpus.

            It assigns the parameter for the name as the Wumpus name and the parameter for the size as the Wumpus size.

            The current position of the Wumpus is set to 0,0 in the constructor.

            Depending on the size of the Wumpus (small, medium, or large) the Wumpus attributes are assigned as follows:

            If the Wumpus is large, it has strength of 15, intellect of 5, health of 50, and mana of 15.
            The large Wumpus has two starting abilities, including "Wumpus Claw (15d)" and "Wumpus Stomp (5d/5m)".

            If the Wumpus is medium, it has strength of 10, intellect of 15, health of 25, and mana of 25.
            The medium Wumpus has two starting abilities, including "Wumpus Claw (10d)" and "Wumpus Bark (15d/5m)".

            If the Wumpus is small, it has strength of 5, intellect of 25, health of 20, and mana of 50.
            The small Wumpus has two starting abilities, including "Wumpus Claw (5d)" and "Wumpus Sparkle (25d/5m)".

        */

        public Wumpus()  
        {
 
        }

        // ############## //
        //   END TASK 1   //
        // ############## //



        // ########### //
        //   TASK 4    //
        // ########### //

        /* 
           In this task, you will create a method that refills the Wumpus' health and mana
           when he/she returns to the "Inn" at 0,0.  

           This method has no input parameters and no return.

           This method should do the following:
           
           1) Clear the Console
           2) Print "Welcome back to the inn!" to the Console.
           3) Set the Wumpus' health and mana based on the size of the Wumpus.
                In other words, if the Wumpus is "large" set the health and mana to
                what they were when the Wumpus was created.  Do this for each size.
        */       

        public void inn()
        {



            Console.WriteLine($"{name} now has {health} health and {mana} mana.");
            Console.WriteLine($"Safe travels, {name}!");
        }

        // ############## //
        //   END TASK 4   //
        // ############## //


        public int[] getWumpusLocation()  // This method returns the current ROW,COL coordinates of the Wumpus.
        {
            return currentPosition;
        }


        // ########### //
        //    TASK 3   //
        // ########### //

        /* 
           In this task, you will create a method that displays the map when called.  
           This method takes the map of Yob caves in as a parameter and has no return.

           This method should display the map as seen in the output.
        */
        public void displayMap(string[,] map)
        {

        }
        // ############## //
        //   END TASK 3   //
        // ############## //


        // ********** START OF DO NOT EDIT SECTION 1 ********** //

        public string explore(string[,] map, string[,] bMap)
        {
            string direction;
            bool invalid = true;
            
            if (currentPosition[0] == 0 && currentPosition[1] == 0)
            {
                map[currentPosition[0], currentPosition[1]] = "Inn";
            }

            if (map[currentPosition[0], currentPosition[1]] == "W")
            {
                map[currentPosition[0], currentPosition[1]] = "^";      
            }

            while (invalid == true)
            {
                Console.Write("Enter direction (use WASD for < ^ v >): ");
                direction = Console.ReadLine().ToLower();
                if (direction == "w")
                {
                    if (currentPosition[0] > 0)
                    {
                        currentPosition[0] = currentPosition[0] - 1; // Move one space up
                        invalid = false;
                    }
                    else
                    {
                        Console.WriteLine("Can't go further north. Try again.");
                    }
                }
                else if (direction == "d")
                {
                    if (currentPosition[1] < map.GetLength(1) - 1)
                    {
                        currentPosition[1] = currentPosition[1] + 1; // Move one space East or right
                        invalid = false;
                    }
                    else
                    {
                        Console.WriteLine("Can't go further east. Retry");
                    }
                }
                else if (direction == "s")
                {
                    if (currentPosition[0] < map.GetLength(0) - 1)
                    {
                        currentPosition[0] = currentPosition[0] + 1; // Move one space South or down
                        invalid = false;
                    }
                    else
                    {
                        Console.WriteLine("Can't go further south. Try again.");
                    }
                }            
                else if (direction == "a")
                {
                    if (currentPosition[1] > 0)
                    {
                        currentPosition[1] = currentPosition[1] - 1; // Move one space West or left
                        invalid = false;
                    }
                    else
                    {
                        Console.WriteLine("Can't go further west. Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
            
            if (map[currentPosition[0], currentPosition[1]] == "_" || map[currentPosition[0], currentPosition[1]] == "^")
            {
                map[currentPosition[0], currentPosition[1]] = "W";
            }       

            return bMap[currentPosition[0], currentPosition[1]];
            
        }

        private void fightMenuDisplay()
        {
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("| ATTACK\t\t| SPECIAL\t\t| INVENTORY 1\t\t| INVENTORY 2\t\t|");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            foreach (string skill in wumpusAbilities)
            {
                Console.Write("| ");
                Console.Write(skill + "\t");
            }

            Console.WriteLine("|");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
        }

        // ********** END OF DO NOT EDIT SECTION 1 ********** //


        // ########### //
        //   TASK 5   //
        // ########## //

        /* 
           In this task, you will create a method that runs the Wumpus fighting a Spook.  
           This method takes the map of Yob caves and the Boss map as parameters and 
           returns the value of the boolean variable lost.
        */

        public bool spookFight(string[,] map, string[,] bMap)
        {
            /*
                Declare four variables for the following:
                1) The health of the Spook
                2) The damage dealt by the Spook
                3) The damage dealt by the Wumpus
                
            */


            bool lost = false; // Represents whether or not the Wumpus lost the fight.

            Console.Clear();
            Console.WriteLine($"{name} has encountered a Spook!");

            while (health > 0 && spookHealth > 0)  // While neither the Spook or the Wumpus has died...
            {
                // Display the fight menu - this is a STATIC method.
                


                // Declare a variable called action and set it to "".

                
                // Ask the user which attack they would like to use (see output for details).
                // Validate their choice so that they MUST enter one of the acceptable choices.
                // If they pick something invalid print "Invalid choice. Try again." to the Console.



                /* 
                    If the action taken is "attack", do the following:
                    1) Take away the value of the Wumpus' strength from the health of the Spook.
                    2) Set the Wumpus damage variable equal to the value of the Wumpus' strength.
                    3) Print the following to the Console:
                        "{wumpus name} used {the matching wumpus ability} on Spook for {wumpus damage} damage."
                */

                {


                }

                 /* 
                    Otherwise, if the action taken is "special" AND the value of mana is greater than 4, do the following:
                    1) Take away the value of the Wumpus' intellect from the health of the Spook.
                    2) Set the Wumpus damage variable equal to the value of the Wumpus' intellect.
                    3) Subtract the value of 5 from the Wumpus' mana.
                    4) Print the following to the Console:
                        "{wumpus name} used {the matching wumpus ability} on Spook for {wumpus damage} damage."
                */        

                {



                }

                /* 
                    Otherwise, if the action taken is "item1" AND the number of available wumpus abilities is greater than 2, do the following:
                    1) Set the Wumpus damage variable equal to 0.
                    2) Print the following to the Console:
                        "{wumpus name} is ineffective."
                */  

                {

                }

                /* 
                    Otherwise, if the action taken is "item2" AND the number of available wumpus abilities is greater than 3, do the following:
                    1) Set the Wumpus damage variable equal to 0.
                    2) Print the following to the Console:
                        "{wumpus name} is ineffective."
                */  

                {


                }

                /* 
                    Otherwise, do the following:
                    1) Set the Wumpus damage variable equal to 0.
                    2) Print the following to the Console:
                        "{wumpus name} is ineffective."
                */  

                { 


                }
                
               
                    
                // If the Spook has 0 or less health, print "Spook defeated!" to the Console.

                {

                }

                /*
                    Otherwise, do the following:
                    1) Print "Spook has {spook health} health." to the Console.
                    2) Subtract the amount of damage the Spook does from the Wumpus' health.       
                */

                {

                    /*  If the Wumpus has 0 or less health, do the following:
                        1) Print "Spook hit {wumpus name} for {spook damage} damage!" to the Console.
                        2) Print "{wumpus name} defeated. GAME OVER." to the Console.
                        3) Set the value of the variable lost equal to true. 
                    */

                    {

                    }
                   
                    // Otherwise, print "{wumpus name} has {wumpus health} health." to the Console.

                    {
                        
                    } 
                }
            }  // END WHILE

            /*
                If the value of the variable lost is equal to false, do the following:
                1) Set the value on the Yob map where the Wumpus is currently equal to "xSx".
                2) Set the value on the Boss map where the Wumpus is currently equal to "_". 
            */
            
            {

            }

            /* 
                Otherwise, set the value on the Yob map where the Wumpus is currently equal to "S".
            */
 
            {

            }

            // Return the value of the variable lost.


        }

        // ############## //
        //   END TASK 5   //
        // ############## //


         // ########### //
        //    TASK 6   //
        // ########### //       

        /* 
           In this task, you will create a method that runs the Wumpus fighting Agbigor the Wumpus Hunter.  
           This method takes the map of Yob caves and the Boss map as parameters and 
           returns the value of the boolean variable lost.
        */

        public bool boss1Fight()
        {
            int abigorHealth = 20;
            int abigorMana = 10;
            int abigorAttackDamage = 7;
            int abigorMagicDamage = 2;
            string abigorAttackName = "";
            int abigorDamageDealt = 0;
            int wumpusDamageDealt = 0;
            string wumpAbilityUsed = "";
            Random rd = new Random();
            bool lost = false;

            // Clear the Console.
            

            // Print "{wumpus name} has encountered Abigor the Wumpus Hunter!" to the Console.


            while (health > 0 && abigorHealth > 0)  // As long as Wumpus and Abigor are both alive...
            {
                // Display the fight menu.  This is a STATIC method.


                // Declare a variable called action and set its value equal to "".


                // Ask the user which attack they would like to use.
                // Validate their choice so that they MUST enter one of the acceptable choices.
                // If they pick something invalid print "Invalid choice. Try again." to the Console.





                /* 
                    If the action taken is "attack", do the following:
                    1) Set the value of wumpAbilityUsed to the value of the first Wumpus Ability in the list.
                    2) Set wumpusDamageDealt equal to the value of the Wumpus' strength.
                */

                {


                }

                /* 
                    Otherwise, if the action taken is "special" do the following:
                    1) Take away the value of the Wumpus' intellect from the health of Abigor.
                    2) Set the Wumpus damage variable equal to the value of the Wumpus' intellect.
                    3) Subtract the value of 5 from the Wumpus' mana.
                    4) Print the following to the Console:
                        "{wumpus name} used {the matching wumpus ability} on Abigor for {wumpus damage} damage."
                */        

                {
                    // If Wumpus has less than 5 mana, do the following:
                    // Print "{wumpus name} does not have enough mana." to the Console.
                    // Set the value of wumpusDamageDealt equal to 0.

                    {

                    }
                    
                    // Otherwise, do the following:
                    // Subtract 5 from the Wumpus mana.
                    // Set wumpAbilityUsed equal to the corresponding Wumpus ability in the list.
                    // Set wumpusDamageDealt equal to the Wumpus' intellect.

                    {
  
                    }
                }
                
                /*
                    Otherwise, set wumpusDamageDealt equal to 0.
                */

                {

                }
                
                /*
                    If wumpusDamageDealt is equal to 0, print "{wumpus name} is ineffective." to the Console.
                */

                {

                }
                
                /*
                    Otherwise, do the following:
                    1) Print {wumpus name} used {name of the Wumpus Ability used} on Abigor for {damage dealt by Wumpus} damage." to the Console
                    2) Set Abigor's health to his heath minus the amount of damage dealt by Wumpus.
                */

                {

                }
                
                /* 
                    If Abigor has 0 or less health, do the following:
                */

                {
                    Console.WriteLine("Abigor the Wumpus Hunter defeated!");
                    Console.WriteLine($"{name} has {health} health and {mana} mana.");
                    Console.WriteLine($"The Dream Catcher has been added to {name}'s inventory!");
                    
                    // Add "Dream Catcher (20d)" to the list of the Wumpus' abilities.

                }
                
                // ********** START OF DO NOT EDIT SECTION 2 ********** //
                else
                {
                    Console.WriteLine($"Abigor has {abigorHealth} health and {abigorMana} mana.");

                    if (rd.Next(1,3) == 1)
                    {
                        abigorDamageDealt = abigorAttackDamage;
                        abigorAttackName = "Arrow Attack";
                    }
                    else
                    {
                        if (abigorMana < 2)
                        {
                            Console.WriteLine($"Abigor does not have enough mana.");
                            abigorDamageDealt = 0;
                        }
                        else
                        {
                            abigorDamageDealt = abigorMagicDamage;
                            abigorAttackName = "Swift Fire Arrow";
                            abigorMana = abigorMana - 2;
                        }
                    }
                    if (abigorDamageDealt == 0)
                    {
                        Console.WriteLine("Abigor is ineffective.");
                    }   
                    else
                    {
                        Console.WriteLine($"Abigor used his {abigorAttackName} and hit {name} for {abigorDamageDealt} damage.");
                        health = health - abigorAttackDamage;

                        if (health <= 0)
                        {
                            Console.WriteLine($"{name} defeated by Abigor the Wumpus Hunter.  GAME OVER.");
                            lost = true;
                        }
                        else 
                        {
                            Console.WriteLine($"{name} has {health} health and {mana} mana.");
                        }
                        
                    }
                } // ********** END OF DO NOT EDIT SECTION 2 ********** //
                
            }  // END WHILE

            // If the value of the variable lost is false, do the following:
            // 1) Set the value on the Yob map where the Wumpus is currently to "xAx".
            // 2) Set the value on the Boss map where the Wumpus is currently to "_".

            {

            }

            // Otherwise, set the value on the Yob map where the Wumpus is currently to "A".

            {

            }

            // Return the value of the variable lost.


        }

        // ############## //
        //   END TASK 6   //
        // ############## //


        // ########### //
        //    TASK 7   //
        // ########### //

        public bool boss2Fight(string[,] map, string[,] bMap)
        {
            // Batibat the Super Bat

            int batHealth = 30;
            int batMana = 20;
            int batAttackDamage = 10;
            int batMagicDamage = 10;
            string batAttackName = "";
            int batDamageDealt = 0;
            int wumpusDamageDealt = 0;
            string wumpAbilityUsed = "";
            Random rd = new Random();
            bool lost = false;

            // Clear the Console.
            

            // Print "{wumpus name} has encountered Batibat the Super Bat!" to the Console.


            while (health > 0 && batHealth > 0)
            {
                
                // Display the fight menu.  This is a STATIC method.


                // Declare a variable called action and set its value equal to "".


                // Ask the user which attack they would like to use.
                // Validate their choice so that they MUST enter one of the acceptable choices.
                // If they pick something invalid print "Invalid choice. Try again." to the Console.





                /* 
                    If the action taken is "attack", do the following:
                    1) Set the value of wumpAbilityUsed to the value of the first Wumpus Ability in the list.
                    2) Set wumpusDamageDealt equal to the value of the Wumpus' strength.
                */

                {


                }

                /* 
                    Otherwise, if the action taken is "special" do the following:
                    1) Take away the value of the Wumpus' intellect from the health of Batibat.
                    2) Set the Wumpus damage variable equal to the value of the Wumpus' intellect.
                    3) Subtract the value of 5 from the Wumpus' mana.
                    4) Print the following to the Console:
                        "{wumpus name} used {the matching wumpus ability} on Batibat for {wumpus damage} damage."
                */        

                {
                    // If Wumpus has less than 5 mana, do the following:
                    // Print "{wumpus name} does not have enough mana." to the Console.
                    // Set the value of wumpusDamageDealt equal to 0.

                    {

                    }
                    
                    // Otherwise, do the following:
                    // Subtract 5 from the Wumpus mana.
                    // Set wumpAbilityUsed equal to the corresponding Wumpus ability in the list.
                    // Set wumpusDamageDealt equal to the Wumpus' intellect.

                    {
  
                    }
                }

                /* 
                    Otherwise, if the action taken is "item1" and the number of available Wumpus abilities is greater than 2, do the following:
                */        

                {
                    // If the third Wumpus ability is equal to "Dream Catcher (20d)",
                    // 1) Set wumpAbilityUsed equal to the corresponding Wumpus ability.
                    // 2) Set wumpusDamageDealt equal to 20.

                    {    

                    }
                } 

                /* 
                    Otherwise, if the action taken is "item2 and the number of available Wumpus abilities is greater than 3, do the following:
                */    

                {

                    // If the fourth Wumpus ability is equal to "Dream Catcher (20d)",
                    // 1) Set wumpAbilityUsed equal to the corresponding Wumpus ability.
                    // 2) Set wumpusDamageDealt equal to 20.

                    {    

                    }                 
                }

                // Otherwise, set wumpusDamageDealt equal to 0.

                {

                }
                
                // If wumpusDamageDealt is equal to 0, print "{wumpus name} is ineffective." to the Console.

                {
                    
                }

                // Otherwise, do the following:
                // 1) Print "{wumpus name} used {wumpAbilityUsed} on Batibat for {wumpusDamageDealt} damage." to the Console.
                // 2) Set Batibat's health equal to her health minus the damage dealt by Wumpus.
               
                {

                }
                
                // ********** START OF DO NOT EDIT SECTION 3 ********** //
                if (batHealth <= 0)
                {
                    Console.WriteLine("Batibat the Super Bat defeated!");
                    Console.WriteLine($"{name} has {health} health and {mana} mana.");
                    Console.WriteLine($"The Silver Bullet has been added to {name}'s inventory!");
                    wumpusAbilities.Add("Silver Bullet (30d)");
                }
                else 
                {
                    Console.WriteLine($"Batibat has {batHealth} health and {batMana} mana.");

                    if (rd.Next(1,3) == 1)
                    {
                        batDamageDealt = batAttackDamage;
                        batAttackName = "Swiping Claw";
                    }
                    else
                    {
                        if (batMana < 5)
                        {
                            Console.WriteLine($"Batibat does not have enough mana.");
                            batDamageDealt = 0;
                        }
                        else
                        {
                            batDamageDealt = batMagicDamage;
                            batAttackName = "Vicious Nightmare";
                            batMana = batMana - 5;
                        }
                    }
                    if (batDamageDealt == 0)
                    {
                        Console.WriteLine("Batibat is ineffective.");
                    }   
                    else
                    {
                        Console.WriteLine($"Batibat used her {batAttackName} and hit {name} for {batDamageDealt} damage.");
                        health = health - batAttackDamage;

                        if (health <= 0)
                        {
                            Console.WriteLine($"{name} defeated by Batibat the Super Bat.  GAME OVER.");
                            lost = true;
                        }
                        else 
                        {
                            Console.WriteLine($"{name} has {health} health and {mana} mana.");
                        }
                        
                    }
                }
            // ********** END OF DO NOT EDIT SECTION 3 ********** //
                
            }  // END WHILE

            // If the value of the variable lost is false, do the following:
            // 1) Set the value on the Yob map where the Wumpus is currently to "xBx".
            // 2) Set the value on the Boss map where the Wumpus is currently to "_".

            {

            }

            // Otherwise, set the value on the Yob map where the Wumpus is currently to "B".

            {

            }

            // Return the value of the variable lost.


        }
        // ############## //
        //   END TASK 7   //
        // ############## //

        // ########### //
        //    TASK 8   //
        // ########### //

        public bool boss3Fight(string[,] map, string[,] bMap)
        {
            // Vladimir the Soul Drinker

            int vladHealth = 50;
            int vladMana = 30;
            int vladAttackDamage = 15;
            int vladMagicDamage = 15;
            string vladAttackName = "";
            int vladDamageDealt = 0;
            int wumpusDamageDealt = 0;
            string wumpAbilityUsed = "";
            Random rd = new Random();
            bool lost = false;

            // Clear the Console.
            

            // Print "{wumpus name} has encountered Vladimir the Soul Eater!" to the Console.



            while (health > 0 && vladHealth > 0)
            {
                // Display the fight menu.  This is a STATIC method.


                // Declare a variable called action and set its value equal to "".


                // Ask the user which attack they would like to use.
                // Validate their choice so that they MUST enter one of the acceptable choices.
                // If they pick something invalid print "Invalid choice. Try again." to the Console.





                /* 
                    If the action taken is "attack", do the following:
                    1) Set the value of wumpAbilityUsed to the value of the first Wumpus Ability in the list.
                    2) Set wumpusDamageDealt equal to the value of the Wumpus' strength.
                */

                {


                }

                /* 
                    Otherwise, if the action taken is "special" do the following:
                    1) Take away the value of the Wumpus' intellect from the health of Vladimir.
                    2) Set the Wumpus damage variable equal to the value of the Wumpus' intellect.
                    3) Subtract the value of 5 from the Wumpus' mana.
                    4) Print the following to the Console:
                        "{wumpus name} used {the matching wumpus ability} on Vladimir for {wumpus damage} damage."
                */        

                {
                    // If Wumpus has less than 5 mana, do the following:
                    // Print "{wumpus name} does not have enough mana." to the Console.
                    // Set the value of wumpusDamageDealt equal to 0.

                    {

                    }
                    
                    // Otherwise, do the following:
                    // Subtract 5 from the Wumpus mana.
                    // Set wumpAbilityUsed equal to the corresponding Wumpus ability in the list.
                    // Set wumpusDamageDealt equal to the Wumpus' intellect.

                    {
  
                    }
                }

                /* 
                    Otherwise, if the action taken is "item1" and the number of available Wumpus abilities is greater than 2, do the following:
                */        

                {
                    // If the third Wumpus ability is equal to "Silver Bullet (30d)",
                    // 1) Set wumpAbilityUsed equal to the corresponding Wumpus ability.
                    // 2) Set wumpusDamageDealt equal to 30.

                    {    

                    }
                } 

                /* 
                    Otherwise, if the action taken is "item2 and the number of available Wumpus abilities is greater than 3, do the following:
                */    

                {

                    // If the fourth Wumpus ability is equal to "Silver Bullet (30d)",
                    // 1) Set wumpAbilityUsed equal to the corresponding Wumpus ability.
                    // 2) Set wumpusDamageDealt equal to 30.

                    {    

                    }                 
                }

                // Otherwise, set wumpusDamageDealt equal to 0.

                {

                }
                
                // If wumpusDamageDealt is equal to 0, print "{wumpus name} is ineffective." to the Console.

                {
                    
                }

                // Otherwise, do the following:
                // 1) Print "{wumpus name} used {wumpAbilityUsed} on Batibat for {wumpusDamageDealt} damage." to the Console.
                // 2) Set Vladimirs's health equal to his health minus the damage dealt by Wumpus.
               
                {

                }
                
                // ********** START OF DO NOT EDIT SECTION 4 ********** //
                if (vladHealth <= 0)
                {
                    Console.WriteLine("Vladimir the Soul Drinker defeated!");
                    Console.WriteLine($"{name} has {health} health and {mana} mana.");
                }
                else 
                {
                    Console.WriteLine($"Vladimir has {vladHealth} health and {vladMana} mana.");

                    if (rd.Next(1,3) == 1)
                    {
                        vladDamageDealt = vladAttackDamage;
                        vladAttackName = "Vampire's Bite";
                    }
                    else
                    {
                        if (vladMana < 10)
                        {
                            Console.WriteLine($"Vladimir does not have enough mana.");
                            vladDamageDealt = 0;
                        }
                        else
                        {
                            vladDamageDealt = vladMagicDamage;
                            vladAttackName = "Sanguine Breath";
                            vladMana = vladMana - 10;
                        }
                    }
                    if (vladDamageDealt == 0)
                    {
                        Console.WriteLine("Vladimir is ineffective.");
                    }   
                    else
                    {
                        Console.WriteLine($"Vladimir used his {vladAttackName} and hit {name} for {vladDamageDealt} damage.");
                        health = health - vladAttackDamage;

                        if (health <= 0)
                        {
                            Console.WriteLine($"{name} defeated by Vladimir the Soul Drinker.  GAME OVER.");
                            lost = true;
                        }
                        else 
                        {
                            Console.WriteLine($"{name} has {health} health and {mana} mana.");
                        }
                        
                    }
                }

            // ********** END OF DO NOT EDIT SECTION 3 ********** //
                
            }  // END WHILE

            // If the value of the variable lost is false, do the following:
            // 1) Set the value on the Yob map where the Wumpus is currently to "xVx".
            // 2) Set the value on the Boss map where the Wumpus is currently to "_".

            {

            }

            // Otherwise, set the value on the Yob map where the Wumpus is currently to "V".

            {

            }

            // Return the value of the variable lost.

        }
        // ############## //
        //   END TASK 8   //
        // ############## //
    
    } // END OF WUMPUS CLASS


    // ********** START OF DO NOT EDIT SECTION 5 ********** //

    class Program
    {    
        static Random rd = new Random();

        static void PlaceBoss(string[,] map, string bossName)
        {
             // Pick a Random location to place the boss. Can't be 0,0
            int row = rd.Next(1, map.GetLength(0));
            int col = rd.Next(1, map.GetLength(1));

            // If that location is not empty
            while(map[row,col] != "_")
            {
                // Try again
                row = rd.Next(1, map.GetLength(0));
                col = rd.Next(1, map.GetLength(1));
            }
            // Once we have an empty location, place the boss there
            map[row, col] = bossName;

        }

        static void Main(string[] args)
        {

            Console.Clear();

            Console.WriteLine("        _________");
            Console.WriteLine("       /         \\");
            Console.WriteLine("   __ /  (.)  (.) \\ __");
            Console.WriteLine(" /_^_/|   v^v^v^v |\\_^_\\");
            Console.WriteLine("      |   ^v^v^v^ |");
            Console.WriteLine("       \\_________/");
            Console.WriteLine(" ");

    // ********** END OF DO NOT EDIT SECTION 5 ********** //


            // ########### //
            //   TASK 2    //
            // ########### //

            /* 
               In this task, you need to declare variables for and get values from the user for the following:
               The Wumpus' name.
               The Wumpus' size -- VALIDATE so that the user MUST enter "small", "medium", or "large".
               The Wumpus' location - represented by an array of 2 values, one for each coordinate.

               You also need to create a new Wumpus using the constructor.
               You also need to get the current location of the Wumpus and store it in your Wumpus' location variable.
             */

            Console.WriteLine("Welcome to Yob's Caves!  Help a Wumpus reclaim what is rightfully his/hers.");
            
            Console.Write("What will you name your Wumpus: ");
            
            Console.Write($"What size will {wName} be (small, medium, large): ");




            // ############## //
            //   END TASK 2   //
            // ############## //

            // ********** START OF DO NOT EDIT SECTION 6 ********** //

            Console.WriteLine("Choose a map size (small, medium, large): ");
            string mapSize = Console.ReadLine();
            int mapBounds;

            if (mapSize == "small")
            {
                mapBounds = 4;
            }
            else if (mapSize == "medium")
            {
                mapBounds = 6;
            }
            else
            {
                mapBounds = 8;
            }
            
            string[,] yob = new string[mapBounds, mapBounds];      // This map is used to keep track of what the user sees when the map is displayed.
            string[,] bossMap = new string[mapBounds, mapBounds];  // This map is used to keep track of the Boss locations.

            for (int i = 0; i < yob.GetLength(0); i++)
            {
                for (int j = 0; j < yob.GetLength(1); j++)
                {
                    yob[i,j] = "_";
                    bossMap[i,j] = "_";
                }
            }

            bool boss1Defeated = false;
            bool boss2Defeated = false;
            bool boss3Defeated = false;

            bool wumpusWon = false;     
            bool gameOver = false;       

            bossMap[0,0] = "Inn";

            PlaceBoss(bossMap, "A"); // Place Boss "1" on the Boss map
            PlaceBoss(bossMap, "B");
            PlaceBoss(bossMap, "V");
            
            for (int i = 0; i < mapBounds / 2 + 3; i++)
            {
                PlaceBoss(bossMap, "S"); // You can place trash enemies too
            }

            yob[0,0] = "W";
            
            // ********** END OF DO NOT EDIT SECTION 6 ********** //


            // ########### //
            //    TASK 9   //
            // ########### //               

            while (wumpusWon == false && gameOver == false)
            {
                // Display the mab of Yob.


                // Move the Wumpus by calling the explore() method.  Catch the result in the spaceStuff variable.
                string spaceStuff; // This variable will hold what is in the Wumpus' current location.
                
                // Clear the Console.


                /* Check to see what is in the Wumpus' current location and respond accordingly. */
                // If what is in the Wumpus' position is the "Inn", call the inn() method.

                {



                }

                // Otherwise, if what is in the Wumpus' position is the "S", call the spookFight() method
                // and catch its return in the variable gameOver.

                {



                }


                /*  
                    Otherwise, if what is in the Wumpus' position is the "A", call the boss1Fight() method
                    and catch its return in the variable gameOver. 
                    
                */

                {
                    
                    
                    // Check whether or not gameOver is equal to false, and if it is, set boss1Defeated equal to true.
                    {

                    }
                }

                {

                }


                /*  
                    Otherwise, if what is in the Wumpus' position is the "B", call the boss2Fight() method
                    and catch its return in the variable gameOver.  
                */
                {

                    
                    // Check whether or not gameOver is equal to false, and if it is, set boss1Defeated equal to true.
                    {

                    }

                }

                /*  
                    Otherwise, if what is in the Wumpus' position is the "V", call the boss3Fight() method
                    and catch its return in the variable gameOver. Use this block to 
                    
                */
                {

                    // Check whether or not gameOver is equal to false, and if it is, set boss1Defeated equal to true.
                    {


                    }

                }

                /*
                    Otherwise, print "Nothing to see here." to the Console.
                */
                {


                }

                /*
                    If all of the bosses have been defeated -- check above, are there variables for these states?
                    Do the following:
                    Clear the Console.
                    Set wumpusWon equal to true.
                    Print to the Console, "{wumpus name} is master of the Yob Caves! Congratulations!".

                */
                {


                }

            // ############## //
            //   END TASK 9  //
            // ############## //     

            } // END MAIN WHILE LOOP
           
        } // END OF MAIN METHOD
                     
    } // END OF PROGRAM CLASS
} // END OF NAMESPACE CLASS

