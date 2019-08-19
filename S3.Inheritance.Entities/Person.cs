using System;
using System.Collections.Generic;
using System.Text;

namespace S3.Inheritance.Entities
{
    public class Person : Entity
    {

        #region Fields
        protected string firstName;
        protected string lastName;
        protected string ssn;

        #endregion

        #region Constructor
        public Person(int id, string firstName, string lastName, string ssn)
            :base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Ssn = ssn;
        }

        public Person(string firstName, string lastName, string ssn)
            :this(default, firstName, lastName, ssn)
        {
            
        }

        public Person()
        {

        }

        #endregion

        #region Properties
        protected string FirstName { get => firstName; set => firstName = value; }
        protected string LastName { get => lastName; set => lastName = value; }
        protected string Ssn { get => ssn; set => ssn = value; }
        #endregion

    }
}
