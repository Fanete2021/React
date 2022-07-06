using API.DAL.Interfaces;
using API.Domain.Entity;
using API.Domain.Responce;
using API.Domain.ViewModels;
using API.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Service.Implementations
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }

        public async Task<BaseResponce<IEnumerable<Genre>>> GetGenresAsync()
        {
            var baseResponse = new BaseResponce<IEnumerable<Genre>>();
            try
            {
                var genres = await genreRepository.SelectAsync();

                if (genres.Count == 0)
                {
                    baseResponse.Data = new List<Genre>();
                } baseResponse.Data = genres;

                baseResponse.StatusCode = Domain.Enum.StatusCode.OK;

                return baseResponse;
            }
            catch(Exception ex)
            {
                return new BaseResponce<IEnumerable<Genre>>()
                {
                    DescriptionError = $"[GetGenresAsync]: {ex.Message}",
                    StatusCode = Domain.Enum.StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponce<Genre>> GetGenreAsync(int id)
        {
            var baseResponse = new BaseResponce<Genre>();

            try
            {
                var genre = await genreRepository.GetAsync(id);

                if(genre == null)
                {
                    baseResponse.DescriptionError = "Genre not found";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.GenreNotFound;

                    return baseResponse;
                }

                baseResponse.Data = genre;
                baseResponse.StatusCode = Domain.Enum.StatusCode.OK;

                return baseResponse;
            }
            catch(Exception ex)
            {
                return new BaseResponce<Genre>()
                {
                    DescriptionError = $"[GetGenreAsync]: {ex.Message}",
                    StatusCode = Domain.Enum.StatusCode.InternalServerError
                };
            }
        }
    }
}
