using System.IO;
using System.Threading.Tasks;

namespace Login_Registation_web_page.Controllers
{
    public interface IFormFile
    {
        string FileName { get; }

        Task CopyToAsync(FileStream stream);
    }
}