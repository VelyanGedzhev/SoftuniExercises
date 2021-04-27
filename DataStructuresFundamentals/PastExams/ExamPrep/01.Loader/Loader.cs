namespace _01.Loader
{
    using _01.Loader.Interfaces;
    using _01.Loader.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Loader : IBuffer
    {
        private List<IEntity> entities;

        public Loader()
        {
            this.entities = new List<IEntity>();
        }

        public int EntitiesCount => this.entities.Count;

        public void Add(IEntity entity)
        {
            this.entities.Add(entity);
        }

        public void Clear()
        {
            this.entities.Clear();
        }

        public bool Contains(IEntity entity)
        {
            return GetById(entity.Id) != null;
        }

        public IEntity Extract(int id)
        {
            var entity = GetById(id);

            if (entity != null)
            {
                this.entities.Remove(entity);
            }

            return entity;
        }

        public IEntity Find(IEntity entity)
        {
            return GetById(entity.Id);
        }

        public List<IEntity> GetAll()
        {
            return new List<IEntity>(this.entities);
        }

        public void RemoveSold()
        {
            this.entities.RemoveAll(e => e.Status == BaseEntityStatus.Sold);
        }

        public void Replace(IEntity oldEntity, IEntity newEntity)
        {
            int index = this.entities.IndexOf(oldEntity);
            ValidateEntity(index);
            this.entities[index] = newEntity;
        }


        public List<IEntity> RetainAllFromTo(BaseEntityStatus lowerBound, BaseEntityStatus upperBound)
        {
            var result = new List<IEntity>(this.entities.Count);

            foreach (var entity in this.entities)
            {
                if ((int)entity.Status >= (int)lowerBound 
                    && (int)entity.Status <= (int)upperBound)
                {
                    result.Add(entity);
                }
            }

            return result;
        }

        public void Swap(IEntity first, IEntity second)
        {
            int firstIndex = this.entities.IndexOf(first);
            ValidateEntity(firstIndex);

            int secondIndex = this.entities.IndexOf(second);
            ValidateEntity(secondIndex);

            var temp = this.entities[firstIndex];
            this.entities[firstIndex] = this.entities[secondIndex];
            this.entities[secondIndex] = temp;
        }

        public IEntity[] ToArray()
        {
            return this.entities.ToArray();
        }

        public void UpdateAll(BaseEntityStatus oldStatus, BaseEntityStatus newStatus)
        {
            foreach (var entity in this.entities)
            {
                if (entity.Status == oldStatus)
                {
                    entity.Status = newStatus;
                }
            }
        }


        public IEnumerator<IEntity> GetEnumerator()
        {
            //return this.entities.GetEnumerator();
            for (int i = 0; i < this.entities.Count; i++)
            {
                yield return this.entities[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEntity GetById(int id)
        {
            foreach (var entity in entities)
            {
                if (entity.Id == id)
                {
                    return entity;
                }
            }

            return null;
        }

        private void ValidateEntity(int index)
        {
            if (index == -1)
            {
                throw new InvalidOperationException("Entity not found");
            }
        }
    }
}
