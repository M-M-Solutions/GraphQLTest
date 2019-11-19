using GraphQLTest.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace GraphQLTest.GraphQL.Message
{
    public class MessageStarshipService
    {
        private readonly ISubject<MessageStarship> _messageStream = new ReplaySubject<MessageStarship>(1);

        public MessageStarship AddStarshipAddedMessage(Starship starship)
        {
            var message = new MessageStarship
            {
                CharacterId = starship.CharacterId,
                Name = starship.Name
            };

            _messageStream.OnNext(message);
            return message;
        }

        public IObservable<MessageStarship> GetMessages()
        {
            return _messageStream.AsObservable();
        }
    }
}
