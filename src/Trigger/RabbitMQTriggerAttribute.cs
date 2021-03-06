﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs
{
    [Binding]
    public sealed class RabbitMQTriggerAttribute : Attribute
    {

        public RabbitMQTriggerAttribute(string queueName)
        {
            QueueName = queueName;
        }

        public RabbitMQTriggerAttribute(string exchangeName, string xMatch, string arguments)
        {
            ExchangeName = exchangeName;
            XMatch = xMatch;
            Arguments = arguments;
        }

        public RabbitMQTriggerAttribute(string hostName, string userNameSetting, string passwordSetting, int port, string queueName)
        {
            HostName = hostName;
            UserNameSetting = userNameSetting;
            PasswordSetting = passwordSetting;
            Port = port;
            QueueName = queueName;
        }

        [ConnectionString]
        public string ConnectionStringSetting { get; set; }

        public string HostName { get; set; }

        public string QueueName { get; }

        [AppSetting]
        public string UserNameSetting { get; set; }

        [AppSetting]
        public string PasswordSetting { get; set; }

        public int Port { get; set; }

        public string DeadLetterExchangeName { get; set; }

        public string ExchangeName { get; set; }

        public string XMatch { get; set; }

        public string Arguments { get; set; }
    }
}
