using Microsoft.Extensions.Primitives;

namespace CarsApi
{

    public record CarDto(Guid Id, string Name, string Description, DateTime DateTime); // minden adat

    public record CreatedCarDto(string Name, string Description); // adat letrehoz

    public record UpdateCarDto (string Name, string Description); // adat frissit

}
