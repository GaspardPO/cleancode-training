using System.Collections.Generic;
using System.Linq;

namespace SOLID.OpenClosePrinciple;

public class ShortestItineraryPreference : IItineraryPreference
{
    public Itinerary GetRelatedItinerary(IEnumerable<Itinerary> itinerariesFor)
    {
        return itinerariesFor.OrderBy(i => i.Duration).FirstOrDefault();
    }
}
