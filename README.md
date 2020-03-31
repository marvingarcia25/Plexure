# Plexure


Exercise # 4 Answers
- There is no Logger. A very important missing part.
- It would be better if there is a consistency with the methods. If all could be asynchronous methods, it would be better for maintenance.
- Dependency Injection. SQL Agent Store and GoogleMapDistanceCalculator should be injected.
- Instantiating the dependency like this is not a good idea.  Configurations such as the database connection and google map api key should be set at the constructor of each class and must not be exposed here.
- (Interface Segregation principle)ItineraryManager should be using an Interface 
- CalculateAirlinePrices has a tendency to return a wrong Exception. If itinerary is null, it should at least return a KeyNotFoundException.
- CalculateAirlinePrices calls the _dataStore.GetItinaryAsync using .Result. It would be better if it is called using await.
- For CalculateAirlinePrices, instead of using foreach to add the qoutes, results.AddRange can be used. This will be better for performance
- _dataStore.GetItinaryAsync has a wrong spelling. Wrong spelling is a sign of unprofessionally written code. 
- CalculateTotalTravelDistanceAsync call to _distanceCalculator.GetDistanceAsync would be better if await is used. 
- For CalculateTotalTravelDistanceAsync, instead of InvalidOperationException, KeyNotFoundException is better used as a result of the null itinerary.
- For CalculateTotalTravelDistanceAsync, result += can be used instead of the existing result = result + ..
- FindAgent is not following Single Responsibility principle.  Finding an agent and updating an agent should be in a separate methods. 
- For FindAgent, instead of returning null, it would be better if an exception can be raised.
