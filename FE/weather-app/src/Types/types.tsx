export interface WeatherInfo {
  current?: Current,
  location?: Location
}

export interface Location {
  country?: string;
  lat?: string;
  localtime?: Date;
  lon?: string;
  name?: string;
  region?: string;
  timezone_id?: string;
  utc_offset?: string;
}

export interface Current {
  weather_code?: number,
  uv_index?: number,
  wind_speed?: number,
  weather_descriptions?: string[]
}
