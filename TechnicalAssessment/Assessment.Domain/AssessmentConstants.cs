using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Domain
{
    public class AssessmentConstants
    {
        public const string RabbitMqUri =
            "amqp://guest:guest@localhost:5672/";
        public const string JsonMimeType =
            "application/json";

        public const string SendHelloExchange =
            "assessment.sendhello.exchange";
        public const string SendHelloQueue =
            "assessment.sendhello.queue";

        public const string HelloSentExchange =
            "assessment.hellosent.exchange";
        public const string HelloSentNotificationQueue =
            "assessment.hellosent.notification.queue";
    }
}
