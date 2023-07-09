export class WeatherModel {
    id: number = 0;
    date: string = '';
    time: string = '';
    temperature: number = 0;
    airHumidity: number = 0;
    temperatureDelta: number = 0;
    atmospherePressure: number = 0;
    windDirection: string | null = null;
    windSpeed: number = 0;
    cloudiness: number = 0;
    height: number = 0;
    vv: number = 0;
    weatherConditions: string | null = null;
}

export class WeatherResponseModel {
    data: WeatherModel[] = [];
    count: number = 0;
}