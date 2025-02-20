using praktika1.validators;
using System;


namespace praktika1
{
    /// <summary>
    /// Class for storing info about a human
    /// </summary>
    public class Human
    {
        /// <summary>
        /// Gets or sets the height of the human.
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Gets or sets the weight of the human.
        /// </summary>
        public int Weight { get; private set; }

        /// <summary>
        /// Gets or sets the first name of the human.
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// Gets or sets the last name of the human.
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// Gets the birthday of the human.
        /// </summary>
        public DateTime Birthday { get; }

        /// <summary>
        /// Gets the full name of the human (first name + last name).
        /// </summary>
        public string FullName
        {
            get
            {
                return FirstName + ' ' + LastName;
            }
        }

        /// <summary>
        /// Calculates and gets the age of the human.
        /// </summary>
        public int Age
        {
            get
            {
                return (DateTime.Now - Birthday).Days / 365;
            }
        }

        /// <summary>
        /// Sets the height of the human, but only if it's not below zero.
        /// </summary>
        /// <param name="height">The new height.</param>
        public void SetHeight(int height)
        {
            this.Height = !IntValidator.IsBelowZero(height) ? height : throw new ArgumentOutOfRangeException("Рост ниже нуля");
        }

        /// <summary>
        /// Initializes a new instance of the Human class with given parameters.
        /// </summary>
        /// <param name="height">The initial height.</param>
        /// <param name="weight">The initial weight.</param>
        /// <param name="firstname">The initial first name.</param>
        /// <param name="lastname">The initial last name.</param>
        /// <param name="birthday">The initial birthday.</param>
        public Human(int height, int weight, string firstname, string
    lastname, DateTime birthday)
        {
            if (IntValidator.IsBelowZero(height))
            {
                throw new ArgumentOutOfRangeException("Рост ниже нуля");
            }
            if (IntValidator.IsBelowZero(weight))
            {
                throw new ArgumentOutOfRangeException("Вес ниже нуля");
            }
            if (!StringValidator.IsNotEmpty(firstname))
            {
                throw new ArgumentOutOfRangeException("Имя не может быть пустым");
            }
            if (!StringValidator.IsNotEmpty(lastname))
            {
                throw new ArgumentOutOfRangeException("Фамилия не может быть пустой");
            }

            Height = height;
            Weight = weight;
            FirstName = firstname;
            LastName = lastname;
            Birthday = birthday;
        }
    }

}
