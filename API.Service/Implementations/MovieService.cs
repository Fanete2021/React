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
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public async Task<BaseResponce<IEnumerable<Movie>>> GetMoviesAsync(int[] idActors, int[] idGenres, string title)
        {
            var baseResponse = new BaseResponce<IEnumerable<Movie>>();
            try
            {
                var movies = await movieRepository.SelectAsync(idActors, idGenres, title);

                if (movies.Count == 0)
                {
                    baseResponse.Data = new List<Movie>();
                } else baseResponse.Data = movies;

                baseResponse.StatusCode = Domain.Enum.StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponce<IEnumerable<Movie>>()
                {
                    DescriptionError = $"[GetMovies]: {ex.Message}",
                    StatusCode = Domain.Enum.StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponce<Movie>> GetMovieAsync(int id)
        {
            var baseResponse = new BaseResponce<Movie>();

            try
            {
                var movie = await movieRepository.GetAsync(id);

                if(movie == null)
                {
                    baseResponse.DescriptionError = "Movie not found";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.MovieNotFound;

                    return baseResponse;
                }

                baseResponse.Data = movie;
                baseResponse.StatusCode = Domain.Enum.StatusCode.OK;

                return baseResponse;
            }
            catch(Exception ex)
            {
                return new BaseResponce<Movie>()
                {
                    DescriptionError = $"[GetMovie]: {ex.Message}",
                    StatusCode = Domain.Enum.StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponce<Movie>> GetLastMovieAsync()
        {
            var baseResponse = new BaseResponce<Movie>();
            try
            {
                var movie = await movieRepository.GetLastAsync();

                if (movie == null)
                {
                    baseResponse.DescriptionError = "Movie not found";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.MovieNotFound;

                    return baseResponse;
                }

                baseResponse.Data = movie;
                baseResponse.StatusCode = Domain.Enum.StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponce<Movie>()
                {
                    DescriptionError = $"[GetLastMovieAsync]: {ex.Message}",
                    StatusCode = Domain.Enum.StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponce<MovieViewModel>> CreateMovieAsync(MovieViewModel model)
        {
            var baseResponse = new BaseResponce<MovieViewModel>();

            try
            {
                var movie = new Movie
                {
                    Title = model.Title,
                    Description = model.Description,
                    PremiereYear = model.PremiereYear
                };

                await movieRepository.CreateAsync(movie);

                baseResponse.Data = model;
                baseResponse.StatusCode = Domain.Enum.StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponce<MovieViewModel>()
                {
                    DescriptionError = $"[CreateMovieAsync]: {ex.Message}",
                    StatusCode = Domain.Enum.StatusCode.DataWithErrors
                };
            }
        }

        public async Task<BaseResponce<MovieGenre>> AddGenreAsync(MovieGenre model)
        {
            var baseResponse = new BaseResponce<MovieGenre>();

            try
            {
                var movie = new MovieGenre
                {
                    MovieId = model.MovieId,
                    GenreId = model.GenreId
                };

                await movieRepository.AddGenreAsync(movie);

                baseResponse.Data = model;
                baseResponse.StatusCode = Domain.Enum.StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponce<MovieGenre>()
                {
                    DescriptionError = $"[AddGenreAsync]: {ex.Message}",
                    StatusCode = Domain.Enum.StatusCode.DataWithErrors
                };
            }
        }
        public async Task<BaseResponce<MovieActor>> AddActorAsync(MovieActor model)
        {
            var baseResponse = new BaseResponce<MovieActor>();

            try
            {
                var movie = new MovieActor
                {
                    MovieId = model.MovieId,
                    ActorId = model.ActorId
                };

                await movieRepository.AddActorAsync(movie);

                baseResponse.Data = model;
                baseResponse.StatusCode = Domain.Enum.StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponce<MovieActor>()
                {
                    DescriptionError = $"[AddActorAsync]: {ex.Message}",
                    StatusCode = Domain.Enum.StatusCode.DataWithErrors
                };
            }
        }

        public async Task<BaseResponce<bool>> DeleteMovieAsync(int id)
        {
            var baseResponse = new BaseResponce<bool>();

            try
            {
                var movie = await movieRepository.GetAsync(id);

                if (movie == null)
                {
                    baseResponse.DescriptionError = "Movie not found";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.MovieNotFound;

                    return baseResponse;
                }

                await movieRepository.DeleteAsync(movie);

                baseResponse.Data = true;
                baseResponse.StatusCode = Domain.Enum.StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponce<bool>()
                {
                    Data = false,
                    DescriptionError = $"[DeleteMovieAsync]: {ex.Message}",
                    StatusCode = Domain.Enum.StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponce<Movie>> EditMovieAsync(int id, MovieViewModel model)
        {
            var baseResponse = new BaseResponce<Movie>();

            try
            {
                var movie = await movieRepository.GetAsync(id);

                if (movie == null)
                {
                    baseResponse.DescriptionError = "Movie not found";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.MovieNotFound;

                    return baseResponse;
                }

                movie.Title = model.Title;
                movie.Description = model.Description;
                movie.PremiereYear = model.PremiereYear;

                await movieRepository.UpdateAsync(movie);

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponce<Movie>()
                {
                    DescriptionError = $"[EditMovieAsync]: {ex.Message}",
                    StatusCode = Domain.Enum.StatusCode.DataWithErrors
                };
            }
        }

        public async Task<BaseResponce<IEnumerable<Actor>>> GetMovieActorsAsync(int movieId)
        {
            var baseResponse = new BaseResponce<IEnumerable<Actor>>();
            try
            {
                var actors = await movieRepository.GetActorsAsync(movieId);

                if (actors.Count == 0)
                {
                    baseResponse.Data = new List<Actor>();
                }
                else baseResponse.Data = actors;


                baseResponse.Data = actors;
                baseResponse.StatusCode = Domain.Enum.StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponce<IEnumerable<Actor>>()
                {
                    DescriptionError = $"[GetMovieActorsAsync]: {ex.Message}",
                    StatusCode = Domain.Enum.StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponce<IEnumerable<Genre>>> GetMovieGenresAsync(int movieId)
        {
            var baseResponse = new BaseResponce<IEnumerable<Genre>>();
            try
            {
                var genres = await movieRepository.GetGenresAsync(movieId);

                if (genres.Count == 0)
                {
                    baseResponse.Data = new List<Genre>();
                } else baseResponse.Data = genres;

                baseResponse.StatusCode = Domain.Enum.StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponce<IEnumerable<Genre>>()
                {
                    DescriptionError = $"[GetMovieGenresAsync]: {ex.Message}",
                    StatusCode = Domain.Enum.StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponce<int>> GetCountMoviesAsync()
        {
            var baseResponse = new BaseResponce<int>();

            try
            {
                var count = await movieRepository.GetCountAsync();

                baseResponse.Data = count;
                baseResponse.StatusCode = Domain.Enum.StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponce<int>()
                {
                    DescriptionError = $"[GetCountMoviesAsync]: {ex.Message}",
                    StatusCode = Domain.Enum.StatusCode.InternalServerError
                };
            }
        }
    }
}
