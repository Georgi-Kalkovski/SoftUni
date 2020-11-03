﻿namespace CinemaWorld.Services.Data.Contracts
{
    using System.Threading.Tasks;

    public interface ICommentsService
    {
        Task Create(int movieId, string userId, string content, int? parentId = null);

        Task<bool> IsInMovieId(int commentId, int movieId);
    }
}
