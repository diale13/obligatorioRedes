
using Domain;
using System;

namespace IServices
{
    public interface ISenderService
    {
        void CreateQueue(string queuePath);
        void SendAG(Genre genre, string queuePath);
        void SendBG(Genre genre, string queuePath);
        void SendMG(Genre genre, string queuePath);
        void SendAP(Movie movie, string queuePath);
        void SendBP(Movie movie, string queuePath);
        void SendMP(Movie movie, string queuePath);
        void SendAS(Genre genre, Movie movie, string queuePath);
        void SendDS(Genre genre, Movie movie, string queuePath);
        void SendAD(Director director, string queuePath);
        void SendBD(Director director, string queuePath);
        void SendMD(Director director, string queuePath);
        void SendSA(string filePath, string queuePath);
        void SendDM(Director director, Movie movie, string queuePath);
        void SendDD(Director director, Movie movie, string queuePath);
        void SendFF(User user, string queuePath);
        void SendError(string queuePath);
    }
}
