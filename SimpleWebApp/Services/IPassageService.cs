using SimpleWebApp.Models;

namespace SimpleWebApp.Services
{
    public interface IPassageService
    {
        Passage GetPassage(int passageId);
    }
}