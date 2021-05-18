function initMap() {
    directionsService = new google.maps.DirectionsService();
    directionsRenderer = new google.maps.DirectionsRenderer();
    map = new google.maps.Map(document.getElementById("map"), {
        zoom: 10,
        center: { lat: 41.85, lng: -87.65 },
    });
    directionsRenderer.setMap(map);
    infoWindow = new google.maps.InfoWindow();
    AskForLocation();

    const geocoder = new google.maps.Geocoder();
    document.getElementById("submit").addEventListener("click", () => {
        geocodeAddress(geocoder, map, startPosition);
    });
}

function setStart(startingPosition)
{
    startPosition = startingPosition;
}

function AskForLocation()
{
        // Try HTML5 geolocation.
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(
                (position) => {
                    const pos = {
                        lat: position.coords.latitude,
                        lng: position.coords.longitude,
                    };
                    originPos = pos;
                    //infoWindow.setPosition(pos);
                    //infoWindow.setContent("Location found");
                    //infoWindow.open(map);
                    map.setCenter(pos);

                    marker = new google.maps.Marker({
                        position: originPos,
                        map: map,
                        title: "Hello world!",
                    });
                    var startCoords = {lat: position.coords["latitude"], long: position.coords["longitude"]};
                    setStart(startCoords);
                },
                () => {
                    handleLocationError(true, infoWindow, map.getCenter());
                }
            );
        } else {
            // Browser doesn't support Geolocation
            handleLocationError(false, infoWindow, map.getCenter());
        }
}

function handleLocationError(browserHasGeolocation, infoWindow, pos) {
    infoWindow.setPosition(pos);
    infoWindow.setContent(
        browserHasGeolocation
            ? "Error: The Geolocation service failed."
            : "Error: Your browser doesn't support geolocation."
    );
    infoWindow.open(map);
    console.log("Handle location error called");
}

function geocodeAddress(geocoder, resultsMap, startPosition) {
    const address = document.getElementById("address").value;
    geocoder.geocode({ address: address }, (results, status) => {
        if (status === "OK") {
            resultsMap.setCenter(results[0].geometry.location);
            markerDestination = new google.maps.Marker({
                    map: resultsMap,
                    position: results[0].geometry.location,
            });
            
            calculateAndDisplayRoute(startPosition, results[0].geometry.location);

        } else {
            alert("Geocode was not successful for the following reason: " + status);
        }
    });
}

function calculateAndDisplayRoute(origin, destination) {
    console.log(origin);
    console.log(destination);
    directionsService.route(
    {
      origin: {lat: origin.lat, lng: origin.long},
      destination: destination,
      // Note that Javascript allows us to access the constant
      // using square brackets and a string value as its
      // "property."
      travelMode: google.maps.TravelMode["DRIVING"],
    },
    (response, status) => {
      if (status == "OK") {
        directionsRenderer.setDirections(response);
        console.log(response.routes[0].legs[0].distance);
        console.log(response.routes[0].legs[0].duration);
      } else {
        window.alert("Directions request failed due to " + status);
      }
    }
  );
}