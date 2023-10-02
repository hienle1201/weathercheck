const url = `https://localhost:7156/WeatherForecast/FetchWeatherData`;

export const fetchZipCode = async(zip: string) => { 
    try { 
        // Fetch data from zip code API
        const response = await fetch(`${url}?zipCode=${zip}`,{
          headers:  {'Content-Type':'application/json'},
          method: "GET",
          mode: 'cors',
        })
        // Fetch data from zip code API
        // console.log(response);
        // if(!response.json()) {
        //     return await response.json();
        // }
        return await response.json();
        
    } catch(error) { 
        console.log(error);
    }
    
}