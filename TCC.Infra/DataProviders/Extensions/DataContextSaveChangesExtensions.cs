using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TCC.Domain.Abstract;

namespace TCC.Infra.DataProviders.Extensions
{
    public static class DataContextSaveChangesExtensions
    {
        public static void AddAuditory(this DataContext context)
        {
            context.ChangeTracker.DetectChanges();

            ApplyOnAddedEntityes(context);
            ApplyOnModifiedEntityes(context);
        }

        private static void ApplyOnAddedEntityes(DataContext context)
        {
            var entities = context.ChangeTracker.Entries()
                .Where(t => t.State == EntityState.Added)
                .Select(t => t.Entity)
                .ToArray();

            foreach (var entity in entities)
            {
                if (entity is IAuditoria)
                {
                    var track = entity as IAuditoria;
                    track.CriandoEm = DateTime.Now;
                }
            }
        }

        private static void ApplyOnModifiedEntityes(DataContext context)
        {
            var entities = context.ChangeTracker.Entries()
                .Where(t => t.State == EntityState.Modified)
                .Select(t => t.Entity)
                .ToArray();

            foreach (var entity in entities)
            {
                if (entity is IAuditoria)
                {
                    var track = entity as IAuditoria;
                    track.CriandoEm = DateTime.Now;
                }
            }
        }
    }
}
