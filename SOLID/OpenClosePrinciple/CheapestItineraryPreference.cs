using System.Collections.Generic;
using System.Linq;

namespace SOLID.OpenClosePrinciple;

public class CheapestItineraryPreference : IItineraryPreference
{

    public Itinerary GetRelatedItinerary(IEnumerable<Itinerary> itinerariesFor)
    {
        return itinerariesFor.OrderBy(i => i.Cost).FirstOrDefault();
    }
}
