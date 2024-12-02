using Nancy.Json;
using ShopTARge23.Core.Dto.WeatherDtos.OpenWeatherDtos;
using ShopTARge23.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARge23.ApplicationServices.Services
{
    public class OpenWeatherServices : IOpenWeatherServices
    {
        //api key = 36ebd29d92db5369407a344f08389e32
        public async Task<OpenWeatherResultDto> OpenWeatherResult(OpenWeatherResultDto dto)
        {
            string openApiKey = "36ebd29d92db5369407a344f08389e32\n";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={dto.City}&units=metric&appid={openApiKey}";


            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                OpenWeatherRootDto weatherRootDto = new JavaScriptSerializer().Deserialize<OpenWeatherRootDto>(json);
                dto.City = weatherRootDto.Name;
                dto.Temp = weatherRootDto.Main.Temp;
                dto.FeelsLike = weatherRootDto.Main.FeelsLike;
                dto.Humidity = weatherRootDto.Main.Humidity;
                dto.Pressure = weatherRootDto.Main.Pressure;
                dto.WindSpeed = weatherRootDto.Wind.Speed;
                dto.Description = weatherRootDto.Weather[0].Description;

            }

            return dto;

        }
    }
}