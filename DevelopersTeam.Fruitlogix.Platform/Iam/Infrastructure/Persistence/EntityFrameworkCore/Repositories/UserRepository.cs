using DevelopersTeam.Fruitlogix.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using DevelopersTeam.Fruitlogix.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;
using DevelopersTeam.Fruitlogix.Platform.Iam.Domain.Model.Aggregates;
using DevelopersTeam.Fruitlogix.Platform.Iam.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevelopersTeam.Fruitlogix.Platform.Iam.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

/**
 * <summary>
 *     The user repository
 * </summary>
 * <remarks>
 *     This repository is used to manage users
 * </remarks>
 */
public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
{
    /**
     * <summary>
     *     Find a user by username
     * </summary>
     * <param name="username">The username to search</param>
     * <param name="cancellationToken">The cancellation token</param>
     * <returns>The user</returns>
     */
    public async Task<User?> FindByUsernameAsync(string username, CancellationToken cancellationToken)
    {
        return await Context.Set<User>().FirstOrDefaultAsync(user => user.Username.Equals(username), cancellationToken);
    }

    /**
     * <summary>
     *     Check if a user exists by username
     * </summary>
     * <param name="username">The username to search</param>
     * <param name="cancellationToken">The cancellation token</param>
     * <returns>True if the user exists, false otherwise</returns>
     */
    public async Task<bool> ExistsByUsernameAsync(string username, CancellationToken cancellationToken)
    {
        return await Context.Set<User>().AnyAsync(user => user.Username.Equals(username), cancellationToken);
    }
}