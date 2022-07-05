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
    public class ActorService : IActorService
    {
        private readonly IActorRepository actorRepository;

        public ActorService(IActorRepository actorRepository)
        {
            this.actorRepository = actorRepository;
        }

        public async Task<BaseResponce<Actor>> GetLastActorAsync()
        {
            var baseResponse = new BaseResponce<Actor>();
            try
            {
                var actor = await actorRepository.GetLastAsync();

                if (actor == null)
                {
                    baseResponse.DescriptionError = "Actor not found";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.ActorNotFound;

                    return baseResponse;
                }

                baseResponse.Data = actor;
                baseResponse.StatusCode = Domain.Enum.StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponce<Actor>()
                {
                    DescriptionError = $"[GetLastActorAsync]: {ex.Message}",
                    StatusCode = Domain.Enum.StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponce<Actor>> GetActorAsync(int id)
        {
            var baseResponse = new BaseResponce<Actor>();

            try
            {
                var actor = await actorRepository.GetAsync(id);

                if(actor == null)
                {
                    baseResponse.DescriptionError = "Actor not found";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.ActorNotFound;

                    return baseResponse;
                }

                baseResponse.Data = actor;
                baseResponse.StatusCode = Domain.Enum.StatusCode.OK;

                return baseResponse;
            }
            catch(Exception ex)
            {
                return new BaseResponce<Actor>()
                {
                    DescriptionError = $"[GetActorAsync]: {ex.Message}",
                    StatusCode = Domain.Enum.StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponce<IEnumerable<Actor>>> GetActorAsync(string substr, int limit, int page, int[] bannedId)
        {
            var baseResponse = new BaseResponce<IEnumerable<Actor>>();

            try
            {
                var actors = await actorRepository.GetAsync(substr, limit, page, bannedId);

                if (actors.Count == 0)
                {
                    baseResponse.Data = new List<Actor>();
                } else baseResponse.Data = actors;

                baseResponse.StatusCode = Domain.Enum.StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponce<IEnumerable<Actor>>()
                {
                    DescriptionError = $"[GetActorAsync]: {ex.Message}",
                    StatusCode = Domain.Enum.StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponce<ActorViewModel>> CreateActorAsync(ActorViewModel model)
        {
            var baseResponse = new BaseResponce<ActorViewModel>();

            try
            {
                var actor = new Actor
                {
                    Name = model.Name,
                    Surname = model.Surname,
                };

                await actorRepository.CreateAsync(actor);

                baseResponse.Data = model;
                baseResponse.StatusCode = Domain.Enum.StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponce<ActorViewModel>()
                {
                    DescriptionError = $"[CreateActorAsync]: {ex.Message}",
                    StatusCode = Domain.Enum.StatusCode.DataWithErrors
                };
            }
        }

        public async Task<BaseResponce<bool>> DeleteActorAsync(int id)
        {
            var baseResponse = new BaseResponce<bool>();

            try
            {
                var movie = await actorRepository.GetAsync(id);

                if (movie == null)
                {
                    baseResponse.DescriptionError = "Actor not found";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.ActorNotFound;

                    return baseResponse;
                }

                await actorRepository.DeleteAsync(movie);

                baseResponse.Data = true;
                baseResponse.StatusCode = Domain.Enum.StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponce<bool>()
                {
                    Data = false,
                    DescriptionError = $"[ActorMovieAsync]: {ex.Message}",
                    StatusCode = Domain.Enum.StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponce<Actor>> EditActorAsync(int id, ActorViewModel model)
        {
            var baseResponse = new BaseResponce<Actor>();

            try
            {
                var actor = await actorRepository.GetAsync(id);

                if (actor == null)
                {
                    baseResponse.DescriptionError = "Actor not found";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.ActorNotFound;

                    return baseResponse;
                }

                actor.Name = model.Name;
                actor.Surname = model.Surname;

                await actorRepository.UpdateAsync(actor);

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponce<Actor>()
                {
                    DescriptionError = $"[EditMovieAsync]: {ex.Message}",
                    StatusCode = Domain.Enum.StatusCode.DataWithErrors
                };
            }
        }

        public async Task<BaseResponce<int>> GetCountActorsAsync()
        {
            var baseResponse = new BaseResponce<int>();

            try
            {
                var count = await actorRepository.GetCountAsync();

                baseResponse.Data = count;
                baseResponse.StatusCode = Domain.Enum.StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponce<int>()
                {
                    DescriptionError = $"[GetCountActorsAsync]: {ex.Message}",
                    StatusCode = Domain.Enum.StatusCode.InternalServerError
                };
            }
        }
    }
}
