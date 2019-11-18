using System;

namespace Example_Projectile_Motion_for_Lincoln
{
    public class Projectile
    {
        public double x;
        public double y; // Self explanatory coordinates //
        const double timeForImpulse = 0.5; // Used as time in Impulse = Force * Time = Change in Momentum //// In a real world setting this would be the time for which the shell is under the force exerted by the ignition of the round //
        const double timeForStep = 1.0; // Constant that dictates how far forward the simulation models each step //
        const double g = -9.81; // Gravitational Constant //
        protected double lateralForce;
        protected double verticalForce; // Component forces that are used to calculate initial component velocities //
        public double lateralVelocity;
        public double verticalVelocity; // Self Explanatory //
        protected double verticalAcceleration; // I've kept this seperate from g in case you want to include air resistance in the model //
        protected int mass;
        protected int damage; // Attributes to be modified by chld classes //
        public double time = 0; // Attribute to keep up with how long the simulation has been running //

        private double calcLateralForce(double force, double bearing)
        {
            return force * (Math.Cos(bearing));
        }

        private double calcVerticalForce(double force, double bearing)
        {
            return force * (Math.Sin(bearing));
        }
        // Both of the above methods are used to split the resultabt force given into its component forces //

        private double calcInitialVerticalVelocity()
        {
            return ((this.verticalForce * timeForImpulse) / this.mass);
        }

        private double calcInitialLateralVelocity()
        {
            return ((this.lateralForce * timeForImpulse) / this.mass);
        }
        // Both methods use Impulse = Force * Time = Change in Momentum = Mass(Final Velocity - Initial Velocity //
        // As initial Velocity is zero we can rearrange for Final Velocity //
        // Final Velocity = (Force * Time)/Mass //
        // As impulse is a vector value we have to do this seperatley for the lateral force and the vertical force //
        // You can try and do these together but ive split them up just to make it a bit more obvious as to whats happening //

        public void stepOneSec()
        {
            this.x = this.x + (this.lateralVelocity * timeForStep);
            this.y = this.y + (this.verticalVelocity * timeForStep);
            // New coordinates can be calculated using Distance  = Speed * Time //
            // When acceleration is concerned, i.e. for the vertical height component, this can be done using your SUVAT equations but this method is somewhat suitable for an approximation while the stepping time is small //

            this.verticalVelocity = this.verticalVelocity + (this.verticalAcceleration * timeForStep);
            // Simple use of Velocity = Acceleration * Time //

            this.time = this.time + timeForStep;
            // Incrementation of how long the simulation has been running //
        }
        protected void instantiate(double xPosition, double yPosition, double force, double bearing)
        {
            this.x = xPosition;
            this.y = yPosition;
            this.lateralForce = calcLateralForce(force, bearing);
            this.verticalForce = calcVerticalForce(force, bearing);
            this.verticalVelocity = calcInitialVerticalVelocity();
            this.lateralVelocity = calcInitialLateralVelocity();
            this.verticalAcceleration = g;
        }
        // Creation of a projectile and any projectile classes that are inherited from this //


    }
    public class tankShell : Projectile
    {
        public tankShell(double xPosition, double yPosition, double force, double bearing)
        {
            this.mass = 100;
            this.damage = 500;
            instantiate(xPosition, yPosition, force,bearing);
        }
        // When defining a new projectile type you just need to set the unique attributes that are attached to that projectile //
        // I've added the mass and the damage but you will probably also need to attach the image sprite for each specific projectile //
    }
    public class lightShell : Projectile
    {
        public lightShell(double xPosition, double yPosition, double force, double bearing)
        {
            this.mass = 50;
            this.damage = 250;
            instantiate(xPosition, yPosition, force, bearing);
        }
    }
    public class heavyShell : Projectile
    {
        public heavyShell(double xPosition, double yPosition, double force, double bearing)
        {
            this.mass = 150;
            this.damage = 750;
            instantiate(xPosition, yPosition, force, bearing);
        }
    }
    // I've added three example projectile types here but you can add as many as you want //
}

