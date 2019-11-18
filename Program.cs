using System;

// Hey Lincoln, This is the way I would set up your projectile motion if your a bit stuck in what to do with the mechanics //
// This code file contains how to use the projectile classes i defined and the other contains the classes themselves with all the mechanics calculations //
// I've included a brief explanation of each calculation in case your unsure why I've done something cause i cant remember what we've done in physics and further maths that you havent done in normal maths //
// If you've got any questions just give me a shout //


namespace Example_Projectile_Motion_for_Lincoln
{
    class Program
    {
        static void Main(string[] args)
        {
            tankShell tShell = new tankShell(50.0, 50.0, 5000, Math.PI / 6);
            lightShell lShell = new lightShell(40.0, 40.0, 4000, Math.PI / 4);
            heavyShell hShell = new heavyShell(30.0, 30.0, 3000, Math.PI / 4);
            // Defintion of each type of projectile //
            // Pass in the intial X Position, Y Position, Force Applied and the angle that force is applied on //




            while (tShell.y > 0)
            {
                Console.WriteLine("X Position: {0}\nY Position: {1}\nLateral Velocity: {2} Vertical Velocity: {3}\nTime: {4}", tShell.x, tShell.y, tShell.lateralVelocity, tShell.verticalVelocity, tShell.time);
                tShell.stepOneSec();
                // This procedure will change the projectiles motion and location to what it would be in a seconds time //
                // There is a constant you can change in the projectile class to alter this if you want to model the projectile every 2 seconds persay //
            }
            // This is the best way i could model your game loop //
            // This will just keep modelling the projectile until its Y Position is less than 0, i.e. it hit the ground //
            // Your using monogame so i would just step the projectile at the end of each iteration of the main game loop //
        }
    }
}
