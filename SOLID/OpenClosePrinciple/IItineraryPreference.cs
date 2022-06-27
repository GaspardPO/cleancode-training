using System.Collections.Generic;

namespace SOLID.OpenClosePrinciple;

public interface IItineraryPreference
{
    Itinerary GetRelatedItinerary(IEnumerable<Itinerary> itinerariesFor);
}
