﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

#if MONGO_DB
namespace DevMentor.Context.MongoDb.Entity
#else
namespace DevMentor.Context.Entity
#endif
{
    public abstract class BaseEntity
    {
        private bool isDirty;

        public BaseEntity()
        {
            var date = DateTime.Now;
            Id = Guid.NewGuid();
            Created = date;
            Updated = date;
        }
        [Key]
        public Guid Id { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        [NotMapped]
        [XmlIgnore]
        public virtual bool IsDirty { get { return isDirty; } }


        [XmlIgnore]
        [NotMapped]
        public bool IsNew { get { return Created == Updated; } }

        public void MakeDirty(bool dirty = false)
        {
            Updated = DateTime.Now;
            isDirty = dirty;
        }
    }
}
