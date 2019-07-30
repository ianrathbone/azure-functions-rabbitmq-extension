// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Microsoft.Azure.WebJobs.Extensions.RabbitMQ.Tests
{
    public class RabbitMQConfigurationTests
    {
        private static readonly IConfiguration _emptyConfig = new ConfigurationBuilder().Build();

        [Fact]
        public void Creates_Context_Correctly()
        {
            var options = new RabbitMQOptions { Hostname = "localhost", QueueName = "queue" };
            var loggerFactory = new LoggerFactory();
            var config = new RabbitMQExtensionConfigProvider(new OptionsWrapper<RabbitMQOptions>(options), (ILoggerFactory)loggerFactory);
            var attribute = new RabbitMQAttribute { Hostname = "localhost", QueueName = "queue" };

            var actualContext = config.CreateContext(attribute);
            RabbitMQContext expectedContext = new RabbitMQContext
            {
                Hostname = "localhost",
                QueueName = "queue"
            };

            Assert.Equal(actualContext.Hostname, expectedContext.Hostname);
            Assert.Equal(actualContext.QueueName, expectedContext.QueueName);
        }
    }
}
