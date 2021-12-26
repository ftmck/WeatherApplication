using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.API.Controllers;
using WeatherApp.Core.Interfaces;
using WeatherApp.Core.Models;
using WeatherApp.Infrastructure.Services;
using Xunit;

namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public async Task Check_Controller_Response()
        {
            //Arrange
            var repositoryStub = new Mock<IWeatherInfoService>();
            repositoryStub.Setup(repo => repo.GetWeatherDataByCity(3))
                .ReturnsAsync((WeatherInformation)null);

            var controller = new WeatherInfoController(repositoryStub.Object);

            //Act
            var actionResult = await controller.GetWeatherByCity(3);

            //Assert
            //var result = actionResult.Result as OkObjectResult;
            Assert.IsType<NotFoundResult>(actionResult.Result);            
        }

        [Fact]
        public async Task Check_Conversion()
        {
            //Arrange
            var weatherRepositoryStub = new Mock<IWeatherInfoRepository>();
            var cityRepositoryStub = new Mock<ICityRepository>();
            var loggerStub = new Mock<ILogger<WeatherInfoService>>();
            var service = new WeatherInfoService(weatherRepositoryStub.Object, cityRepositoryStub.Object, loggerStub.Object);

            //Act
            TemperatureModel mockData = new TemperatureModel();

            mockData.Temperature = 100;
            mockData.Temperature_Max = 110;
            mockData.Temperature_Min = 90;

            var actionResult = await service.ConvertTemperature(mockData);

            //Assert
            TemperatureModel checkResult = new TemperatureModel();
            checkResult.Temperature = 37.78M;
            checkResult.Temperature_Max = 43.33M;
            checkResult.Temperature_Min = 32.22M;

            Assert.Equal(checkResult.Temperature, actionResult.Temperature);
            Assert.Equal(checkResult.Temperature_Max, actionResult.Temperature_Max);
            Assert.Equal(checkResult.Temperature_Min, actionResult.Temperature_Min);
        }        
    }
}
