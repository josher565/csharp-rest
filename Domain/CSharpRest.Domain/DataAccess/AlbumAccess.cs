using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRest.Domain.DataAccess
{
    public class AlbumAccess : DbContext
    {
        public AlbumAccess() : base("MusicDb") {
            var objectContext = ((IObjectContextAdapter)this).ObjectContext;      
        }

        public virtual DbSet<Data.Album> Albums { get; set; }

        public override int SaveChanges()
        {
            //credit https://stackoverflow.com/questions/3879011/entity-framework-sql2008-how-to-automatically-update-lastmodified-fields-for-e

            ObjectContext context = ((IObjectContextAdapter)this).ObjectContext;
            IEnumerable<ObjectStateEntry> objectStateEntries =
                from e in context.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified)
                where
                    e.IsRelationship == false &&
                    e.Entity != null &&
                    typeof(Data.BaseModel).IsAssignableFrom(e.Entity.GetType())
                select e;

            var currentTime = DateTime.Now;

            foreach (var entry in objectStateEntries)
            {
                var entityBase = entry.Entity as Data.BaseModel;

                if (entry.State == EntityState.Added)
                {
                    entityBase.Created = currentTime;
                }

                entityBase.LastModified = currentTime;
            }
            return base.SaveChanges();
        }
    }
}
