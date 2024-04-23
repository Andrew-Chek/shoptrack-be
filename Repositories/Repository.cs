using Microsoft.EntityFrameworkCore;
using shoptrack_be.Models;

namespace shoptrack_be.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly ShopTrackDbContext _context;

    public Repository(ShopTrackDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(int id, TEntity entity)
    {
        // Retrieve the entity from the database by its ID
        var existingEntity = await _context.Set<TEntity>().FindAsync(id);

        // If the entity with the given ID doesn't exist, return
        if (existingEntity == null)
        {
            throw new ArgumentException($"Entity with ID {id} not found.");
        }

        // Update the properties of the existing entity with the values from the provided entity
        foreach (var property in _context.Entry(existingEntity).Properties)
        {
            // Exclude the ID property from being updated
            if (property.Metadata.Name != "UserId")
            {
                property.CurrentValue = _context.Entry(entity).Property(property.Metadata.Name).CurrentValue;
            }
        }

        // Save the changes to the database
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}
