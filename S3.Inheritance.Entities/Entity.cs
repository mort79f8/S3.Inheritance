using System;
using System.Collections.Generic;
using System.Text;

namespace S3.Inheritance.Entities
{
    public abstract class Entity
    {
        #region Fields
        protected int id;
        #endregion

        #region Properties
        public int Id
        {
            get => id;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Id is 0. To create new account use the other constructors.");
                }
                else
                {
                    id = value;
                }
                
            }
        }
        #endregion

        #region Constructors
        public Entity()
        {

        }

        public Entity(int id)
        {
            Id = id;
        }
        #endregion
    }
}
