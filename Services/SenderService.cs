using Domain;
using IServices;
using System;
using System.Messaging;

namespace Services
{
    public class SenderService : ISenderService
    {

        private bool ExistsQueue(string queuePath)
        {
            return MessageQueue.Exists(queuePath);
        }

        public void CreateQueue(string queuePath)
        {
            if (!ExistsQueue(queuePath))
            {
                MessageQueue.Create(queuePath);
            }
        }

        public void SendAG(Genre genre, string queuePath)
        {
            using (var messageQueue = new MessageQueue(queuePath))
            {
                var message = new Message(genre);
            }
        }

        public void SendBG(Genre genre, string queuePath)
        {
            using (var messageQueue = new MessageQueue(queuePath))
            {
                var message = new Message(genre);
            }
        }

        public void SendMG(Genre genre, string queuePath)
        {
            using (var messageQueue = new MessageQueue(queuePath))
            {
                var message = new Message(genre);
            }
        }

        public void SendAP(Movie movie, string queuePath)
        {
            using (var messageQueue = new MessageQueue(queuePath))
            {
                var message = new Message(movie);
            }
        }

        public void SendBP(Movie movie, string queuePath)
        {
            using (var messageQueue = new MessageQueue(queuePath))
            {
                var message = new Message(movie);
            }
        }

        public void SendMP(Movie movie, string queuePath)
        {
            using (var messageQueue = new MessageQueue(queuePath))
            {
                var message = new Message(movie);
            }
        }

        public void SendAS(Genre genre, Movie movie, string queuePath)
        {
            using (var messageQueue = new MessageQueue(queuePath))
            {
                var messageMovie = new Message(movie);
                var messageGenre = new Message(genre);
            }
        }

        public void SendDS(Genre genre, Movie movie, string queuePath)
        {
            using (var messageQueue = new MessageQueue(queuePath))
            {
                var messageMovie = new Message(movie);
                var messageGenre = new Message(genre);
            }
        }

        public void SendAD(Director director, string queuePath)
        {
            using (var messageQueue = new MessageQueue(queuePath))
            {
                var message = new Message(director);
            }
        }

        public void SendBD(Director director, string queuePath)
        {
            using (var messageQueue = new MessageQueue(queuePath))
            {
                var message = new Message(director);
            }
        }

        public void SendMD(Director director, string queuePath)
        {
            using (var messageQueue = new MessageQueue(queuePath))
            {
                var message = new Message(director);
            }
        }

        public void SendSA(string filePath, string queuePath)
        {
            using (var messageQueue = new MessageQueue(queuePath))
            {
                var message = new Message(filePath);
            }
        }

        public void SendDM(Director director, Movie movie, string queuePath)
        {
            using (var messageQueue = new MessageQueue(queuePath))
            {
                var messageDirector = new Message(director);
                var messageMovie = new Message(movie);
            }
        }

        public void SendDD(Director director, Movie movie, string queuePath)
        {
            using (var messageQueue = new MessageQueue(queuePath))
            {
                var messageDirector = new Message(director);
                var messageMovie = new Message(movie);
            }
        }

        public void SendFF(User user, string queuePath)
        {
            using (var messageQueue = new MessageQueue(queuePath))
            {
                var message = new Message(user)
                {
                    Label = "Usuario desconectado",
                    Recoverable = true
                };
            }
        }

        public void SendError(string queuePath)
        {
            using (var messageQueue = new MessageQueue(queuePath))
            {
                var message = new Message()
                {
                    Label = "Error",
                    Recoverable = true
                };
            }
        }
    }
}
