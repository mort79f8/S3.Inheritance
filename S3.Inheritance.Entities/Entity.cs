using System;
using System.Collections.Generic;
using System.Text;

namespace S3.Inheritance.Entities
{
    public abstract class Entity
    {
        protected int id;

        public int Id
        {
            get => id;
            set
            {
                id = value;
            }
        }

        public Entity()
        {

        }

        public Entity(int id)
        {
            Id = id;
        }
    }
}
