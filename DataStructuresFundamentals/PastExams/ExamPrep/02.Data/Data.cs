namespace _02.Data
{
    using _02.Data.Interfaces;
    using _02.Data.Models;
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class Data : IRepository
    {
        private OrderedBag<IEntity> entities;

        public Data()
        {
            this.entities = new OrderedBag<IEntity>();
        }

        public Data(Data copy)
        {
            this.entities = copy.entities;
        }

        public int Size => this.entities.Count;

        public void Add(IEntity entity)
        {
            this.entities.Add(entity);
            var parentNode = GetById((int)entity.ParentId);

            if (parentNode != null)
            {
                parentNode.Children.Add(entity);
            }
        }

        public IRepository Copy()
        {
            Data copy = (Data)this.MemberwiseClone();
            return new Data(copy);
        }

        public IEntity DequeueMostRecent()
        {
            EnsureNotEmpty();
            return this.entities.RemoveFirst();
        }

        public List<IEntity> GetAll()
        {
            return new List<IEntity>(this.entities);
        }

        public List<IEntity> GetAllByType(string type)
        {
            bool isValidType =
                type == typeof(Invoice).Name
                || type == typeof(StoreClient).Name
                || type == typeof(User).Name;

            var result = new List<IEntity>(Size);

            if (!isValidType)
            {
                throw new InvalidOperationException("Invalid type: " + type);
            }

            foreach (var entity in this.entities)
            {
                if (entity.GetType().Name.Equals(type))
                {
                    result.Add(entity);
                }
            }

            return result;
        }

        public IEntity GetById(int id)
        {
            if (id < 0 || id > Size)
            {
                return null;
            }

            return this.entities[Size - 1 - id];
        }

        public List<IEntity> GetByParentId(int parentId)
        {
            var parentNode = GetById(parentId);

            if (parentNode == null)
            {
                return new List<IEntity>();
            }

            return parentNode.Children;
        }

        public IEntity PeekMostRecent()
        {
            EnsureNotEmpty();

            return this.entities.GetFirst();
        }

        private void EnsureNotEmpty()
        {
            if (Size < 1)
            {
                throw new InvalidOperationException("Operation on empty Data");
            }
        }
    }
}
