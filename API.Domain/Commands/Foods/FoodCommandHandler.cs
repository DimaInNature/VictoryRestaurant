using API.Services.Abstract.Foods;
using MediatR;
using System.ComponentModel.DataAnnotations;
using VictoryRestaurant.Entities;

namespace API.Domain.Commands.Foods;

public static class AddFood
{
    public record Command(FoodEntity Food) : IRequest<Response>;

    public class Validator
    {
        private readonly IFoodFacadeService _repository;

        public Validator(IFoodFacadeService repository)
        {
            _repository = repository;
        }

        public async Task<ValidationResult> Validate(Command request)
        {
            return ValidationResult.Success;
        }
    }

    public class Handler : IRequestHandler<Command, Response>
    {
        private readonly IFoodFacadeService _repository;

        public Handler(IFoodFacadeService repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
        {
            await _repository.InsertFoodAsync(request.Food);

            await _repository.SaveAsync();

            return new Response { Id = 10 };
        }
    }

    // Response
    public record Response
    {
        public int Id { get; init; }
    }

}