# Plexure
Exercise # 1 Answer
- 
- The source code for Exercise 1 can be found inside Plexure/PlexureTechnicalExam/PlexureTechnicalExam/. I created a console app that calls a facade. The main logic can be found inside Plexure/PlexureTechnicalExam/PlexureTechnicalExam/Facades/Implementation/ResourcesFacade.cs


Exercise # 2 Answer
- 
I choose to make my data model as a mongodb. I created 3 main collections, namely, Coupon, Redemption and UserCouponRedemptions

- Coupon - Collection of all the coupons. You might notice that I added the total_redemption_count and IsActive. This is will determine if a consumer can redeem a coupon.
- UserCouponRedemptions - holds the count of user redemption of a specified coupon. This is will determine if a consumer can redeem a coupon.
- Redemptions - holds all the redemptions and can be used for reporting.

```json
Collection: Coupon
Document
{
    "id": "",
    "title": "",
    "start_date": "",
    "end_date":"",
    "max_usage_per_user": "",
    "max_usage_accross_all_users" : "",
    "total_redemption_count":"",
    "IsActive": ""
}
Index: {
    "IsActive": -1, 
    "max_usage_per_user": -1, 
    "max_usage_accross_all_users":-1, 
    "start_date": 1, 
    "end_date": -1
}


Collection: Redemption 
Document:
{
    "coupon":{
        "id":"",
        "title":""
    },
    "user": 
        {
            "user_id":"",
            "user_name" :""
        },
    "datetime" :"",
    "code" : ""
}
Index: {
    "coupon.id" : 1
}
Shard Key- hashed


Collection: UserCouponRedemptions
Document:
{
    "coupon_id":"",
    "user_id":"",
    "usage_count" :""
}
Index:{
  "coupon_id": 1,
  "user_id":1
}
```

Exercise # 3 
-
The unit tests can be found at Plexure/PlexureTechnicalExam/Exercise3/CouponManagerTests.cs

Exercise # 4 Answers
-
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

Exercise # 5
-
- The code can be found at Plexure/PlexureTechnicalExam/Exercise5/Pages/Index.cshtml and Plexure/PlexureTechnicalExam/Exercise5/wwwroot/css/site.css
